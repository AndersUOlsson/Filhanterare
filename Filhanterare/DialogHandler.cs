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
        private static string filePath = string.Empty;

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
        public static string OpenFileDialogWindow()
        {
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
                            Form1.ActiveForm.Text = fileName.ToString();
                        }
                    }
                }
            }
            catch(FileLoadException e)
            {
                throw new ApplicationException("Something wrong happened in the open module :", e);
            }
            return fileContent.ToString();
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
                    if(saveFileDialog1.FilterIndex == 1)
                    {
                        using (FileStream f = File.Create(saveFileDialog1.FileName.ToString()))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(text);
                            // Add some information to the file.
                            f.Write(info, 0, info.Length);
                            f.Close();
                        }
                    }
                    filePath = saveFileDialog1.FileName.ToString();
                }
            }
            catch(IOException e)
            {
                throw new ApplicationException("Something wrong happened in the save as module :", e);
            }
        }
    }
}
