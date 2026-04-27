namespace UI
{
    partial class frmCustomer
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
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtId = new TextBox();
            btnAddUpdate = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(530, 192);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(530, 225);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 0;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(530, 258);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(530, 159);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 0;
            // 
            // btnAddUpdate
            // 
            btnAddUpdate.Location = new Point(530, 309);
            btnAddUpdate.Name = "btnAddUpdate";
            btnAddUpdate.Size = new Size(132, 43);
            btnAddUpdate.TabIndex = 1;
            btnAddUpdate.Text = "הוסף לקוח";
            btnAddUpdate.UseVisualStyleBackColor = true;
            btnAddUpdate.Click += btnAddUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(691, 158);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 2;
            label1.Text = "ת.ז";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(691, 195);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 2;
            label2.Text = "שם מלא";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(691, 258);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 2;
            label3.Text = "פלאפון";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(691, 228);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 2;
            label4.Text = "כתובת";
            // 
            // frmCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddUpdate);
            Controls.Add(txtId);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Name = "frmCustomer";
            Text = "frmCustomer";
            Load += frmCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtId;
        private Button btnAddUpdate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}