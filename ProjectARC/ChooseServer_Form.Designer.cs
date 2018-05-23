namespace ProjectARC
{
    partial class ChooseServer_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseServer_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.ServerName_tb = new System.Windows.Forms.TextBox();
            this.SaveServer_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите имя сервера";
            // 
            // ServerName_tb
            // 
            this.ServerName_tb.Location = new System.Drawing.Point(261, 34);
            this.ServerName_tb.Name = "ServerName_tb";
            this.ServerName_tb.Size = new System.Drawing.Size(374, 20);
            this.ServerName_tb.TabIndex = 1;
            // 
            // SaveServer_btn
            // 
            this.SaveServer_btn.Location = new System.Drawing.Point(79, 97);
            this.SaveServer_btn.Name = "SaveServer_btn";
            this.SaveServer_btn.Size = new System.Drawing.Size(161, 42);
            this.SaveServer_btn.TabIndex = 2;
            this.SaveServer_btn.Text = "Сохранить";
            this.SaveServer_btn.UseVisualStyleBackColor = true;
            this.SaveServer_btn.Click += new System.EventHandler(this.SaveServer_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(474, 97);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(161, 42);
            this.Cancel_btn.TabIndex = 3;
            this.Cancel_btn.Text = "Отмена";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // ChooseServer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 151);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.SaveServer_btn);
            this.Controls.Add(this.ServerName_tb);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseServer_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор сервера";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerName_tb;
        private System.Windows.Forms.Button SaveServer_btn;
        private System.Windows.Forms.Button Cancel_btn;
    }
}