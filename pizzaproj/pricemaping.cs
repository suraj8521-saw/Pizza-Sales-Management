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
    public partial class pricemaping : Form
    {
        public pricemaping()
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
            SqlCommand com = new SqlCommand("select priceid ,product_name,quantity_type,amount from pricemapingtable", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2), sdr.GetValue(3));
            }
            cn.Close();

        }

        
        public void getpid()
        {
            SqlConnection cn = new SqlConnection(scn);
            string pid;
            string query = "select priceid from pricemapingtable order  by priceid Desc";
            cn.Open();

            SqlCommand com = new SqlCommand(query, cn);
            SqlDataReader sdr = com.ExecuteReader();
            if (sdr.Read())
            {
                Int32 id = int.Parse(sdr[0].ToString()) + 1;
                pid = id.ToString("0000");
            }
            else if (Convert.IsDBNull(sdr))
            {
                pid = ("0001");
            }
            else
            {
                pid = ("0001");
            }
            cn.Close();
            textBox1.Text = pid.ToString();
        }

        private void pricemaping_Load(object sender, EventArgs e)
        {
            getpid();
            Dgrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into pricemapingtable values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + Convert.ToDouble(textBox3.Text) + "')", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data savedddd");
            Dgrid();
            cn.Close();
            cn.Open();
            textBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            cn.Close();
            cn.Open();
            getpid();
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
               SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("delete from pricemapingtable where priceid='" + textBox1.Text + "'", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data removed successfully");
            cn.Close();
            Dgrid();
            cn.Close();
            cn.Open();
            getpid();
            cn.Close();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from pricemapingtable where priceid= '" + textBox1.Text + "' ", cn);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox1.Text = ds.Tables[0].Rows[0]["priceid"].ToString();
                textBox2.Text = ds.Tables[0].Rows[0]["product_name"].ToString();
                comboBox1.Text = ds.Tables[0].Rows[0]["quantity_type"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["amount"].ToString();
               

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("update pricemapingtable set priceid ='" + textBox1.Text + "' , product_name ='" + textBox2.Text + "' , quantity_type='" + comboBox1.Text + "', amount='" + textBox3.Text + "' where priceid ='" + textBox1.Text + "'", cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("data updated successfully");

            Dgrid();
            cn.Close();
            cn.Open();
            textBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            cn.Close();
            cn.Open();

        }

    }
}
