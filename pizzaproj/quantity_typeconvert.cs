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
    public partial class quantity_typeconvert : Form
    {
        public quantity_typeconvert()
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
            SqlCommand com = new SqlCommand("select* from quantity_typeconvert", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0));
            }
            cn.Close();

        }
        private void quantity_typeconvert_Load(object sender, EventArgs e)
        {
            Dgrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into quantity_typeconvert values('" + comboBox1.Text + "')", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data savedddd");
            Dgrid();
            cn.Close();
            cn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("delete from quantity_typeconvert where type_quantity='" + comboBox1.Text + "'", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data removed successfully");
            cn.Close();
            cn.Open();
            Dgrid();
            cn.Close();
            
        
        }
    }
}
