using BlApi;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class frmSaleList : Form
    {
        private readonly IBl bl = Factory.Get();

        public frmSaleList()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            SalesGrid.AutoGenerateColumns = true;
            SalesGrid.DataSource = bl.Sale.ReadAll().ToList();
        }

        private void txtProductIdFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductIdFilter.Text))
            {
                RefreshGrid();
                return;
            }

            if (int.TryParse(txtProductIdFilter.Text, out int productId))
            {
                SalesGrid.DataSource = bl.Sale.ReadAll()
                    .Where(s => s.ProductId == productId)
                    .ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (new frmSale().ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SalesGrid.CurrentRow == null)
            {
                MessageBox.Show("אנא בחרי מבצע מהרשימה לעדכון.");
                return;
            }

            var sale = (BO.Sale)SalesGrid.CurrentRow.DataBoundItem;

            if (new frmSale(sale.Id).ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SalesGrid.CurrentRow == null)
            {
                MessageBox.Show("אנא בחרי מבצע מהרשימה למחיקה.");
                return;
            }

            var sale = (BO.Sale)SalesGrid.CurrentRow.DataBoundItem;

            var result = MessageBox.Show(
                "האם למחוק את המבצע?",
                "אישור מחיקה",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bl.Sale.Delete(sale.Id);
                    RefreshGrid();
                    MessageBox.Show("המבצע נמחק בהצלחה!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "שגיאה במחיקה");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtProductIdFilter.Text = "";
            RefreshGrid();
        }

        private void SalesGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}