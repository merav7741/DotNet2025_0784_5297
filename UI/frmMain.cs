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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SetupButtonStyles();
        }
        private void SetupButtonStyles()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    // עיצוב כשהעכבר עובר מעל הכפתור
                    btn.FlatAppearance.MouseOverBackColor = Color.LightGoldenrodYellow;
                    // עיצוב כשלוקחים על הכפתור
                    btn.FlatAppearance.MouseDownBackColor = Color.Goldenrod;
                }
            }
        }
        private void btnProductsbtnProducts_Click(object sender, EventArgs e)
        {
            ProductList frm = new ProductList();
            frm.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomerList frm = new frmCustomerList();
            frm.ShowDialog();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            //frmSaleList frm = new frmSaleList();
            //frm.ShowDialog();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            frm.ShowDialog();
        }
    }
}
