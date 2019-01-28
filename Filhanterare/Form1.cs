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
            
            string text = richTextBoxWindow.Text;
            string path = "C:\\Users\\andyw\\Desktop\\NewFile.txt";
            if (text != null && NameOfTheCurrentText != null)
            {
                System.IO.File.WriteAllText(NameOfTheCurrentText, text);
            }
            else
            {

            }
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }

        }

        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text|*.txt";
            saveFileDialog1.Title = "Save an text File";
            saveFileDialog1.ShowDialog();
            string text = richTextBoxWindow.Text;

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                //System.IO.FileStream fs =
                //   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the  
                // File type selected in the dialog box.  
                // NOTE that the FilterIndex property is one-based.  
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                 
                    using (FileStream f = File.Create(saveFileDialog1.FileName.ToString()))
                    {
                    Byte[] info = new UTF8Encoding(true).GetBytes(text);
                    // Add some information to the file.

                    f.Write(info, 0, info.Length);
                    f.Close();
                    }
                        break;
                }
            }
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    System.IO.StreamReader sr = new
            //       System.IO.StreamReader(openFileDialog1.FileName);
            //    MessageBox.Show(sr.ReadToEnd());
            //    sr.Close();
            //}
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    if(fileContent != null)
                    {
                        richTextBoxWindow.Text = fileContent.ToString();
                    }
                    NameOfTheCurrentText = filePath.ToString();
                }
            }
        }
    }
}
