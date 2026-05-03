using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
                    btn.FlatAppearance.MouseOverBackColor = Color.LightGoldenrodYellow;
                    btn.FlatAppearance.MouseDownBackColor = Color.Goldenrod;
                }
            }
        }
        private void btnProductsbtnProducts_Click(object sender, EventArgs e)
        {
            string secretCode = "1234";
            string input = Interaction.InputBox("כניסה למנהל בלבד: נא להקיש קוד גישה", "אבטחת מערכת", "");

            if (input == secretCode)
            {
                MessageBox.Show("הקוד אומת בהצלחה!", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProductList frm = new ProductList();
                frm.ShowDialog();
            }
            else if (string.IsNullOrEmpty(input))
            {
                return;
            }
            else
            {
                MessageBox.Show("קוד שגוי. אין לך גישה למערכת.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            string secretCode = "1234";

            string input = Interaction.InputBox("כניסה למנהל בלבד: נא להקיש קוד גישה", "אבטחת מערכת", "");

            if (input == secretCode)
            {
                MessageBox.Show("הקוד אומת בהצלחה!", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCustomerList frm = new frmCustomerList();
                frm.ShowDialog();
            }
            else if (string.IsNullOrEmpty(input)) { return; }
            else
            {
                MessageBox.Show("קוד שגוי. אין לך גישה למערכת.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            string secretCode = "1234";

            string input = Interaction.InputBox("כניסה למנהל בלבד: נא להקיש קוד גישה", "אבטחת מערכת", "");

            if (input == secretCode)
            {
                MessageBox.Show("הקוד אומת בהצלחה!", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //frmSaleList frm = new frmSaleList();
                //frm.ShowDialog();
            }
            else if (string.IsNullOrEmpty(input)) { return; }
            else
            {
                MessageBox.Show("קוד שגוי. אין לך גישה למערכת.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            frm.ShowDialog();
        }
    }
}
