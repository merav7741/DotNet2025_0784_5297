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
    public partial class ProductList : Form
    {
        private readonly IBl bl = Factory.Get();

        public ProductList()
        {
            InitializeComponent();

            var categories = Enum.GetValues(typeof(BO.Categories))
                                 .Cast<BO.Categories>()
                                 .ToList();

            categories.Insert(0, (BO.Categories)(-1));
            CategorySelector.DataSource = categories;

            CategorySelector.Format += (s, e) =>
            {
                if ((BO.Categories)e.Value == (BO.Categories)(-1))
                    e.Value = "הכל";
            };

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            ProductsGrid.DataSource = bl.Product.ReadAll().ToList();
        }

        private void CategorySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategorySelector.SelectedItem is BO.Categories category)
            {
                if ((int)category == -1)
                {
                    RefreshGrid();
                }
                else
                {
                    ProductsGrid.DataSource = bl.Product.ReadAll(p => p.Category == category).ToList();
                }
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (new frmProduct().ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (ProductsGrid.CurrentRow != null)
            {
                var product = (BO.Product)ProductsGrid.CurrentRow.DataBoundItem;
                if (new frmProduct(product.Id).ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("אנא בחרי מוצר מהרשימה לעדכון.", "שימי לב", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (ProductsGrid.CurrentRow != null)
            {
                var product = (BO.Product)ProductsGrid.CurrentRow.DataBoundItem;

                var result = MessageBox.Show(
                    $"האם למחוק את {product.Name}?",
                    "אישור מחיקה",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bl.Product.Delete(product.Id);
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "שגיאה במחיקה");
                    }
                }
            }
        }

        private void ProductsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var column = ProductsGrid.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    btnUpdateProduct_Click(sender, EventArgs.Empty);
                }
            }
        }

        private void ProductsGrid_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            btnUpdateProduct_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            if (ProductsGrid.CurrentRow != null)
            {
                var product = (BO.Product)ProductsGrid.CurrentRow.DataBoundItem;
                new frmProduct(product.Id, true).ShowDialog();
            }
            else
            {
                MessageBox.Show("אנא בחרי מוצר מהרשימה לצפייה.", "צפייה במוצר", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}