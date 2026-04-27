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
    public partial class frmCustomerList : Form
    {
        BlApi.IBl bl;
        public frmCustomerList()
        {
            InitializeComponent();
            bl = BlApi.Factory.Get();
            RefreshCustomerGrid();

        }
        private void RefreshCustomerGrid()
        {
            var data = bl.Customer.ReadAll().ToList();
            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = data;
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshCustomerGrid();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearchName.Text.ToLower();
            dgvCustomers.DataSource = bl.Customer.ReadAll()
                .Where(c => string.IsNullOrEmpty(filter) || c.Name.ToLower().Contains(filter))
                .ToList();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                var customer = (BO.Customer)dgvCustomers.CurrentRow.DataBoundItem;

                new frmCustomer(customer.Id).ShowDialog();

                RefreshCustomerGrid();
            }
            else
            {
                MessageBox.Show("אנא בחרי לקוח מהרשימה לעדכון.");
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                var customer = (BO.Customer)dgvCustomers.CurrentRow.DataBoundItem;
                var result = MessageBox.Show($"האם את בטוחה שברצונך למחוק את {customer.Name}?",
                                           "אישור מחיקה",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bl.Customer.Delete(customer.Id);
                        RefreshCustomerGrid();

                        MessageBox.Show("הלקוח נמחק בהצלחה!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "שגיאה במחיקה");
                    }
                }
            }
            else
            {
                MessageBox.Show("אנא בחרי לקוח מהרשימה תחילה.");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new frmCustomer().ShowDialog();
            RefreshCustomerGrid();
        }

        private void dgvCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                var customer = (BO.Customer)dgvCustomers.CurrentRow.DataBoundItem;

                new frmCustomer(customer.Id).ShowDialog();

                RefreshCustomerGrid();
            }
        }
    }
}
