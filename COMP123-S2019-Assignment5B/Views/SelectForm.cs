using COMP123_S2019_Assignment5B.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * STUDENT NAME: Jarod Lavine
 * STUDENT ID: 301037634
 * DATE: 29-07-2019
 * DESCRIPTION: This is the SelectForm - this form displays the data from table in the database in a DataGridView and passes info of the selected row to other forms and the Order class
 */

namespace COMP123_S2019_Assignment5B
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void SelectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dollarComputersDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.dollarComputersDataSet.products);

            if (ConnectedToDatabase())
            {
                MessageBox.Show("Connected to Database");
            }

            NextButton.Enabled = false;
            Program.productInfoForm.NextButton.Enabled = false;
        }

        public bool ConnectedToDatabase()
        {
            using (var db = new ProductModel())
            {
                db.products.Load();
                productBindingSource.DataSource = db.products.Local.ToBindingList();

                if (productBindingSource.DataSource != null)
                {
                    return true;
                }
            }

            return false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This event handler sends data from the table to the labels on ProductInfoForm and to the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            //Send data to ProductInfoForm and Order class
            var rowIndex = ProductDataGridView.CurrentCell.RowIndex;

            //tried to get index by column name but it didn't work (returned null), so I manually added the index:
            //var productIDColumnIndex = ProductDataGridView.Columns["productID"].Index;

            Program.order.ProductID = Program.productInfoForm.ProductIDDisplayLabel.Text = ProductDataGridView[0, rowIndex].Value.ToString();
            Program.order.Condition = Program.productInfoForm.ConditionDisplayLabel.Text = ProductDataGridView[14, rowIndex].Value.ToString();
            Program.order.Cost = Program.productInfoForm.CostDisplayLabel.Text = ProductDataGridView[1, rowIndex].Value.ToString();
            Program.order.Platform = Program.productInfoForm.PlatformDisplayLabel.Text = ProductDataGridView[16, rowIndex].Value.ToString();
            Program.order.OperatingSystem = Program.productInfoForm.OperatingSystemDisplayLabel.Text = ProductDataGridView[15, rowIndex].Value.ToString();
            Program.order.Manufacturer = Program.productInfoForm.ManufacturerDisplayLabel.Text = ProductDataGridView[2, rowIndex].Value.ToString();
            Program.order.Model = Program.productInfoForm.ModelDisplayLabel.Text = ProductDataGridView[3, rowIndex].Value.ToString();
            Program.order.Memory = Program.productInfoForm.MemoryDisplayLabel.Text = ProductDataGridView[5, rowIndex].Value.ToString();
            Program.order.LCDSize = Program.productInfoForm.LCDSizeDisplayLabel.Text = ProductDataGridView[7, rowIndex].Value.ToString();
            Program.order.StorageCapacity = Program.productInfoForm.StorageCapacityDisplayLabel.Text = ProductDataGridView[17, rowIndex].Value.ToString();
            Program.order.CPUBrand = Program.productInfoForm.CPUBrandDisplayLabel.Text = ProductDataGridView[10, rowIndex].Value.ToString();
            Program.order.CPUNumber = Program.productInfoForm.CPUNumberDisplayLabel.Text = ProductDataGridView[13, rowIndex].Value.ToString();
            Program.order.GPUType = Program.productInfoForm.GPUTypeDisplayLabel.Text = ProductDataGridView[19, rowIndex].Value.ToString();
            Program.order.CPUType = Program.productInfoForm.CPUTypeDisplayLabel.Text = ProductDataGridView[11, rowIndex].Value.ToString();
            Program.order.CPUSpeed = Program.productInfoForm.CPUSpeedDisplayLabel.Text = ProductDataGridView[12, rowIndex].Value.ToString();
            Program.order.Webcam = Program.productInfoForm.WebcamDisplayLabel.Text = ProductDataGridView[30, rowIndex].Value.ToString();

            //enable the next button in ProductInfoForm
            Program.productInfoForm.NextButton.Enabled = true;
            Program.productInfoForm.Show();
        }

        /// <summary>
        /// THis method sends the data from the cost, manufacturer and model columns in the currently selected row to the SelectionLabel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectData(object sender, EventArgs e)
        {
            var rowIndex = ProductDataGridView.CurrentCell.RowIndex;
            var columnIndex = ProductDataGridView.CurrentCell.ColumnIndex;

            var cost = ProductDataGridView[1, rowIndex].Value.ToString();
            var manufacturer = ProductDataGridView[2, rowIndex].Value.ToString();
            var model = ProductDataGridView[3, rowIndex].Value.ToString();
            SelectionLabel.Text = manufacturer + " " + model + " " + cost;
        }

        /// <summary>
        /// This method calls the SelectData method when a selection on the ProductDataGridView is changed and enables the NextButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            SelectData(sender,e);
            NextButton.Enabled = true;
        }
    }
}
