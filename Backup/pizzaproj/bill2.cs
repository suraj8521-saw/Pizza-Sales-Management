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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace pizzaproj
{
    public partial class bill2 : Form
    {
        public bill2()
        {
            InitializeComponent();
        }
        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";

        private void bill2_Load(object sender, EventArgs e)
        {
            getproductname();
            getbillid();
            getinvoiceno();
            // Dgrid();
            countrow();
            totalquantcalc();
            totalamountcalc();
            getsid();
            comboBox4.Items.Clear();
            getbillnoincomb();
            dgridforsell();

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
        public void countrow()
        {

            int totalrow = dataGridView1.Rows.Count - 1;
            Int32 totalrows = Convert.ToInt32(totalrow);
            dataGridView1.Rows[totalrows].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[totalrows].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[totalrows].Cells[2].Value = dateTimePicker1.Text.ToString();
            dataGridView1.Rows[totalrows].Cells[3].Value = comboBox1.Text;
            dataGridView1.Rows[totalrows].Cells[4].Value = comboBox2.Text;
            dataGridView1.Rows[totalrows].Cells[5].Value = "-";
            dataGridView1.Rows[totalrows].Cells[6].Value = "1";
            dataGridView1.Rows[totalrows].Cells[7].Value = "+";
            dataGridView1.Rows[totalrows].Cells[8].Value = textBox3.Text;
            comboBox4.Text = textBox1.Text;
        }

        private void insertvaliue()
        {
            string l = "no";
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            int totalrow = dataGridView1.Rows.Count - 1;
            Int32 totalrows = Convert.ToInt32(totalrow);
            SqlCommand com = new SqlCommand("insert into bill values('" + dataGridView1.Rows[totalrows].Cells[0].Value + "','" + dataGridView1.Rows[totalrows].Cells[1].Value + "','" + dataGridView1.Rows[totalrows].Cells[2].Value + "','" + dataGridView1.Rows[totalrows].Cells[3].Value + "','" + dataGridView1.Rows[totalrows].Cells[4].Value + "','" + Convert.ToDouble(dataGridView1.Rows[totalrows].Cells[6].Value) + "','" + Convert.ToDouble(dataGridView1.Rows[totalrows].Cells[8].Value) + "','" + l + "')", cn);
            com.ExecuteNonQuery();
            MessageBox.Show("data savedddd");
            cn.Close();
            cn.Open();
            // textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            cn.Close();
            cn.Open();
            //getbillid();
            getinvoiceno();
            dataGridView1.Rows.Clear();
            // Dgrid();
            countrow();
            totalquantcalc();
            totalamountcalc();
            comboBox4.Items.Clear();
            getbillnoincomb();
        }
        private void updatevalue()
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            string l = "no";
            int totalrow = dataGridView1.Rows.Count - 1;
            Int32 totalrows = Convert.ToInt32(totalrow);
            SqlCommand com = new SqlCommand("update bill set bill_no ='" + dataGridView1.Rows[totalrows].Cells[0].Value + "' , invoiceno ='" + dataGridView1.Rows[totalrows].Cells[1].Value + "' , invoice_date='" + dataGridView1.Rows[totalrows].Cells[2].Value + "', product_name='" + dataGridView1.Rows[totalrows].Cells[3].Value + "', quantity_type='" + dataGridView1.Rows[totalrows].Cells[4].Value + "', quantity='" + Convert.ToDouble(dataGridView1.Rows[totalrows].Cells[6].Value) + "',amount='" + Convert.ToDouble(dataGridView1.Rows[totalrows].Cells[8].Value) + "',status='" + l + "'  where  bill_no='" + dataGridView1.Rows[totalrows].Cells[0].Value + "'", cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("data updated successfully");
            totalquantcalc();
            totalamountcalc();
            comboBox4.Items.Clear();
            getbillnoincomb();
        }

        public void totalquantcalc()
        {
            int totalrow = dataGridView1.Rows.Count - 1;
            Int32 totalrows = Convert.ToInt32(totalrow);
            double sum = 0;
            for (Int32 i = 0; i < totalrows; i++)
            {

                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);

            }
            textBox4.Text = sum.ToString();
        }
        public void totalamountcalc()
        {
            int totalrow = dataGridView1.Rows.Count - 1;
            Int32 totalrows = Convert.ToInt32(totalrow);
            double summ = 0;
            for (Int32 i = 0; i < totalrows; i++)
            {

                summ = summ + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);

            }
            textBox5.Text = summ.ToString();
        }
        private void Dgrid()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select* from bill", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), ((DateTime)sdr.GetValue(2)).ToString("dd MMM yyyy"), sdr.GetValue(3), sdr.GetValue(4), "-", sdr.GetValue(5), "+", sdr.GetValue(6), sdr.GetValue(7));
            }
            cn.Close();

        }
        private void dgridforsell()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com2 = new SqlCommand("select* from sell", cn);
            SqlDataReader sdr = com2.ExecuteReader();
            dataGridView2.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView2.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), sdr.GetValue(2), sdr.GetValue(3), sdr.GetValue(4), sdr.GetValue(5), sdr.GetValue(6), sdr.GetValue(7), sdr.GetValue(8));
            }
            cn.Close();
        }
        private void dgridbysid()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select* from bill where bill_no='" + textBox1.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), ((DateTime)sdr.GetValue(2)).ToString("dd MMM yyyy"), sdr.GetValue(3), sdr.GetValue(4), "-", sdr.GetValue(5), "+", sdr.GetValue(6), sdr.GetValue(7));
            }
            cn.Close();
        }
        private void dgridbycheckorder()
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select* from bill where bill_no='" + comboBox3.Text + "' ", cn);
            SqlDataReader sdr = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (sdr.Read())
            {
                dataGridView1.Rows.Add(sdr.GetValue(0), sdr.GetValue(1), ((DateTime)sdr.GetValue(2)).ToString("dd MMM yyyy"), sdr.GetValue(3), sdr.GetValue(4), "-", sdr.GetValue(5), "+", sdr.GetValue(6), sdr.GetValue(7));
            }
            cn.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            countrow();
            dgridbysid();
            countrow();
            totalquantcalc();
            totalamountcalc();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            countrow();
            label15.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            countrow();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(scn);
            if (comboBox1.Text == "" || comboBox2.Text == "")
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
                countrow();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            int totalrow = dataGridView1.Rows.Count - 1;
            Int32 totalrows = Convert.ToInt32(totalrow);
            SqlCommand checkprime = new SqlCommand("select invoiceno from bill where invoiceno='" + dataGridView1.Rows[totalrows].Cells[1].Value + "'", cn);
            string m = (string)checkprime.ExecuteScalar();
            double id = Convert.ToDouble(m);
            double invno = Convert.ToDouble(dataGridView1.Rows[totalrows].Cells[1].Value);
            if (id == invno)
            {
                MessageBox.Show("dublicate invoice no");
                textBox2.Text = string.Empty;
                getinvoiceno();
            }
            else
            {


                totalquantcalc();
                totalamountcalc();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || dateTimePicker1.Text == "")
                {
                    MessageBox.Show("please insetr above details first");
                }
                else
                {
                    cn.Close();
                    cn.Open();
                    int totalrowd = dataGridView1.Rows.Count - 1;
                    Int32 totalrowsd = Convert.ToInt32(totalrowd);
                    SqlCommand checkprimed = new SqlCommand("select invoiceno from bill where invoiceno='" + dataGridView1.Rows[totalrows].Cells[1].Value + "'", cn);
                    string md = (string)checkprimed.ExecuteScalar();
                    double idd = Convert.ToDouble(md);
                    string lid = Convert.ToString(dataGridView1.Rows[totalrows].Cells[1].Value);
                    double lidd = Convert.ToDouble(lid);
                    if (idd == lidd)
                    {
                    }
                    else
                    {
                        insertvaliue();
                        dgridbysid();
                        totalquantcalc();
                        totalamountcalc();
                        comboBox4.Items.Clear();
                        getbillnoincomb();
                        getsellamount();

                    }
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //      SqlConnection cn = new SqlConnection(scn);
            //    cn.Close();
            //  cn.Open();
            //int totalrow = dataGridView1.Rows.Count - 1;
            //Int32 totalrows = Convert.ToInt32(totalrow);
            //SqlCommand checkprime = new SqlCommand("select bill_no from bill where bill_no='" + dataGridView1.Rows[totalrows].Cells[0].Value + "'", cn);
            //string m = (string)checkprime.ExecuteScalar();
            //double id = Convert.ToDouble(m);
            //double qn = Convert.ToDouble(dataGridView1.Rows[totalrows].Cells[6].Value);
            //double am = Convert.ToDouble(dataGridView1.Rows[totalrows].Cells[8].Value);
            //string lid = Convert.ToString(dataGridView1.Rows[totalrows].Cells[0].Value);
            //double lidd = Convert.ToDouble(lid);
            //if (id == lidd)
            // {
            //    updatevalue();
            // }
            // else
            // {
            //     if (qn == 1 && am > 0)
            //     {
            //         insertvaliue();
            //     }
            // }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            int totalrow = dataGridView1.Rows.Count - 1;
            Int32 totalrows = Convert.ToInt32(totalrow);

            int ri = dataGridView1.CurrentCellAddress.Y;
            if (dataGridView1[5, ri].Selected)
            {
                int totalrowb = dataGridView1.Rows.Count - 1;
                Int32 totalrowsb = Convert.ToInt32(totalrowb);
                if (dataGridView1[5, totalrowsb].Selected)
                {
                    MessageBox.Show("please select type and size of pizza");
                }
                else
                {
                    double a = Convert.ToDouble(dataGridView1.Rows[ri].Cells[6].Value);
                    double s = Convert.ToDouble(dataGridView1.Rows[ri].Cells[8].Value);
                    double t = s / a;
                    if (a == 1)
                    {
                        MessageBox.Show("quantity cant be less than 1");
                    }
                    else
                    {

                        double b = a - 1;
                        dataGridView1.Rows[ri].Cells[6].Value = b;
                        double u = s - t;
                        dataGridView1.Rows[ri].Cells[8].Value = u;
                        cn.Close();
                        cn.Open();

                        string l = "no";
                        int totalroo = dataGridView1.Rows.Count - 1;
                        Int32 totalroos = Convert.ToInt32(totalroo);
                        SqlCommand com = new SqlCommand("update bill set bill_no ='" + dataGridView1.Rows[ri].Cells[0].Value + "' , invoiceno ='" + dataGridView1.Rows[ri].Cells[1].Value + "' , invoice_date='" + dataGridView1.Rows[ri].Cells[2].Value + "', product_name='" + dataGridView1.Rows[ri].Cells[3].Value + "', quantity_type='" + dataGridView1.Rows[ri].Cells[4].Value + "', quantity='" + Convert.ToDouble(dataGridView1.Rows[ri].Cells[6].Value) + "',amount='" + Convert.ToDouble(dataGridView1.Rows[ri].Cells[8].Value) + "',status='" + l + "'  where  invoiceno='" + dataGridView1.Rows[ri].Cells[1].Value + "'", cn);
                        com.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("data updated successfully");
                        dgridbysid();
                        totalquantcalc();
                        totalamountcalc();
                        comboBox4.Items.Clear();
                        getbillnoincomb();
                        getsellamount();

                    }
                }
            }


            if (dataGridView1[7, ri].Selected)
            {

                int totalrowa = dataGridView1.Rows.Count - 1;
                Int32 totalrowsa = Convert.ToInt32(totalrowa);
                if (dataGridView1[7, totalrowsa].Selected)
                {
                    MessageBox.Show("please select type and size of pizza");
                }
                else
                {
                    double a = Convert.ToDouble(dataGridView1.Rows[ri].Cells[6].Value);
                    double s = Convert.ToDouble(dataGridView1.Rows[ri].Cells[8].Value);
                    double t = s / a;
                    cn.Close();
                    cn.Open();
                    double b = a + 1;
                    dataGridView1.Rows[ri].Cells[6].Value = b;
                    double u = s + t;
                    dataGridView1.Rows[ri].Cells[8].Value = u;
                    cn.Close();
                    cn.Open();
                    string l = "no";
                    cn.Close();
                    cn.Open();
                    SqlCommand com = new SqlCommand("update bill set bill_no ='" + dataGridView1.Rows[ri].Cells[0].Value + "' , invoiceno ='" + dataGridView1.Rows[ri].Cells[1].Value + "' , invoice_date='" + dataGridView1.Rows[ri].Cells[2].Value + "', product_name='" + dataGridView1.Rows[ri].Cells[3].Value + "', quantity_type='" + dataGridView1.Rows[ri].Cells[4].Value + "', quantity='" + Convert.ToDouble(dataGridView1.Rows[ri].Cells[6].Value) + "',amount='" + Convert.ToDouble(dataGridView1.Rows[ri].Cells[8].Value) + "',status='" + l + "'  where  invoiceno='" + dataGridView1.Rows[ri].Cells[1].Value + "'", cn);
                    com.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("data updated successfully");
                    dgridbysid();
                    totalquantcalc();
                    totalamountcalc();
                    comboBox4.Items.Clear();
                    getbillnoincomb();
                    getsellamount();
                }
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            countrow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            dateTimePicker1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label13.Visible = true;
            label1.Visible = true;
            label15.Visible = true;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            getbillid();
            getinvoiceno();
            comboBox4.Items.Clear();
            getbillnoincomb();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }



        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        public void getsid()
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
            textBox6.Text = pid.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getbillnoincomb()
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select distinct bill_no from bill  ", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();

            while (reader.Read())
            {

                comboBox4.Items.Add(reader["bill_no"].ToString());

            }
            cn.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            calctotalamount();
        }

        private void getsellamount()
        {

            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand com = new SqlCommand("select  amount from bill where bill_no= '" + comboBox4.Text + "'", cn);
            SqlDataReader reader = com.ExecuteReader();
            DataSet ds = new DataSet();
            double suma = 0;
            while (reader.Read())
            {

                string aa = (reader["amount"].ToString());
                double ba = Convert.ToDouble(aa);
                suma = suma + ba;

            }
            textBox11.Text = suma.ToString();
            cn.Close();
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            getsellamount();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            calctotalamount();
        }

        private void calctotalamount()
        {
            if (textBox11.Text == "")
            {
                textBox13.Text = "0";
            }
            else
            {
                double ca = Convert.ToDouble(textBox11.Text);
                if (textBox12.Text == "")
                {
                    textBox13.Text = ca.ToString();
                }
                else
                {
                    double da = Convert.ToDouble(textBox12.Text);

                    double ea = (ca * da) / 100;
                    double fa = ca + ea;
                    textBox13.Text = fa.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string l = "yes";
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            SqlCommand checksid = new SqlCommand("select bill_no from sell where bill_no='" + comboBox4.Text + "'", cn);
            string n = (string)checksid.ExecuteScalar();
            double id = Convert.ToDouble(n);
            string r = Convert.ToString(comboBox4.Text);
            double s = Convert.ToDouble(r);
            if (id == s)
            {
                MessageBox.Show("this customer bill and sell record  already updated");
            }
            else
            {
                SqlCommand com = new SqlCommand("insert into sell values('" + textBox6.Text + "','" + comboBox4.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + l + "')", cn);
                com.ExecuteNonQuery();

                MessageBox.Show("data savedddd");
                cn.Close();
                cn.Open();
                SqlCommand com2 = new SqlCommand("update bill set status='" + l + "'  where  bill_no='" + comboBox4.Text + "'", cn);
                com2.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("data updated successfully");
                cn.Close();
                cn.Open();
                dgridforsell();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
           
            cn.Close();
            cn.Open();
            string query = " select bill_no, product_name,quantity_type,quantity,amount from bill where bill_no='" + comboBox4.Text + "'";
            SqlCommand com = new SqlCommand( query,cn);
            DataTable data = new DataTable();
           
            cn.Close();
            cn.Open();
            SqlDataReader reader = com.ExecuteReader();
            data.Load(reader);
            if (data.Rows.Count > 0)
            {
                
                crystelrptviewserforsell rptview = new crystelrptviewserforsell();
                string apppath = Application.StartupPath;
                string reportpath = @"sellreport.rpt";
                string fullpath = Path.Combine(apppath,reportpath);
                rptview.reportname = fullpath;
                rptview.reportdata = data;
                rptview.Show();
                
                
               }
            cn.Close();
            cn.Open();
            
         }
    }
}