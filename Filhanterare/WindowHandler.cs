namespace Filhanterare
{
    class WindowHandler
    {
        public void TextChange()
        {
            if (!System.Windows.Forms.Form.ActiveForm.Text.Contains("*"))
            {
                System.Windows.Forms.Form.ActiveForm.Text = System.Windows.Forms.Form.ActiveForm.Text.ToString() + "*";
            }
        }
    }
}
