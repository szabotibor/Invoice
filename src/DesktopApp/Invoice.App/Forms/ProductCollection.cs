using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using Invoice.Application.Services;
using System.Collections.Generic;
using System.Linq;
using Invoice.Application.Dto;

namespace Invoice
{
    public partial class ProductCollection : ResizeForm
    {
        //DbConnectorClass db;
        //SqlDataAdapter adapter;
        DataSet DS;
        CreateOrder co;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        ArrayList products;
        String routeValue;

        private IProductService _productService;
        private List<ProductDto> _products;

        public ProductCollection(IServiceProvider serviceProvider, CreateOrder co, ArrayList products, String routeValue)
        {
            this.products = products;
            this.co = co;
            this.routeValue = routeValue;
            _productService = serviceProvider.GetRequiredService<IProductService>();

            InitializeComponent();
            ProductLoad();
            this.MaximizedBounds = Screen.GetWorkingArea(this);
        }

        public async void ProductLoad()
        {
            List<string> categoriesToExclude = new() { "MEAT", "FROZEN", "GROCERY", "PRODUCE" };

            try
            {
                _products = await _productService.GetProducts(default);

                setComboBox(MeatListBox, "MEAT", _products);
                setComboBox(FrozenListBox, "FROZEN", _products);
                setComboBox(GroceryListBox, "GROCERY", _products);
                setComboBox(ProduceListBox, "PRODUCE", _products);

                
                var etcProducts = _products.Where(x => !categoriesToExclude.Contains(x.Category!)).ToList();

                EtcListBox.DataSource = etcProducts;
                EtcListBox.DisplayMember = "Name";
                EtcListBox.ValueMember = "Id";

                setChecked(MeatListBox);
                setChecked(FrozenListBox);
                setChecked(GroceryListBox);
                setChecked(ProduceListBox);
                setChecked(EtcListBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setComboBox(CheckedListBox cb, string category, List<ProductDto> products) {
            var data = products.Where(x => string.Equals(x.Category, category, StringComparison.InvariantCultureIgnoreCase)).ToList();

            cb.DataSource = data;
            cb.DisplayMember = "Name";
            cb.ValueMember = "Id";
        }

        private void setChecked(CheckedListBox cb)
        {
            if (products == null) return;
            for (int k = 0; k < products.Count; k++)
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    string cbText = ((ProductDto)cb.Items[i]).Name;
                    string product = (string)products[k]!;
                    if (cbText.Equals(product))
                    {
                        cb.SetItemChecked(i, true);
                        break;
                    }
                }

            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            CheckedListBox[] boxList = new CheckedListBox[5];
            boxList.SetValue(MeatListBox, 0);
            boxList.SetValue(FrozenListBox, 1);
            boxList.SetValue(GroceryListBox, 2);
            boxList.SetValue(ProduceListBox, 3);
            boxList.SetValue(EtcListBox, 4);
            DataGridView dataView = co.getOrderDataView();
            //use products to figure out deleted product
            for (int b = 0; b < boxList.Length; b++) {
                CheckedListBox listBox = boxList[b];
                for (int i = 0; i < listBox.CheckedItems.Count; i++)
                {
                    var item = (ProductDto)listBox.CheckedItems[i];
                    String prodName = item.Name;
                    try
                    {
                        bool isFound = false;
                        for (int k = 0; k < dataView.Rows.Count; k++)
                        {
                            DataGridViewCellCollection cells = dataView.Rows[k].Cells;
                            if (cells[0].Value.Equals(prodName))
                            {
                                products.Remove(prodName);
                                isFound = true;
                                break;
                            }
                        }
                        if (!isFound)
                        {
                            var product = _products.Where(x => string.Equals(x.Name, prodName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                            if (product is not null)
                            {
                                int box = 0;
                                int each = 0;
                                int pound = 0;
                                string price = "$" + product.Price.ToString();
                                int amount = 0;
                                string market = "";
                                string note = product.Note!;
                                
                                //add only new items
                                dataView.Rows.Add(prodName, box, each, pound, price, amount, market, routeValue, note);
                            }
                            //dbReader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            //remove unchecked item from order list
            for (int k = 0; k < products.Count; k++)
            {
                for (int u = 0; u < dataView.Rows.Count; u++)
                {
                    if (dataView.Rows[u].Cells[0].Value.Equals(products[k]))
                    {
                        dataView.Rows.RemoveAt(u);
                        break;
                    }
                }
            }
            this.Close();
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
    }
}
