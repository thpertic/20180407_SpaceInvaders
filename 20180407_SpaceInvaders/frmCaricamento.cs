using System;
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
    public partial class frmCaricamento : Form
    {
        public frmCaricamento()
        {
            InitializeComponent();
        }

        private void frmCaricamento_Load(object sender, EventArgs e)
        {
            timeCaricamento.Start();
        }

        private void timeCaricamento_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
            pgbCaricamento.Value = Program.progress;

            if (pgbCaricamento.Value == pgbCaricamento.Maximum)
                Close();
        }
    }
}
