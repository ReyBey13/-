using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Курсовой_проект
{
    public partial class FormRegulations : Form
    {
             
        List<GroupBox> listP = new List<GroupBox>();
        int i;

        public FormRegulations()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            listP[i].Visible = false;
            i--;
            listP[i].Visible = true;
            if (i == 0)
            {
                buttonBack.Enabled = false;
            }
            if (i < 3)
            {
                buttonForward.Enabled = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            listP[i].Visible = false;
            i++;
            listP[i].Visible = true;
            if (i==3)
            {
                buttonForward.Enabled = false;
            }
            if (i > 0)
            {
                buttonBack.Enabled = true;
            }
        }

        private void FormRegulations_Load(object sender, EventArgs e)
        {
            listP.Add(GB1);
            listP.Add(GB2);
            listP.Add(GB3);
            listP.Add(GB4);
        }
    }
}
