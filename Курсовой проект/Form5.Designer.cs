namespace Курсовой_проект
{
    partial class FormResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResult));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.labelResText1 = new System.Windows.Forms.Label();
            this.labelResText2 = new System.Windows.Forms.Label();
            this.labelResText3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(94, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMenu.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMenu.Location = new System.Drawing.Point(102, 183);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(110, 27);
            this.buttonMenu.TabIndex = 4;
            this.buttonMenu.Text = "ОК";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // labelResText1
            // 
            this.labelResText1.BackColor = System.Drawing.Color.Transparent;
            this.labelResText1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResText1.Location = new System.Drawing.Point(102, 14);
            this.labelResText1.Name = "labelResText1";
            this.labelResText1.Size = new System.Drawing.Size(110, 28);
            this.labelResText1.TabIndex = 5;
            this.labelResText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResText2
            // 
            this.labelResText2.BackColor = System.Drawing.Color.Transparent;
            this.labelResText2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResText2.Location = new System.Drawing.Point(12, 51);
            this.labelResText2.Name = "labelResText2";
            this.labelResText2.Size = new System.Drawing.Size(297, 24);
            this.labelResText2.TabIndex = 6;
            this.labelResText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResText3
            // 
            this.labelResText3.BackColor = System.Drawing.Color.Transparent;
            this.labelResText3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResText3.Location = new System.Drawing.Point(12, 86);
            this.labelResText3.Name = "labelResText3";
            this.labelResText3.Size = new System.Drawing.Size(297, 24);
            this.labelResText3.TabIndex = 7;
            this.labelResText3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Курсовой_проект.Properties.Resources.Result;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(321, 222);
            this.Controls.Add(this.labelResText3);
            this.Controls.Add(this.labelResText2);
            this.Controls.Add(this.labelResText1);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результат";
            this.Load += new System.EventHandler(this.FormResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Label labelResText1;
        private System.Windows.Forms.Label labelResText2;
        private System.Windows.Forms.Label labelResText3;
    }
}