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
    public partial class misclanious : Form
    {
        public misclanious()
        {
            InitializeComponent();
        }

        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";
        public void getcategoryid()
        {
            SqlConnection cn = new SqlConnection(scn);
            string catid;
            string query = "select cat_id from category order  by cat_id Desc";
            cn.Open();

            SqlCommand com = new SqlCommand(query, cn);
            SqlDataReader sdr = com.ExecuteReader();
            if (sdr.Read())
            {
                Int32 id = int.Parse(sdr[0].ToString()) + 1;
                catid = id.ToString("0000");
            }
            else if (Convert.IsDBNull(sdr))
            {
                catid = ("0001");
            }
            else
            {
                catid = ("0001");
            }
            cn.Close();
            textBox1.Text = catid.ToString();


        }
        public void quantityid()
        {
            SqlConnection cn = new SqlConnection(scn);
            string qid;
            string query = "select quantity_id from quantity order  by quantity_id Desc";
            cn.Open();

            SqlCommand com = new SqlCommand(query, cn);
            SqlDataReader sdr = com.ExecuteReader();
            if (sdr.Read())
            {
                Int32 id = int.Parse(sdr[0].ToString()) + 1;
                qid = id.ToString("0000");
            }
            else if (Convert.IsDBNull(sdr))
            {
                qid = ("0001");
            }
            else
            {
                qid = ("0001");
            }
            cn.Close();
            textBox2.Text = qid.ToString();


        }
        private void Dgrid()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select *from category", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
           
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1));
            }
            cn.Close();
        }
        private void Dgrid2()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Open();
            SqlDataAdapter sdb = new SqlDataAdapter();
            SqlCommand con = new SqlCommand("select *from quantity", cn);
            SqlDataReader sdc = con.ExecuteReader();
          
            dataGridView2.Rows.Clear();
            while (sdc.Read())
            {
                dataGridView2.Rows.Add(sdc.GetValue(0), sdc.GetValue(1));
            }
            cn.Close();

        }
       

        private void misclanious_Load(object sender, EventArgs e)
        {
            getcategoryid();
            Dgrid();
            quantityid();
            Dgrid2();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into category values('" + textBox1.Text + "','" + comboBox1.Text + "')", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data savedddd");
            Dgrid();
            cn.Close();
            cn.Open();
            comboBox1.Text = string.Empty;
            cn.Close();
            cn.Open();
            getcategoryid();
            cn.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into quantity values('" + textBox2.Text + "','" + comboBox2.Text + "')", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data savedddd");
            Dgrid2();
            cn.Close();
            cn.Open();
            
            comboBox2.Text = string.Empty;
            cn.Close();
            cn.Open();
            quantityid();
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("delete from category where cat_id='" + textBox1.Text + "'", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data removed successfully");
            cn.Close();
            Dgrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int ri = dataGridView1.CurrentCellAddress.Y;
            if (dataGridView1[2, ri].Selected)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                SqlCommand com = new SqlCommand("delete from category where cat_id='" + textBox1.Text + "'", cn);
                com.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("data removed successfully");
                Dgrid();
                cn.Close();
                cn.Open();
                getcategoryid();
                cn.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            int ri = dataGridView2.CurrentCellAddress.Y;
            if (dataGridView2[2, ri].Selected)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                SqlCommand com = new SqlCommand("delete from quantity where quantity_id='" + textBox2.Text + "'", cn);
                com.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("data removed successfully");
                Dgrid2();
                cn.Close();
                cn.Open();
                quantityid();
                cn.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            purches quantityshow = new purches();
            quantityshow.ShowDialog();
            this.Hide();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            main backmain = new main();
            backmain.ShowDialog();
            this.Hide();
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
