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
    public partial class FormResult : Form
    {
        public int Res, HCRes,m,s;
        
        public FormResult()
        {
            InitializeComponent();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            FormLogic frm2 = new FormLogic();
            frm2.Show();
            this.Hide();
        }

        private void FormResult_Load(object sender, EventArgs e)
        {
            if (Res == 0)
            {
                labelResText1.Text = "Упс!";
                labelResText2.Text = "У тебя кончились сердечки!";
                labelResText3.Text = "Попробуй еще раз!";
                pictureBox1.Image = Properties.Resources.RipCat;
            }
            if (Res==1)
            {
                labelResText4.Text = "Молодец";
                if (m < 10)
                {
                    if (s < 10)
                    {
                        labelResText5.Text = "Пройденное время: 0" + m + ":0" + s;
                    }
                    else { labelResText5.Text = "Пройденное время: 0" + m + ":" + s; }
                    }
                                  
                else
                {
                    labelResText5.Text = "Пройденное время: " + m + ":" + s;
                }
                
                labelResText6.Text = "Количество сохраненных сердечек";
                HeartCat1(HCRes);
            }
            if (Res == 3)
            {
                labelResText10.Text = "Ура!";
                labelResText8.Text = "Ты прошел тренировку!";
                labelResText9.Text = "Теперь ты готов к работе!";
                pictureBox1.Image = Properties.Resources.HappyCat;
            }
        }

        public void HeartCat1(int HCRes)
        {
            switch (HCRes)
            {
                case 3: pictureBox1.Image = Properties.Resources.Hearts3; break;
                case 2: pictureBox1.Image = Properties.Resources.Hearts2; break;
                case 1: pictureBox1.Image = Properties.Resources.Hearts1; break;
            }
        }
    }
}
