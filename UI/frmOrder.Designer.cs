namespace UI
{
    partial class frmOrder
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
            button2 = new Button();
            label1 = new Label();
            txtProductId = new TextBox();
            label2 = new Label();
            numAmount = new NumericUpDown();
            label3 = new Label();
            btnAddProduct = new Button();
            dgvOrderProducts = new DataGridView();
            dgvSalesInOrder = new DataGridView();
            lblTotal = new Label();
            chkPreferedCustomer = new CheckBox();
            btnDoOrder = new Button();
            btnClearOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSalesInOrder).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(69, 53);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "חזרה ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 85);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 6;
            label1.Click += label1_Click;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(151, 114);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(125, 27);
            txtProductId.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 121);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 8;
            label2.Text = "ProductId";
            // 
            // numAmount
            // 
            numAmount.Location = new Point(151, 156);
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(150, 27);
            numAmount.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(307, 163);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 10;
            label3.Text = "כמות";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(170, 205);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(94, 29);
            btnAddProduct.TabIndex = 11;
            btnAddProduct.Text = "הוסף מוצר";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // dgvOrderProducts
            // 
            dgvOrderProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderProducts.Location = new Point(398, 46);
            dgvOrderProducts.Name = "dgvOrderProducts";
            dgvOrderProducts.RowHeadersWidth = 51;
            dgvOrderProducts.Size = new Size(300, 188);
            dgvOrderProducts.TabIndex = 12;
            // 
            // dgvSalesInOrder
            // 
            dgvSalesInOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesInOrder.Location = new Point(398, 240);
            dgvSalesInOrder.Name = "dgvSalesInOrder";
            dgvSalesInOrder.RowHeadersWidth = 51;
            dgvSalesInOrder.Size = new Size(300, 188);
            dgvSalesInOrder.TabIndex = 13;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(321, 335);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(17, 20);
            lblTotal.TabIndex = 14;
            lblTotal.Text = "0";
            lblTotal.TextAlign = ContentAlignment.TopCenter;
            // 
            // chkPreferedCustomer
            // 
            chkPreferedCustomer.AutoSize = true;
            chkPreferedCustomer.Location = new Point(170, 280);
            chkPreferedCustomer.Name = "chkPreferredCustomer";
            chkPreferedCustomer.Size = new Size(106, 24);
            chkPreferedCustomer.TabIndex = 15;
            chkPreferedCustomer.Text = "לקוח מועדף";
            chkPreferedCustomer.UseVisualStyleBackColor = true;
            chkPreferedCustomer.CheckedChanged += chkPreferedCustomer_CheckedChanged;
            // 
            // btnDoOrder
            // 
            btnDoOrder.Location = new Point(207, 331);
            btnDoOrder.Name = "btnDoOrder";
            btnDoOrder.Size = new Size(94, 29);
            btnDoOrder.TabIndex = 16;
            btnDoOrder.Text = "בצע הזמנה";
            btnDoOrder.UseVisualStyleBackColor = true;
            btnDoOrder.Click += btnDoOrder_Click;
            // 
            // btnClearOrder
            // 
            btnClearOrder.Location = new Point(107, 331);
            btnClearOrder.Name = "btnClearOrder";
            btnClearOrder.Size = new Size(94, 29);
            btnClearOrder.TabIndex = 17;
            btnClearOrder.Text = "נקה הזמנה";
            btnClearOrder.UseVisualStyleBackColor = true;
            btnClearOrder.Click += btnClearOrder_Click;
            // 
            // frmOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClearOrder);
            Controls.Add(btnDoOrder);
            Controls.Add(chkPreferedCustomer);
            Controls.Add(lblTotal);
            Controls.Add(dgvSalesInOrder);
            Controls.Add(dgvOrderProducts);
            Controls.Add(btnAddProduct);
            Controls.Add(label3);
            Controls.Add(numAmount);
            Controls.Add(label2);
            Controls.Add(txtProductId);
            Controls.Add(label1);
            Controls.Add(button2);
            Name = "frmOrder";
            Text = "frmOrder";
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSalesInOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Label label1;
        private TextBox txtProductId;
        private Label label2;
        private NumericUpDown numAmount;
        private Label label3;
        private Button btnAddProduct;
        private DataGridView dgvOrderProducts;
        private DataGridView dgvSalesInOrder;
        private Label lblTotal;
        private CheckBox chkPreferedCustomer;
        private Button btnDoOrder;
        private Button btnClearOrder;
    }
}