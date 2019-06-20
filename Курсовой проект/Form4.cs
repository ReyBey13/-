using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовой_проект
{
    // структура для хранения информации о линии
    // без неё всё это было бы невозможно, так как инфрмация для каждой из линий записывается в свойство Tag
    // а Tag может включать в себя только один обьект, потому три переменные:
    // состояние линии и две ссылки на ресурсы с черной и зеленой картинкой записываются структурой
    // вся инициализации и запись структур для картинок происходит в отдельном методе, вызываемом при загрузке формы
    public struct ImageInfo
    {
        public bool State;
        public Image Green;
        public Image Black;
    }

    public partial class FormGame : Form
    {
        int HC = 3;// жизни

        int s = 0;// таймер
        int m = 0;// таймер

        bool gameType;// режим игры

        int CountPanels = 0;                       // счетчик панелей для выхода и для справочника
        List<Panel> panels = new List<Panel>();    // список панелей(один для обоих режимов)

        Bitmap[] spravka = new Bitmap[4];          // основной массив картинок для справочника
        List<Bitmap> listB = new List<Bitmap>();   // список для работы со справочником

        // конструктор игровой формы
        // аргумент - режим, с которым запускается формы
        public FormGame(bool type)
        {
            InitializeComponent();

            // присваиваем переменной типа режима значение из аргумента конструктора
            // так как переменная нужна и в других функциях, а аргумент доступен только внутри конструктора
            gameType = type;

            // проверка на режим
            // true - тренировка
            // false - обычный
            if (gameType)
            {
                // вызов функции инициализации всех линий, создание для них обьектов структуры ImageInfo
                InitalizePic();

                // скрытие таймера и сердец
                labelMin.Visible = false;
                labelPoints.Visible = false;
                labelSec.Visible = false;
                pictureBoxHearts.Visible = false;

                // добавление всех панелей в список, для показа во время игры
                panels.Add(panellvl1);
                panels.Add(panelLvl2);
                panels.Add(panelLvl3);
                panels.Add(panelLvl4);
                panels.Add(panelLvl6);
                panels.Add(panelLvl5);

                // запуск таймера для работы блоков отрицания, И и ИЛИ
                timerCheck.Start();

                // добавление в основной массив картинок справочника
                spravka[1] = Properties.Resources.NotGif;
                spravka[2] = Properties.Resources.OrGif;
                spravka[3] = Properties.Resources.AndGif;
            }
            else
            {
                // обычный режим
                // просто добавляем панели в список и делаем видимой кнопку проверки
                panels.Add(panelLvl11);
                panels.Add(panelLvl22);
                panels.Add(panelLvl33);
                panels.Add(panelLvl44);
                panels.Add(panelLvl55);
                panels.Add(panelLvl66);
                panels.Add(panelLvl77);
                buttonProv.Visible = true;
            }
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
            FormLogic form = new FormLogic();
            form.Show();
            Hide();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            // после загрузки раскрываем панель первого уроня и делаем видимой
            pictureBoxHearts.Image = Properties.Resources.Hearts3;
            panels[CountPanels].Location = new Point(263, 25);
            panels[CountPanels].Size = new Size(600, 470);
            panels[CountPanels].Visible = true;

            // остановка времени
            timerGame.Stop();
        }

        private void FormGame_Shown(object sender, EventArgs e)
        {
            // показ вводной формы с текстом при запуске формы в обычном режиме
            if (!gameType)
            {
                string show = "Раз ты попал сюда - это значит, что уже готов к настоящим заданиям. " +
                              "Здесь всё немного сложнее, но не менее интересно. Все задачи выполняются на выключенных блоках, поэтому ты не будешь видеть, как твои действия " +
                              "влияют на работу, пока не решишься проверить, как ты справился. " +
                              "И да, ошибки здесь не прощаются, поэтому количество попыток ограничено; если кончатся - всё для тебя закончится. " +
                              "Также напоминаю, что время работает против нас, а потому постарайся сделать всё как можно быстрее. " +
                              "Теперь у тебя есть таймер для отслеживания потраченного времени. " +
                              "Вот, теперь ты точно готов - можешь приступать.";

                // создание формы и метки
                Form formInfo = new Form
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Size = new Size(450, 320),
                    BackgroundImage = Properties.Resources.Result,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Text = "Обрати внимание",
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    Icon = Properties.Resources.iconGame,
                };
                Label labelInfo = new Label
                {
                    Location = new Point(15, -20),
                    AutoSize = false,
                    Size = new Size(410, 310),
                    Text = show,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Comic Sans MS", 10),
                    BackColor = Color.Transparent,

                };

                // добавление метки на панель
                formInfo.Controls.Add(labelInfo);

                // показ в режиме диалога - с главной формой нельзя взаимодействовать, пока не закроешь форму диалога
                formInfo.ShowDialog();

                // после закрытия вводной формы начинаем считать врем игры
                timerGame.Start();
            }
        }

        // тик таймера тренировки
        // выполняет всю работу логических блоков и ламп
        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            // переключатель по уровням(панелям)
            // однотипны и отличаются только элементами
            switch (CountPanels)
            {
                case 0:
                    {
                        // получаем тэг картинки и превращаем в структуру
                        ImageInfo info = (ImageInfo)picLineLvl1.Tag;

                        // проверяем состояние линии и меняем картинку в зависимости от состояния
                        picLineLvl1.Image = info.State ? info.Green : info.Black;

                        // меняем картинку котачу функцией смены лампы
                        // меняем на основании состояния линии:
                        // если истинна - лампа горит и наоборот
                        picPuLvl1.Image = GetLamp(info.State);

                        // присваиваем в тэг котачу обратное состояние линии - это такой костыль, так везде
                        picPuLvl1.Tag = !info.State;

                        // проверяем, показывать ли кнопку следующего уровня в зависимости от тэга котачу
                        if (Convert.ToBoolean(picPuLvl1.Tag))
                            buttonNext.Visible = false;
                        else
                            buttonNext.Visible = true;
                    }
                    break;
                case 1:
                    {
                        // на втором уровне уже появляется отрицание
                        // поэтому каждый тик создаем экземпляр класса отрицания, который будет менять состояния и цвета линий около него
                        // последовательно пишем в аргументы линии, подробнее о работе смотри внизу
                        Negation(picNotLvl2, picLineLvl21, picLineLvl22);

                        // меняем цвет и тэг котачу на основаниии входящей в него линии
                        picPuLvl2.Image = GetLamp(((ImageInfo)picLineLvl22.Tag).State);
                        picPuLvl2.Tag = !((ImageInfo)picLineLvl22.Tag).State;

                        // работа с кнопкой уровня
                        if (Convert.ToBoolean(picPuLvl2.Tag))
                            buttonNext.Visible = false;
                        else
                            buttonNext.Visible = true;
                    }
                    break;
                case 2:
                    {
                        // появление ИЛИ
                        // в общем-то ничего сложного, класс делает сам все, нужно только правильно указать входные-выходные линии
                        Addition(picLineLvl31, picLineLvl32, picLineLvl33);

                        // меняем цвет и тэг котачу
                        picPuLvl3.Image = GetLamp(((ImageInfo)picLineLvl33.Tag).State);
                        picPuLvl3.Tag = !((ImageInfo)picLineLvl33.Tag).State;

                        // кнопка уровня
                        if (Convert.ToBoolean(picPuLvl3.Tag))
                            buttonNext.Visible = false;
                        else
                            buttonNext.Visible = true;
                    }
                    break;
                case 3:
                    {
                        // блок И
                        Multiply(picLineLvl41, picLineLvl42, picLineLvl43);

                        // изменение цвета и тэга котачу
                        picPuLvl4.Image = GetLamp(((ImageInfo)picLineLvl43.Tag).State);
                        picPuLvl4.Tag = !((ImageInfo)picLineLvl43.Tag).State;

                        // кнопка уровня
                        if (Convert.ToBoolean(picPuLvl4.Tag))
                            buttonNext.Visible = false;
                        else
                            buttonNext.Visible = true;
                    }
                    break;
                case 4:
                    {
                        // опять же ничего нового, только блоков больше
                        Negation(picNotLvl61, picLineLvl61, picLineLvl62);
                        Negation(picNotLvl62, picLineLvl67, picLineLvl68);
                        Negation(picNotLvl63, picLineLvl65, picLineLvl66);
                        Addition(picLineLvl62, picLineLvl63, picLineLvl64);
                        Addition(picLineLvl64, picLineLvl66, picLineLvl67);

                        // котачу
                        picPuLvl6.Image = GetLamp(((ImageInfo)picLineLvl68.Tag).State);
                        picPuLvl6.Tag = !((ImageInfo)picLineLvl68.Tag).State;

                        // кнопка уровня
                        if (Convert.ToBoolean(picPuLvl6.Tag))
                            buttonNext.Visible = false;
                        else
                            buttonNext.Visible = true;

                    }
                    break;
                case 5:
                    {
                        // начало не предвещает беды
                        Multiply(picLineLvl51, picLineLvl52, picLineLvl53);
                        Addition(picLineLvl54, picLineLvl57, picLineLvl58);

                        // даров, это шляпа
                        // просто здесь нельзя пользоваться обычным классом, так как картинка другая(смотрящая вниз)
                        // также как и всегда получаем информацию о линиях около отрицания
                        ImageInfo imgLeftInfo = (ImageInfo)picLineLvl53.Tag;
                        ImageInfo imgRightInfo = (ImageInfo)picLineLvl54.Tag;

                        // состояние входной линии
                        bool input = imgLeftInfo.State;

                        // условие и смена тэгов, подробнее можешь посмотреть в описании класса отрицания
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

                        // а эти отрицания уже обычные
                        Negation(picNotLvl52, picLineLvl58, picLineLvl55);
                        Negation(picNotLvl53, picLineLvl58, picLineLvl56);

                        // работа со всеми котачу
                        picPuLvl51.Image = GetLamp(((ImageInfo)picLineLvl53.Tag).State);
                        picPuLvl51.Tag = !((ImageInfo)picLineLvl53.Tag).State;

                        picPuLvl52.Image = GetLamp(((ImageInfo)picLineLvl55.Tag).State);
                        picPuLvl52.Tag = !((ImageInfo)picLineLvl55.Tag).State;

                        picPuLvl53.Image = GetLamp(((ImageInfo)picLineLvl56.Tag).State);
                        picPuLvl53.Tag = !((ImageInfo)picLineLvl56.Tag).State;

                        if (Convert.ToBoolean(picPuLvl53.Tag) && Convert.ToBoolean(picPuLvl52.Tag) && Convert.ToBoolean(picPuLvl51.Tag))
                            buttonNext.Visible = false;
                        else
                            buttonNext.Visible = true;
                    }
                    break;
            }

        }


        // функция для установки состояния у линии, передаваемой в аргумент
        private object SetState(PictureBox pic)
        {
            // создание экземпляра ImageInfo из тэга полученной картинки
            ImageInfo imageInfo = (ImageInfo)pic.Tag;

            // проверка состояния линии через поле экземпляра и его изменение
            if (imageInfo.State)
            {
                imageInfo.State = false;
            }
            else
            {
                imageInfo.State = true;
            }

            // возврат экземпляра
            // функция используется сразу для присвоения тэга картинки по виду "картинка.Tag = SetState(картинка)"
            return imageInfo;
        }

        // функция получения лампы
        private Image GetLamp(bool state)
        {
            // если входная переменная истинна, то возвращаем включенную и наоборот
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

        private void ButtonProv_Click(object sender, EventArgs e)
        {

        }

        // переходы на следующий уровень в тренировке и в обычном режимах
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            // скрываем текущую панель
            panels[CountPanels].Visible = false;

            // проверка на режим
            if (gameType)
            {
                // если тренировка

                // увеличиваем счетчик
                CountPanels++;

                // скрываем кнопку следующего хода
                buttonNext.Visible = false;

                // если у нас уровень 0, 1, 2, 3, то добавляем в список элементы спавки каждый ход
                if (CountPanels <= 3)
                {
                    // делаем видимой кнопку справки
                    buttonSprav.Visible = true;

                    // добавляем в список элемент из массива по номеру уровня
                    listB.Add(spravka[CountPanels]);
                }

                // если мы нажали кнопку на последнем уровне, то выходим на форму результата
                if (CountPanels == 6)
                {
                    // переход на результат
                    FormResult form = new FormResult();
                    form.Res = 2;
                    form.Show();
                    Close();

                    // выход из функции для того, чтобы не обрабатывать строчки ниже(убери и увидишь ошибку на последнем уровне)
                    return;
                }
            }
            else
            {
                // если обычный режим


                // вызов функции для проверки, правильно ли выбраны кнопки и котачу
                if (CheckQuest(CountPanels) == 0)
                {
                    // если неправильно, то снимаем жизни
                    HC--;
                    HeartCat(HC);
                }

                // увеличение счетчика уровней
                CountPanels++;


                // если на последнем, идем на форму результата
                if (CountPanels == 7)
                {
                    // переход
                    FormResult form = new FormResult();
                    form.Res = 1;

                    // так как режим обычный, передать нужно еще сердца и время
                    form.m = int.Parse(labelMin.Text);
                    form.s = int.Parse(labelSec.Text);
                    form.HCRes = HC;
                    form.Show();
                    Close();

                    // выход из функции для того, чтобы не обрабатывать строчки ниже(убери и увидишь ошибку на последнем уровне)
                    return;
                }
            }

            // после увеличение счетчика выше, в любом из режимов, показываем панель следующего уровня
            panels[CountPanels].Location = new Point(263, 25);
            panels[CountPanels].Size = new Size(600, 470);
            panels[CountPanels].Visible = true;
        }

        // функция проверки правильности сделанных схем в обыном режиме
        // получает номер уровня, сверяет правильные свойства со свойствами, установленными кликами пользователя
        // возвращает 1 при правильном ответе и 0 при ложном
        int CheckQuest(int option)
        {
            switch (option)
            {
                case 0:
                    {
                        if (picPuLvl11.Tag.ToString() == "1") return 1;
                    }
                    break;
                case 1:
                    {
                        if (picPuLvl221.Tag.ToString() == "1" && picPuLvl222.Tag.ToString() == "0") return 1;
                    }
                    break;
                case 2:
                    {
                        if (picPuLvl331.Tag.ToString() == "1" && picPuLvl333.Tag.ToString() == "1" && picPuLvl332.Tag.ToString() == "0") return 1;
                    }
                    break;
                case 3:
                    {
                        if (picPowLvl441.Tag.ToString() == "1" && picPowLvl442.Tag.ToString() == "0") return 1;
                    }
                    break;
                case 4:
                    {
                        if (picPuLvl552.Tag.ToString() == "1" && picPuLvl553.Tag.ToString() == "1" && picPuLvl554.Tag.ToString() == "1" && picPuLvl551.Tag.ToString() == "0") return 1;
                    }
                    break;
                case 5:
                    {
                        if (picPowLvl661.Tag.ToString() == "0" && picPowLvl662.Tag.ToString() == "0" && picPowLvl663.Tag.ToString() == "1") return 1;
                    }
                    break;
                case 6:
                    {
                        if (picPuLvl552.Tag.ToString() == "1" && picPuLvl553.Tag.ToString() == "1" && picPuLvl554.Tag.ToString() == "1" && picPuLvl551.Tag.ToString() == "0") return 1;
                    }
                    break;
            }

            return 0;
        }

        // функция для обработки нажатий на кнопки в тренировке
        // отличий от других нажатий почти нет
        private void Pic_Click(object sender, EventArgs e)
        {
            // инициализируем картинку по нашему обьекту
            PictureBox box = sender as PictureBox;

            // создаем логическую переменную по нашему тэгу
            bool end = bool.Parse(box.Tag.ToString());

            // классическое условие для проверки значения тэга и смене цвета
            if (end)
            {
                box.Image = Properties.Resources.ButtonOff;
                box.Tag = false;
            }
            else
            {
                box.Image = Properties.Resources.ButtonOn;
                box.Tag = true;

            }

            // создание экземляра прилегающей картинки(линии) при помощи вызова функции GetLine
            PictureBox pic = GetLine(sender);

            // изменение значения и цвета найденной линии функцией SetState
            pic.Tag = SetState(pic);
        }

        // величайшая функция(нет)
        // просто хорошая оптимизаци, хорошо изучи каждую её строчку
        // все названия дословны и переводятся по смыслу
        // функция для поиска и возврата прилежащей картинки
        // работает только в случае нахождения искомой картинки на уровне или над известной картинкой
        private PictureBox GetLine(object sender)
        {
            // полученный аргумент(обьект) превращаем в картинку
            PictureBox input = sender as PictureBox;

            // выходная картинка, пока что равная входной
            PictureBox output = input;

            // получаем "родителя" входной картинки
            // то бишь узнаем панель, на которой лежат наши две картинки
            Panel parent = input.Parent as Panel;

            // создание экземпляра четырехугольника по координатам и размеру входной картинки
            // четырехугольники необходимы, так как только в этом классе(Rectangle) есть нужный метод на проверку пересечения обьектов
            Rectangle rect1 = new Rectangle(input.Location, input.Size);

            // цикл, проходящий по каждому из элементов панели-родителя для поиска нужной картинки
            // массив обьектов parent.Controls - это все обьекты, лежащие на панели, где-то там нужный нам
            foreach (object piece in parent.Controls)
            {
                // попытка превратить обьект в картинку
                // специально, чтобы не хватать метки или ещё что-нибудь мешающее
                // при ошибке не произойдет ничего, цикл просто продолжит перебор
                try
                {
                    // превращение элемента в картинку
                    PictureBox box = piece as PictureBox;

                    // создание четырехугольника уже по расположению и размерам только что созданной картинки строкой выше
                    Rectangle rect2 = new Rectangle(box.Location, box.Size);

                    // проверка, пересекается ли четырехугольник первой картинки с четырехугольником второй
                    if (rect2.IntersectsWith(rect1))
                    {
                        // если пересекаются, то созданная тут картинка присваивается выходной переменной и цикл останавливается, т.к. всё нашли
                        output = box;
                        break;
                    }
                }
                catch { }
            }

            // после нахождения прилежащей картинки возвращаем её
            // поэтому функция используется в виде "прилежащая линия = GetLine(обьект входной картинки)"
            return output;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FormResult form = new FormResult();
        //    form.Res = 2;
        //    form.Show();
        //    Close();
        //}


        // выглядит величественно, страшно и вообще ужасно, если честно
        // скажи это кроту, он тоже на фоне прекрасной природы не очень-то и красив
        // в общем это функция инициализации всех линий на уровнях тренировки
        // запись в тэг каждой нужно линии на уровнях обьекта ImageInfo, с указанием картинок, которые должны меняться и состояния на начало игры
        // всё по порядку, абзац на уровень
        private void InitalizePic()
        {
            picLineLvl1.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };

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
            picLineLvl54.Tag = new ImageInfo { Black = Properties.Resources.Line_Vertical_black, Green = Properties.Resources.Line_Vertical_green, State = true };
            picLineLvl55.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = true };
            picLineLvl56.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
            picLineLvl57.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = true };
            picLineLvl58.Tag = new ImageInfo { Black = Properties.Resources.Line_black_lvl5, Green = Properties.Resources.Line_green_lvl5, State = true };

            picLineLvl61.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
            picLineLvl62.Tag = new ImageInfo { Black = Properties.Resources.LineG_black, Green = Properties.Resources.LineG_Green, State = false };
            picLineLvl63.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = false };
            picLineLvl64.Tag = new ImageInfo { Black = Properties.Resources.LineG_black, Green = Properties.Resources.LineG_Green, State = false };
            picLineLvl65.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
            picLineLvl66.Tag = new ImageInfo { Black = Properties.Resources.LineGN_Black, Green = Properties.Resources.LineGN_Green, State = false };
            picLineLvl67.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = true };
            picLineLvl68.Tag = new ImageInfo { Black = Properties.Resources.Line_black, Green = Properties.Resources.Line_green, State = false };
        }

        // функция для смены картинок у кнопок энергии в обычном режиме
        private void PicPow_Click(object sender, EventArgs e)
        {
            // каждая кнопка питания, с которой нам необходимо взаимодействовать, имеет цифру в свойстве Tag
            // 1 - включена
            // 0 - выключена

            // создание экземпляра картинки по обьекту, который получаем в аргумент(sender) 
            PictureBox pic = sender as PictureBox;

            // классическая проверка: если текст в тэге равен нулю, "включаем" кнопку, то бишь меняем ее цвет и цифру в тэге
            if (pic.Tag.ToString() == "0")
            {
                pic.Tag = 1;
                pic.Image = Properties.Resources.ButtonOn;
            }
            else
            {
                // если же кнопка с 1 в тэге, значит уже включена, нам нужно ее выключить и положить в тэг 0
                pic.Tag = 0;
                pic.Image = Properties.Resources.ButtonOff;
            }
        }

        // функция для смены картинок у котачу
        // работает также, как предыдущая функция, абсолютно
        // разница только в картинках
        private void Pu_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Tag.ToString() == "0")
            {
                pic.Tag = 1;
                pic.Image = Properties.Resources.LampOn;
            }
            else
            {
                pic.Tag = 0;
                pic.Image = Properties.Resources.LampOff;
            }
        }

        private void buttonSprav_Click(object sender, EventArgs e)
        {
            Sprav();
        }

        // функция вызова справочника(ну или что там будет) в тренировке
        public void Sprav()
        {

            int count;

            // проверка условия
            // показываем индивидуальную справку только для первого, второго и третьего уровней
            if (CountPanels > 0 && CountPanels <= 3)
            {
                // отнимаем единицу, т.к. массив картинок начинается с нуля, значит на единицу меньше нашего счетчика панелей
                count = CountPanels - 1;
            }
            else
            {
                // если мы находимся на панелях 4, 5, 6, то справка появляется с самого начала
                count = 0;
            }

            // создание формы
            Form FormSprav = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Size = listB[count].Size, // размер устанавливаем в соответствии с уровнем справочника(подгоняем под картинку)
                BackgroundImage = Properties.Resources.Regul,
                BackgroundImageLayout = ImageLayout.Stretch,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
            };

            // картинку берем из списка
            PictureBox picPusheen = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = listB[count],
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
            };

            // кнопка переходом по справочнику
            Button btn = new Button
            {
                Size = new Size(20, 20),
                Text = ">>",
            };

            // добавляем на форму картинку и кнопку
            FormSprav.Controls.Add(picPusheen);
            FormSprav.Controls.Add(btn);

            // установка положения кнопки в рависимости от размеров формы
            btn.Location = new Point(2, btn.Parent.Height - 60);

            // перемещаем кнопку наверх, чтобы она было над картинкой
            btn.BringToFront();

            // добавление события для нажатия по кнопке переключения
            btn.Click += buttClick;

            // функция нажатия
            void buttClick(object sender, EventArgs e)
            {
                // увеличиваем счетчик
                count++;

                // если счетчик больше, чем количество картинок в списке
                if (count >= listB.Count)
                {
                    // обнуляем счетчик
                    count = 0;

                    // меняем размер формы под нулевую картинку
                    FormSprav.Size = listB[count].Size;

                    // картинку меняем на нулевую
                    picPusheen.Image = listB[count];
                }
                else
                {
                    // если же счетчик меньше, просто меняем размеры формы под картинку
                    FormSprav.Size = listB[count].Size;

                    // меняем картинку, берем из списка
                    picPusheen.Image = listB[count];
                }

                // не забываем перенести кнопку, так как размеры формы изменились
                btn.Location = new Point(2, btn.Parent.Height - 60);
            }

            // отображение формы справочника
            FormSprav.Show();
        }

        /// ЭТО НЕОБХОДИМО ИЗУЧИТЬ ВО ВТОРУЮ ОЧЕРЕДЬ, СРАЗУ ПОСЛЕ ИЗУЧЕНИЯ СТРУКТУРЫ ImageInfo
        /// ЭТО НЕОБХОДИМО ИЗУЧИТЬ ВО ВТОРУЮ ОЧЕРЕДЬ, СРАЗУ ПОСЛЕ ИЗУЧЕНИЯ СТРУКТУРЫ ImageInfo
        /// ЭТО НЕОБХОДИМО ИЗУЧИТЬ ВО ВТОРУЮ ОЧЕРЕДЬ, СРАЗУ ПОСЛЕ ИЗУЧЕНИЯ СТРУКТУРЫ ImageInfo

        // функции реализации работы блока отрицания,
        // остальные два блока основаны на нем
        // общая работа заключается в изменении состояний у линий
        // получает входную линию, и если истина, то меняется сам на красный и изменяет входную линию на зеленую, выходную - на черную
        // в случае, когда входная линия ложна, изменяется сам на зеленый, меняет входную линию на 

        // имеет три аргумента: картинку(красная или зеленая), линию на вход и линию на выход

        void Negation(PictureBox Picture, PictureBox PicLeft, PictureBox PicRight)
        {
            // создание экземпляров структуры информации о линиях, входной и выходной
            // эти структуры уже лежат в тэгах картинок, поэтому их оттуда и извлекаем
            ImageInfo imgLeftInfo = (ImageInfo)PicLeft.Tag;
            ImageInfo imgRightInfo = (ImageInfo)PicRight.Tag;
            // переменная состояния входной линии

            bool input;
            // получение состояния входной, то есть левой, линии
            // получение доступа к полям структуры прост - пишется название экземпляра и через точку - поле
            // в данном случае нам нужно поле State, хранящая истинность или ложность линии
            input = imgLeftInfo.State;

            // проверка истинности
            if (input)
            {
                // если истинна, то перекрашиваем линии и меняем состояния

                // этот кусок может выглядеть особенно сложным, но попробую объяснить
                // левая часть(до знака =) - это обращение к картинке левой линии, к свойству Image, отвечающую за изображение
                // правая часть(после знака =) - это обращение к экземпляру ImageInfo, который мы достали из тэга левой картинки, изображение берем из поля Green
                PicLeft.Image = imgLeftInfo.Green;

                // действия аналогичны предыдущим, только уже с выходной(правой) картинкой и изменение ее цвета на черный
                PicRight.Image = imgRightInfo.Black;

                // смена картинки самого блока отрицания
                Picture.Image = Properties.Resources.NotRed;

                // установка поля State в экземпляре ImageInfo для правой картинки на false
                imgRightInfo.State = false;

                // запись в тэг правой картинки экземпляр с уже измененным состоянием
                PicRight.Tag = imgRightInfo;
            }
            else
            {
                // в случае ложности входной линии делаем действия, полностью обратные тем, что делаем при истинности
                PicLeft.Image = imgLeftInfo.Black;
                PicRight.Image = imgRightInfo.Green;
                Picture.Image = Properties.Resources.NotGreen;

                imgRightInfo.State = true;
                PicRight.Tag = imgRightInfo;
            }
        }



        // функция для реализаци блока AND 
        // почти полная копия предыдущего
        // реализует обычную работу блока - проверяет две входные линии, если обе истинны - делает истиной и выходную, в ином случае делает ее ложной

        //получает три картинки - две входные и выходную
        void Multiply(PictureBox PicIn1, PictureBox PicIn2, PictureBox PicOut)
        {
            // создание экземпляров для тэгов каждой из линий
            ImageInfo imgIn1Info = (ImageInfo)PicIn1.Tag;
            ImageInfo imgIn2Info = (ImageInfo)PicIn2.Tag;
            ImageInfo imgOutInfo = (ImageInfo)PicOut.Tag;

            // переменные для записи состояний входных линий
            bool input1, input2;

            // входа уже два, поэтому и переменные две
            // состояния берем из входных линий
            input1 = imgIn1Info.State;
            input2 = imgIn2Info.State;

            // если первая входная истинна - присваиваем ей зеленую картинку, которую получили из ее экземпляра ImageInfo
            // иначе присваиваем ей черную картинку
            if (input1)
            {
                PicIn1.Image = imgIn1Info.Green;
            }
            else
            {
                PicIn1.Image = imgIn1Info.Black;
            }

            // работа с перекрашиванием второй входной картинки, аналогична первой выше
            if (input2)
            {
                PicIn2.Image = imgIn2Info.Green;
            }
            else
            {
                PicIn2.Image = imgIn2Info.Black;
            }

            // проверка истинности обеих входных линий
            if (input1 && input2)
            {
                // если истинна - перекрашиваем выходную линию
                PicOut.Image = imgOutInfo.Green;

                // меняем состояние линии сначала у экземпляра, а потом записываем экземпляр в тэг картинки, выше описывал чуть подробнее
                imgOutInfo.State = true;
                PicOut.Tag = imgOutInfo;
            }
            else
            {
                // в случае ложности делаем обратные действия
                PicOut.Image = imgOutInfo.Black;

                imgOutInfo.State = false;
                PicOut.Tag = imgOutInfo;
            }
        }


        // функция реализации блока OR
        // теперь уж точно копия предыдущего
        // линии три, две входные и одна выходная, проверяем, чтобы была истинна хотя бы одна из двух входных

        // получает три линии - две входные и одну выходную
        void Addition(PictureBox PicIn1, PictureBox PicIn2, PictureBox PicOut)
        {
            // создание экземпляров для каждой из линий
            ImageInfo imgIn1Info = (ImageInfo)PicIn1.Tag;
            ImageInfo imgIn2Info = (ImageInfo)PicIn2.Tag;
            ImageInfo imgOutInfo = (ImageInfo)PicOut.Tag;

            // переменные для работы состояний входных линий
            bool input1, input2;
            // получение состояний входных линий
            input1 = imgIn1Info.State;
            input2 = imgIn2Info.State;

            // перекрашивание линий входных линий
            // не буду писать, выше всё подробно описано, ничего не изменилось
            // кусь
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

            // проверка на истинность хотя бы одной из двух входных линий
            if (input1 || input2)
            {
                // в случае истинности - перекрашиваем выходную и меняем её стостояние
                PicOut.Image = imgOutInfo.Green;

                imgOutInfo.State = true;
                PicOut.Tag = imgOutInfo;
            }
            else
            {
                // делаем обратные действия
                PicOut.Image = imgOutInfo.Black;

                imgOutInfo.State = false;
                PicOut.Tag = imgOutInfo;
            }
        }
    }
}
