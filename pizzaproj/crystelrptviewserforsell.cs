using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;


namespace pizzaproj
{
    public partial class crystelrptviewserforsell : Form
    {
        public crystelrptviewserforsell()
        {
            InitializeComponent();
        }
         public string reportname { get; set; }
        public DataTable reportdata { get; set; }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
                ReportDocument rdd = new ReportDocument();
                rdd.Load(reportname);
                rdd.SetDataSource(reportdata);
                crystalReportViewer1.ReportSource = rdd;
            
        }
    }
}
