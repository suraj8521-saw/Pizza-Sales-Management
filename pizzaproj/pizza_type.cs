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
    public partial class pizza_type : Form
    {
        public pizza_type()
        {
            InitializeComponent();
        }
        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";
         public void getpizzaid()
        {
            SqlConnection cn = new SqlConnection(scn);
            string pizid;
            string query = "select pizza_id from pizza_type order  by pizza_id Desc";
            cn.Open();

            SqlCommand com = new SqlCommand(query, cn);
            SqlDataReader sdr = com.ExecuteReader();
            if (sdr.Read())
            {
                Int32 id = int.Parse(sdr[0].ToString()) + 1;
                pizid = id.ToString("0000");
            }
            else if (Convert.IsDBNull(sdr))
            {
                pizid = ("0001");
            }
            else
            {
                pizid = ("0001");
            }
            cn.Close();
            textBox1.Text = pizid.ToString();
        }
         private void Dgrid()
         {
             SqlConnection cn = new SqlConnection(scn);
             cn.Close();
             cn.Open();
             SqlDataAdapter sda = new SqlDataAdapter();
             SqlCommand com = new SqlCommand("select* from pizza_type", cn);
             SqlDataReader sdr = com.ExecuteReader();
             dataGridView1.Rows.Clear();
             while (sdr.Read())
             {
                 dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2), sdr.GetValue(3), sdr.GetValue(4), sdr.GetValue(5));
             }
             cn.Close();

         }
        private void pizza_type_Load(object sender, EventArgs e)
        {
            getpizzaid();
            getquantityname();
           
            Dgrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            getquantityname();
        }
        private void getquantityname()
        {

             SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from stock  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();
         
          while(reader.Read())
            {

                comboBox3.Items.Add(reader["product_name"].ToString());
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into pizza_type values('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "','" + comboBox4.Text + "','" + comboBox2.Text + "')", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data savedddd");
            Dgrid();
            cn.Close();
            cn.Open();

            textBox1.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox3.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;
            comboBox2.Text = string.Empty;
            cn.Close();
            cn.Open();
            getpizzaid();
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("delete from pizza_type where pizza_id='" + textBox1.Text + "'", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data removed successfully");
            cn.Close();
            Dgrid();
            cn.Close();
            cn.Open();
            getpizzaid();
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
