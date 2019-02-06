using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Filhanterare
{
    public partial class Form1 : Form
    {
        WindowHandler WindowHandler = new WindowHandler();
        private bool isDataSaved;

        public Form1()
        {
            InitializeComponent();
           
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
            //this.isDataSaved = false;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = ActiveForm.Text.TrimEnd('*');
            string text = richTextBoxWindow.Text;
            DialogHandler.SaveFile(text);
            isDataSaved = true;
        }

        

        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = ActiveForm.Text.TrimEnd('*');
            string text = richTextBoxWindow.Text;
            DialogHandler.SaveAsDialogWindow(text);
            isDataSaved = true;
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            //string text = richTextBoxWindow.Text = fileContent.ToString();
            //NameOfTheCurrentText = DialogHandler.OpenFileDialogWindow();

            richTextBoxWindow.Text = DialogHandler.OpenFileDialogWindow();
        }

        private void NewTextField(object sender, EventArgs e)
        {
            richTextBoxWindow.Text = string.Empty;

            ActiveForm.Text = "dok1.txt".ToString();
        }

        private void RichTextBoxWindow_TextChanged(object sender, EventArgs e)
        {
            WindowHandler.TextChange();
            isDataSaved = false;
            string text = richTextBoxWindow.ToString();
            int counter = text.Length;
            int counterWithOutSpace = text.Trim(' ').Length;
            InformationLbl.Text = "Antal ord " + richTextBoxWindow.TextLength + " Antal ord utan mellanslag " + richTextBoxWindow.Text.Trim(' ').Length +
                " Rader " + richTextBoxWindow.Lines.Length;
        }


       

        private void Form1_Closing(Object sender, CancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNoCancel);


            switch (dialogResult)
            {
                case DialogResult.Yes:
                    if (!isDataSaved)
                    {
                        if (MessageBox.Show("Whould you like to save first?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            e.Cancel = true;
                            SaveAsBtn_Click(sender, e);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        void RichTextBoxWindow_DragDrop(object sender, DragEventArgs e)
        {
            object filename = e.Data.GetData("FileDrop");
            if (filename != null)
            {
                try
                {


                    if (filename is string[] list && !string.IsNullOrWhiteSpace(list[0]))
                    {
                        //richTextBoxWindow.Clear();
                        richTextBoxWindow.LoadFile(list[0], RichTextBoxStreamType.PlainText);
                    }

                }
                catch(Exception ex)
                {
                    throw ex;
                }
               

            }
        }
    }
}
