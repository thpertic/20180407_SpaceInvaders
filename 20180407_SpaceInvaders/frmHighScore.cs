﻿using System;
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
            lblNumScore.Text = Program.score.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}