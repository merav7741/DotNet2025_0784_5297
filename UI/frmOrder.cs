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
    public partial class frmOrder : Form
    {
        private readonly IBl bl = Factory.Get();

        public frmOrder()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            //OrdersGrid.DataSource = bl.Order.().ToList();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var order = new BO.Order
            //    {
            //        // אם יש לך שדות נוספים תוסיפי כאן
            //        // לדוגמה: Date = DateTime.Now
            //    };

            //    //bl.Order.Create(order);
            //    MessageBox.Show("הזמנה נוספה בהצלחה!");

            //    RefreshGrid();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (OrdersGrid.CurrentRow == null)
            //        return;

            //    var order = (BO.Order)OrdersGrid.CurrentRow.DataBoundItem;

            //    var result = MessageBox.Show(
            //        "למחוק את ההזמנה?",
            //        "אישור",
            //        MessageBoxButtons.YesNo);

            //    if (result == DialogResult.Yes)
            //    {
            //        //bl.Order.Delete(order.Id);
            //        RefreshGrid();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
