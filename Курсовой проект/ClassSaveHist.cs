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
    class ClassSaveHist
    {
        static internal string Name;

        public ClassSaveHist()
        {

        }
        public ClassSaveHist(string name)
        {
            Name = name;
        }

        public void ShowForm()
        {
            Form FormHistory = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(500, 550),
                BackgroundImage = Properties.Resources.Regul,
                BackgroundImageLayout = ImageLayout.Stretch,
                Text = "Выбор режима",
                MaximizeBox = false,
                Icon=Properties.Resources.iconGame,
            };

            PictureBox picPush = new PictureBox();
            picPush.Location = new Point(25, 25);
            picPush.Size = new Size(110, 80);
            picPush.Image = Properties.Resources.ReadingCat;
            picPush.SizeMode = PictureBoxSizeMode.StretchImage;
            picPush.BackColor = Color.Transparent;


            Label tit = new Label
            {
                Location = new Point(160, 25),
                AutoSize = false,
                Height = 80,
                Width = 300,
                Text = "Привет, " + Name + "! \nРад приветствовать тебя на производстве котороботов Коточу.",
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
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btn = new Button();
            btn.Location = new Point(25, 430);
            btn.Text = "Возврат в меню";
            btn.Width = 130;
            btn.Height = 32;
            btn.BackColor = Color.PeachPuff;
            btn.Font = new Font("Comic Sans MS", 10);
            btn.FlatStyle = FlatStyle.Popup;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.DialogResult = DialogResult.Abort;


            //btn.Click += Btn_Click;

            Button btnTrain = new Button();
            btnTrain.Location = new Point(190, 430);
            btnTrain.Text = "Тренировка";
            btnTrain.Width = 120;
            btnTrain.Height = 32;
            btnTrain.BackColor = Color.PeachPuff;
            btnTrain.Font = new Font("Comic Sans MS", 10);
            btnTrain.DialogResult = DialogResult.OK;
            btnTrain.FlatStyle = FlatStyle.Popup;


            Button btnPlay = new Button();
            btnPlay.Location = new Point(340, 430);
            btnPlay.Text = "Приступить";
            btnPlay.Width = 120;
            btnPlay.Height = 32;
            btnPlay.BackColor = Color.PeachPuff;
            btnPlay.Font = new Font("Comic Sans MS", 10);
            btnPlay.DialogResult = DialogResult.Yes;
            btnPlay.FlatStyle = FlatStyle.Popup;


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
            }
            else if (dg == DialogResult.Yes)
            {
                frm1 = new FormGame(false);
                frm1.Show();
            }
            else
            {
                FormLogic form = new FormLogic();
                form.Show();
            }
        }
        
    }
}
