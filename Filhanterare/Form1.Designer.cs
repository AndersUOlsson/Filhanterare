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
            richTextBoxWindow = new System.Windows.Forms.RichTextBox();
            this.OpenFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(9, 5);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.SaveAsBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(72, 28);
            this.SaveAsBtn.TabIndex = 1;
            this.SaveAsBtn.Text = "Save As...";
            this.SaveAsBtn.UseVisualStyleBackColor = true;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveAsBtn_Click);
            // 
            // richTextBoxWindow
            // 
            richTextBoxWindow.Location = new System.Drawing.Point(9, 43);
            richTextBoxWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            richTextBoxWindow.Name = "richTextBoxWindow";
            richTextBoxWindow.Size = new System.Drawing.Size(518, 561);
            richTextBoxWindow.TabIndex = 2;
            richTextBoxWindow.Text = "";
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.Location = new System.Drawing.Point(466, 6);
            this.OpenFileBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(61, 28);
            this.OpenFileBtn.TabIndex = 3;
            this.OpenFileBtn.Text = "Open File";
            this.OpenFileBtn.UseVisualStyleBackColor = true;
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 609);
            this.Controls.Add(this.OpenFileBtn);
            this.Controls.Add(richTextBoxWindow);
            this.Controls.Add(this.SaveAsBtn);
            this.Controls.Add(this.SaveBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button SaveAsBtn;
        public  static System.Windows.Forms.RichTextBox richTextBoxWindow;
        private System.Windows.Forms.Button OpenFileBtn;
    }
}

