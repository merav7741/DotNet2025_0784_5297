namespace UI
{
    partial class frmSaleList
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
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            label1 = new Label();
            SalesGrid = new DataGridView();
            label2 = new Label();
            txtProductIdFilter = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)SalesGrid).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(152, 107);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(155, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "הוספת מבצע";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(152, 142);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(155, 29);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "עדכון מבצע";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += button2_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(152, 177);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(155, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "מחיקת מבצע";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(152, 212);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(155, 29);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(497, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 5;
            label1.Text = "ניהול מבצעים";
            label1.Click += label1_Click;
            // 
            // SalesGrid
            // 
            SalesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SalesGrid.Location = new Point(339, 86);
            SalesGrid.Name = "SalesGrid";
            SalesGrid.RowHeadersWidth = 51;
            SalesGrid.Size = new Size(403, 304);
            SalesGrid.TabIndex = 0;
            SalesGrid.MouseDoubleClick += SalesGrid_MouseDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(582, 54);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 6;
            label2.Text = "סינון לפי קוד מוצר";
            // 
            // txtProductIdFilter
            // 
            txtProductIdFilter.Location = new Point(508, 53);
            txtProductIdFilter.Name = "txtProductIdFilter";
            txtProductIdFilter.Size = new Size(68, 27);
            txtProductIdFilter.TabIndex = 7;
            txtProductIdFilter.TextChanged += txtProductIdFilter_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(24, 26);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 8;
            button2.Text = "חזרה ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // frmSaleList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(txtProductIdFilter);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(SalesGrid);
            Name = "frmSaleList";
            Text = "formSale";
            ((System.ComponentModel.ISupportInitialize)SalesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private Label label1;
        private DataGridView SalesGrid;
        private Label label2;
        private TextBox txtProductIdFilter;
        private Button button2;
    }

}