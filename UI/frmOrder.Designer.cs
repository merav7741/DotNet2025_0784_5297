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
            btnAddOrder = new Button();
            textBox1 = new TextBox();
            btnDeleteOrder = new Button();
            btnUpdateOrder = new Button();
            SuspendLayout();
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(363, 230);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(140, 29);
            btnAddOrder.TabIndex = 0;
            btnAddOrder.Text = "הוסף הזמנה";
            btnAddOrder.UseVisualStyleBackColor = true;
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(378, 188);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Location = new Point(363, 265);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(140, 29);
            btnDeleteOrder.TabIndex = 0;
            btnDeleteOrder.Text = "מחיקת הזמנה";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // btnUpdateOrder
            // 
            btnUpdateOrder.Location = new Point(363, 300);
            btnUpdateOrder.Name = "btnUpdateOrder";
            btnUpdateOrder.Size = new Size(140, 29);
            btnUpdateOrder.TabIndex = 0;
            btnUpdateOrder.Text = "עדכון הזמנה";
            btnUpdateOrder.UseVisualStyleBackColor = true;
            btnUpdateOrder.Click += btnUpdateOrder_Click;
            // 
            // frmOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(btnUpdateOrder);
            Controls.Add(btnDeleteOrder);
            Controls.Add(btnAddOrder);
            Name = "frmOrder";
            Text = "frmOrder";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddOrder;
        private TextBox textBox1;
        private Button btnDeleteOrder;
        private Button btnUpdateOrder;
    }
}