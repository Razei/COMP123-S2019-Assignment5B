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
                        Program.productInfoForm.ProductIDDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.ConditionDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.CostDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.PlatformDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.OperatingSystemDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.ManufacturerDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.ModelDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.MemoryDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.LCDSizeDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.StorageCapacityDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.CPUBrandDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.CPUNumberDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.GPUTypeDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.CPUTypeDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.CPUSpeedDisplayLabel.Text = InputStream.ReadLine();
                        Program.productInfoForm.WebcamDisplayLabel.Text = InputStream.ReadLine();

                        //cleanup
                        InputStream.Close();
                        InputStream.Dispose();
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
