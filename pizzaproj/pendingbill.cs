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
    public partial class pendingbill : Form
    {
        public pendingbill()
        {
            InitializeComponent();
        }
        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";
        private void Dgrid()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select bill_no ,invoiceno,invoice_date,product_name,quantity_type ,quantity,amount ,status from bill", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1),((DateTime) sdr.GetValue(2)).ToString("dd MMM yyyy"), sdr.GetValue(3), sdr.GetValue(4), "-", sdr.GetValue(5), "+", sdr.GetValue(6), sdr.GetValue(7));
            }
            cn.Close();

        }
        private void Dgrid1()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select bill_no ,invoiceno,invoice_date,product_name,quantity_type ,quantity,amount ,status from bill where status='" + "no" + "'", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), ((DateTime)sdr.GetValue(2)).ToString("dd MMM yyyy"), sdr.GetValue(3), sdr.GetValue(4), "-", sdr.GetValue(5), "+", sdr.GetValue(6), sdr.GetValue(7));
            }
            cn.Close();

        }
        private void Dgrid2()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select bill_no ,invoiceno,invoice_date,product_name,quantity_type ,quantity,amount ,status from bill where status='" + "yes" + "'", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), ((DateTime)sdr.GetValue(2)).ToString("dd MMM yyyy"), sdr.GetValue(3), sdr.GetValue(4), "-", sdr.GetValue(5), "+", sdr.GetValue(6), sdr.GetValue(7));
            }
            cn.Close();

        }
        private void Dgrid3()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select bill_no ,invoiceno,invoice_date,product_name,quantity_type,quantity,amount ,status from bill where bill_no='" + comboBox1.Text + "'", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), ((DateTime)sdr.GetValue(2)).ToString("dd MMM yyyy"), sdr.GetValue(3), sdr.GetValue(4), "-", sdr.GetValue(5), "+", sdr.GetValue(6), sdr.GetValue(7));
            }
            cn.Close();

        }

        private void pendingbill_Load(object sender, EventArgs e)
        {
            getbillid();
            Dgrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getbillid()
        { 
        SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct bill_no from bill where status='"+"no"+"' ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox1.Items.Add(reader["bill_no"].ToString());
            }
            cn.Close();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Dgrid3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dgrid1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dgrid2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dgrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            int ri = dataGridView1.CurrentCellAddress.Y;
            if (dataGridView1[10, ri].Selected)
            {

                cn.Close();
                cn.Open();
                SqlCommand com = new SqlCommand("delete from bill where bill_no='" + dataGridView1.Rows[ri].Cells[0].Value + "'", cn);
                com.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("data removed successfully");
                dataGridView1.Rows[ri].Cells[0].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[1].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[2].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[3].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[4].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[5].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[6].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[7].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[8].Value = string.Empty;
                dataGridView1.Rows[ri].Cells[9].Value = string.Empty;

            }
            if (dataGridView1[5, ri].Selected)
            {
                double a = Convert.ToDouble(dataGridView1.Rows[ri].Cells[6].Value);
                if (a == 1)
                {
                    MessageBox.Show("quantity cant be less than 1");
                }
                else
                {
                    double b = a - 1;
                    dataGridView1.Rows[ri].Cells[5].Value = b;
                    cn.Close();
                    cn.Open();


                }
            }
            if (dataGridView1[7, ri].Selected)
            {
                double a = Convert.ToDouble(dataGridView1.Rows[ri].Cells[6].Value);
                
                    double b = a + 1;
                    dataGridView1.Rows[ri].Cells[6].Value = b;
                   
                    cn.Close();
                    cn.Open();
                    SqlCommand com = new SqlCommand("update bill set bill_no ='" + dataGridView1.Rows[ri].Cells[0].Value + "' , invoiceno ='" + dataGridView1.Rows[ri].Cells[1].Value + "' , invoice_date='" + dataGridView1.Rows[ri].Cells[2].Value + "', product_name='" + dataGridView1.Rows[ri].Cells[3].Value + "', quantity_type='" + dataGridView1.Rows[ri].Cells[4].Value + "', quantity='" + Convert.ToDouble(dataGridView1.Rows[ri].Cells[6].Value) + "',amount='" + Convert.ToDouble(dataGridView1.Rows[ri].Cells[8].Value) + "',status='" + dataGridView1.Rows[ri].Cells[9].Value + "'  where  bill_no='" + dataGridView1.Rows[ri].Cells[0].Value + "'", cn);
                    com.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("data updated successfully");
                

            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Dgrid3();
        }
        private void insertvaliue()
        {
            string l = "no";
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into bill values('" + dataGridView1.Rows[0].Cells[0].Value + "','" + dataGridView1.Rows[0].Cells[1].Value + "','" + dataGridView1.Rows[0].Cells[2].Value + "','" + dataGridView1.Rows[0].Cells[3].Value + "','" + "" + "','" + Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value) + "','" + Convert.ToDouble(dataGridView1.Rows[0].Cells[7].Value) + "','" + l + "')", cn);
            com.ExecuteNonQuery();
            MessageBox.Show("data savedddd");
            cn.Close();
            cn.Open();
            button3.Visible = true;


        }
        private void updatevalue()
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            string l = "no";
            SqlCommand com = new SqlCommand("update bill set bill_no ='" + dataGridView1.Rows[0].Cells[0].Value + "' , invoiceno ='" + dataGridView1.Rows[0].Cells[1].Value + "' , invoice_date='" + dataGridView1.Rows[0].Cells[2].Value + "', product_name='" + dataGridView1.Rows[0].Cells[3].Value + "', quantity_type='" + "" + "', quantity='" + Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value) + "',amount='" + Convert.ToDouble(dataGridView1.Rows[0].Cells[7].Value) + "',status='" + l + "'  where  bill_no='" + dataGridView1.Rows[0].Cells[0].Value + "'", cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("data updated successfully");
        }
        }
    }

