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
    public partial class frmCustomer : Form
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        public frmCustomer()
        {
            InitializeComponent();

        }
        public frmCustomer(int id)
        {
            InitializeComponent();
            var customer = bl.Customer.Read(id);

            txtId.Text = customer.Id.ToString();
            txtId.ReadOnly = true; 
            txtName.Text = customer.Name;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;

            btnAddUpdate.Text = "עדכן לקוח";
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            BO.Customer customer = new BO.Customer
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };

            if (btnAddUpdate.Text == "עדכן לקוח")
            {
                bl.Customer.Update(customer);
                MessageBox.Show("הפרטים של הלקוח שונו בהצלחה!");
            }
            else
            {
                bl.Customer.Create(customer);
                MessageBox.Show("הלקוח התווסף לרשימה!");
            }
            this.Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
