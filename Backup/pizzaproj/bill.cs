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
    public partial class bill : Form
    {
        public bill()
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
            SqlCommand com = new SqlCommand("select* from sell", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView2.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView2.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2), sdr.GetValue(3), sdr.GetValue(4), sdr.GetValue(5), sdr.GetValue(6), sdr.GetValue(7), sdr.GetValue(8), sdr.GetValue(9));
            }
            cn.Close();

        }
        private void dgridquantity()
        {

            string fa = "1";
            string va = "0";
            dataGridView1.Rows[0].Cells[5].Value = fa;
            dataGridView1.Rows[0].Cells[7].Value = va;
            

        }
        private void bill_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            label15.Visible = false;
            getproductname();
            getbillid();
            getinvoiceno();
            dgridquantity();
            
            string ia = "-";
            dataGridView1.Rows[0].Cells[4].Value = ia;
            string j = "+";
            dataGridView1.Rows[0].Cells[6].Value = j;
            getsid();
            Dgrid();
            cn.Close();
            cn.Open();

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getproductname()
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct pizza_category from pizza_type  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox1.Items.Add(reader["pizza_category"].ToString());

            }
            cn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            dataGridView1.Rows[0].Cells[0].Value = a;
            textBox5.Text = a;

        }
        public void getbillid()
        {
            SqlConnection cn = new SqlConnection(scn);
            string pid;
            string query = "select bill_no from bill order  by bill_no Desc";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string b = textBox2.Text;
            dataGridView1.Rows[0].Cells[1].Value = b;
        }
        public void getinvoiceno()
        {
            SqlConnection cn = new SqlConnection(scn);
            string pid;
            string query = "select invoiceno from bill order  by invoiceno Desc";
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
            textBox2.Text = pid.ToString();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            label15.Visible = false;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();

            SqlCommand com1 = new SqlCommand("select product_name from pricemapingtable where product_name='" + comboBox1.Text + "'", cn);
            string a = (string)com1.ExecuteScalar();
            if (a == comboBox1.Text)
            {
                SqlCommand com3 = new SqlCommand("select amount from pricemapingtable where product_name='" + comboBox1.Text + "'", cn);
                double d = Convert.ToDouble(com3.ExecuteScalar());
                textBox3.Text = d.ToString();
            }
            else
            {

                textBox3.Text = "";
            }

            string f = comboBox1.Text;
            dataGridView1.Rows[0].Cells[3].Value = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string l = "no";
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into bill values('" + dataGridView1.Rows[0].Cells[0].Value + "','" + dataGridView1.Rows[0].Cells[1].Value + "','" + dataGridView1.Rows[0].Cells[2].Value + "','" + dataGridView1.Rows[0].Cells[3].Value + "','"+comboBox2.Text+"','" +Convert.ToDouble( dataGridView1.Rows[0].Cells[5].Value) + "','" +Convert.ToDouble( dataGridView1.Rows[0].Cells[7].Value) + "','"+l+"')", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data savedddd");
           
            cn.Close();
            cn.Open();
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            dataGridView1.Rows[0].Cells[0].Value = string.Empty;
            dataGridView1.Rows[0].Cells[1].Value = string.Empty;
            dataGridView1.Rows[0].Cells[3].Value = string.Empty;
            dataGridView1.Rows[0].Cells[7].Value = string.Empty;
            dataGridView1.Rows[0].Cells[5].Value = string.Empty;

            cn.Close();
            cn.Open();
            getbillid();
            getinvoiceno();
            dgridquantity();
            //getsid();
            cn.Close();
            cn.Open();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string c = dateTimePicker1.Text.ToString();

            dataGridView1.Rows[0].Cells[2].Value = c;

        }

        private void dateTimePicker1_VisibleChanged(object sender, EventArgs e)
        {

            string c = dateTimePicker1.Text.ToString();

            dataGridView1.Rows[0].Cells[2].Value = c;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            if (comboBox1.Text == "")
            {
                cn.Close();
                cn.Open();
                textBox3.Text = string.Empty;
                cn.Close();
                cn.Open();
                label15.Visible = true;
                cn.Close();
                cn.Open();
            }
            else
            {
                
                cn.Close();
                cn.Open();
                string g = textBox3.Text;
                dataGridView1.Rows[0].Cells[7].Value = g;
              
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            int ri = dataGridView1.CurrentCellAddress.Y;
            double n = Convert.ToDouble(dataGridView1.Rows[ri].Cells[5].Value);

            string u = textBox3.Text;

            if (textBox3.Text == "")
            {

                MessageBox.Show("Select Pizza type first");
            }
            else
            {
                double x = Convert.ToDouble(textBox3.Text);

                if (dataGridView1[4, ri].Selected)
                {


                    double q = Convert.ToDouble(dataGridView1.Rows[ri].Cells[7].Value);
                    
                    cn.Close();
                    cn.Open();
                    Int32 m = 1;
                    double o = n - m;
                    string p = o.ToString();
                    if (o == 0)
                    {
                        MessageBox.Show("quantity cant be less than 1");
                    }
                    else
                    {
                        dataGridView1.Rows[ri].Cells[5].Value = p;
                        double h = q - x;
                        dataGridView1.Rows[ri].Cells[7].Value = h;
                        tamtcalc();
                        cn.Close();
                        cn.Open();
                        if (h!=0 )
                        {


                            updatevalue();
                            tamtcalc();

                        }
                       
                    }


                }

                if (dataGridView1[6, ri].Selected)
                {
                    double q = Convert.ToDouble(dataGridView1.Rows[ri].Cells[7].Value);

                    Int32 m = 1;
                    double o = n + m;
                    string p = o.ToString();
                    dataGridView1.Rows[ri].Cells[5].Value = p;
                    double h = q + x;
                    dataGridView1.Rows[ri].Cells[7].Value = h;
                    cn.Close();
                    cn.Open();
                    updatevalue();
                    tamtcalc();


                }




                if (dataGridView1[8, ri].Selected)
                {

                    string l = "no";
                   
                    cn.Close();
                    cn.Open();
                    SqlCommand com = new SqlCommand("insert into bill values('" + dataGridView1.Rows[0].Cells[0].Value + "','" + dataGridView1.Rows[0].Cells[1].Value + "','" + dataGridView1.Rows[0].Cells[2].Value + "','" + dataGridView1.Rows[0].Cells[3].Value + "','" + comboBox2.Text + "','" + Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value) + "','" + Convert.ToDouble(dataGridView1.Rows[0].Cells[7].Value) + "','" + l + "')", cn);
                    com.ExecuteNonQuery();
                    MessageBox.Show("data savedddd");
                    cn.Close();
                    cn.Open();
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    dataGridView1.Rows[0].Cells[0].Value = string.Empty;
                    dataGridView1.Rows[0].Cells[1].Value = string.Empty;
                    dataGridView1.Rows[0].Cells[3].Value = string.Empty;
                    dataGridView1.Rows[0].Cells[7].Value = string.Empty;
                    dataGridView1.Rows[0].Cells[5].Value = string.Empty;
                    cn.Close();
                    cn.Open();
                    getbillid();
                    getinvoiceno();
                    dgridquantity();
                    cn.Close();
                    cn.Open();

                }

            }
            cn.Close();
            cn.Open();
           
            SqlCommand com1 = new SqlCommand("select invoiceno from bill where bill_no='" + textBox5.Text + "'", cn);
            SqlDataAdapter sda = new SqlDataAdapter(com1);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox6.Text = ds.Tables[0].Rows[0]["invoiceno"].ToString();
                label16.Visible = false;

            }
            else
            {
                label16.Visible = true;
                textBox6.Text = "no details";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void getsid()
        {
            SqlConnection cn = new SqlConnection(scn);
            string pid;
            string query = "select sid from sell order  by sid Desc";
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
            textBox4.Text = pid.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com3 = new SqlCommand("select sid from sell where bill_no='" + textBox5.Text + "'", cn);
            SqlDataAdapter ssda = new SqlDataAdapter(com3);
            DataSet dss = new DataSet();
            ssda.Fill(dss);
            if (dss.Tables[0].Rows.Count > 0)
            {
                textBox4.Text = dss.Tables[0].Rows[0]["sid"].ToString();
               

            }
            else
            {
                getsid();
            }
            SqlCommand com1 = new SqlCommand("select invoiceno from bill where bill_no='" + textBox5.Text + "'", cn);
            SqlDataAdapter sda = new SqlDataAdapter(com1);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox6.Text = ds.Tables[0].Rows[0]["invoiceno"].ToString();
                label16.Visible = false;

            }
            else
            {
                label16.Visible=true;
                textBox6.Text = "no details";
            }
            tamtcalc();
        }
        private void insertvaliue()
        {
            string l = "no";
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into bill values('" + dataGridView1.Rows[0].Cells[0].Value + "','" + dataGridView1.Rows[0].Cells[1].Value + "','" + dataGridView1.Rows[0].Cells[2].Value + "','" + dataGridView1.Rows[0].Cells[3].Value + "','" + comboBox2.Text + "','" + Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value) + "','" + Convert.ToDouble(dataGridView1.Rows[0].Cells[7].Value) + "','" + l + "')", cn);
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
            SqlCommand com = new SqlCommand("update bill set bill_no ='" + dataGridView1.Rows[0].Cells[0].Value + "' , invoiceno ='" + dataGridView1.Rows[0].Cells[1].Value + "' , invoice_date='" + dataGridView1.Rows[0].Cells[2].Value + "', product_name='" + dataGridView1.Rows[0].Cells[3].Value + "', quantity_type='" + comboBox2.Text + "', quantity='" + Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value) + "',amount='" + Convert.ToDouble(dataGridView1.Rows[0].Cells[7].Value) + "',status='" + l + "'  where  bill_no='" + dataGridView1.Rows[0].Cells[0].Value + "'", cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("data updated successfully");
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand checkprime = new SqlCommand("select bill_no from bill where bill_no='" + dataGridView1.Rows[0].Cells[0].Value + "'", cn);
            string m = (string)checkprime.ExecuteScalar();
            double id = Convert.ToDouble(m);
            double qn= Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value);
            double am = Convert.ToDouble(dataGridView1.Rows[0].Cells[7].Value);
            string lid = Convert.ToString( dataGridView1.Rows[0].Cells[0].Value);
            double lidd = Convert.ToDouble(lid);
            if (id==lidd)
            {
            }
            else
            {
                if (qn == 1 && am > 0)
                {
                    insertvaliue();
                }
            }
             cn.Close();
            cn.Open();

            SqlCommand com1 = new SqlCommand("select invoiceno from bill where bill_no='" + textBox5.Text + "'", cn);
            SqlDataAdapter sda = new SqlDataAdapter(com1);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox6.Text = ds.Tables[0].Rows[0]["invoiceno"].ToString();
                label16.Visible = false;

            }
            else
            {
                label16.Visible = true;
                textBox6.Text = "no details";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand checkprime = new SqlCommand("select bill_no from bill where bill_no='" + dataGridView1.Rows[0].Cells[0].Value + "'", cn);
            string m = (string)checkprime.ExecuteScalar();
            double id = Convert.ToDouble(m);
            double qn = Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value);
            double am = Convert.ToDouble(dataGridView1.Rows[0].Cells[7].Value);
            string lid = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
            double lidd = Convert.ToDouble(lid);
            if (id == lidd)
            {
                updatevalue();
            }
            else
            {
                if (qn == 1 && am > 0)
                {
                    insertvaliue();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label15.Visible = false;
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            
            comboBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox2.Text = string.Empty;
            dataGridView1.Rows[0].Cells[7].Value = 0;
            cn.Close();
            cn.Open();
            getbillid();
            getinvoiceno();
            cn.Close();
            cn.Open();


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand checkprime = new SqlCommand("select bill_no from bill where bill_no='" + textBox5.Text + "'", cn);
            string m = (string)checkprime.ExecuteScalar();
            double id = Convert.ToDouble(m);
            string g = textBox5.Text;
            double f = Convert.ToDouble(g);
            if(id==f)
            {
                tamtcalc();
            }
            else{
                MessageBox.Show("please select correct bill id to calculate the gst and amount");
                textBox10.Text = string.Empty;
                textBox11.Text = string.Empty;
            }
        }
        private void tamtcalc()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            string g = textBox10.Text;
            
            SqlCommand getamt = new SqlCommand("select amount from bill where bill_no='" + textBox5.Text + "'", cn);
            double d = Convert.ToDouble(getamt.ExecuteScalar());
            if (g == "")
            {
                textBox11.Text = d.ToString();
            }


           // double d = Convert.ToDouble(c);
            else
            {
                double f = Convert.ToDouble(g);
                double gstamt = ((d * f) / 100);
                double tamt = gstamt + d;
                textBox11.Text = tamt.ToString();
            }
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            string l = "yes";
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand checksid = new SqlCommand("select bill_no from bill where bill_no='" + textBox5.Text + "'", cn);
            string n = (string)checksid.ExecuteScalar();
            double id = Convert.ToDouble(n);
            string r= Convert.ToString( textBox4.Text);
            double s=Convert.ToDouble(r);
            if(id==s)
            {
                MessageBox.Show("this customer bill and sell record  has been updated");
            }
            else{
            SqlCommand sellinsert = new SqlCommand("select product_name from bill where bill_no='" + textBox5.Text + "'", cn);
            string x = (string)sellinsert.ExecuteScalar();
            SqlCommand com = new SqlCommand("insert into sell values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + x + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + l + "')", cn);
            com.ExecuteNonQuery();

            MessageBox.Show("data savedddd");
            cn.Close();
            cn.Open();

            SqlCommand com2 = new SqlCommand("update bill set status='" + l + "'  where  bill_no='" + textBox5.Text + "'", cn);
            com2.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("data updated successfully");
            cn.Close();
            cn.Open();
        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            pendingbill pending = new pendingbill();
            pending.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // Int32 row = 1;
           // textBox11.Text = string.Empty;

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

      
        
    }
  }

    

