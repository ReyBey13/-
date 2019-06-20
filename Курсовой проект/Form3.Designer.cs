namespace Курсовой_проект
{
    partial class FormRegistration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistration));
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.pictureBoxWritingCat = new System.Windows.Forms.PictureBox();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWritingCat)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.Location = new System.Drawing.Point(100, 30);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(128, 23);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Как тебя зовут?";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(33, 66);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(274, 34);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // pictureBoxWritingCat
            // 
            this.pictureBoxWritingCat.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWritingCat.BackgroundImage = global::Курсовой_проект.Properties.Resources.WritingCat;
            this.pictureBoxWritingCat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxWritingCat.Location = new System.Drawing.Point(107, 107);
            this.pictureBoxWritingCat.Name = "pictureBoxWritingCat";
            this.pictureBoxWritingCat.Size = new System.Drawing.Size(127, 92);
            this.pictureBoxWritingCat.TabIndex = 2;
            this.pictureBoxWritingCat.TabStop = false;
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonStartGame.Enabled = false;
            this.buttonStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartGame.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartGame.Location = new System.Drawing.Point(33, 157);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(75, 23);
            this.buttonStartGame.TabIndex = 3;
            this.buttonStartGame.Text = "Вперед!";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonCansel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCansel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(232, 157);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 23);
            this.buttonCansel.TabIndex = 4;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = false;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // FormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Курсовой_проект.Properties.Resources.Regist;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.pictureBoxWritingCat);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelUserName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWritingCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.PictureBox pictureBoxWritingCat;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonCansel;
    }
}