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
        string tmpFile = "tmp.txt";

        public frmHighScore()
        {
            InitializeComponent();
        }

        private void frmHighScore_Load(object sender, EventArgs e)
        {
            this.Hide();

            Form frmGameOver = new frmGameOver();
            frmGameOver.ShowDialog();

            //if (!Program.max)
            //    Close();

            lblNumScore.Text = Program.score.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length == 3)
            {
                // deve scrivere in ordine di punteggio
                // max 10
                if (File.Exists(Program.filename))
                {
                    byte i = 0;
                    bool scritto = false;

                    StreamReader reader = new StreamReader(Program.filename);
                    StreamWriter writer = new StreamWriter(tmpFile);

                    while (!reader.EndOfStream && i < 9)
                    {
                        string[] vs = reader.ReadLine().Split(' ');

                        if (Program.score > Convert.ToInt32(vs[1]) && !scritto)
                        {
                            writer.WriteLine(txtNome.Text + " " + Program.score);
                            scritto = true;
                        }
                        else if (Program.score == Convert.ToInt32(vs[1]) && !scritto)
                        {
                            if (String.Compare(txtNome.Text, vs[0]) < 0)
                            {
                                writer.WriteLine(txtNome.Text + " " + Program.score);
                                scritto = true;
                            }
                        }

                        writer.WriteLine(vs[0] + " " + vs[1]);
                        i++;
                    }
                    // File.Decrypt(Program.filename);

                    // StreamWriter FileW = new StreamWriter(Program.filename);
                    // FileW.Write(txtNome.Text + " " + Program.score.ToString());
                    // FileW.Close();

                    reader.Close();
                    writer.Close();

                    File.Delete(Program.filename);
                    File.Move(tmpFile, Program.filename);
                }

                Application.Restart();
                Environment.Exit(0);
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