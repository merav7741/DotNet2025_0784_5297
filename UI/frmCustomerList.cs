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

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
