using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;
using System.Data.OleDb;

namespace pizzaproj
{
    public partial class stock_search : Form
    {
        public stock_search()
        {
            InitializeComponent();
        }
        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com1 = new SqlCommand("select * from stock where product_name='" + comboBox1.Text + "'", cn);

            SqlCommand com2 = new SqlCommand("select  product_name from stock ", cn);
            SqlDataAdapter sd = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            
            {


                SqlCommand com3 = new SqlCommand("select quantity from stock where product_name='" + comboBox1.Text + "'", cn);
                double b = Convert.ToDouble(com3.ExecuteScalar());
                if (b==5||b>5)
                {

                    dataGridView1.ForeColor = Color.Green;
                    SqlDataReader sdr = com1.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (sdr.Read())
                    {

                        dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                    }
                    cn.Close();
                }
                else if (b > 1 || b==1)
                {
                    dataGridView1.ForeColor = Color.Orange;
                    SqlDataReader sdr = com1.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (sdr.Read())
                    {
                        dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                    }
                    cn.Close();
                }
                else if (b < 1)
                {
                    {
                        //dataGridView1.ForeColor = Color.Red;
                          dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
                       
                       
                        SqlDataReader sdr = com1.ExecuteReader();
                        dataGridView1.Rows.Clear();

                        while (sdr.Read())
                        {
                            dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                        }
                        cn.Close();
                    }
                }

                else
                {
                    MessageBox.Show("No Product record found");

                }
            }
            cn.Close();
            cn.Open();
            comboBox1.Text = string.Empty;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            
            
        }
        public void getproductname()
        {
            
                    SqlConnection cn = new SqlConnection(scn);
                    cn.Close();
                    cn.Open();
                    SqlCommand com = new SqlCommand("select  product_name from stock  ", cn);
                    SqlDataReader reader = com.ExecuteReader();
                    DataSet ds = new DataSet();

                    while (reader.Read())
                    {

                        comboBox1.Items.Add(reader["product_name"].ToString());

                    }
                    cn.Close();               
}

        private void stock_search_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            getproductname();
            cn.Close();
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            main backmain = new main();
            backmain.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.Hide();
            main backmain = new main();
            backmain.Show();
            this.Hide();
        }
    }
}
