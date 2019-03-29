using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Filhanterare
{
    public partial class Form1 : Form
    {
        WindowHandler windowHandler = new WindowHandler();
        private bool isDataSaved;

        public Form1()
        {
            InitializeComponent();

            //Have this becouse the drag and drop function of the program. 
            richTextBoxWindow.DragDrop += new DragEventHandler(RichTextBoxWindow_DragDrop);
            richTextBoxWindow.EnableAutoDragDrop = false;
            richTextBoxWindow.AllowDrop = true;
            OtherInitialize();
        }

        // Call this method from the constructor of your form
        private void OtherInitialize()
        {
            Closing += new CancelEventHandler(Form1_Closing);
            // Exchange commented line and note the difference.
            isDataSaved = true;
         
        }

        //Save button function, if the user wants to save. Saves and remove astrix that shows that the
        //document have been changes.
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = ActiveForm.Text.TrimEnd('*');
            string text = richTextBoxWindow.Text;
            DialogHandler.SaveFile(text);
            isDataSaved = true;
        }

        
        //Save as function. Is almost the same as above function but the user is prompt with a save as window.
        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = ActiveForm.Text.TrimEnd('*');
            string text = richTextBoxWindow.Text;
            DialogHandler.SaveAsDialogWindow(text);
            isDataSaved = true;
        }

        //Open a new file.
        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            richTextBoxWindow.Text = DialogHandler.OpenFileDialogWindow(richTextBoxWindow);
            
        }

        //Create a new file. Ask if the user want to save before clearing textbox. 
        private void NewTextField(object sender, EventArgs e)
        {
          
            DialogHandler.SaveQuestion(richTextBoxWindow);
            richTextBoxWindow.Text = string.Empty;
            DialogHandler.filePath = string.Empty;
            ActiveForm.Text = "dok1.txt".ToString();
        }

        //Update information about the text. Also add an astrix if the text is changed.
        private void RichTextBoxWindow_TextChanged(object sender, EventArgs e)
        {
            windowHandler.TextChange();
            isDataSaved = false;

           
            string text = richTextBoxWindow.Text.ToString();
            string a = string.Concat(text.Where(c => !char.IsWhiteSpace(c)));
            int counter  = a.Length;
        


            InformationLbl.Text = "Antal bokstäver: " + richTextBoxWindow.Text.Length + " Antal bokstäver utan mellanslag: " + counter.ToString() +
            " Antal rader: " + richTextBoxWindow.Lines.Length + " Antal ord: " + DialogHandler.WordCount(richTextBoxWindow.Text);
        }

        
        //Closes the window. Promt if the user wants to quit, if yes! The user is prompt with an other 
        //window asking if the user wants to save, if changes have been made in the document. 
        private void Form1_Closing(Object sender, CancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Whould you like to save first?", "Close Application", MessageBoxButtons.YesNoCancel);
       
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    if (!isDataSaved && ((ControlAccessibleObject)((Control)sender).AccessibilityObject).Name.Contains("*") == true)
                    {
                        e.Cancel = true;
                        string text = richTextBoxWindow.Text;
                        DialogHandler.SaveFile(text);
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = false;
                        Application.Exit();
                    }
                    break;
                default:
                    e.Cancel = true;
                    Application.Exit();
                    break;
            }
        }

        //Call the drag and drop function in WindowHandler class. 
        void RichTextBoxWindow_DragDrop(object sender, DragEventArgs e) => windowHandler.DragAndDrop(e, richTextBoxWindow, ModifierKeys);

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            
            DialogHandler.SaveQuestion(richTextBoxWindow);
            Application.Exit();
        }
    }
}
