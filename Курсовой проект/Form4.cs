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
    public struct ImageInfo
    {
        public bool State;
        public Image Green;
        public Image Black;
    }
    public partial class FormGame : Form
    {
        int Res = 1;
        int HC = 3;
        int s = 0;
        int m = 0;
        bool btn = false;
        object a, b;
        object q = null;
        int[] locA = new int[2];
        int[] locB = new int[2];
        List<Panel> panels = new List<Panel>();
        int i = 0;
        int tr = 0;
        bool gameType;

        int CountPanels = 0;
        public FormGame(bool type)
        {
            InitializeComponent();
            InitalizePic();
            gameType = type;
            if (gameType)
            {
                buttonHint.Visible = false;
                labelMin.Visible = false;
                labelPoints.Visible = false;
                labelSec.Visible = false;
                pictureBoxHearts.Visible = false;
            }

            panellvl1.Location = new Point(280, 42);
            panellvl1.Size = new Size(562, 442);

            panels.Add(panellvl1);
            panels.Add(panelLvl2);
            panels.Add(panelLvl3);
            panels.Add(panelLvl4);
            panels.Add(panelLvl5);
            panels.Add(panelLvl6);

            Image img = Properties.Resources.NotGreen;
            img.RotateFlip(RotateFlipType.Rotate90FlipX);
            picNotLvl51.Image = img;

            timerCheck.Start();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {

        }
    
        public void timerGame_Tick(object sender, EventArgs e)
        {
            if (labelSec.Enabled == true)
            {
                if (s < 59)
                {
                    s++;
                    if (s < 10) labelSec.Text = "0" + s.ToString();
                    else labelSec.Text = s.ToString();
                }
                else
                {
                    if (m < 59)
                    {
                        m++;
                        if (m < 10) labelMin.Text = "0" + m.ToString();
                        else labelMin.Text = m.ToString();
                        s = 0;
                        labelSec.Text = "00";
                    }
                    else
                    {
                        m = 0;
                        labelMin.Text = "00";
                    }
                }
            }
            else labelMin.Enabled = true;
        }

        public void timerCat_Tick(object sender, EventArgs e)
        {
            pictureBoxCat2.Visible = false;
            HeartCat(HC);
            timerCat.Stop();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //FormLogic form0 = new FormLogic();
            //form0.buttonExit_Click(sender, e);
            FormLogic form = new FormLogic();
            form.Show();
            Hide();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            pictureBoxHearts.Image = Properties.Resources.Hearts3;
        }

     

        private void buttonHint_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBoxCat_Click(object sender, EventArgs e)
        {

        }

        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            switch (CountPanels)
            {
                case 0:
                    {
                        if (Convert.ToBoolean(picPuLvl1.Tag)) buttonNext.Visible = false;
                        else buttonNext.Visible = true;
                    }
                    break;
                case 1:
                    {
                        Negation neg = new Negation(picNotLvl2, picLineLvl21, picLineLvl22);
                        picPuLvl2.Image = GetLamp(((ImageInfo)picLineLvl22.Tag).State);
                        picPuLvl2.Tag = !((ImageInfo)picLineLvl22.Tag).State;
                        if (Convert.ToBoolean(picPuLvl2.Tag)) buttonNext.Visible = false;
                        else buttonNext.Visible = true;
                    }
                    break;
                case 2:
                    {
                        Addition add = new Addition(picLineLvl31, picLineLvl32, picLineLvl33);
                        picPuLvl3.Image = GetLamp(((ImageInfo)picLineLvl33.Tag).State);
                        picPuLvl3.Tag = !((ImageInfo)picLineLvl33.Tag).State;
                        if (Convert.ToBoolean(picPuLvl3.Tag)) buttonNext.Visible = false;
                        else buttonNext.Visible = true;
                    }
                    break;
                case 3:
                    {
                        Multiply add = new Multiply(picLineLvl41, picLineLvl42, picLineLvl43);
                        picPuLvl4.Image = GetLamp(((ImageInfo)picLineLvl43.Tag).State);
                        picPuLvl4.Tag = !((ImageInfo)picLineLvl43.Tag).State;
                        if (Convert.ToBoolean(picPuLvl4.Tag)) buttonNext.Visible = false;
                        else buttonNext.Visible = true;
                    }
                    break;
                case 4:
                    {
                        Multiply add = new Multiply(picLineLvl51, picLineLvl52, picLineLvl53);
                        

                        ImageInfo imgLeftInfo = (ImageInfo)picLineLvl53.Tag;
                        ImageInfo imgRightInfo = (ImageInfo)picLineLvl54.Tag;

                        bool input = imgLeftInfo.State;

                        if (input)
                        {
                            picLineLvl53.Image = imgLeftInfo.Green;
                            picLineLvl54.Image = imgRightInfo.Black;
                            picNotLvl51.Image = Properties.Resources.NotRedDown;

                            imgRightInfo.State = false;
                            picLineLvl54.Tag = imgRightInfo;
                        }
                        else
                        {
                            picLineLvl53.Image = imgLeftInfo.Black;
                            picLineLvl54.Image = imgRightInfo.Green;
                            picNotLvl51.Image = Properties.Resources.NotGreenDown;

                            imgRightInfo.State = true;
                            picLineLvl54.Tag = imgRightInfo;
                        }
                        //Negation neg1 = new Negation(picNotLvl51, picLineLvl53, picLineLvl54);
                        Negation neg2 = new Negation(picNotLvl52, picLineLvl54, picLineLvl55);
                        Negation neg3 = new Negation(picNotLvl53, picLineLvl54, picLineLvl56);

                        picPuLvl51.Image = GetLamp(((ImageInfo)picLineLvl53.Tag).State);
                        picPuLvl51.Tag = !((ImageInfo)picLineLvl53.Tag).State;
                        if (Convert.ToBoolean(picPuLvl51.Tag)) buttonNext.Visible = false;
                        else buttonNext.Visible = true;

                        picPuLvl52.Image = GetLamp(((ImageInfo)picLineLvl55.Tag).State);
                        picPuLvl52.Tag = !((ImageInfo)picLineLvl55.Tag).State;
                        if (Convert.ToBoolean(picPuLvl52.Tag)) buttonNext.Visible = false;
                        else buttonNext.Visible = true;

                        picPuLvl53.Image = GetLamp(((ImageInfo)picLineLvl56.Tag).State);
                        picPuLvl53.Tag = !((ImageInfo)picLineLvl56.Tag).State;
                        if (Convert.ToBoolean(picPuLvl53.Tag)) buttonNext.Visible = false;
                        else buttonNext.Visible = true;

                    }
                    break;
                case 5:
                    {
                        Negation neg1 = new Negation(picNotLvl61, picLineLvl61, picLineLvl62);
                        Negation neg2 = new Negation(picNotLvl62, picLineLvl67, picLineLvl68);
                        Negation neg3 = new Negation(picNotLvl63, picLineLvl65, picLineLvl66);
                        Addition add1 = new Addition(picLineLvl62, picLineLvl63, picLineLvl64);
                        Addition add2 = new Addition(picLineLvl64, picLineLvl66, picLineLvl67);

                        picPuLvl6.Image = GetLamp(((ImageInfo)picLineLvl68.Tag).State);
                        picPuLvl6.Tag = !((ImageInfo)picLineLvl68.Tag).State;

                        if (Convert.ToBoolean(picPuLvl6.Tag))
                        {
                            button1.Visible = false;
                            
                        }
                        else
                        {  button1.Visible = true;
                            //FormResult frm5 = new FormResult();
                            //frm5.Res = 3;
                            //frm5.Show();
                            //this.Hide();
                        }
                    }
                    break;
            }
            
        }

        private void PicPowLvl1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl1.Tag))
            {
                picPowLvl1.Image = Properties.Resources.ButtonOn;
                picLineLvl1.Image = Properties.Resources.Line_green;
                picPuLvl1.Image = Properties.Resources.LampOn;
                picPowLvl1.Tag = false;
                picPuLvl1.Tag = false;
            }
            else
            {
                picPowLvl1.Image = Properties.Resources.ButtonOff;
                picLineLvl1.Image = Properties.Resources.Line_black;
                picPuLvl1.Image = Properties.Resources.LampOff;
                picPowLvl1.Tag = true;
                picPuLvl1.Tag = true;
            }
        }
        private object SetState(PictureBox pic)
        {
            ImageInfo imageInfo = (ImageInfo)pic.Tag;
            if (imageInfo.State)
            {
                imageInfo.State = false;
            }
            else
            {
                imageInfo.State = true;
            }

            return imageInfo;
        }

        private Image GetLamp(bool state)
        {
            if (state)
            {
                return Properties.Resources.LampOn;
            }
            else
            {
                return Properties.Resources.LampOff;
            }
        }
        public void HeartCat(int picture)
        {
            switch (picture)
            {
                case 3: pictureBoxHearts.Image = Properties.Resources.Hearts3; pictureBoxCat.Image = Properties.Resources.Kitten; break;
                case 2: pictureBoxHearts.Image = Properties.Resources.Hearts2; pictureBoxCat.Image = Properties.Resources.Kitten2; break;
                case 1: pictureBoxHearts.Image = Properties.Resources.Hearts1; pictureBoxCat.Image = Properties.Resources.Kitten3; break;
                case 0:
                    FormResult frm5 = new FormResult();
                    frm5.Res = 0;
                    frm5.Show();
                    this.Hide();
                    break;
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            panels[CountPanels].Visible = false;
            
            CountPanels++;
            panels[CountPanels].Location = new Point(263, 25);
            panels[CountPanels].Size = new Size(600, 470);
            panels[CountPanels].Visible = true;
            buttonNext.Visible = false;
        }

        private void PicPowLvl2_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl2.Tag))
            {
                picPowLvl2.Image = Properties.Resources.ButtonOff;
                picPowLvl2.Tag = false;
            }
            else
            {
                picPowLvl2.Image = Properties.Resources.ButtonOn;
                picPowLvl2.Tag = true;
            }

            picLineLvl21.Tag = SetState(picLineLvl21);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void PicPowLvl31_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl31.Tag))
            {
                picPowLvl31.Image = Properties.Resources.ButtonOn;
                picPowLvl31.Tag = false;
            }
            else
            {
                picPowLvl31.Image = Properties.Resources.ButtonOff;
                picPowLvl31.Tag = true;
            }

            picLineLvl31.Tag = SetState(picLineLvl31);
        }

        private void PicPowLvl32_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl32.Tag))
            {
                picPowLvl32.Image = Properties.Resources.ButtonOn;
                picPowLvl32.Tag = false;
            }
            else
            {
                picPowLvl32.Image = Properties.Resources.ButtonOff;
                picPowLvl32.Tag = true;
            }

            picLineLvl32.Tag = SetState(picLineLvl32);
        }

        private void PicPowLvl41_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl41.Tag))
            {
                picPowLvl41.Image = Properties.Resources.ButtonOn;
                picPowLvl41.Tag = false;
            }
            else
            {
                picPowLvl41.Image = Properties.Resources.ButtonOff;
                picPowLvl41.Tag = true;
            }

            picLineLvl41.Tag = SetState(picLineLvl41);
        }

        private void PicPowLvl42_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl42.Tag))
            {
                picPowLvl42.Image = Properties.Resources.ButtonOn;
                picPowLvl42.Tag = false;
            }
            else
            {
                picPowLvl42.Image = Properties.Resources.ButtonOff;
                picPowLvl42.Tag = true;
            }

            picLineLvl42.Tag = SetState(picLineLvl42);
        }

        private void PicPowLvl51_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl51.Tag))
            {
                picPowLvl51.Image = Properties.Resources.ButtonOn;
                picPowLvl51.Tag = false;
            }
            else
            {
                picPowLvl51.Image = Properties.Resources.ButtonOff;
                picPowLvl51.Tag = true;
            }

            picLineLvl51.Tag = SetState(picLineLvl51);
        }

        private void PicPowLvl52_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl52.Tag))
            {
                picPowLvl52.Image = Properties.Resources.ButtonOn;
                picPowLvl52.Tag = false;
            }
            else
            {
                picPowLvl52.Image = Properties.Resources.ButtonOff;
                picPowLvl52.Tag = true;
            }

            picLineLvl52.Tag = SetState(picLineLvl52);
        }

        private void PicPowLvl61_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl61.Tag))
            {
                picPowLvl61.Image = Properties.Resources.ButtonOn;
                picPowLvl61.Tag = false;
            }
            else
            {
                picPowLvl61.Image = Properties.Resources.ButtonOff;
                picPowLvl61.Tag = true;
            }

            picLineLvl61.Tag = SetState(picLineLvl61);
        }

        private void PicPowLvl62_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl62.Tag))
            {
                picPowLvl62.Image = Properties.Resources.ButtonOn;
                picPowLvl62.Tag = false;
            }
            else
            {
                picPowLvl62.Image = Properties.Resources.ButtonOff;
                picPowLvl62.Tag = true;
            }

            picLineLvl63.Tag = SetState(picLineLvl63);
        }

        private void PicPowLvl63_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(picPowLvl63.Tag))
            {
                picPowLvl63.Image = Properties.Resources.ButtonOff;
                picPowLvl63.Tag = false;
            }
            else
            {
                picPowLvl63.Image = Properties.Resources.ButtonOn;
                picPowLvl63.Tag = true;
            }

            picLineLvl65.Tag = SetState(picLineLvl65);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FormLogic form = new FormLogic();
            //form.Show();
            //Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void InitalizePic()
        {
            //picLineLvl1.Tag = new ImageInfo{ Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
            picLineLvl21.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = true };
            picLineLvl22.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };

            picLineLvl31.Tag = new ImageInfo { Black = Properties.Resources.LineG_black, Green = Properties.Resources.LineG_Green, State = false };
            picLineLvl32.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = false };
            picLineLvl33.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };

            picLineLvl41.Tag = new ImageInfo { Black = Properties.Resources.LineG_black, Green = Properties.Resources.LineG_Green, State = false };
            picLineLvl42.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = false };
            picLineLvl43.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };

            picLineLvl51.Tag = new ImageInfo { Black = Properties.Resources.LineG_black, Green = Properties.Resources.LineG_Green, State = false };
            picLineLvl52.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = false };
            picLineLvl53.Tag = new ImageInfo { Black = Properties.Resources._5lvl_1lamp_black, Green = Properties.Resources._5lvl_1lamp_green, State = false };
            picLineLvl54.Tag = new ImageInfo { Black = Properties.Resources._5lvl_3btn_black, Green = Properties.Resources._5lvl_3btn_green, State = true };
            picLineLvl55.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = true };
            picLineLvl56.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };


            picLineLvl61.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
            picLineLvl62.Tag = new ImageInfo { Black = Properties.Resources.LineG_black, Green = Properties.Resources.LineG_Green, State = false };
            picLineLvl63.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = false };
            picLineLvl64.Tag = new ImageInfo { Black = Properties.Resources.LineG_black, Green = Properties.Resources.LineG_Green, State = false };
            picLineLvl65.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
            picLineLvl66.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = false };
            picLineLvl67.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
            picLineLvl68.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
        }
    }


    public class Negation
    {
        public Negation(PictureBox picture, PictureBox left, PictureBox right)
        {
            Picture = picture;
            PicLeft = left;
            PicRight = right;
            ImageInfo imgLeftInfo = (ImageInfo)PicLeft.Tag;
            ImageInfo imgRightInfo = (ImageInfo)PicRight.Tag;

            input = imgLeftInfo.State;

            if (input)
            {
                PicLeft.Image = imgLeftInfo.Green;
                PicRight.Image = imgRightInfo.Black;
                picture.Image = Properties.Resources.NotRed;

                imgRightInfo.State = false;
                PicRight.Tag = imgRightInfo;
            }
            else
            {
                PicLeft.Image = imgLeftInfo.Black;
                PicRight.Image = imgRightInfo.Green;
                picture.Image = Properties.Resources.NotGreen;

                imgRightInfo.State = true;
                PicRight.Tag = imgRightInfo;
            }
        }

        bool input;

        public PictureBox PicLeft;
        public PictureBox PicRight;

        public PictureBox Picture;
    }

    public class Multiply
    {
        public Multiply(PictureBox picIn1, PictureBox picIn2, PictureBox picOut)
        {
            PicIn1 = picIn1;
            PicIn2 = picIn2;
            PicOut = picOut;
            ImageInfo imgIn1Info = (ImageInfo)PicIn1.Tag;
            ImageInfo imgIn2Info = (ImageInfo)PicIn2.Tag;
            ImageInfo imgOutInfo = (ImageInfo)PicOut.Tag;

            input1 = imgIn1Info.State;
            input2 = imgIn2Info.State;

            if (input1)
            {
                PicIn1.Image = imgIn1Info.Green;
            }
            else
            {
                PicIn1.Image = imgIn1Info.Black;
            }

            if (input2)
            {
                PicIn2.Image = imgIn2Info.Green;
            }
            else
            {
                PicIn2.Image = imgIn2Info.Black;
            }

            if (input1 && input2)
            {
                PicOut.Image = imgOutInfo.Green;

                imgOutInfo.State = true;
                PicOut.Tag = imgOutInfo;
            }
            else
            {
                PicOut.Image = imgOutInfo.Black;

                imgOutInfo.State = false;
                PicOut.Tag = imgOutInfo;
            }
        }

        bool input1, input2;

        public PictureBox PicIn1;
        public PictureBox PicIn2;
        public PictureBox PicOut;
    }

    public class Addition
    {
        public Addition(PictureBox picIn1, PictureBox picIn2, PictureBox picOut)
        {
            PicIn1 = picIn1;
            PicIn2 = picIn2;
            PicOut = picOut;
            ImageInfo imgIn1Info = (ImageInfo)PicIn1.Tag;
            ImageInfo imgIn2Info = (ImageInfo)PicIn2.Tag;
            ImageInfo imgOutInfo = (ImageInfo)PicOut.Tag;

            input1 = imgIn1Info.State;
            input2 = imgIn2Info.State;

            if (input1)
            {
                PicIn1.Image = imgIn1Info.Green;
            }
            else
            {
                PicIn1.Image = imgIn1Info.Black;
            }

            if (input2)
            {
                PicIn2.Image = imgIn2Info.Green;
            }
            else
            {
                PicIn2.Image = imgIn2Info.Black;
            }

            if (input1 || input2)
            {
                PicOut.Image = imgOutInfo.Green;

                imgOutInfo.State = true;
                PicOut.Tag = imgOutInfo;
            }
            else
            {
                PicOut.Image = imgOutInfo.Black;

                imgOutInfo.State = false;
                PicOut.Tag = imgOutInfo;
            }
        }

        bool input1, input2;

        public PictureBox PicIn1;
        public PictureBox PicIn2;
        public PictureBox PicOut;
    }
}
