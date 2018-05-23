namespace ProjectARC
{
    partial class Autorization
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
            this.Login_tb = new System.Windows.Forms.TextBox();
            this.Password_tb = new System.Windows.Forms.TextBox();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.Enter_btn = new System.Windows.Forms.Button();
            this.Login_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login_tb
            // 
            this.Login_tb.Location = new System.Drawing.Point(162, 43);
            this.Login_tb.Name = "Login_tb";
            this.Login_tb.Size = new System.Drawing.Size(180, 20);
            this.Login_tb.TabIndex = 0;
            // 
            // Password_tb
            // 
            this.Password_tb.Location = new System.Drawing.Point(162, 97);
            this.Password_tb.Name = "Password_tb";
            this.Password_tb.Size = new System.Drawing.Size(180, 20);
            this.Password_tb.TabIndex = 1;
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(312, 157);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(125, 35);
            this.Cancel_btn.TabIndex = 2;
            this.Cancel_btn.Text = "Отмена";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Enter_btn
            // 
            this.Enter_btn.Location = new System.Drawing.Point(92, 157);
            this.Enter_btn.Name = "Enter_btn";
            this.Enter_btn.Size = new System.Drawing.Size(120, 35);
            this.Enter_btn.TabIndex = 1;
            this.Enter_btn.Text = "Войти";
            this.Enter_btn.UseVisualStyleBackColor = true;
            this.Enter_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.Location = new System.Drawing.Point(89, 43);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(41, 13);
            this.Login_label.TabIndex = 4;
            this.Login_label.Text = "Логин:";
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(89, 104);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(48, 13);
            this.Password_label.TabIndex = 5;
            this.Password_label.Text = "Пароль:";
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 221);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Enter_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Password_tb);
            this.Controls.Add(this.Login_tb);
            this.Name = "Autorization";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Login_tb;
        private System.Windows.Forms.TextBox Password_tb;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button Enter_btn;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Label Password_label;
    }
}