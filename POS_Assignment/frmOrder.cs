using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Assignment
{
    public partial class frmOrder : Form
    {
        int[] orderid = new int[8];
        int j = 1;
        int k = 1;
        double qty, price;
        double total = 0, alltotal = 0;
        string discount;
        string[][] pro = { };
        ListViewItem listitem;
        double pro_total = 0;
        
        public frmOrder()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text != "")
            {
                if (txtQty.Text == "")
                {
                    txtQty.Text = Convert.ToString(1);
                }
                qty = Convert.ToDouble(txtQty.Text);
                price = Convert.ToDouble(txtPrice.Text);

                total = qty * price;

                if (total < 100)
                {
                    txtDiscount.Text = "5 %";
                    alltotal = total - ((total * 5) / 100);
                }
                else if (total >= 100 && total < 500)
                {
                    txtDiscount.Text = "10 %";
                    alltotal = total - ((total * 10) / 100);
                }
                else if (total >= 500 && total < 1000)
                {
                    txtDiscount.Text = "20 %";
                    alltotal = total - ((total * 20) / 100);
                }
                else if (total >= 1000)
                {
                    txtDiscount.Text = "50 %";
                    alltotal = total - ((total * 50) / 100);
                }

                discount = txtDiscount.Text;
                txtTotalAmount.Text = Convert.ToString(alltotal);

                //add value to listview
                listitem = listViewdata.Items.Add(txtOrderID.Text);
                listitem.SubItems.Add(DTPorderDate.Text);
                listitem.SubItems.Add(txtQty.Text);
                listitem.SubItems.Add(txtPrice.Text);
                listitem.SubItems.Add(discount);
                listitem.SubItems.Add(Convert.ToString(alltotal));
                pro_total += pro_total + alltotal;
                txtalltotal.Text = Convert.ToString(pro_total);
                j++;
                k++;
                txtOrderID.Text = Convert.ToString("00" + j);
            }
            else
            {
                MessageBox.Show("Please input price", "complete input");

            }
                      
        }    

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txtOrderID.Text = Convert.ToString("00" + j);
            txtOrderID.Enabled = false;
            txtDiscount.Enabled = false;
            txtTotalAmount.Enabled = false;
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            bool digi = false;
            TextBox txt = (TextBox)sender;
            string number = txt.Text.Trim();
            string letter;


            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsNumber(number[i]))
                {
                    digi = true;

                }
                if (digi)
                {
                    //Do what you want do if input value is not numeric
                    try
                    {
                        MessageBox.Show("please input numeric only !", "Invalid input");

                        //Left method
                        letter = txt.Text.Substring(0, txt.Text.Length - 1);
                        txt.Text = letter;
                        //txt.Focus();
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listViewdata.Items.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewdata.SelectedItems.Count > 0)
            {
                listViewdata.SelectedItems[0].Remove();
            }
            

            }
            
        }

        

        

        
        
    }

