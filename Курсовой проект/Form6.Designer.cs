namespace Курсовой_проект
{
    partial class FormRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecords));
            this.buttonCloseRes = new System.Windows.Forms.Button();
            this.dataGridViewRec = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRec)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCloseRes
            // 
            this.buttonCloseRes.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonCloseRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCloseRes.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCloseRes.Location = new System.Drawing.Point(263, 425);
            this.buttonCloseRes.Name = "buttonCloseRes";
            this.buttonCloseRes.Size = new System.Drawing.Size(100, 30);
            this.buttonCloseRes.TabIndex = 0;
            this.buttonCloseRes.Text = "Закрыть";
            this.buttonCloseRes.UseVisualStyleBackColor = false;
            this.buttonCloseRes.Click += new System.EventHandler(this.buttonCloseRes_Click);
            // 
            // dataGridViewRec
            // 
            this.dataGridViewRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRec.Location = new System.Drawing.Point(22, 28);
            this.dataGridViewRec.Name = "dataGridViewRec";
            this.dataGridViewRec.Size = new System.Drawing.Size(600, 380);
            this.dataGridViewRec.TabIndex = 1;
            // 
            // FormRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Курсовой_проект.Properties.Resources.Records;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(644, 481);
            this.Controls.Add(this.dataGridViewRec);
            this.Controls.Add(this.buttonCloseRes);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рекорды";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCloseRes;
        private System.Windows.Forms.DataGridView dataGridViewRec;
    }
}