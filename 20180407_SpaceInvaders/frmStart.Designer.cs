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
            this.pictSpaceInvaders = new System.Windows.Forms.PictureBox();
            this.pictPressStart = new System.Windows.Forms.PictureBox();
            this.lblHIGHSCORE = new System.Windows.Forms.Label();
            this.lblNumHIGHSCORE = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceInvaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPressStart)).BeginInit();
            this.SuspendLayout();
            // 
            // pictSpaceInvaders
            // 
            this.pictSpaceInvaders.Image = ((System.Drawing.Image)(resources.GetObject("pictSpaceInvaders.Image")));
            this.pictSpaceInvaders.InitialImage = global::_20180407_SpaceInvaders.Properties.Resources.space_invaders_logo;
            this.pictSpaceInvaders.Location = new System.Drawing.Point(64, 12);
            this.pictSpaceInvaders.Name = "pictSpaceInvaders";
            this.pictSpaceInvaders.Size = new System.Drawing.Size(417, 125);
            this.pictSpaceInvaders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictSpaceInvaders.TabIndex = 0;
            this.pictSpaceInvaders.TabStop = false;
            // 
            // pictPressStart
            // 
            this.pictPressStart.Image = global::_20180407_SpaceInvaders.Properties.Resources.press_start;
            this.pictPressStart.Location = new System.Drawing.Point(205, 198);
            this.pictPressStart.Name = "pictPressStart";
            this.pictPressStart.Size = new System.Drawing.Size(100, 50);
            this.pictPressStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictPressStart.TabIndex = 1;
            this.pictPressStart.TabStop = false;
            this.pictPressStart.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblHIGHSCORE
            // 
            this.lblHIGHSCORE.AutoSize = true;
            this.lblHIGHSCORE.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHIGHSCORE.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHIGHSCORE.Location = new System.Drawing.Point(40, 314);
            this.lblHIGHSCORE.Name = "lblHIGHSCORE";
            this.lblHIGHSCORE.Size = new System.Drawing.Size(265, 42);
            this.lblHIGHSCORE.TabIndex = 2;
            this.lblHIGHSCORE.Text = "HIGHSCORE -";
            // 
            // lblNumHIGHSCORE
            // 
            this.lblNumHIGHSCORE.AutoSize = true;
            this.lblNumHIGHSCORE.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumHIGHSCORE.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNumHIGHSCORE.Location = new System.Drawing.Point(325, 314);
            this.lblNumHIGHSCORE.Name = "lblNumHIGHSCORE";
            this.lblNumHIGHSCORE.Size = new System.Drawing.Size(104, 39);
            this.lblNumHIGHSCORE.TabIndex = 3;
            this.lblNumHIGHSCORE.Text = "prova";
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(546, 402);
            this.Controls.Add(this.lblNumHIGHSCORE);
            this.Controls.Add(this.lblHIGHSCORE);
            this.Controls.Add(this.pictPressStart);
            this.Controls.Add(this.pictSpaceInvaders);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.Load += new System.EventHandler(this.frmStart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceInvaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictPressStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictSpaceInvaders;
        private System.Windows.Forms.PictureBox pictPressStart;
        private System.Windows.Forms.Label lblHIGHSCORE;
        private System.Windows.Forms.Label lblNumHIGHSCORE;
    }
}