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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            if (File.Exists(Program.filename))
            {
                StreamReader stream = new StreamReader(Program.filename);
                lblNumHIGHSCORE.Text = stream.ReadLine();
                stream.Close();
            }
            else
            {
                FileStream file = new FileStream(Program.filename, FileMode.Create);
                file.Close();

                string internoFile = "aaa 0";

                lblNumHIGHSCORE.Text = internoFile;
                StreamWriter stream = new StreamWriter(Program.filename);
                stream.WriteLine(internoFile);
                stream.Close();

                File.Encrypt(Program.filename);
            }
        }
    }
}
