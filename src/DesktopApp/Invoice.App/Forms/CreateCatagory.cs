using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Invoice.Application.Services;
using Invoice.Application.Dto;

namespace Invoice
{
    public partial class CreateCatagory : ResizeForm
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private IProductService _productService;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public CreateCatagory(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productService = serviceProvider.GetRequiredService<IProductService>();

            Category_Load();
            AddBtns();
            this.MaximizedBounds = Screen.GetWorkingArea(this);
        }

        private async void Category_Load()
        {
            try
            {
                var categories = await _productService.GetProductCategories(default);

                CatagoryDataView.Rows.Clear();

                for (int i = 0; i < categories.Count; i++)
                {
                    var category = categories[i];

                    DataGridViewRow row = (DataGridViewRow)CatagoryDataView.Rows[0].Clone();
                    row.Cells[0].Value = category.Id;
                    row.Cells[1].Value = category.Name;
                    row.Cells[2].Value = category.SubCategoryName;
                    
                    CatagoryDataView.Rows.Add(row);
                }
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
            this.CatagoryDataView.Columns.Add(SaveBtnColumn);
            DataGridViewButtonColumn DeleteBtnColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            this.CatagoryDataView.Columns.Add(DeleteBtnColumn);

        }
        // Calls the Employee.RequestStatus method.

        private void CatagoryDataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            int rowNum = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.CatagoryDataView.Rows[rowNum];
                if (e.ColumnIndex == this.CatagoryDataView.Columns["Save"].Index)
                    SaveProduce(row);
                if (e.ColumnIndex == this.CatagoryDataView.Columns["Delete"].Index)
                    DeleteProduce(row);
            }
        }

        private async void DeleteProduce(DataGridViewRow row)
        {
            // Retrieve the task ID.
            String catagoryId = row.Cells[0].Value.ToString();
            try
            {
                var x = MessageBox.Show("Are you sure you want to delete? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == x)
                {
                    if (catagoryId!.Equals(""))
                    {
                        this.CatagoryDataView.Rows.Remove(row);
                    }
                    else
                    {
                        await _productService.DeleteCategory(int.Parse(catagoryId), default);
                    }
                    //db.RunQuery(sqlQuery).Close();
                    // need to close this form after click 'OK' button]
                    Category_Load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void SaveProduce(DataGridViewRow row)
        {
            String categoryId = "";
            String Category = "";
            String SubCategory = "";

            if (row.Cells[0].Value != null)
                 categoryId = row.Cells[0].Value.ToString()!;
            if (row.Cells[1].Value != null)
                Category = row.Cells[1].Value.ToString()!.ToUpper();
            if (row.Cells[2].Value != null)
                SubCategory = row.Cells[2].Value.ToString()!.ToUpper();
            try
            {
                var x = MessageBox.Show("Are you sure you want to save? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == x)
                {
                    //String sqlQuery = "";
                    if (categoryId.Equals(""))
                    {
                        await _productService.AddCategory(new CategoryDto {
                            Id = 0,
                            Name = Category.Trim(),
                            SubCategoryName = SubCategory.Trim()
                        }, default);
                    }
                    else
                    {
                        await _productService.AddCategory(new CategoryDto
                        {
                            Id = int.Parse(categoryId),
                            Name = Category.Trim(),
                            SubCategoryName = SubCategory.Trim()
                        }, default);
                    }
                    // need to close this form after click 'OK' button
                    Category_Load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelBtn_Click_1(object sender, EventArgs e)
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
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
