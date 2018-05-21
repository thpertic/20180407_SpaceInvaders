using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20180407_SpaceInvaders
{
    public partial class frmGameOver : Form
    {
        public frmGameOver()
        {
            InitializeComponent();
        }

        private void frmGameOver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmGameOver_Load(object sender, EventArgs e)
        {
            if(Program.win)
                BackgroundImage = global::_20180407_SpaceInvaders.Properties.Resources.you_win;
            else
                BackgroundImage = global::_20180407_SpaceInvaders.Properties.Resources.game_over;
        }
    }
}
