using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * STUDENT NAME: Jarod Lavine
 * STUDENT ID: 301037634
 * DATE: 29-07-2019
 * DESCRIPTION: This is the StartForm - this form allows the user to create a new order or open a previously saved order
 */

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

        /// <summary>
        /// This event handler jumps straight to the ProductInfoForm after opening an OpenFileDialog and reads the data from the text file into the ProductInfoForm labels and the order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenOrderButton_Click(object sender, EventArgs e)
        {
            //configure file dialog
            Program.productInfoForm.OpenOrderDialog.FileName = "Order.txt";
            Program.productInfoForm.OpenOrderDialog.InitialDirectory = Directory.GetCurrentDirectory();
            Program.productInfoForm.OpenOrderDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            //open the file dialog
            var result = Program.productInfoForm.OpenOrderDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try
                {
                    using (StreamReader InputStream = new StreamReader(
                    File.Open(Program.productInfoForm.OpenOrderDialog.FileName, FileMode.Open)))
                    {
                        //Read stuff into the class
                        Program.productInfoForm.ProductIDDisplayLabel.Text = Program.order.ProductID = InputStream.ReadLine();
                        Program.productInfoForm.ConditionDisplayLabel.Text = Program.order.Condition = InputStream.ReadLine();
                        Program.productInfoForm.CostDisplayLabel.Text = Program.order.Cost = InputStream.ReadLine();
                        Program.productInfoForm.PlatformDisplayLabel.Text = Program.order.Platform = InputStream.ReadLine();
                        Program.productInfoForm.OperatingSystemDisplayLabel.Text = Program.order.OperatingSystem = InputStream.ReadLine();
                        Program.productInfoForm.ManufacturerDisplayLabel.Text = Program.order.Manufacturer = InputStream.ReadLine();
                        Program.productInfoForm.ModelDisplayLabel.Text = Program.order.Model = InputStream.ReadLine();
                        Program.productInfoForm.MemoryDisplayLabel.Text = Program.order.Memory = InputStream.ReadLine();
                        Program.productInfoForm.LCDSizeDisplayLabel.Text = Program.order.LCDSize = InputStream.ReadLine();
                        Program.productInfoForm.StorageCapacityDisplayLabel.Text = Program.order.StorageCapacity = InputStream.ReadLine();
                        Program.productInfoForm.CPUBrandDisplayLabel.Text = Program.order.CPUBrand = InputStream.ReadLine();
                        Program.productInfoForm.CPUNumberDisplayLabel.Text = Program.order.CPUNumber = InputStream.ReadLine();
                        Program.productInfoForm.GPUTypeDisplayLabel.Text = Program.order.GPUType = InputStream.ReadLine();
                        Program.productInfoForm.CPUTypeDisplayLabel.Text = Program.order.CPUType = InputStream.ReadLine();
                        Program.productInfoForm.CPUSpeedDisplayLabel.Text = Program.order.CPUSpeed = InputStream.ReadLine();
                        Program.productInfoForm.WebcamDisplayLabel.Text = Program.order.Webcam = InputStream.ReadLine();

                        //cleanup
                        InputStream.Close();
                        InputStream.Dispose();

                        Program.productInfoForm.NextButton.Enabled = true;
                    }
                }
                catch (IOException exception)
                {
                    MessageBox.Show("Error: " + exception.Message, "File I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                Program.productInfoForm.Show();
                this.Hide();
            }
        }
    }
}
