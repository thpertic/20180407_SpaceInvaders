namespace _20180407_SpaceInvaders
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.lblHIGHSCORE = new System.Windows.Forms.Label();
            this.lblNumHIGHSCORE = new System.Windows.Forms.Label();
            this.lblHighscores = new System.Windows.Forms.Label();
            this.lblHighPunti = new System.Windows.Forms.Label();
            this.pictBack = new System.Windows.Forms.PictureBox();
            this.pictPressStart = new System.Windows.Forms.PictureBox();
            this.pictSpaceInvaders = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPressStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceInvaders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHIGHSCORE
            // 
            this.lblHIGHSCORE.AutoSize = true;
            this.lblHIGHSCORE.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHIGHSCORE.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHIGHSCORE.Location = new System.Drawing.Point(167, 280);
            this.lblHIGHSCORE.Name = "lblHIGHSCORE";
            this.lblHIGHSCORE.Size = new System.Drawing.Size(206, 42);
            this.lblHIGHSCORE.TabIndex = 2;
            this.lblHIGHSCORE.Text = "Highscores";
            this.lblHIGHSCORE.Click += new System.EventHandler(this.lblHIGHSCORE_Click);
            // 
            // lblNumHIGHSCORE
            // 
            this.lblNumHIGHSCORE.AutoSize = true;
            this.lblNumHIGHSCORE.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumHIGHSCORE.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNumHIGHSCORE.Location = new System.Drawing.Point(139, 12);
            this.lblNumHIGHSCORE.Name = "lblNumHIGHSCORE";
            this.lblNumHIGHSCORE.Size = new System.Drawing.Size(258, 39);
            this.lblNumHIGHSCORE.TabIndex = 3;
            this.lblNumHIGHSCORE.Text = "HIGH SCORES";
            this.lblNumHIGHSCORE.Visible = false;
            // 
            // lblHighscores
            // 
            this.lblHighscores.AutoSize = true;
            this.lblHighscores.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighscores.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHighscores.Location = new System.Drawing.Point(169, 70);
            this.lblHighscores.Name = "lblHighscores";
            this.lblHighscores.Size = new System.Drawing.Size(129, 28);
            this.lblHighscores.TabIndex = 4;
            this.lblHighscores.Text = "provaNomi";
            this.lblHighscores.Visible = false;
            // 
            // lblHighPunti
            // 
            this.lblHighPunti.AutoSize = true;
            this.lblHighPunti.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighPunti.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHighPunti.Location = new System.Drawing.Point(304, 70);
            this.lblHighPunti.Name = "lblHighPunti";
            this.lblHighPunti.Size = new System.Drawing.Size(142, 28);
            this.lblHighPunti.TabIndex = 5;
            this.lblHighPunti.Text = "provaPunti";
            this.lblHighPunti.Visible = false;
            // 
            // pictBack
            // 
            this.pictBack.Image = global::_20180407_SpaceInvaders.Properties.Resources.back;
            this.pictBack.Location = new System.Drawing.Point(12, 328);
            this.pictBack.Name = "pictBack";
            this.pictBack.Size = new System.Drawing.Size(65, 62);
            this.pictBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBack.TabIndex = 6;
            this.pictBack.TabStop = false;
            this.pictBack.Visible = false;
            this.pictBack.Click += new System.EventHandler(this.pictBack_Click);
            // 
            // pictPressStart
            // 
            this.pictPressStart.Image = ((System.Drawing.Image)(resources.GetObject("pictPressStart.Image")));
            this.pictPressStart.Location = new System.Drawing.Point(205, 198);
            this.pictPressStart.Name = "pictPressStart";
            this.pictPressStart.Size = new System.Drawing.Size(113, 55);
            this.pictPressStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictPressStart.TabIndex = 1;
            this.pictPressStart.TabStop = false;
            this.pictPressStart.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictSpaceInvaders
            // 
            this.pictSpaceInvaders.Image = ((System.Drawing.Image)(resources.GetObject("pictSpaceInvaders.Image")));
            this.pictSpaceInvaders.Location = new System.Drawing.Point(47, 12);
            this.pictSpaceInvaders.Name = "pictSpaceInvaders";
            this.pictSpaceInvaders.Size = new System.Drawing.Size(439, 159);
            this.pictSpaceInvaders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictSpaceInvaders.TabIndex = 0;
            this.pictSpaceInvaders.TabStop = false;
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(546, 402);
            this.Controls.Add(this.pictBack);
            this.Controls.Add(this.lblHighPunti);
            this.Controls.Add(this.lblHighscores);
            this.Controls.Add(this.lblNumHIGHSCORE);
            this.Controls.Add(this.lblHIGHSCORE);
            this.Controls.Add(this.pictPressStart);
            this.Controls.Add(this.pictSpaceInvaders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStart_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPressStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceInvaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictSpaceInvaders;
        private System.Windows.Forms.PictureBox pictPressStart;
        private System.Windows.Forms.Label lblHIGHSCORE;
        private System.Windows.Forms.Label lblNumHIGHSCORE;
        private System.Windows.Forms.Label lblHighscores;
        private System.Windows.Forms.Label lblHighPunti;
        private System.Windows.Forms.PictureBox pictBack;
    }
}