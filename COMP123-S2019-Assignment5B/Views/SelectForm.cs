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

        private void NextButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.productInfoForm.Show();
        }

        private void SelectData(object sender, EventArgs e)
        {
            var rowIndex = ProductDataGridView.CurrentCell.RowIndex;
            var columnIndex = ProductDataGridView.CurrentCell.ColumnIndex;

            var cost = ProductDataGridView[1, rowIndex].Value.ToString();
            var manufacturer = ProductDataGridView[2, rowIndex].Value.ToString();
            var model = ProductDataGridView[3, rowIndex].Value.ToString();
            SelectionLabel.Text = manufacturer + " " + model + " " + cost;
        }

        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            SelectData(sender,e);
            NextButton.Enabled = true;
        }
    }
}
