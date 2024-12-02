using System;
using System.Windows.Forms;

namespace Lab13
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Parse the input values
            double x1min = double.Parse(tbx1min.Text);
            double x1max = double.Parse(tbx1max.Text);
            double dx1 = double.Parse(tbdx1.Text);
            double x2min = double.Parse(tbx2min.Text);
            double x2max = double.Parse(tbx2max.Text);
            double dx2 = double.Parse(tbdx2.Text);

            // Calculate the number of rows and columns
            int rows = (int)((x1max - x1min) / dx1) + 1;
            int columns = (int)((x2max - x2min) / dx2) + 1;

            // Initialize the DataGridView
            gv.Rows.Clear();
            gv.Columns.Clear();

            // Add columns
            for (int i = 0; i < columns; i++)
            {
                gv.Columns.Add("col" + i, "x2=" + (x2min + i * dx2).ToString());
            }

            // Add row for the data and calculate the values
            for (int i = 0; i < rows; i++)
            {
                double x1 = x1min + i * dx1;
                gv.Rows.Add();
                gv.Rows[i].Cells[0].Value = "x1=" + x1.ToString();

                double rowSum = 0;

                for (int j = 0; j < columns; j++)
                {
                    double x2 = x2min + j * dx2;
                    double value = x1 * x2; // Example calculation: x1 * x2
                    gv.Rows[i].Cells[j].Value = value;
                    rowSum += value;
                }

                // Add the row sum in the last column
                gv.Rows[i].Cells[columns].Value = rowSum.ToString();
            }

            // Add the sum for each column in the last row
            gv.Rows.Add();
            gv.Rows[rows].Cells[0].Value = "Sum";

            for (int j = 0; j < columns; j++)
            {
                double columnSum = 0;

                for (int i = 0; i < rows; i++)
                {
                    columnSum += Convert.ToDouble(gv.Rows[i].Cells[j].Value);
                }

                gv.Rows[rows].Cells[j].Value = columnSum.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the grid and inputs
            gv.Rows.Clear();
            gv.Columns.Clear();
            tbx1min.Clear();
            tbx1max.Clear();
            tbdx1.Clear();
            tbx2min.Clear();
            tbx2max.Clear();
            tbdx2.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
