namespace _20180407_SpaceInvaders
{
    partial class frmSpaceInvaders
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpaceInvaders));
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHiScore = new System.Windows.Forms.Label();
            this.timeMove = new System.Windows.Forms.Timer(this.components);
            this.lblPunteggio = new System.Windows.Forms.Label();
            this.lblMassimoPunteggio = new System.Windows.Forms.Label();
            this.timeColpito = new System.Windows.Forms.Timer(this.components);
            this.pictSpaceship = new System.Windows.Forms.PictureBox();
            this.timeSpecialShip = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceship)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(74, 20);
            this.lblScore.TabIndex = 39;
            this.lblScore.Text = "SCORE";
            // 
            // lblHiScore
            // 
            this.lblHiScore.AutoSize = true;
            this.lblHiScore.BackColor = System.Drawing.Color.Transparent;
            this.lblHiScore.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHiScore.Location = new System.Drawing.Point(364, 9);
            this.lblHiScore.Name = "lblHiScore";
            this.lblHiScore.Size = new System.Drawing.Size(139, 20);
            this.lblHiScore.TabIndex = 40;
            this.lblHiScore.Text = "HIGH-SCORE";
            // 
            // timeMove
            // 
            this.timeMove.Interval = 50;
            this.timeMove.Tick += new System.EventHandler(this.timeMove_Tick);
            // 
            // lblPunteggio
            // 
            this.lblPunteggio.AutoSize = true;
            this.lblPunteggio.BackColor = System.Drawing.Color.Transparent;
            this.lblPunteggio.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPunteggio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPunteggio.Location = new System.Drawing.Point(93, 9);
            this.lblPunteggio.Name = "lblPunteggio";
            this.lblPunteggio.Size = new System.Drawing.Size(22, 20);
            this.lblPunteggio.TabIndex = 41;
            this.lblPunteggio.Text = "0";
            // 
            // lblMassimoPunteggio
            // 
            this.lblMassimoPunteggio.AutoSize = true;
            this.lblMassimoPunteggio.BackColor = System.Drawing.Color.Transparent;
            this.lblMassimoPunteggio.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMassimoPunteggio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMassimoPunteggio.Location = new System.Drawing.Point(509, 9);
            this.lblMassimoPunteggio.Name = "lblMassimoPunteggio";
            this.lblMassimoPunteggio.Size = new System.Drawing.Size(22, 20);
            this.lblMassimoPunteggio.TabIndex = 42;
            this.lblMassimoPunteggio.Text = "0";
            // 
            // timeColpito
            // 
            this.timeColpito.Tick += new System.EventHandler(this.timeColpito_Tick);
            // 
            // pictSpaceship
            // 
            this.pictSpaceship.BackColor = System.Drawing.Color.Transparent;
            this.pictSpaceship.Image = global::_20180407_SpaceInvaders.Properties.Resources.spaceship;
            this.pictSpaceship.Location = new System.Drawing.Point(391, 609);
            this.pictSpaceship.Name = "pictSpaceship";
            this.pictSpaceship.Size = new System.Drawing.Size(36, 41);
            this.pictSpaceship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictSpaceship.TabIndex = 0;
            this.pictSpaceship.TabStop = false;
            this.pictSpaceship.Click += new System.EventHandler(this.PictAlien36_Click);
            // 
            // timeSpecialShip
            // 
            this.timeSpecialShip.Interval = 10;
            this.timeSpecialShip.Tick += new System.EventHandler(this.timeSpecialShip_Tick);
            // 
            // frmSpaceInvaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(839, 662);
            this.Controls.Add(this.lblMassimoPunteggio);
            this.Controls.Add(this.lblPunteggio);
            this.Controls.Add(this.lblHiScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pictSpaceship);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSpaceInvaders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Invaders";
            this.Load += new System.EventHandler(this.frmSpaceInvaders_Load);
            this.Click += new System.EventHandler(this.PictAlien36_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSpaceInvaders_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSpaceInvaders_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictSpaceship)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictSpaceship;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblHiScore;
        private System.Windows.Forms.Timer timeMove;
        private System.Windows.Forms.Label lblPunteggio;
        private System.Windows.Forms.Label lblMassimoPunteggio;
        private System.Windows.Forms.Timer timeColpito;
        private System.Windows.Forms.Timer timeSpecialShip;
    }
}

