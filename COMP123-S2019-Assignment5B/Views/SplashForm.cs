using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * STUDENT NAME: Jarod Lavine
 * STUDENT ID: 301037634
 * DATE: 29-07-2019
 * DESCRIPTION: This is the SplashForm - this form displays for 3 seconds and then shows the StartForm
 */

namespace COMP123_S2019_Assignment5B.Views
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            SplashTimer.Enabled = true;
        }

        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            SplashTimer.Enabled = false;           
            Program.startForm.Show();
            this.Hide();
        }
    }
}
