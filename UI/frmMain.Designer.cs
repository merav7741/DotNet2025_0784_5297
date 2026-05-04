namespace UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProductsbtnProducts = new Button();
            btnCustomers = new Button();
            btnSales = new Button();
            btnNewOrder = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnProductsbtnProducts
            // 
            btnProductsbtnProducts.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 128);
            btnProductsbtnProducts.FlatStyle = FlatStyle.Flat;
            btnProductsbtnProducts.Font = new Font("Segoe UI Light", 9F, FontStyle.Bold);
            btnProductsbtnProducts.ForeColor = Color.Brown;
            btnProductsbtnProducts.Location = new Point(195, 215);
            btnProductsbtnProducts.Name = "btnProductsbtnProducts";
            btnProductsbtnProducts.Size = new Size(188, 29);
            btnProductsbtnProducts.TabIndex = 0;
            btnProductsbtnProducts.Text = "ניהול מוצרים";
            btnProductsbtnProducts.UseVisualStyleBackColor = true;
            btnProductsbtnProducts.Click += btnProductsbtnProducts_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 128);
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI Light", 9F, FontStyle.Bold);
            btnCustomers.ForeColor = Color.Brown;
            btnCustomers.Location = new Point(195, 250);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(188, 29);
            btnCustomers.TabIndex = 0;
            btnCustomers.Text = "ניהול לקוחות";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnSales
            // 
            btnSales.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 128);
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI Light", 9F, FontStyle.Bold);
            btnSales.ForeColor = Color.Brown;
            btnSales.Location = new Point(195, 285);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(188, 29);
            btnSales.TabIndex = 0;
            btnSales.Text = "ניהול מבצעים";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnNewOrder
            // 
            btnNewOrder.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 192);
            btnNewOrder.FlatStyle = FlatStyle.Flat;
            btnNewOrder.Font = new Font("Segoe UI Light", 9F, FontStyle.Bold);
            btnNewOrder.ForeColor = Color.Brown;
            btnNewOrder.Location = new Point(195, 320);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(188, 29);
            btnNewOrder.TabIndex = 0;
            btnNewOrder.Text = "ביצוע הזמנה חדשה";
            btnNewOrder.UseVisualStyleBackColor = true;
            btnNewOrder.Click += btnNewOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Window;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(113, 140);
            label1.Name = "label1";
            label1.Size = new Size(350, 39);
            label1.TabIndex = 1;
            label1.Text = "שלום לחנות התכשיטים";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.AA024458;
            ClientSize = new Size(579, 481);
            Controls.Add(label1);
            Controls.Add(btnNewOrder);
            Controls.Add(btnSales);
            Controls.Add(btnCustomers);
            Controls.Add(btnProductsbtnProducts);
            Name = "frmMain";
            RightToLeft = RightToLeft.Yes;
            Text = "חנות תכשיטים";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProductsbtnProducts;
        private Button btnCustomers;
        private Button btnSales;
        private Button btnNewOrder;
        private Label label1;
    }
}