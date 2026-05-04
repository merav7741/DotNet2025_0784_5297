namespace UI
{
    partial class frmSale
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
            txtProductId = new TextBox();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            chkAllCustomers = new CheckBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(341, 81);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(125, 27);
            txtProductId.TabIndex = 0;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(341, 114);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(341, 157);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 2;
            // 
            // chkAllCustomers
            // 
            chkAllCustomers.AutoSize = true;
            chkAllCustomers.Location = new Point(329, 211);
            chkAllCustomers.Name = "chkAllCustomers";
            chkAllCustomers.Size = new Size(175, 24);
            chkAllCustomers.TabIndex = 3;
            chkAllCustomers.Text = "המבצע לכלל הלקוחות";
            chkAllCustomers.UseVisualStyleBackColor = true;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(274, 256);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 4;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(274, 299);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(250, 27);
            dtpEnd.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(341, 356);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "שמור";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(485, 84);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 7;
            label1.Text = "ProductId";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(485, 117);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 8;
            label2.Text = "כמות";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(485, 164);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 9;
            label3.Text = "מחיר";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(542, 261);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 10;
            label4.Text = "תאריך התחלה";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(542, 299);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 11;
            label5.Text = "תאריך סיום";
            // 
            // formSale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(chkAllCustomers);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txtProductId);
            Name = "formSale";
            Text = "formSale";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProductId;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private CheckBox chkAllCustomers;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}