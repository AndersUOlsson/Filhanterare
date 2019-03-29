using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filhanterare
{
    class DialogHandler
    {
        private static string fileContent = string.Empty;
        public static string filePath = string.Empty;
        public static bool flagForOpenFile = false;
        public static int counter = 0;

        //Saves the file. If there is no file path then the function calls the save as function.
        public static void SaveFile(string text)
        {
            if (text != string.Empty && filePath != string.Empty)
            {
                try
                {
                    File.WriteAllText(filePath, text);
                }
                catch(FileNotFoundException e)
                {
                    throw new ApplicationException("Something wrong happened in the save module :", e);
                }
            }
            else
            {
                SaveAsDialogWindow(text);
            }
        }

        //Open txt file and reads in the information from  file to richtextbox.
        public static string OpenFileDialogWindow(RichTextBox richTextBox)
        {
            SaveQuestion(richTextBox);
            flagForOpenFile = true;

            try
            {
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

                        if (fileContent != null)
                        {
                            string path = filePath.ToString();
                            string[] pathArr = path.Split('\\');
                            string fileName = pathArr.Last().ToString();
                            Form.ActiveForm.Text = fileName.ToString();
                        }
                    }
                }
            }
            catch (FileLoadException e)
            {
                throw new ApplicationException("Something wrong happened in the open module :", e);
            }
            return fileContent.ToString();
        }

        //If the document is changed, promp a window ask if the user wants to save.
        public static void SaveQuestion(RichTextBox richTextBox)
        {
            if (Form.ActiveForm.Text.Contains("*"))
            {
                if (MessageBox.Show("Whould you like to save first?", "Close Application", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    SaveFile(richTextBox.Text);
                    richTextBox.Clear();
                }
            }
        }

        //This is the save as function and it thus what you expect. Throw exception otherwise.
        public static void SaveAsDialogWindow(string text)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Text|*.txt",
                    Title = "Save an text File"
                };
                saveFileDialog1.ShowDialog();
                
                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog1.FileName != "")
                {
                    filePath = saveFileDialog1.FileName;
                    if (saveFileDialog1.FilterIndex == 1)
                    {
                        using (FileStream f = File.Create(saveFileDialog1.FileName.ToString()))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(text);
                            // Add some information to the file.
                            f.Write(info, 0, info.Length);
                            f.Close();
                        }
                    }
                
                    string path = saveFileDialog1.FileName.ToString();
                    string[] pathArr = path.Split('\\');
                    string fileName = pathArr.Last().ToString();
                    Form.ActiveForm.Text = fileName.ToString();
                }
            }
            catch(IOException e)
            {
                throw new ApplicationException("Something wrong happened in the save as module :", e);
            }
        }
        public static string WordCount( string s)
        {
            return s.Split(new char[] { ' ' },
              StringSplitOptions.RemoveEmptyEntries).Length.ToString();
        }
        public static int LetterCount(string s)
        {
            foreach(var l in s )
            {
                if (l.Equals(' '))
                    counter++;
            }

            return counter;
        }

    }
}
