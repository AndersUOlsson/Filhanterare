using System;
using System.IO;
using System.Windows.Forms;



namespace Filhanterare
{
    class WindowHandler
    {
        //If the document have been changed, adds an astrix.
        public void TextChange()
        {
            if (!Form.ActiveForm.Text.Contains("*") && DialogHandler.flagForOpenFile == false)
            {
                Form.ActiveForm.Text = Form.ActiveForm.Text.ToString() + "*";
            }
            DialogHandler.flagForOpenFile = false;
        }

        //Drag and drop function. 
        public void DragAndDrop(DragEventArgs e, RichTextBox richTextBox, Keys keys)
        {
            //Reads the content from the file that has been droped in the editor.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string s = "";
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                    StreamReader file = new StreamReader(files[0]);
                    s = file.ReadToEnd();
                    file.Close();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex);
                    throw new Exception();
                }

                //Diffrent action depending on the key the user press under the time the user 
                //drags and drop content to editor. 
                switch (keys)
                {
                    case Keys.Control:
                        string text = richTextBox.Text;
                        richTextBox.Clear();
                        text += richTextBox.Text.ToString();
                        richTextBox.Text = text + s;
                        break;
                    case Keys.Shift:
                        richTextBox.SelectionStart += richTextBox.SelectionLength;
                        richTextBox.SelectionLength = 0;
                        richTextBox.SelectedText = s;
                        break;
                    default:
                        //Warning window, ask if the user wants to save before the new content is displayed in the editor.
                        if (MessageBox.Show("Whould you like to save first?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DialogHandler.SaveFile(richTextBox.Text);
                            richTextBox.Clear();
                            richTextBox.Text = s;
                        }
                        else
                        {
                            richTextBox.Clear();
                            richTextBox.Text = s;
                        }
                        break;
                }
            }
        }
    }
}
