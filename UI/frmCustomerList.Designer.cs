namespace UI
{
    partial class frmCustomerList
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
            dgvCustomers = new DataGridView();
            label1 = new Label();
            txtSearchName = new TextBox();
            btnDeleteCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnAddCustomer = new Button();
            button1 = new Button();
            btnViewCustomer = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(220, 165);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(538, 254);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            dgvCustomers.MouseDoubleClick += dgvCustomers_MouseDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(463, 135);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 1;
            label1.Text = "חפש לקוח לפי שם:";
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(332, 132);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.PlaceholderText = "הקלד שם...";
            txtSearchName.Size = new Size(125, 27);
            txtSearchName.TabIndex = 2;
            txtSearchName.TextChanged += txtSearchName_TextChanged;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.BackColor = Color.Red;
            btnDeleteCustomer.Location = new Point(36, 301);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(141, 29);
            btnDeleteCustomer.TabIndex = 3;
            btnDeleteCustomer.Text = "מחיקת לקוח";
            btnDeleteCustomer.UseVisualStyleBackColor = false;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(36, 266);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(141, 29);
            btnUpdateCustomer.TabIndex = 3;
            btnUpdateCustomer.Text = "עדכון פרטי לקוח";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(36, 231);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(141, 29);
            btnAddCustomer.TabIndex = 3;
            btnAddCustomer.Text = "הוספת לקוח חדש";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(65, 14);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "חזרה ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnViewCustomer
            // 
            btnViewCustomer.Location = new Point(36, 187);
            btnViewCustomer.Name = "btnViewCustomer";
            btnViewCustomer.Size = new Size(141, 29);
            btnViewCustomer.TabIndex = 5;
            btnViewCustomer.Text = "צפיה בפרטי לקוח";
            btnViewCustomer.UseVisualStyleBackColor = true;
            btnViewCustomer.Click += btnViewCustomer_Click;
            // 
            // frmCustomerList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnViewCustomer);
            Controls.Add(button1);
            Controls.Add(btnAddCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(txtSearchName);
            Controls.Add(label1);
            Controls.Add(dgvCustomers);
            Name = "frmCustomerList";
            Text = "frmCustomerList";
            Load += frmCustomerList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomers;
        private Label label1;
        private TextBox txtSearchName;
        private Button btnDeleteCustomer;
        private Button btnUpdateCustomer;
        private Button btnAddCustomer;
        private Button button1;
        private Button btnViewCustomer;
    }
}