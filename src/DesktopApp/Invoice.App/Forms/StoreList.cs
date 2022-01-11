using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Invoice.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Invoice.Application.Clients;
using Invoice.Application.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Invoice
{
    public partial class StoreList : ResizeForm
    {
        //DbConnectorClass db;
        //SqlDataAdapter adapter;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private readonly IStoreService _storeService;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private int STORE_ID = 0;
        private int STORE_NAME = 1;
        private int STORE_PHONE = 2;
        private int STORE_FAX = 3;
        private int STORE_ADDRESS = 4;
        private int CONTACT_NAME = 5;
        private int CONTACT_PHONE = 6;
        private int STORE_NOTE = 7;
        private int IS_MARKET = 8;

        private List<StoreDto> _stores;

        public StoreList(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _storeService = serviceProvider.GetRequiredService<IStoreService>();

            GetStoreList();
            AddBtns();
            MaximizedBounds = Screen.GetWorkingArea(this);
        }

        public void GetStoreList()
        {
            GetStoreList(true, true, true);
        }
        public async void GetStoreList(bool isMarket, bool isCustomer, bool forceUpdate = false)
        {
            try
            {
                if (_stores == null || _stores.Count == 0 || forceUpdate)
                {
                    var result = await _storeService.GetStores(default);
                    if (result.IsFailed)
                    {
                        MessageBox.Show("Error while retrieving data.");
                        return;
                    }

                    _stores = result.Value;
                }

                StoreDataView.Rows.Clear();

                List<StoreDto> filteredStores;
                if (isMarket && isCustomer)
                {
                    filteredStores = _stores;
                }
                else if (isMarket)
                {
                    filteredStores = _stores.Where(x => x.IsMarket == 1).ToList();
                }
                else if (isCustomer)
                {
                    filteredStores = _stores.Where(x => x.IsMarket == 0).ToList();
                }
                else
                {
                    filteredStores = _stores.Where(x => x.IsMarket == 2).ToList();
                }

                for (int i = 0; i < filteredStores.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)StoreDataView.Rows[0].Clone();
                    var store = filteredStores[i];

                    row.Cells[STORE_ID].Value = store.Id;
                    row.Cells[STORE_NAME].Value = store.Name.Trim();
                    row.Cells[STORE_PHONE].Value = store.Phone.Trim();
                    row.Cells[STORE_FAX].Value = store.Fax?.Trim();
                    row.Cells[STORE_ADDRESS].Value = store.Address.Trim();
                    row.Cells[CONTACT_NAME].Value = store.ContactName?.Trim();
                    row.Cells[CONTACT_PHONE].Value = store.ContactPhone?.Trim();
                    row.Cells[STORE_NOTE].Value = "";

                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[IS_MARKET];
                    var isMarketVal = store.IsMarket;
                    if (isMarketVal.Equals(1))
                    {
                        chk.Value = chk.TrueValue;
                    }
                    else
                    {
                        chk.Value = chk.FalseValue;
                    }

                    StoreDataView.Rows.Add(row);
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
            this.StoreDataView.Columns.Add(SaveBtnColumn);
            DataGridViewButtonColumn DeleteBtnColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            this.StoreDataView.Columns.Add(DeleteBtnColumn);
        }
        private async void DeleteStore(DataGridViewRow row)
        {
            // Retrieve the task ID.
            var storeId = row.Cells[0].Value !=null ? (int)row.Cells[0].Value : 0;
            try
            {
                var x = MessageBox.Show("Are you sure you want to delete? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == x)
                {
                    if (storeId == 0)
                    {
                        this.StoreDataView.Rows.Remove(row);
                    }
                    else
                    {
                        var result = await _storeService.DeleteStore(storeId, default);
                    }

                    // need to close this form after click 'OK' button]
                    GetStoreList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void SaveStore(DataGridViewRow row, bool saveAll)
        {
            // Retrieve the task ID.
            int storeId = row.Cells[STORE_ID].Value != null ? (int)row.Cells[STORE_ID].Value:0;
   
            try
            {
                var x = DialogResult.No;
                if (!saveAll)
                    x = MessageBox.Show("Are you sure you want to save? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == x || saveAll)
                {
                    if (storeId == 0)
                    {
                        await _storeService.AddStore(DataRowToStore(row), default);
                    }
                    else
                    {
                        await _storeService.UpdateStore(DataRowToStore(row), default);
                    }
                    
                    //// need to close this form after click 'OK' button
                    if (!saveAll)
                        GetStoreList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private StoreDto DataRowToStore(DataGridViewRow row)
        {
            return new StoreDto(
                row.Cells[STORE_ID].Value !=null ? (int)row.Cells[STORE_ID].Value : 0,
                (string)row.Cells[STORE_NAME].Value,
                (string)row.Cells[STORE_PHONE].Value,
                (string)row.Cells[STORE_ADDRESS].Value,
                (string)row.Cells[CONTACT_NAME].Value,
                (string)row.Cells[STORE_PHONE].Value,
                (string)row.Cells[STORE_PHONE].Value,
                (string)row.Cells[STORE_NOTE].Value,
                row.Cells[IS_MARKET].Value != null ? int.Parse(row.Cells[IS_MARKET].Value.ToString()) : 0
                ); ;
        }

        private void ShowOptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isMarket = this.ShowMarketCheckBox.Checked;
            bool isCustomer = this.ShowCustomerCheckBox.Checked;
            GetStoreList(isMarket, isCustomer);
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
            var x = MessageBox.Show("Are you sure you want to save? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == x)
            {
                for (int i = 0; i < this.StoreDataView.RowCount - 1; i++)
                {
                    DataGridViewRow row = this.StoreDataView.Rows[i];
                    SaveStore(row, true);
                }
                GetStoreList();
            }
        }

        private void StoreDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            int rowNum = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.StoreDataView.Rows[rowNum];
                if (e.ColumnIndex == this.StoreDataView.Columns["Save"].Index)
                    SaveStore(row, false);
                if (e.ColumnIndex == this.StoreDataView.Columns["Delete"].Index)
                    DeleteStore(row);
            }
        }
    }
}
