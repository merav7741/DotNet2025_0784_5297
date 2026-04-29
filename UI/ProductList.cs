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
                    ProductsGrid.DataSource =
                        bl.Product.ReadAll(p => p.Category == category).ToList();
                }
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            new frmProduct().ShowDialog();
            RefreshGrid();
        }

        private void ProductsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (ProductsGrid.CurrentRow != null)
            {
                var product = (BO.Product)ProductsGrid.CurrentRow.DataBoundItem;

                var result = MessageBox.Show(
                    $"האם למחוק את {product.Name}?",
                    "אישור",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    bl.Product.Delete(product.Id);
                    RefreshGrid();
                }
            }
        }

        private void ProductsGrid_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (ProductsGrid.CurrentRow != null)
            {
                var product = (BO.Product)ProductsGrid.CurrentRow.DataBoundItem;

                new frmProduct(product.Id).ShowDialog();

                RefreshGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
