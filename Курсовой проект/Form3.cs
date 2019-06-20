using System;
using System.Windows.Forms;

namespace Курсовой_проект
{
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            ClassSaveHist hist = new ClassSaveHist(textBoxName.Text);
            hist.ShowForm();
            Hide();
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            FormLogic frm2 = new FormLogic();
            frm2.Show();
            this.Hide();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length == 0)
                buttonStartGame.Enabled = false;
            else buttonStartGame.Enabled = true;
        }
    }
}
