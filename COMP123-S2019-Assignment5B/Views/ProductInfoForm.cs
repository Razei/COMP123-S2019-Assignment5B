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
 * DESCRIPTION: This is the ProductInfoForm - this form displays the data selected in SelectForm or loaded from a form
 */

namespace COMP123_S2019_Assignment5B.Views
{
    public partial class ProductInfoForm : Form
    {
        public ProductInfoForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Program.orderForm.ConditionDisplayLabel.Text = Program.order.Condition;
            Program.orderForm.PriceDisplayLabel.Text = decimal.Parse(Program.order.Cost).ToString("C2");
            Program.orderForm.PlatformDisplayLabel.Text = Program.order.Platform;
            Program.orderForm.OperatingSystemDisplayLabel.Text = Program.order.OperatingSystem;
            Program.orderForm.ManufacturerDisplayLabel.Text = Program.order.Manufacturer;
            Program.orderForm.ModelDisplayLabel.Text = Program.order.Model;
            Program.orderForm.MemoryDisplayLabel.Text = Program.order.Memory;
            Program.orderForm.LCDSizeDisplayLabel.Text = Program.order.LCDSize;
            Program.orderForm.StorageCapacityDisplayLabel.Text = Program.order.StorageCapacity;
            Program.orderForm.CPUBrandDisplayLabel.Text = Program.order.CPUBrand;
            Program.orderForm.CPUNumberDisplayLabel.Text = Program.order.CPUNumber;
            Program.orderForm.GPUTypeDisplayLabel.Text = Program.order.GPUType;
            Program.orderForm.CPUTypeDisplayLabel.Text = Program.order.CPUType;
            Program.orderForm.CPUSpeedDisplayLabel.Text = Program.order.CPUSpeed;
            Program.orderForm.WebcamDisplayLabel.Text = Program.order.Webcam;

            Program.orderForm.TaxDisplayLabel.Text = (Convert.ToDouble(Program.order.Cost) * 0.13).ToString("C2");
            Program.orderForm.TotalPriceDisplayLabel.Text = (Convert.ToDouble(Program.order.Cost) + (Convert.ToDouble(Program.order.Cost) * 0.13)).ToString("C2");

            Program.orderForm.Show();
            this.Hide();
        }

        private void SelectNewButton_Click(object sender, EventArgs e)
        {
            Program.selectForm.Show();
            this.Hide();
        }


        /// <summary>
        /// This event handler opens an OpenFileDialog and reads the data from the text file into the ProductInfoForm labels and the order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //configure file dialog
            OpenOrderDialog.FileName = "Order.txt";
            OpenOrderDialog.InitialDirectory = Directory.GetCurrentDirectory();
            OpenOrderDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            //open the file dialog
            var result = OpenOrderDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try
                {
                    using (StreamReader InputStream = new StreamReader(
                    File.Open(OpenOrderDialog.FileName, FileMode.Open)))
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
            }
        }

        /// <summary>
        /// This event handler saves the selected data to a text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //configure file dialog
            SaveOrderDialog.FileName = "Order.txt";
            SaveOrderDialog.InitialDirectory = Directory.GetCurrentDirectory();
            SaveOrderDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            //open the file dialog
            var result = SaveOrderDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try
                {
                    using (StreamWriter outputStream = new StreamWriter(
                    File.Open(SaveOrderDialog.FileName, FileMode.Create)))
                    {
                        //Read stuff into the class
                        outputStream.WriteLine(Program.order.ProductID);
                        outputStream.WriteLine(Program.order.Condition);
                        outputStream.WriteLine(Program.order.Cost);
                        outputStream.WriteLine(Program.order.Platform);
                        outputStream.WriteLine(Program.order.OperatingSystem);
                        outputStream.WriteLine(Program.order.Manufacturer);
                        outputStream.WriteLine(Program.order.Model);
                        outputStream.WriteLine(Program.order.Memory);
                        outputStream.WriteLine(Program.order.LCDSize);
                        outputStream.WriteLine(Program.order.StorageCapacity);
                        outputStream.WriteLine(Program.order.CPUBrand);
                        outputStream.WriteLine(Program.order.CPUNumber);
                        outputStream.WriteLine(Program.order.GPUType);
                        outputStream.WriteLine(Program.order.CPUType);
                        outputStream.WriteLine(Program.order.CPUSpeed);
                        outputStream.WriteLine(Program.order.Webcam);

                        //cleanup
                        outputStream.Close();
                        outputStream.Dispose();

                        NextButton_Click(sender, e);
                    }
                }
                catch (IOException exception)
                {
                    MessageBox.Show("Error: " + exception.Message, "File I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }
    }
}

