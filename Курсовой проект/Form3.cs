using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Btn_Click(object sender, EventArgs e)
        {
            
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

        private void FormRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
