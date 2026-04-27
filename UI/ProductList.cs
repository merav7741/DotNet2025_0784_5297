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
            CategorySelector.DataSource = Enum.GetValues(typeof(BO.Categories));
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
                ProductsGrid.DataSource = bl.Product.ReadAll(p => p.Category == category).ToList();
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            new frmProduct().ShowDialog();
            RefreshGrid();
        }
    }
}
