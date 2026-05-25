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
    public partial class suplierinfo : Form
    {
        public suplierinfo()
        {
            InitializeComponent();
        }

        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";
           public void getsuplierid()
        {
            SqlConnection cn = new SqlConnection(scn);
             string sids;
             string query = "select SID from suplierinfo order  by SID Desc";
            cn.Open();

            SqlCommand com = new SqlCommand(query, cn);
            SqlDataReader sdr = com.ExecuteReader();
            if (sdr.Read())
            {
                Int32 id = int.Parse(sdr[0].ToString()) + 1;
                sids = id.ToString("0000");
            }
            else if (Convert.IsDBNull(sdr))
            {
                sids = ("0001");
            }
            else
            {
                sids = ("0001");
            }
            cn.Close();
            textBox1.Text = sids.ToString();


        }

     
        private void Dgrid()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select SID ,Firm_Name,GST_Type,Address,Email ,Mobole_No from suplierinfo", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2), sdr.GetValue(3), sdr.GetValue(4), sdr.GetValue(5));
            }
            cn.Close();

        }
        private void suplierinfo_Load(object sender, EventArgs e)
        {
            Dgrid();
            getsuplierid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into Suplierinfo values('" +textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" +textBox4.Text + "','" + textBox5.Text + "')", cn);
            com.ExecuteNonQuery();
           
            MessageBox.Show("data savedddd");
            Dgrid();
            cn.Close();
            cn.Open();
            textBox2.Text=string.Empty;
            comboBox1.Text = string.Empty; 
            textBox3.Text = string.Empty; 
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            cn.Close();
            cn.Open();
            getsuplierid();
            cn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("delete from suplierinfo where SID='" + textBox1.Text + "'", cn);
            com.ExecuteNonQuery();
           
            MessageBox.Show("data removed successfully");
            cn.Close();
            Dgrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from suplierinfo where SID= '" + textBox1.Text + "' ", cn);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox1.Text = ds.Tables[0].Rows[0]["SID"].ToString();
                textBox2.Text = ds.Tables[0].Rows[0]["Firm_Name"].ToString();
                comboBox1.Text = ds.Tables[0].Rows[0]["GST_Type"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                textBox4.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0]["Mobole_No"].ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("update suplierinfo set SID ='" + textBox1.Text + "' , Firm_Name ='" + textBox2.Text + "' , GST_type='" + comboBox1.Text + "', Address='" + textBox3.Text + "', Email='" + textBox4.Text + "', Mobole_No='" + textBox5.Text + "'  where  SID='" + textBox1.Text + "'", cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("data updated successfully");
            
            Dgrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int ri = dataGridView1.CurrentCellAddress.Y;
            if (dataGridView1[6, ri].Selected)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                SqlCommand com = new SqlCommand("select * from suplierinfo where SID= '" + textBox1.Text + "' ", cn);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataSet da = new DataSet();
                sda.Fill(da);
                if (da.Tables[0].Rows.Count > 0)
                {
                    textBox1.Text = da.Tables[0].Rows[0]["SID"].ToString();
                    textBox2.Text = da.Tables[0].Rows[0]["Firm_Name"].ToString();
                    comboBox1.Text = da.Tables[0].Rows[0]["GST_Type"].ToString();
                    textBox3.Text = da.Tables[0].Rows[0]["Address"].ToString();
                    textBox4.Text = da.Tables[0].Rows[0]["Email"].ToString();
                    textBox5.Text = da.Tables[0].Rows[0]["Mobole_No"].ToString();

                }
                cn.Close();
            }

            if (dataGridView1[7, ri].Selected)
            {
                SqlConnection cn = new SqlConnection(scn);
                cn.Close();
                cn.Open();
                SqlCommand com = new SqlCommand("delete from suplierinfo where SID='" + textBox1.Text + "'", cn);
                com.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("data removed successfully");
                Dgrid();
            }
        }
       

       
       

      
    }
}
