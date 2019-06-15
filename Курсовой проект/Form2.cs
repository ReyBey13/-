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

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            for (i = 0; i >= 2; i++)
            {
                listP[i].Visible=false;
                i++;
                listP[i].Visible = true;
            }            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
