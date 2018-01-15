using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace WpfReportDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReportViewerDemo.Reset();
            DataTable dt = GetData();
            ReportDataSource ds = new ReportDataSource("DataSet1",dt);
            ReportViewerDemo.LocalReport.DataSources.Add(ds);
            ReportViewerDemo.LocalReport.ReportEmbeddedResource = "WpfReportDemo.Report1.rdlc";
            ReportViewerDemo.RefreshReport();
        }
        private DataTable GetData() {
            string connStr = @"data source=.\SQLEXPRESS;initial catalog=phv-berry;integrated security=True";
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connStr)) {
                SqlCommand cmd = new SqlCommand("Select CompanyID,Name from Company", cn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;
        }
    }
}
