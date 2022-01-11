using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Drawing;
using Invoice.Application.Enums;
using Microsoft.Extensions.DependencyInjection;
using Invoice.Application.Services;
using System.Collections.Generic;
using Invoice.Application.Dto;
using System.Linq;

namespace Invoice
{
    public partial class ProductList : ResizeForm
    {
        private IProductService _productService;
        private IList<CategoryDto> _productCategories;
        private IList<ProductDto> _products;

        //private DbConnectorClass db;
        //private SqlDataAdapter adapter;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public ProductList(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productService = serviceProvider.GetRequiredService<IProductService>();

            InitCategories();

            GetProductList();
            AddBtns();
            this.MaximizedBounds = Screen.GetWorkingArea(this);
        }

        private async void InitCategories()
        {
            _productCategories = await _productService.GetProductCategories(default);
            var categories = _productCategories.Where(x => string.IsNullOrEmpty(x.SubCategoryName)).Select(x => x.Name.Trim()).Distinct().ToList();
            CategoryBox.Items.Add("");
            foreach (string name in categories)
            {
                (ProductDataView.Columns[4] as DataGridViewComboBoxColumn)!.Items.Add(name.ToUpper());
                CategoryBox.Items.Add(name.ToUpper());
            }
        }

        public async void GetProductList(bool refreshData = false) {
            try
            {
                if(_products == null || refreshData)
                {
                    _products = await _productService.GetProducts(default);
                }

                var products = _products;
                if(CategoryBox.SelectedItem != null && !CategoryBox.SelectedItem.Equals(""))
                {
                    products = _products.Where(x => string.Equals(x.Category, CategoryBox.SelectedItem.ToString(), StringComparison.InvariantCultureIgnoreCase)).ToList();
                }

                ProductDataView.Rows.Clear();
                for (int i = 0; i < products.Count; i++)
                {
                    var item = products[i];

                    DataGridViewRow row = (DataGridViewRow)ProductDataView.Rows[0].Clone();
                    row.Cells[0].Value = item.Id;
                    row.Cells[1].Value = item.Name;
                    row.Cells[2].Value = item.Price;
                    row.Cells[3].Value = item.Quantity;
                    row.Cells[4].Value = item.Category;
                    SelectedCatagory(row, item.Category!);
                    row.Cells[5].Value = item.SubCategory;
                    row.Cells[6].Value = item.Note;

                    ProductDataView.Rows.Add(row);
                }

                ProductDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddBtns()
        {
            DataGridViewButtonColumn SaveBtnColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "Save",
                Text = "Save",
                UseColumnTextForButtonValue = true
            };
            this.ProductDataView.Columns.Add(SaveBtnColumn);
            DataGridViewButtonColumn DeleteBtnColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            this.ProductDataView.Columns.Add(DeleteBtnColumn);
            this.ProductDataView.EditingControlShowing +=
                    new DataGridViewEditingControlShowingEventHandler(DataGridView_EditingControlShowing);

        }
        // Calls the Employee.RequestStatus method.
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            int rowNum = e.RowIndex;
            if (e.RowIndex >= 0) {
                DataGridViewRow row = this.ProductDataView.Rows[rowNum];
                if (e.ColumnIndex == this.ProductDataView.Columns["Save"].Index)
                    SaveProduct(row, false);
                if (e.ColumnIndex == this.ProductDataView.Columns["Delete"].Index)
                    DeleteProduce(row);
            }
        }
        String oldValue = "";
        

        public void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            if (e.Control is ComboBox combo)
            {
                oldValue = (String)combo.SelectedItem;
                // Remove an existing event-handler, if present, to avoid 
                // adding multiple handlers when the editing control is reused.
                combo.SelectedIndexChanged -= new EventHandler(DataGridView1_CellValueChanged);
                // Add the event handler. 
                combo.SelectedIndexChanged += new EventHandler(DataGridView1_CellValueChanged);
            }
        }
        private void DataGridView1_DataError(object sender, EventArgs e)
        {
            //do nothing when data error occur
        }
        private void DataGridView1_CellValueChanged(object sender, EventArgs e)
        {
            String catagoryName = (String)((ComboBox)sender).SelectedItem;
            int rowNum = (int)((DataGridViewComboBoxEditingControl)sender).EditingControlRowIndex;

            if (rowNum > 0)
            {
                DataGridViewRow row = this.ProductDataView.Rows[rowNum];
                if (oldValue != catagoryName)
                {
                    SelectedCatagory(row, catagoryName);
                    ((DataGridViewComboBoxEditingControl)sender).BackColor = Color.White;

                    DataGridViewComboBoxEditingControl combo = (DataGridViewComboBoxEditingControl)sender;
                    combo.SelectedIndexChanged -= new EventHandler(DataGridView1_CellValueChanged);
                    combo.DropDown += new EventHandler(combo_DropDown);
                    combo.GotFocus += new EventHandler(combo_DropDown);
                }
            }
        }
        void combo_DropDown(object sender, EventArgs e)
        {
            ((DataGridViewComboBoxEditingControl)sender).BackColor = Color.White;
        }


        private void SelectedCatagory(DataGridViewRow row, string catagoryName)
        {
            row.Cells[5].Value = 0;
            (row.Cells[5] as DataGridViewComboBoxCell)!.Items.Clear();

            if (!row.Cells[4].Value.Equals("")) {
                var subCategories = _productCategories.Where(x => x.Name == catagoryName).Select(x => x.SubCategoryName).ToList();
                foreach(var name in subCategories)
                {
                    (row.Cells[5] as DataGridViewComboBoxCell)!.Items.Add(name is null ? "" : name);
                }
            }
        }

        private async void DeleteProduce(DataGridViewRow row)
        {
            // Retrieve the task ID.
            String productId = row.Cells[0].Value.ToString();
            try
            {
                var x = MessageBox.Show("Are you sure you want to delete? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == x)
                {
                    String sqlQuery = "";
                    if (productId.Equals(""))
                    {
                        this.ProductDataView.Rows.Remove(row);
                    }
                    else
                    {
                        await _productService.DeleteProduct(int.Parse(productId), default);
                    }
                    //db.RunQuery(sqlQuery).Close();
                    // need to close this form after click 'OK' button]
                    GetProductList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void SaveProduct(DataGridViewRow row, bool saveAll)
        {
            // Retrieve the task ID.
            String productId = "";
            String Product = "";
            String Price = "";
            String Quantity = "";
            String Catagory = "";
            String SubCatagory = "";
            String Note = "";
            if (row.Cells[0].Value != null)
                productId    = row.Cells[0].Value.ToString();
            if (row.Cells[1].Value != null)
                Product      = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value != null)
                Price        = row.Cells[2].Value.ToString();
            if (row.Cells[3].Value != null)
                Quantity     = row.Cells[3].Value.ToString();
            if (row.Cells[4].Value != null)
                Catagory     = row.Cells[4].Value.ToString().ToUpper();
            if (row.Cells[5].Value != null)
                SubCatagory  = row.Cells[5].Value.ToString().ToUpper();
            if (row.Cells[6].Value != null)
                Note         = row.Cells[6].Value.ToString();

            if (Price.Equals(""))
            {
                Price = "0.00";
            }
            if (Quantity.Equals(""))
            {
                Quantity = "0";
            }
            try
            {
                var x = DialogResult.No;

                if (!saveAll)
                    x = MessageBox.Show("Are you sure you want to save? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.Yes == x || saveAll)
                {
                    if (productId is null || productId.Equals(""))
                    {
                        await _productService.AddProduct(new ProductDto
                        {
                            Id = 0,
                            Name = Product!,
                            Price = decimal.Parse(Price),
                            Quantity = int.Parse(Quantity),
                            Category = Catagory,
                            SubCategory = SubCatagory,
                            Note = Note

                        }, default);
                    }
                    else
                    {
                        await _productService.UpdateProduct(new ProductDto
                        {
                            Id = int.Parse(productId),
                            Name = Product!,
                            Price = decimal.Parse(Price),
                            Quantity = int.Parse(Quantity),
                            Category = Catagory,
                            SubCategory = SubCatagory,
                            Note = Note

                        }, default);
                    }

                    // need to close this form after click 'OK' button
                    if (!saveAll)
                        GetProductList(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DragTitlePanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < this.ProductDataView.RowCount-1; i++)
            {
                DataGridViewRow row = this.ProductDataView.Rows[i];
                SaveProduct(row, true);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductList();
        }
    }
}
