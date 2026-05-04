using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmSale : Form
    {
        public frmSale()
        {
            InitializeComponent();
            sale = new BO.Sale();
        }
        private BlApi.IBl bl = BlApi.Factory.Get();
        private BO.Sale sale;
        private bool isUpdate = false;



        public frmSale(int id)
        {
            InitializeComponent();

            sale = bl.Sale.Read(id);
            isUpdate = true;

            txtProductId.Text = sale.ProductId.ToString();
            txtQuantity.Text = sale.QuantityForSale.ToString();
            txtPrice.Text = sale.SalePrice.ToString();
            chkAllCustomers.Checked = sale.IsSaleToAllCustomer;
            dtpStart.Value = sale.StartSale ?? DateTime.Now;
            dtpEnd.Value = sale.EndSale ?? DateTime.Now;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sale.ProductId = int.Parse(txtProductId.Text);
                sale.QuantityForSale = int.Parse(txtQuantity.Text);
                sale.SalePrice = double.Parse(txtPrice.Text);
                sale.IsSaleToAllCustomer = chkAllCustomers.Checked;
                sale.StartSale = dtpStart.Value;
                sale.EndSale = dtpEnd.Value;

                if (isUpdate)
                    bl.Sale.Update(sale);
                else
                    bl.Sale.Create(sale);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה בשמירת מבצע");
            }
        }
    }
}
