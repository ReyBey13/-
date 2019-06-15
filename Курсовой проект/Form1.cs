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
    public partial class FormLogic : Form
    {
        public FormLogic()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            FormRegistration frm0 = new FormRegistration();
            frm0.Show();
            this.Hide();
        }

        public void buttonExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            result = MessageBox.Show("Действительно хотите выйти?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
        }

        private void buttonRegulations_Click(object sender, EventArgs e)
        {
            FormRegulations frm4 = new FormRegulations();
            frm4.Show();
        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            FormRecords frm5 = new FormRecords();
            frm5.Show();
        }

        private void FormLogic_Load(object sender, EventArgs e)
        {

        }
    }
}
