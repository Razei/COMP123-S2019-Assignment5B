using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * STUDENT NAME: Jarod Lavine
 * STUDENT ID: 301037634
 * DATE: 29-07-2019
 * DESCRIPTION: This is the OrderForm - this form displays the data from the Order class
 */

namespace COMP123_S2019_Assignment5B
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void PrintToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing...");
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormCancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// This event handler displays a box telling the user about their order when the Finish button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for your business!\n\n\nYour order will be processed in 7-10 business days");
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.productInfoForm.Show();
            this.Hide();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutForm.Show();
        }
    }
}
