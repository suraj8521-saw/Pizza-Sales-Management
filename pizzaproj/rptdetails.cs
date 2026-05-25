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
    public partial class rptdetails : Form
    {
        public rptdetails()
        {
            InitializeComponent();
        }
        String scn = @"Data Source=LAPTOP-P563KI5P\SQLEXPRESS; Initial Catalog= pizza; Integrated Security=True";
        DataSet3 ds = new DataSet3();
        private void rptdetails_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(scn);
            cn.Close();
            cn.Open();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from sell", cn);
            da.Fill(ds, "sell");
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            cn.Close();
        }
    }
}
