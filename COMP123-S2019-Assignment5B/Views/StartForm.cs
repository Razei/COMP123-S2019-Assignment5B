using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Assignment5B.Views
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseApplication();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }
        private static void CloseApplication()
        {
            Application.Exit();
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {   
            Program.selectForm.Show();
            this.Hide();
        }
    }
}
