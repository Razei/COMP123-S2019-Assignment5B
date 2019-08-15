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
            Program.orderForm.Show();
            this.Hide();
        }

        private void SelectNewButton_Click(object sender, EventArgs e)
        {
            Program.selectForm.Show();
            this.Hide();
        }

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
                        Program.order.ProductID = InputStream.ReadLine();
                        Program.order.Condition = InputStream.ReadLine();
                        Program.order.Cost = InputStream.ReadLine();
                        Program.order.Platform = InputStream.ReadLine();
                        Program.order.OperatingSystem = InputStream.ReadLine();
                        Program.order.Manufacturer = InputStream.ReadLine();
                        Program.order.Model = InputStream.ReadLine();
                        Program.order.Memory = InputStream.ReadLine();
                        Program.order.LCDSize = InputStream.ReadLine();
                        Program.order.StorageCapacity = InputStream.ReadLine();
                        Program.order.CPUBrand = InputStream.ReadLine();
                        Program.order.CPUNumber = InputStream.ReadLine();
                        Program.order.GPUType = InputStream.ReadLine();
                        Program.order.CPUType = InputStream.ReadLine();
                        Program.order.CPUSpeed = InputStream.ReadLine();
                        Program.order.Webcam = InputStream.ReadLine();

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
                    File.Open(SaveOrderDialog.FileName, FileMode.Open)))
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

