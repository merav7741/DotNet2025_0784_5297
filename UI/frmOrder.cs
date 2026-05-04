using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;

namespace UI
{
    public partial class frmOrder : Form
    {   
        private readonly IBl bl = Factory.Get();
        private BO.Order currentOrder = new BO.Order();
        
        
        public frmOrder()
        {
            InitializeComponent();
           
            lblTotal.Text = "0";
            dgvOrderProducts.AutoGenerateColumns = true;
            dgvSalesInOrder.AutoGenerateColumns = true;
        }

     

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductId.Text))
                {
                    MessageBox.Show("יש להזין קוד מוצר");
                    return;
                }

                if (numAmount.Value <= 0)
                {
                    MessageBox.Show("יש להזין כמות גדולה מ-0");
                    return;
                }
                int productId = int.Parse(txtProductId.Text);
                int amount = (int)numAmount.Value;

                var salesForProduct = bl.Order.AddProductToOrder(currentOrder, productId, amount);

                dgvOrderProducts.DataSource = null;
                dgvOrderProducts.DataSource = currentOrder.listProductInOrder;

                dgvSalesInOrder.DataSource = null;
                dgvSalesInOrder.DataSource = salesForProduct;
                if (salesForProduct == null || !salesForProduct.Any())
                {
                    dgvSalesInOrder.DataSource = null;
                }

                lblTotal.Text = currentOrder.finalPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtProductId.Text = "";
            numAmount.Value = 0;
            txtProductId.Focus();
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void chkPreferedCustomer_CheckedChanged(object sender, EventArgs e)
        {
            currentOrder.isPreferedCustomer = chkPreferedCustomer.Checked;
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder.listProductInOrder == null || !currentOrder.listProductInOrder.Any())
            {
                MessageBox.Show("לא ניתן לבצע הזמנה ללא מוצרים");
                return;
            }

            try
            {
                bl.Order.DoOrder(currentOrder);

                MessageBox.Show("ההזמנה בוצעה בהצלחה!");

                btnClearOrder_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            currentOrder = new BO.Order();

            dgvOrderProducts.DataSource = null;
            dgvSalesInOrder.DataSource = null;

            lblTotal.Text = "0";
            txtProductId.Text = "";
            numAmount.Value = 0;
            chkPreferedCustomer.Checked = false;
        }
    }
}
