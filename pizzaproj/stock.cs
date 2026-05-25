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
    public partial class stock : Form
    {
        public stock()
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
            SqlCommand com = new SqlCommand("select* from stock", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2));
            }
            cn.Close();

        }
        private void stock_Load(object sender, EventArgs e)
        {
           
            Dgrid();
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
