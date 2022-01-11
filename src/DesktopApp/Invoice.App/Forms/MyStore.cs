using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Invoice.Application.Dto;
using Invoice.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice.App.Forms
{
    public partial class MyStore : ResizeForm
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private StoreDto _store;

        public IStoreService _storeService { get; }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public MyStore(IServiceProvider serviceProvider) : base()
        {
            _storeService = serviceProvider.GetRequiredService<IStoreService>();

            InitializeComponent();
        }
        
        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var x = MessageBox.Show("Are you sure you want to save? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(DialogResult.Yes == x)
                {
                    SyncData();
                    var result = await _storeService.UpdateMyStore(_store, default);

                    if (result.IsSuccess)
                        MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Error occured while saving data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void MyStore_Load(object sender, EventArgs e)
        {
            try
            {
                var result = await _storeService.GetMyStore(default);
                
                if (result.IsSuccess && result.Value is not null)
                {
                    _store = result.Value;

                    SyncData(_store);
                }
                else
                {
                    MessageBox.Show("Error while retrieving data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SyncData(StoreDto? store = null)
        {
            if (store is null)
            {
                _store.Name = storeNameTxt.Text;
                _store.Phone = storePhoneTxt.Text;
                _store.Address = storeAddressTxt.Text;
                _store.Fax = storeFaxTxt.Text;
                _store.Detail = storeDetailTxt.Text;
            }
            else
            {
                storeNameTxt.Text = store.Name;
                storePhoneTxt.Text = store.Phone;
                storeAddressTxt.Text = store.Address;
                storeFaxTxt.Text = store.Fax;
                storeDetailTxt.Text = store.Detail;
            }
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!this.storeNameTxt.Text.Equals(_store?.Name) ||
            !this.storePhoneTxt.Text.Equals(_store?.Phone) ||
            !this.storeAddressTxt.Text.Equals(_store?.Address) ||
            !this.storeFaxTxt.Text.Equals(_store?.Fax) ||
            !this.storeDetailTxt.Text.Equals(_store?.Detail))
            {
                var x = MessageBox.Show("Are you sure you want to really exit?\n unsaved data will be lost. ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
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
    }
}
