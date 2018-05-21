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
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            chiudi();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            
        }

        private void frmStart_KeyDown(object sender, KeyEventArgs e)
        {
            if(pictPressStart.Visible)
                if(e.KeyCode == Keys.Enter)
                    chiudi();
        }

        private void chiudi()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lblHIGHSCORE_Click(object sender, EventArgs e)
        {
            // nasconde la prima schermata
            pictPressStart.Visible = false;
            pictPressStart.Enabled = false;

            pictSpaceInvaders.Visible = false;
            pictSpaceInvaders.Enabled = false;

            lblHIGHSCORE.Visible = false;
            lblHIGHSCORE.Enabled = false;

            // mostra la seconda schermata
            pictBack.Visible = true;
            pictBack.Enabled = true;

            lblNumHIGHSCORE.Visible = true;
            lblHighscores.Visible = true;
            lblHighPunti.Visible = true;
            if (File.Exists(Program.filename))
            {
                lblHighscores.Text = "";
                lblHighPunti.Text = "";

                StreamReader stream = new StreamReader(Program.filename);
                while (!stream.EndOfStream)
                {
                    string[] lineaFile = stream.ReadLine().Split(' ');

                    lblHighscores.Text += lineaFile[0] + "  -\n";
                    lblHighPunti.Text += lineaFile[1] + "\n";//"      " + lineaFile[1] + "\n";
                }

                stream.Close();
            }
            else
            {
                FileStream file = new FileStream(Program.filename, FileMode.Create);
                file.Close();

                string[] internoFile = { "aaa", "0" };

                lblHighscores.Text = internoFile[0];
                lblHighPunti.Text = internoFile[1];
                StreamWriter stream = new StreamWriter(Program.filename);
                stream.WriteLine(internoFile);
                stream.Close();

                // File.Encrypt(Program.filename);
            }
        }

        private void pictBack_Click(object sender, EventArgs e)
        {
            // nasconde la seconda schermata
            pictBack.Visible = false;
            pictBack.Enabled = false;

            lblNumHIGHSCORE.Visible = false;
            lblHighscores.Visible = false;
            lblHighPunti.Visible = false;

            // mostra la prima schermata
            pictPressStart.Visible = true;
            pictPressStart.Enabled = true;

            pictSpaceInvaders.Visible = true;
            pictSpaceInvaders.Enabled = true;

            lblHIGHSCORE.Visible = true;
            lblHIGHSCORE.Enabled = true;
        }
    }
}
