using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderOptionsMaintenance.Models;
using Microsoft.Data.SqlClient;

namespace OrderOptionsMaintenance
{
    public partial class frmOptionsMaint : Form
    {
        private OrderOptions orderOptions;

        public frmOptionsMaint()
        {
            InitializeComponent();
        }


        


        private void frmOptionsMaint_Load(object sender, EventArgs e)
        {

         

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    //take input values
                    double taxRate = Convert.ToDouble(txtSalesTax.Text);
                    double firstBookCharge = Convert.ToDouble(txtShipFirstBook.Text);
                    double ShippingCharge = Convert.ToDouble(txtShipAddlBook.Text);
                    //Sql connection string set
                    SqlConnection conn = new SqlConnection(@"Data Source=NEHALAHMEDCCB3; Initial Catalog=MMABooks; Integrated Security=True");
                    conn.Open(); //open a connection
                    SqlCommand cmd = new SqlCommand("insert into MMABookTable values('" + taxRate + "', '" + firstBookCharge + "', '" + ShippingCharge + "');", conn); //create a query
                    cmd.ExecuteNonQuery(); //execute query
                    MessageBox.Show("Data Inserted Successfully"); //message to display data inserted
                    conn.Close();
                }
                catch (Exception ex) //display if error
                {
                    MessageBox.Show("Error in insertion, " + ex.Message + "\t" + ex.GetType());
                }
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtSalesTax) &&
                   Validator.IsDecimal(txtSalesTax) &&
                   Validator.IsPresent(txtShipFirstBook) &&
                   Validator.IsDecimal(txtShipFirstBook) &&
                   Validator.IsPresent(txtShipAddlBook) &&
                   Validator.IsDecimal(txtShipAddlBook);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    internal class OrderOptions
    {
    }
}
