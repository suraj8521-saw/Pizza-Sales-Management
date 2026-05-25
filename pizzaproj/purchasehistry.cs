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
    public partial class purchasehistry : Form
    {
        public purchasehistry()
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
            SqlCommand com = new SqlCommand("select* from purches", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2), sdr.GetValue(3), sdr.GetValue(4), sdr.GetValue(5), sdr.GetValue(6), sdr.GetValue(7), sdr.GetValue(8), sdr.GetValue(9), sdr.GetValue(10), sdr.GetValue(11), sdr.GetValue(12), sdr.GetValue(13), sdr.GetValue(14));
            }
            cn.Close();

        }
        private void purchasehistry_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            Dgrid();
          cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            main backmain = new main();
            backmain.Show();
            this.Hide();
        }
    }
}
