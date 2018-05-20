using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180407_SpaceInvaders
{
    public partial class frmHighScore : Form
    {
        public frmHighScore()
        {
            InitializeComponent();
        }

        private void frmHighScore_Load(object sender, EventArgs e)
        {
            this.Hide();

            Form frmGameOver = new frmGameOver();
            frmGameOver.ShowDialog();

            if (!Program.max)
                Close();

            lblNumScore.Text = Program.score.ToString();
            this.Activate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length == 3)
            {
                if (File.Exists(Program.filename))
                {
                    File.Decrypt(Program.filename);

                    StreamWriter FileW = new StreamWriter(Program.filename);
                    FileW.Write(txtNome.Text + " " + Program.score.ToString());
                    FileW.Close();
                }

                Close();
            }
            else
                MessageBox.Show("Il nome può essere lungo solamente 3 caratteri.", "Si deve inserire tre caratteri.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 3)
            {
                txtNome.Text = txtNome.Text.Substring(0, 3);
            }

            try
            {
                if (txtNome.Text[txtNome.Text.Length - 1] == ' ')
                {
                    txtNome.Text = txtNome.Text.Substring(0, txtNome.Text.Length - 2);
                }
            }
            catch { }
        }
    }
}
