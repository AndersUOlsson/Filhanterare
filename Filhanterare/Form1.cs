using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filhanterare
{
    public partial class Form1 : Form
    {

        private string NameOfTheCurrentText;

        public Form1()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogHandler.SaveFile();

        }

        

        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            DialogHandler.SaveAsDialogWindow();
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            NameOfTheCurrentText = DialogHandler.OpenFileDialogWindow();
        }

        private void newTextField(object sender, EventArgs e)
        {
            Form1.richTextBoxWindow.Text = string.Empty;

            Form1.ActiveForm.Text = "dok1.txt".ToString();
        }
    }
}
