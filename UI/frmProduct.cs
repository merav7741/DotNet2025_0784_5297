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
            btnSave.Text = "הוסף מוצר"; 
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
                // 1. בדיקת חובה: שם מוצר
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("חובה להזין שם מוצר", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. בדיקת תקינות מחיר
                if (!double.TryParse(txtPrice.Text, out double price) || price < 0)
                {
                    MessageBox.Show("נא להזין מחיר תקין (מספר חיובי)", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. בדיקת תקינות מלאי
                if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
                {
                    MessageBox.Show("נא להזין כמות מלאי תקינה", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // יצירת אובייקט המוצר לעדכון או הוספה
                var p = new BO.Product
                {
                    Id = productId ?? 0, // אם זה חדש - 0, אם זה עדכון - ה-ID הקיים
                    Name = txtName.Text,
                    Price = price,
                    CountStock = stock,
                    Category = (BO.Categories)cmbCategory.SelectedItem
                };

                if (productId == null)
                {
                    bl.Product.Create(p);
                    MessageBox.Show("המוצר נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bl.Product.Update(p);
                    MessageBox.Show("המוצר עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה במערכת", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}