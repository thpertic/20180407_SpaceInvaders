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
            this.pictSpaceInvaders = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceInvaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictSpaceInvaders
            // 
            this.pictSpaceInvaders.Image = global::_20180407_SpaceInvaders.Properties.Resources.space_invaders_logo;
            this.pictSpaceInvaders.InitialImage = global::_20180407_SpaceInvaders.Properties.Resources.space_invaders_logo;
            this.pictSpaceInvaders.Location = new System.Drawing.Point(12, 12);
            this.pictSpaceInvaders.Name = "pictSpaceInvaders";
            this.pictSpaceInvaders.Size = new System.Drawing.Size(522, 158);
            this.pictSpaceInvaders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictSpaceInvaders.TabIndex = 0;
            this.pictSpaceInvaders.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_20180407_SpaceInvaders.Properties.Resources.press_start;
            this.pictureBox1.Location = new System.Drawing.Point(214, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(546, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictSpaceInvaders);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceInvaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictSpaceInvaders;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}