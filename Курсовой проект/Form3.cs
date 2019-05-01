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
            Form FormHistory = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(500, 550),
                BackgroundImage = Properties.Resources.Regul,
                BackgroundImageLayout = ImageLayout.Stretch,
            };

            PictureBox picPush = new PictureBox
            {
                Location = new Point(25, 25),
                Size = new Size(110, 80),
                Image = Properties.Resources.ReadingCat,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
            };

            Label tit = new Label
            {
                Location = new Point(160, 25),
                AutoSize = false,
                Height = 80,
                Width = 300,
                Text = "Привет, " + textBoxName.Text + "! \nРад приветствовать тебя на производстве котороботов Коточу.",
                BackColor = Color.Transparent,
                Font = new Font("Comic Sans MS", 12),
            };

            Label labl = new Label
            {
                Location = new Point(25, 110),
                AutoSize = false,
                Height = 300,
                Width = 430,
                Text = "Ты пришел вовремя, котороботы почти готовы. \n" +
                        "Осталось их только зарядить.\n" +
                        "У тебя есть хороший шанс помочь нам с этим, указав в блоках зарядки какой Коточу получит энергию.\n" +
                        "Каждый из этих блоков - один уровень игры.\n" +
                        "Блоки зарядки работают по логическим схемам с элементами, которых ты, возможно, не знаешь.\n" +
                        "Поэтому я предлагаю тебе изучить их в нашем Тренировочном отделе.\n" +
                        "Для этого нажми Тренировка. " +
                        "Но если ты уверен в том, что знаешь элементы логических схем, \n" +
                        "то можешь сразу же приступить к помощи нам.\n" +
                        "Учитывай, что в настоящей работе сроки ограничены и лучше не допускать ошибок.\n" +
                        "Готов ? Тогда жми Приступить.",
                BackColor = Color.Transparent,
                Font = new Font("Comic Sans MS", 10),
                TextAlign = ContentAlignment.TopLeft
            };

            Button btn = new Button
            {
                Location = new Point(25, 430),
                Text = "Возврат в меню",
                Width = 130,
                Height = 32,
                BackColor = Color.PeachPuff,
                Font = new Font("Comic Sans MS", 10),
                FlatStyle = FlatStyle.Popup,
                TextAlign = ContentAlignment.MiddleLeft,
                DialogResult = DialogResult.Abort,
                
            };
            //btn.Click += Btn_Click;

            Button btnTrain = new Button
            {
                Location = new Point(160, 430),
                Text = "Тренировка",
                Width = 120,
                Height = 32,
                BackColor = Color.PeachPuff,
                Font = new Font("Comic Sans MS", 10),
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Popup,
            };

            Button btnPlay = new Button
            {
                Location = new Point(295, 430),
                Text = "Приступить",
                Width = 120,
                Height = 32,
                BackColor = Color.PeachPuff,
                Font = new Font("Comic Sans MS", 10),
                DialogResult = DialogResult.Cancel,
                FlatStyle = FlatStyle.Popup,
            };
            FormHistory.Controls.Add(picPush);
            FormHistory.Controls.Add(btn);
            FormHistory.Controls.Add(btnTrain);
            FormHistory.Controls.Add(btnPlay);
            FormHistory.Controls.Add(tit);
            FormHistory.Controls.Add(labl);
            FormGame frm1;
            DialogResult dg = (DialogResult)FormHistory.ShowDialog();
            if (dg == DialogResult.OK)
            {
                frm1 = new FormGame(true);
                frm1.Show();
                this.Hide();
            }
            else if(dg == DialogResult.Cancel)
            {
                frm1 = new FormGame(false);
                frm1.Show();
                this.Hide();
            }
            else
            {
                FormLogic form = new FormLogic();
                form.Show();
                this.Close();
            }

            
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
