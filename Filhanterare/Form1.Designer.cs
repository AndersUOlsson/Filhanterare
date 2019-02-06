namespace Filhanterare
{
    public partial class Form1
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SaveAsBtn = new System.Windows.Forms.Button();
            this.richTextBoxWindow = new System.Windows.Forms.RichTextBox();
            this.OpenFileBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.InformationLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(9, 5);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(61, 29);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.Location = new System.Drawing.Point(74, 6);
            this.SaveAsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(72, 28);
            this.SaveAsBtn.TabIndex = 1;
            this.SaveAsBtn.Text = "Save As...";
            this.SaveAsBtn.UseVisualStyleBackColor = true;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveAsBtn_Click);
            // 
            // richTextBoxWindow
            // 
            this.richTextBoxWindow.EnableAutoDragDrop = true;
            this.richTextBoxWindow.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxWindow.Location = new System.Drawing.Point(9, 43);
            this.richTextBoxWindow.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxWindow.Name = "richTextBoxWindow";
            this.richTextBoxWindow.Size = new System.Drawing.Size(518, 541);
            this.richTextBoxWindow.TabIndex = 2;
            this.richTextBoxWindow.Text = "";
            this.richTextBoxWindow.TextChanged += new System.EventHandler(this.RichTextBoxWindow_TextChanged);
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.Location = new System.Drawing.Point(466, 6);
            this.OpenFileBtn.Margin = new System.Windows.Forms.Padding(2);
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(61, 28);
            this.OpenFileBtn.TabIndex = 3;
            this.OpenFileBtn.Text = "Open File";
            this.OpenFileBtn.UseVisualStyleBackColor = true;
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(407, 5);
            this.newBtn.Margin = new System.Windows.Forms.Padding(2);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(55, 29);
            this.newBtn.TabIndex = 4;
            this.newBtn.Text = "New";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.NewTextField);
            // 
            // InformationLbl
            // 
            this.InformationLbl.AutoSize = true;
            this.InformationLbl.Location = new System.Drawing.Point(6, 587);
            this.InformationLbl.Name = "InformationLbl";
            this.InformationLbl.Size = new System.Drawing.Size(0, 13);
            this.InformationLbl.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 609);
            this.Controls.Add(this.InformationLbl);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.OpenFileBtn);
            this.Controls.Add(this.richTextBoxWindow);
            this.Controls.Add(this.SaveAsBtn);
            this.Controls.Add(this.SaveBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "dok1.txt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button SaveAsBtn;
        private System.Windows.Forms.Button OpenFileBtn;
        private System.Windows.Forms.Button newBtn;
        public System.Windows.Forms.RichTextBox richTextBoxWindow;
        private System.Windows.Forms.Label InformationLbl;
    }
}

