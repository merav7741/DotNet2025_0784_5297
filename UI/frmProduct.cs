using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;

namespace UI
{
    public partial class frmProduct : Form
    {
        private readonly IBl bl = Factory.Get();
        private int? productId = null;
        public frmProduct()
        {
            InitializeComponent();
            cmbCategory.DataSource = Enum.GetValues(typeof(BO.Categories));
        }
        public frmProduct(int id) : this()
        {
            productId = id;
            var p = bl.Product.Read(id);
            txtName.Text = p.Name;
            txtPrice.Text = p.Price.ToString();
            txtStock.Text = p.CountStock.ToString();
            cmbCategory.SelectedItem = p.Category;
            btnSave.Text = "עדכן מוצר";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(txtPrice.Text, out double price))
                {
                    MessageBox.Show("מחיר לא תקין");
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show("כמות לא תקינה");
                    return;
                }
                var p = new BO.Product
                { 
                    Id = productId ?? 0,
                    Name = txtName.Text,
                     Price = price,
                    CountStock = stock,
                    Category = (BO.Categories)cmbCategory.SelectedItem
                };
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("שם מוצר חובה");
                    return;
                }
                if (productId == null)
                {
                    bl.Product.Create(p); 
                    MessageBox.Show("המוצר נוסף בהצלחה!");
                }
                else
                {
                    bl.Product.Update(p); 
                    MessageBox.Show("המוצר עודכן בהצלחה!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
