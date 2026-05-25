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
    public partial class purches : Form
    {
        public purches()
        {
            InitializeComponent();
        }
        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";

        public void getpurchesid()
        {
            SqlConnection cn = new SqlConnection(scn);
            string pid;
            string query = "select purches_id from purches order  by purches_id Desc";
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

        public void getinvoiceno()
        {
            SqlConnection cn = new SqlConnection(scn);
            string invno;
            string query = "select invoiceno from purches order  by invoiceno Desc";
            cn.Open();

            SqlCommand com = new SqlCommand(query, cn);
            SqlDataReader sdr = com.ExecuteReader();
            if (sdr.Read())
            {
                Int32 id = int.Parse(sdr[0].ToString()) + 1;
                invno = id.ToString("0000");
            }
            else if (Convert.IsDBNull(sdr))
            {
                invno = ("0001");
            }
            else
            {
                invno = ("0001");
            }
            cn.Close();
            textBox2.Text = invno.ToString();


        }
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
        private void purches_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            Dgrid();
            getpurchesid();
            getinvoiceno();
            getproductname();
            getquantitytype();
            getcategory();
            cn.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            
                
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();

            SqlCommand checkprime = new SqlCommand("select purches_id from purches where purches_id='" + textBox1.Text + "'", cn);
            string m =(string)checkprime.ExecuteScalar();
            if (m == textBox1.Text)
            {
                MessageBox.Show("already exist purches_id");
                getpurchesid();
            }


            else
            {
                SqlCommand com9 = new SqlCommand("select type_quantity from quantity_typeconvert where type_quantity='" + comboBox2.Text + "'", cn);
                string n = (string)com9.ExecuteScalar();
                   
                
               if (comboBox2.Text ==n)
               {
                   double x = Convert.ToDouble(textBox6.Text);
                   double c = (x / 1000);

                   SqlCommand com = new SqlCommand("insert into purches values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox11.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + Convert.ToDouble(textBox5.Text) + "','" + Convert.ToDouble(textBox6.Text) + "','" + Convert.ToDouble(textBox7.Text) + "','" + Convert.ToDouble(textBox8.Text) + "','" + Convert.ToDouble(textBox9.Text) + "','" + Convert.ToDouble(textBox10.Text) + "','" + comboBox4.Text + "')", cn);
                   SqlCommand com1 = new SqlCommand("select product_name from stock where product_name='" + comboBox3.Text + "'", cn);
                    string a = (string)com1.ExecuteScalar();
                    if (a == comboBox3.Text)
                    {
                        SqlCommand com3 = new SqlCommand("select quantity from stock where product_name='" + comboBox3.Text + "'", cn);
                        double b = Convert.ToDouble(com3.ExecuteScalar());
                        double f = b + c;
                        SqlCommand com10 = new SqlCommand("select quantity_type from stock where product_name='" + comboBox3.Text + "'", cn);
                        string z = (string)com10.ExecuteScalar();
                        SqlCommand com2 = new SqlCommand("update stock set product_name ='" + comboBox3.Text + "', quantity='" + f + "',quantity_type='" + z + "' where  product_name='" + comboBox3.Text + "'", cn);
                        com2.ExecuteNonQuery();
                        com10.ExecuteNonQuery();
                    }
                    else
                    {
                       SqlCommand com2 = new SqlCommand(" insert into stock values('" + comboBox3.Text + "','" + c + "','" + comboBox2.Text + "')", cn);
                       com2.ExecuteNonQuery();
                    }
                    com9.ExecuteNonQuery();
                   com.ExecuteNonQuery();
                   MessageBox.Show("data savedddd");
                   Dgrid();
                   cn.Close();
                   cn.Open();
                   textBox11.Text = string.Empty;
                   textBox3.Text = string.Empty;
                   comboBox1.Text = string.Empty;
                   dateTimePicker1.Text = string.Empty;
                   comboBox3.Text = string.Empty;
                   comboBox2.Text = string.Empty;
                   textBox5.Text = string.Empty;
                   textBox6.Text = string.Empty;
                   textBox7.Text = string.Empty;
                   textBox8.Text = string.Empty;
                   textBox9.Text = string.Empty;
                   textBox10.Text = string.Empty;
                   comboBox4.Text = string.Empty;
                  
                   cn.Close();
                   cn.Open();
                   getpurchesid();
                    getinvoiceno();
                 cn.Close();
                }
                  
            
               else
                {
                    SqlCommand com = new SqlCommand("insert into purches values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox11.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + Convert.ToDouble(textBox5.Text) + "','" + Convert.ToDouble(textBox6.Text) + "','" + Convert.ToDouble(textBox7.Text) + "','" + Convert.ToDouble(textBox8.Text) + "','" + Convert.ToDouble(textBox9.Text) + "','" + Convert.ToDouble(textBox10.Text) + "','" + comboBox4.Text + "')", cn);
                    SqlCommand com1 = new SqlCommand("select product_name from stock where product_name='" + comboBox3.Text + "'", cn);
                    string a = (string)com1.ExecuteScalar();
                    if (a == comboBox3.Text)
                    {
                        SqlCommand com3 = new SqlCommand("select quantity from stock where product_name='" + comboBox3.Text + "'", cn);
                        double b = Convert.ToDouble(com3.ExecuteScalar());
                        double c = Convert.ToDouble(textBox6.Text);
                        double f = b + c;

                        SqlCommand com2 = new SqlCommand("update stock set product_name ='" + comboBox3.Text + "', quantity='" + f + "',quantity_type='" + comboBox2.Text + "' where  product_name='" + comboBox3.Text + "'", cn);
                        com2.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand com2 = new SqlCommand(" insert into stock values('" + comboBox3.Text + "','" + Convert.ToDouble(textBox6.Text) + "','" + comboBox2.Text + "')", cn);
                        com2.ExecuteNonQuery();
                    }
                    com.ExecuteNonQuery();
                    MessageBox.Show("data savedddd");
                    Dgrid();
                    cn.Close();
                    cn.Open();
                    textBox11.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    dateTimePicker1.Text = string.Empty;
                    comboBox3.Text = string.Empty;
                    comboBox2.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    textBox7.Text = string.Empty;
                    textBox8.Text = string.Empty;
                    textBox9.Text = string.Empty;
                    textBox10.Text = string.Empty;
                    comboBox4.Text = string.Empty;
                  
                    cn.Close();
                    cn.Open();
                    getpurchesid();
                    getinvoiceno();
                    cn.Close();

                }
            }
      }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("delete from purches where purches_id='" + textBox1.Text + "'", cn);
            
            SqlCommand com1 = new SqlCommand("select quantity from purches where purches_id='" + textBox1.Text + "'", cn);
            double b  =Convert.ToDouble(com1.ExecuteScalar());
            SqlCommand com8 = new SqlCommand("select product_name from purches where purches_id= '" + textBox1.Text + "' ", cn);
            string w = (string)com8.ExecuteScalar();
            SqlCommand com2 = new SqlCommand("select quantity from stock where product_name= '" + w + "'", cn);
            double c =Convert.ToDouble(com2.ExecuteScalar());
            if (c > b)
            {
              double j =  c - b;
              SqlCommand com3 = new SqlCommand("select product_name from purches where purches_id= '" + textBox1.Text + "' ", cn);
              string u = (string)com3.ExecuteScalar();
              SqlCommand com4 = new SqlCommand("select quantity_type from purches where purches_id= '" + textBox1.Text + "' ", cn);
              string v = (string)com4.ExecuteScalar();
              SqlCommand com5 = new SqlCommand("update stock set product_name ='" + u + "', quantity='" + j + "',quantity_type='" + v + "' where  product_name='" + u + "'", cn);
              com3.ExecuteNonQuery();
              com4.ExecuteNonQuery();
              com5.ExecuteNonQuery();
            }
            else
            {
                SqlCommand com6=new SqlCommand("select product_name from purches where purches_id= '" + textBox1.Text + "' ", cn);
                string u = (string)com6.ExecuteScalar();
                SqlCommand com7 = new SqlCommand("delete from stock where product_name='"+u+"'", cn);
                com6.ExecuteNonQuery();
                com7.ExecuteNonQuery();
            }
            com.ExecuteNonQuery();
            com1.ExecuteNonQuery();
            com2.ExecuteNonQuery();
            com8.ExecuteNonQuery();
            MessageBox.Show("data removed successfully");
            cn.Close();
            Dgrid();
            cn.Close();
            cn.Open();
            getpurchesid();
            getinvoiceno();
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from purches where purches_id= '" + textBox1.Text + "' ", cn);
            SqlCommand com1 = new SqlCommand("select quantity from purches where purches_id='" + textBox1.Text + "'", cn);
            double b = Convert.ToDouble(com1.ExecuteScalar());
            SqlCommand com8 = new SqlCommand("select product_name from purches where purches_id= '" + textBox1.Text + "' ", cn);
            string w = (string)com8.ExecuteScalar();
            SqlCommand com2 = new SqlCommand("select quantity from stock where product_name= '" + w + "' ", cn);
            double c = Convert.ToDouble(com2.ExecuteScalar());
            if (c > b)
            {
                double j = c - b;
                SqlCommand com3 = new SqlCommand("select product_name from purches where purches_id= '" + textBox1.Text + "' ", cn);
                string u = (string)com3.ExecuteScalar();
                SqlCommand com4 = new SqlCommand("select quantity_type from purches where purches_id= '" + textBox1.Text + "' ", cn);
                string v = (string)com4.ExecuteScalar();
                SqlCommand com5 = new SqlCommand("update stock set product_name ='" + u + "', quantity='" + j + "',quantity_type='" + v + "' where  product_name='" + u + "'", cn);
                com3.ExecuteNonQuery();
                com4.ExecuteNonQuery();
                com5.ExecuteNonQuery();
            }
            else
            {
                SqlCommand com6 = new SqlCommand("select product_name from purches where purches_id= '" + textBox1.Text + "' ", cn);
                string u = (string)com6.ExecuteScalar();
                SqlCommand com7 = new SqlCommand("delete from stock where product_name='" + u + "'", cn);
                com6.ExecuteNonQuery();
                com7.ExecuteNonQuery();
            }
            com1.ExecuteNonQuery();
            com2.ExecuteNonQuery();
            com8.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox1.Text = ds.Tables[0].Rows[0]["purches_id"].ToString();
                textBox2.Text = ds.Tables[0].Rows[0]["invoiceno"].ToString();
                textBox11.Text = ds.Tables[0].Rows[0]["SID"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["Firm_Name"].ToString();
                comboBox1.Text = ds.Tables[0].Rows[0]["GST_Type"].ToString();
                dateTimePicker1.Text = ds.Tables[0].Rows[0]["invoice_date"].ToString();
                comboBox3.Text = ds.Tables[0].Rows[0]["product_name"].ToString();
                comboBox2.Text = ds.Tables[0].Rows[0]["quantity_type"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0]["price"].ToString();
                textBox6.Text = ds.Tables[0].Rows[0]["quantity"].ToString();
                textBox7.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                textBox8.Text = ds.Tables[0].Rows[0]["GST_percentage"].ToString();
                textBox9.Text = ds.Tables[0].Rows[0]["GST_value"].ToString();
                textBox10.Text = ds.Tables[0].Rows[0]["total_amount"].ToString();
                comboBox4.Text = ds.Tables[0].Rows[0]["category_type"].ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();

            SqlCommand com = new SqlCommand("update purches set purches_id ='" + textBox1.Text + "' , invoiceno ='" + textBox2.Text + "' , SID='" + textBox11.Text + "', Firm_Name='" + textBox3.Text + "', GST_Type='" + comboBox1.Text + "' , invoice_date='" + dateTimePicker1.Text + "',product_name='" + comboBox3.Text + "',quantity_type='" + comboBox2.Text + "', price='" + textBox5.Text + "', quantity='" + textBox6.Text + "', amount='" + textBox7.Text + "', GST_percentage='" + textBox8.Text + "', GST_value='" + textBox9.Text + "',total_amount='" + textBox10.Text + "', category_type ='" + comboBox4.Text + "' where  purches_id='" + textBox1.Text + "'", cn);
            SqlCommand com1 = new SqlCommand("select product_name from stock where product_name='" + comboBox3.Text + "'", cn);
            string a = (string)com1.ExecuteScalar();
            if (a == comboBox3.Text)
            {
                SqlCommand com3 = new SqlCommand("select quantity from stock where product_name='" + comboBox3.Text + "'", cn);
                double d = Convert.ToDouble(com3.ExecuteScalar());
                double g = Convert.ToDouble(textBox6.Text);
                double f = d + g;

                SqlCommand com2 = new SqlCommand("update stock set product_name ='" + comboBox3.Text + "', quantity='" + f + "',quantity_type='" + comboBox2.Text + "' where  product_name='" + comboBox3.Text + "'", cn);
                com2.ExecuteNonQuery();
            }
            else
            {
                SqlCommand com2 = new SqlCommand(" insert into stock values('" + comboBox3.Text + "','" + Convert.ToDouble(textBox6.Text) + "','" + comboBox2.Text + "')", cn);
                com2.ExecuteNonQuery();
            }
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("data updated successfully");

            Dgrid();
            cn.Close();
            cn.Open();
            textBox11.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox2.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            comboBox4.Text = string.Empty;
            cn.Close();
            cn.Open();
            getpurchesid();
            getinvoiceno();
            cn.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            amountcalc();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            amountcalc();
        }

        private void amountcalc()
        {
            try
            {
                double num1 = Convert.ToDouble(textBox5.Text);
                double num2 = Convert.ToDouble(textBox6.Text);
                double num3 = num1 * num2;
                textBox7.Text = num3.ToString();
            }
            catch (FormatException)
            {
                textBox7.Text = "..";

            }
            catch (Exception )
            {
                textBox7.Text = "an error occured";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            gstamountcalc();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            gstamountcalc();
            totalamount();
        }
        private void gstamountcalc()
        { 
             try
            {
                double num1 = Convert.ToDouble(textBox7.Text);
                double num2 = Convert.ToDouble(textBox8.Text);
                double num3 = ((num1 * num2)/100);
                textBox9.Text = num3.ToString();
            }
            catch (FormatException)
            {
                textBox9.Text = "..";

            }
            catch (Exception )
            {
                textBox9.Text = "an error occured";
            }
        
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            totalamount();
        }
        public void totalamount()
        {
            try
            {
                double num1 = Convert.ToDouble(textBox7.Text);
                double num2 = Convert.ToDouble(textBox9.Text);
                double num3 =num1 +num2;
                textBox10.Text = num3.ToString();
            }
            catch (FormatException)
            {
                textBox10.Text = "..";

            }
            catch (Exception )
            {
                textBox10.Text = "an error occured";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            getsuplierdetails();
        }
        public void getsuplierdetails()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from suplierinfo where SID= '" + textBox11.Text + "' ", cn);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox11.Text = ds.Tables[0].Rows[0]["SID"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["Firm_Name"].ToString();
                comboBox1.Text = ds.Tables[0].Rows[0]["GST_Type"].ToString();

            }
            else {
                textBox3.Text = "no details";
                comboBox1.Text = "no details";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void getproductname()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct product_name from purches  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox3.Items.Add(reader["product_name"].ToString());
            }
            cn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getquantitytype()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select  quantity_type from quantity  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox2.Items.Add(reader["quantity_type"].ToString());
            }
            cn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            misclanious backmislanious = new misclanious();
            backmislanious.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            main backmain = new main();
            backmain.ShowDialog();
            this.Hide();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = string.Empty;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Empty;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getcategory()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct category_type from category  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox4.Items.Add(reader["category_type"].ToString());
            }
            cn.Close();
        }


    }
}
