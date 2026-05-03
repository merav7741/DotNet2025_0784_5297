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
    public partial class frmCustomer : Form
    {
        private readonly IBl bl = Factory.Get();
        private bool isViewMode = false;

        public frmCustomer()
        {
            InitializeComponent();
            btnAddUpdate.Text = "הוסף לקוח";
        }

        public frmCustomer(int id) : this()
        {
            LoadCustomerData(id);
            btnAddUpdate.Text = "עדכן לקוח";
            txtId.ReadOnly = true;
        }

        public frmCustomer(int id, bool isView) : this()
        {
            isViewMode = isView;
            LoadCustomerData(id);

            if (isViewMode)
            {
                btnAddUpdate.Text = "חזרה";
                txtId.ReadOnly = true;
                txtName.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtPhone.ReadOnly = true;
            }
        }

        private void LoadCustomerData(int id)
        {
            var customer = bl.Customer.Read(id);
            txtId.Text = customer.Id.ToString();
            txtName.Text = customer.Name;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (isViewMode)
            {
                this.Close();
                return;
            }

            try
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
                    MessageBox.Show("הפרטים של הלקוח שונו בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bl.Customer.Create(customer);
                    MessageBox.Show("הלקוח התווסף לרשימה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
        }
    }
}