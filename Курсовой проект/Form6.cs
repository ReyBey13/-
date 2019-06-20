using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Курсовой_проект
{
    public partial class FormRecords : Form
    {
        public FormRecords()
        {
            InitializeComponent();
        }

        private void buttonCloseRes_Click(object sender, EventArgs e)
        {
            if (ClassSaveHist.Name == null)
            {
                Hide();
            }
            else
            {
                ClassSaveHist.Name = null;
                FormLogic frm = new FormLogic();
                frm.Show();
                Hide();
            }
        }

        private void FormRecords_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("records.txt");
            string allData = reader.ReadToEnd();
            string[] rows = allData.Split(';');

            for (int i = 0; i < rows.Length - 1; i++)
            {
                string[] columns = rows[i].Split(':');
                dataGridViewRec.Rows.Add(columns[0], columns[1]);
                Bitmap bitmap = Properties.Resources.Hearts1;
                switch (columns[2])
                {
                    case "2": bitmap = Properties.Resources.Hearts2;break;
                    case "3": bitmap = Properties.Resources.Hearts3;break;
                }
                dataGridViewRec.Rows[i].Cells[2].Value = bitmap;
            }
            reader.Close();
        }

        private void FormRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClassSaveHist.Name == null)
            {
                Hide();
            }
            else
            {
                ClassSaveHist.Name = null;
                FormLogic frm = new FormLogic();
                frm.Show();
                Hide();
            }
        }
    }
}
