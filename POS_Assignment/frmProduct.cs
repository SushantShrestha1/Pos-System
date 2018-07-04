using Microsoft.VisualBasic.FileIO;
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

namespace POS_Assignment
{
    public partial class frmProduct : Form
    {
        int row = 0;
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text != "" && cmbCategory.Text != "" && txtPrice.Text != "")
            {
                int row = dataGridView1.RowCount - 1;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells[0].Value = txtProductName.Text;                
                dataGridView1.Rows[row].Cells[1].Value = txtPrice.Text;
                dataGridView1.Rows[row].Cells[2].Value = cmbCategory.Text;

                this.btnSave.Text = "Save";
                dataGridView1.Rows[this.row].Selected = true;
            }
            DialogResult dialog = MessageBox.Show("Record has been saved", "Details Entry", MessageBoxButtons.OK);
            if (dialog == DialogResult.OK)
            {
                txtProductName.Text = String.Empty;
                txtPrice.Text = String.Empty;
                cmbCategory.Text = String.Empty;


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;

            if (selectedRow >= 0)
            {
                dataGridView1.Rows.RemoveAt(selectedRow);

            }
            MessageBox.Show(Convert.ToString(this.dataGridView1.RowCount), "Deleted Row");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string fileRow;
            string[] fileDataField;
            int count = 0;
            if (DataLoaded == false)
            {
                try
                {
                    if (System.IO.File.Exists(txtBox.Text))
                    {
                        System.IO.StreamReader fileReader = new StreamReader(txtBox.Text);

                        if (fileReader.Peek() != -1)
                        {
                            fileRow = fileReader.ReadLine();
                            fileDataField = fileRow.Split(delimiter);
                            count = fileDataField.Count();
                            count = count - 1;

                            for (int i = 0; i <= count; i++)
                            {
                                DataGridTextBoxColumn columnDataGridTextBox = new DataGridTextBoxColumn();
                                DataGridViewTextBoxColumn productName = new DataGridViewTextBoxColumn();
                                DataGridViewTextBoxColumn category = new DataGridViewTextBoxColumn();
                                DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();

                            }

                        }
                        else
                        {
                            MessageBox.Show("File is Empty!!");
                        }

                        while (fileReader.Peek() != -1)
                        {
                            fileRow = fileReader.ReadLine();
                            fileDataField = fileRow.Split(delimiter);
                            dataGridView1.Rows.Add(fileDataField);
                        }

                        fileReader.Close();

                    }
                    else
                    {
                        MessageBox.Show("No File is Selected!!");
                    }

                    DataLoaded = true;
                }
                catch (Exception exceptionObject)
                {
                    MessageBox.Show(exceptionObject.ToString());
                }
            }
            MessageBox.Show("Product details successfully imported.", "Import Notification");

            
            
        }
        private void importCSVFile(string filePath)
        {
            try
            {
                TextFieldParser csvreader = new TextFieldParser(filePath);

                csvreader.SetDelimiters(new string[] { "," });

                csvreader.HasFieldsEnclosedInQuotes = true;

                while (!csvreader.EndOfData)
                {
                    string[] fielddata = csvreader.ReadFields();

                    for (int i = 0; i < fielddata.Length; i++)
                    {
                        Console.WriteLine(fielddata[i] + "\t");

                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to import CSV File.\n" + ex.Message, "Import CSV File", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();
                dialog.Filter = "All CSV Files (*.csv) | *.csv";
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBox.Text = dialog.FileName;
                }
            }
            char delimiter = ',';
            Boolean DataLoaded = false;

            private void btnASort_Click(object sender, EventArgs e)
            {
                dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
                MessageBox.Show("The Ascending sort has been successfully in main table.", "Sort Notification");
            }

            private void btnDSort_Click(object sender, EventArgs e)
            {
                dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
                MessageBox.Show("The Descending sort has been successfully in main table.", "Sort Notification");
            }

           

            private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
        

    }
}
