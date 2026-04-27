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
                var p = new BO.Product
                {

                    Id =  0,
                    Name = txtName.Text,
                    Price = double.Parse(txtPrice.Text),
                    CountStock = int.Parse(txtStock.Text),
                    Category = (BO.Categories)cmbCategory.SelectedItem
                };

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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
