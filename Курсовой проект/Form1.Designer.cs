namespace Курсовой_проект
{
    partial class FormLogic
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogic));
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBoxCatSleep = new System.Windows.Forms.PictureBox();
            this.labelLogicName1 = new System.Windows.Forms.Label();
            this.labelLogicName2 = new System.Windows.Forms.Label();
            this.buttonRegulations = new System.Windows.Forms.Button();
            this.buttonRecords = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCatSleep)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(69, 47);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(121, 56);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Начать игру";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBoxCatSleep
            // 
            this.pictureBoxCatSleep.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCatSleep.Image = global::Курсовой_проект.Properties.Resources.SleepCat;
            this.pictureBoxCatSleep.Location = new System.Drawing.Point(56, 109);
            this.pictureBoxCatSleep.Name = "pictureBoxCatSleep";
            this.pictureBoxCatSleep.Size = new System.Drawing.Size(148, 141);
            this.pictureBoxCatSleep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCatSleep.TabIndex = 1;
            this.pictureBoxCatSleep.TabStop = false;
            // 
            // labelLogicName1
            // 
            this.labelLogicName1.AutoSize = true;
            this.labelLogicName1.BackColor = System.Drawing.Color.Transparent;
            this.labelLogicName1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogicName1.Location = new System.Drawing.Point(85, 263);
            this.labelLogicName1.Name = "labelLogicName1";
            this.labelLogicName1.Size = new System.Drawing.Size(92, 26);
            this.labelLogicName1.TabIndex = 2;
            this.labelLogicName1.Text = "ЛОГИКА";
            // 
            // labelLogicName2
            // 
            this.labelLogicName2.AutoSize = true;
            this.labelLogicName2.BackColor = System.Drawing.Color.Transparent;
            this.labelLogicName2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogicName2.Location = new System.Drawing.Point(38, 296);
            this.labelLogicName2.Name = "labelLogicName2";
            this.labelLogicName2.Size = new System.Drawing.Size(180, 69);
            this.labelLogicName2.TabIndex = 3;
            this.labelLogicName2.Text = "игровой тренажер для\r\nизучения логических \r\nвыражений";
            this.labelLogicName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRegulations
            // 
            this.buttonRegulations.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonRegulations.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRegulations.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegulations.Location = new System.Drawing.Point(69, 384);
            this.buttonRegulations.Name = "buttonRegulations";
            this.buttonRegulations.Size = new System.Drawing.Size(121, 32);
            this.buttonRegulations.TabIndex = 4;
            this.buttonRegulations.Text = "Правила";
            this.buttonRegulations.UseVisualStyleBackColor = false;
            this.buttonRegulations.Click += new System.EventHandler(this.buttonRegulations_Click);
            // 
            // buttonRecords
            // 
            this.buttonRecords.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonRecords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRecords.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRecords.Location = new System.Drawing.Point(69, 431);
            this.buttonRecords.Name = "buttonRecords";
            this.buttonRecords.Size = new System.Drawing.Size(121, 32);
            this.buttonRecords.TabIndex = 5;
            this.buttonRecords.Text = "Рекорды";
            this.buttonRecords.UseVisualStyleBackColor = false;
            this.buttonRecords.Click += new System.EventHandler(this.buttonRecords_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(69, 516);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(121, 40);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormLogic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Курсовой_проект.Properties.Resources.FonsLogic;
            this.ClientSize = new System.Drawing.Size(259, 600);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonRecords);
            this.Controls.Add(this.buttonRegulations);
            this.Controls.Add(this.labelLogicName2);
            this.Controls.Add(this.labelLogicName1);
            this.Controls.Add(this.pictureBoxCatSleep);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Логика";
            this.Load += new System.EventHandler(this.FormLogic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCatSleep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBoxCatSleep;
        private System.Windows.Forms.Label labelLogicName1;
        private System.Windows.Forms.Label labelLogicName2;
        private System.Windows.Forms.Button buttonRegulations;
        private System.Windows.Forms.Button buttonRecords;
        private System.Windows.Forms.Button buttonExit;
    }
}

