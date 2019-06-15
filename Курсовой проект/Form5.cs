using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Курсовой_проект
{
    public partial class FormResult : Form
    {
        public int Res, HCRes, m, s;
        
        public FormResult()
        {
            InitializeComponent();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            ClassSaveHist hist = new ClassSaveHist();
            if (Res == 0 || Res == 2)
            {
                Hide();
                hist.ShowForm();
            }
            else
            {
                StreamWriter streamWriter = new StreamWriter("records.txt", true);
                streamWriter.WriteLine(ClassSaveHist.Name + ":" + m + " мин " + s + " сек " + ":" + HCRes + ";");
                streamWriter.Close();
                FormRecords form = new FormRecords();
                form.Show();
                Hide();
            }
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
                labelResText1.Text = "Молодец";
                if (m < 10)
                {
                    if (s < 10)
                    {
                        labelResText2.Text = "Затраченное время: 0" + m + ":0" + s;
                    }
                    else { labelResText2.Text = "Затраченное время: 0" + m + ":" + s; }
                    }
                                  
                else
                {
                    labelResText2.Text = "Затраченное время: " + m + ":" + s;
                }
                
                labelResText3.Text = "Количество сохраненных сердечек";
                HeartCat1(HCRes);
            }
            if (Res == 2)
            {
                labelResText1.Text = "Ура!";
                labelResText2.Text = "Ты прошел тренировку!";
                labelResText3.Text = "Теперь ты готов к работе!";
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
