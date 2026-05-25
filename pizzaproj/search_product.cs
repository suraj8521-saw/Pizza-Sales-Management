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
    public partial class search_product : Form
    {
        public search_product()
        {
            InitializeComponent();
        }
        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";

        private void Dgrid()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text+ "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid2()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid3()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where category_type='" + comboBox3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }

        private void Dgrid4()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid5()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
           
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where invoice_date='" + dateTimePicker1.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid6()
        {
            double d=0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();

            
            
                while (sdr.Read())
                {
                    dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                    d++;
                }
                cn.Close();
                if (d <1)
                {
                    MessageBox.Show("no item found");
                }
                
        }
        private void Dgrid7()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND category_type='" + comboBox3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid8()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid9()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid10()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' AND invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid11()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid12()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid13()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' AND invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid14()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid15()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        } 
        private void Dgrid16()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid17()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid18()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();



            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid19()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where category_type='" + comboBox3.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid20()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid21()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid22()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid23()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' AND invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid24()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid25()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid26()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND category_type='" + comboBox3.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid27()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid28()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid29()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid30()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' AND invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid31()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        private void Dgrid32()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' AND Firm_Name='" + comboBox2.Text + "' AND category_type='" + comboBox3.Text + "' AND invoiceno='" + comboBox4.Text + "' AND invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }
        }
        public void getproductname()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct product_name from purches  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox1.Items.Add(reader["product_name"].ToString());
            }
            cn.Close();
        }

      

        private void comboBox1_Click(object sender, EventArgs e)
        {
         comboBox1.Text = string.Empty;
        }
        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = string.Empty;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            
            if ( checkBox1.Checked)
            {
               
                comboBox1.Visible = true;
                
            }
                 
            else 
            {
                comboBox1.Visible = false;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {

                comboBox2.Visible = true;

            }

            else
            {
                comboBox2.Visible = false;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {

                comboBox3.Visible = true;

            }

            else
            {
                comboBox3.Visible = false;
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {

                comboBox4.Visible = true;

            }

            else
            {
                comboBox4.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {

                dateTimePicker1.Visible = true;


            }

            else
            {
                dateTimePicker1.Visible = false;
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox3.Text = string.Empty;
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            comboBox4.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked&&checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid32();
                cn.Close();
                cn.Open();
            }


           else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid16();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid31();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox2.Checked && checkBox4.Checked && checkBox5.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid30();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox3.Checked && checkBox4.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid29();
                cn.Close();
                cn.Open();
            }
            else if (checkBox2.Checked && checkBox3.Checked && checkBox4.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid28();
                cn.Close();
                cn.Open();
            }

            else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid12();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox2.Checked && checkBox4.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid13();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox2.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid27();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox3.Checked && checkBox4.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid14();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox3.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid26();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox4.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid25();
                cn.Close();
                cn.Open();
            }
            else if (checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid15();
                cn.Close();
                cn.Open();
            }

            else if (checkBox2.Checked && checkBox3.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid24();
                cn.Close();
                cn.Open();
            }
            else if (checkBox2.Checked && checkBox4.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid23();
                cn.Close();
                cn.Open();
            }
            else if (checkBox3.Checked && checkBox4.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid22();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {

                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid6();
                cn.Close();
                cn.Open();

            }
            else if (checkBox1.Checked && checkBox3.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid7();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox4.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid8();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid21();
                cn.Close();
                cn.Open();
            }
            else if (checkBox2.Checked && checkBox3.Checked)
            {

                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid9();
                cn.Close();
                cn.Open();
            }
            else if (checkBox2.Checked && checkBox4.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid10();
                cn.Close();
                cn.Open();
            }
            else if (checkBox2.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid20();
                cn.Close();
                cn.Open();
            }
            else if (checkBox3.Checked && checkBox4.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid11();
                cn.Close();
                cn.Open();
            }
            else if (checkBox3.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid19();
                cn.Close();
                cn.Open();
            }
            else if (checkBox4.Checked && checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid18();
                cn.Close();
                cn.Open();
            }
            else if (checkBox1.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid();
                cn.Close();
                cn.Open();
            }
            else if (checkBox2.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid2();
                cn.Close();
                cn.Open();
            }
            else if (checkBox3.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid3();
                cn.Close();
                cn.Open();
            }
            else if (checkBox4.Checked)
            {

                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid4();
                cn.Close();
                cn.Open();
            }
            else if (checkBox5.Checked)
            {

                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid5();
                cn.Close();
                cn.Open();
            }
            else if (checkBox6.Checked)
            {

                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid17();
                cn.Close();
                cn.Open();
            }
            else
            {
                MessageBox.Show("an error occured");
            }
        }

        private void search_product_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            getproductname();
            getfirname();
            getinvoiceno();
            getcategory();
            cn.Close();
            cn.Open();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getfirname()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct Firm_Name from purches  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox2.Items.Add(reader["Firm_Name"].ToString());
            }
            cn.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getinvoiceno()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct invoiceno from purches  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox4.Items.Add(reader["invoiceno"].ToString());
            }
            cn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getcategory()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct category_type from purches  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox3.Items.Add(reader["category_type"].ToString());
            }
            cn.Close();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            main backmain = new main();
            backmain.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main backmain = new main();
            backmain.ShowDialog();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {

                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;



            }

            else
            {
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
            }
        }

        private void Dgrid33()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid34()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid35()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "' OR category_type='" + comboBox3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid36()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "' OR category_type='" + comboBox3.Text + "' OR invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid37()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "' OR category_type='" + comboBox3.Text + "' OR invoiceno='" + comboBox4.Text + "' OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }

        private void Dgrid38()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where Firm_Name='" + comboBox2.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid39()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where  Firm_Name='" + comboBox2.Text + "' OR category_type='" + comboBox3.Text + "'", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid40()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where  Firm_Name='" + comboBox2.Text + "' OR category_type='" + comboBox3.Text + "' OR invoiceno='" + comboBox4.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid41()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where  Firm_Name='" + comboBox2.Text + "' OR category_type='" + comboBox3.Text + "' OR invoiceno='" + comboBox4.Text + "' OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid42()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select product_name, quantity ,quantity_type from purches where category_type='" + comboBox3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid43()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where   category_type='" + comboBox3.Text + "' OR invoiceno='" + comboBox4.Text + "'", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid44()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where   category_type='" + comboBox3.Text + "' OR invoiceno='" + comboBox4.Text + "' OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid45()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where    invoiceno='" + comboBox4.Text + "'", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid46()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where    invoiceno='" + comboBox4.Text + "' OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid47()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where      invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid48()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "' OR category_type='" + comboBox3.Text + "'  OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid50()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "'  OR invoiceno='" + comboBox4.Text + "' OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid51()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "'  OR invoiceno='" + comboBox4.Text + "'   ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid52()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR category_type='" + comboBox3.Text + "' OR invoiceno='" + comboBox4.Text + "' OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid53()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR category_type='" + comboBox3.Text + "'  OR invoiceno='" + comboBox4.Text + "'   ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid54()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR category_type='" + comboBox3.Text + "'  OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'     ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid55()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR category_type='" + comboBox3.Text + "'", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid56()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR Firm_Name='" + comboBox2.Text + "' OR   invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid57()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR invoiceno='" + comboBox4.Text + "' OR   invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid58()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "' OR invoiceno='" + comboBox4.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid59()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where   Firm_Name='" + comboBox2.Text + "'OR category_type='" + comboBox3.Text + "'  OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'     ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid60()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where  Firm_Name='" + comboBox2.Text + "'  OR invoiceno='" + comboBox4.Text + "' OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid61()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where  Firm_Name='" + comboBox2.Text + "'  OR invoiceno='" + comboBox4.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid62()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where  Firm_Name='" + comboBox2.Text + "' OR   invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid63()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where    category_type='" + comboBox3.Text + "'  OR  invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'     ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void Dgrid64()
        {
            double d = 0;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select  product_name, quantity ,quantity_type from purches where product_name='" + comboBox1.Text + "'  OR   invoice_date between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'  ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
                d++;
            }
            cn.Close();
            cn.Close();
            if (d < 1)
            {
                MessageBox.Show("no item found");
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    if (checkBox3.Checked)
                   {
                        if (checkBox4.Checked)
                       {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid37();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                    cn.Close();
                                    cn.Open();
                                    Dgrid36();
                                    cn.Close();
                                    cn.Open();
                                   }
                         
                       }

                        else
                        {
                            if(checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid48();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                            SqlConnection cn = new SqlConnection(scn);
                            cn.Close();
                            cn.Open();
                            Dgrid35();
                            cn.Close();
                            cn.Open();
                            }
                        }
                    }
                    else
                    {
                        if (checkBox4.Checked)
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid50();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid51();
                                cn.Close();
                                cn.Open();
                            }
                        }
                        else
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid56();
                                cn.Close();
                                cn.Open();

                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid34();
                                cn.Close();
                                cn.Open();
                            }
                        }
                    }
                }
                else
                {
                    if (checkBox3.Checked)
                    {
                        if (checkBox4.Checked)
                        {
                            if (checkBox6.Checked)
                            {

                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid52();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid53();
                                cn.Close();
                                cn.Open();
                            }
                        }
                        else 
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid54();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {

                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid55();
                                cn.Close();
                                cn.Open();
                            }
                        }
                    }                                                             
                    else
                    {
                        if (checkBox4.Checked)
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid57();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid58();
                                cn.Close();
                                cn.Open();
                            
                            }
                        }
                        else
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid64();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid33();
                                cn.Close();
                                cn.Open();
                            }
                        }
                    }
                }
            }

            else  if (checkBox2.Checked)
                {
                    if (checkBox3.Checked)
                    {
                        if (checkBox4.Checked)
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid41();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid40();
                                cn.Close();
                                cn.Open();
                            }
                        }

                        else
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid59();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid39();
                                cn.Close();
                                cn.Open();
                            }
                        }
                    }
                    else
                    {
                        if (checkBox4.Checked)
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid60();
                                cn.Close();
                                cn.Open();
                            }
                            else 
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid61();
                                cn.Close();
                                cn.Open();
                            }
                        }
                        else
                        {
                            if (checkBox6.Checked)
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid62();
                                cn.Close();
                                cn.Open();
                            }
                            else
                            {
                                SqlConnection cn = new SqlConnection(scn);
                                cn.Close();
                                cn.Open();
                                Dgrid38();
                                cn.Close();
                                cn.Open();
                            }
                        }
                    }
                }


            else if (checkBox3.Checked)
            {
                if (checkBox4.Checked)
                {
                    if (checkBox6.Checked)
                    {
                        SqlConnection cn = new SqlConnection(scn);
                        cn.Close();
                        cn.Open();
                        Dgrid44();
                        cn.Close();
                        cn.Open();
                    }
                    else 
                    {
                        SqlConnection cn = new SqlConnection(scn);
                        cn.Close();
                        cn.Open();
                        Dgrid43();
                        cn.Close();
                        cn.Open();
                    }
                }
                else
                {
                    if (checkBox6.Checked)
                    {
                        SqlConnection cn = new SqlConnection(scn);
                        cn.Close();
                        cn.Open();
                        Dgrid63();
                        cn.Close();
                        cn.Open();
                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(scn);
                        cn.Close();
                        cn.Open();
                        Dgrid42();
                        cn.Close();
                        cn.Open();
                    }
                }
            
            }
            else if(checkBox4.Checked)
            {
                if (checkBox6.Checked)
                {
                    SqlConnection cn = new SqlConnection(scn);
                    cn.Close();
                    cn.Open();
                    Dgrid46();
                    cn.Close();
                    cn.Open();
                }
                else
                {
                    SqlConnection cn = new SqlConnection(scn);
                    cn.Close();
                    cn.Open();
                    Dgrid45();
                    cn.Close();
                    cn.Open();
                }
            }

            else if (checkBox6.Checked)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                Dgrid47();
                cn.Close();
                cn.Open();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

       

       

       

       

      

       

        
    }
}
