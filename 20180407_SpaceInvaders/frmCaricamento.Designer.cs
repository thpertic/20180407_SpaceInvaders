﻿namespace _20180407_SpaceInvaders
{
    partial class frmCaricamento
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
            this.components = new System.ComponentModel.Container();
            this.pgbCaricamento = new System.Windows.Forms.ProgressBar();
            this.timeCaricamento = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pgbCaricamento
            // 
            this.pgbCaricamento.Location = new System.Drawing.Point(12, 12);
            this.pgbCaricamento.Maximum = 3000;
            this.pgbCaricamento.Name = "pgbCaricamento";
            this.pgbCaricamento.Size = new System.Drawing.Size(412, 36);
            this.pgbCaricamento.TabIndex = 0;
            // 
            // timeCaricamento
            // 
            this.timeCaricamento.Tick += new System.EventHandler(this.timeCaricamento_Tick);
            // 
            // frmCaricamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(436, 60);
            this.Controls.Add(this.pgbCaricamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCaricamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCaricamento";
            this.Load += new System.EventHandler(this.frmCaricamento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbCaricamento;
        private System.Windows.Forms.Timer timeCaricamento;
    }
}