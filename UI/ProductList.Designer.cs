namespace UI
{
    partial class ProductList
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
            CategorySelector = new ComboBox();
            ProductsGrid = new DataGridView();
            BtnAddProduct = new Button();
            btnDeleteProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).BeginInit();
            SuspendLayout();
            // 
            // CategorySelector
            // 
            CategorySelector.FormattingEnabled = true;
            CategorySelector.Location = new Point(462, 122);
            CategorySelector.Name = "CategorySelector";
            CategorySelector.Size = new Size(151, 28);
            CategorySelector.TabIndex = 0;
            CategorySelector.SelectedIndexChanged += CategorySelector_SelectedIndexChanged;
            // 
            // ProductsGrid
            // 
            ProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsGrid.Location = new Point(395, 156);
            ProductsGrid.Name = "ProductsGrid";
            ProductsGrid.RowHeadersWidth = 51;
            ProductsGrid.Size = new Size(378, 261);
            ProductsGrid.TabIndex = 1;
            ProductsGrid.CellContentClick += ProductsGrid_CellContentClick;
            ProductsGrid.MouseDoubleClick += ProductsGrid_MouseDoubleClick_1;
            // 
            // BtnAddProduct
            // 
            BtnAddProduct.Location = new Point(229, 214);
            BtnAddProduct.Name = "BtnAddProduct";
            BtnAddProduct.Size = new Size(136, 29);
            BtnAddProduct.TabIndex = 2;
            BtnAddProduct.Text = "הוספת מוצר";
            BtnAddProduct.UseVisualStyleBackColor = true;
            BtnAddProduct.Click += BtnAddProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(229, 263);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(127, 29);
            btnDeleteProduct.TabIndex = 3;
            btnDeleteProduct.Text = "מחיקת מוצר";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // ProductList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteProduct);
            Controls.Add(BtnAddProduct);
            Controls.Add(ProductsGrid);
            Controls.Add(CategorySelector);
            Name = "ProductList";
            Text = "ProductList";
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CategorySelector;
        private DataGridView ProductsGrid;
        private Button BtnAddProduct;
        private Button btnDeleteProduct;
    }
}