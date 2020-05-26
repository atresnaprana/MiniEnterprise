using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.SqlClient;
using Telerik.Web.UI;
using Telerik.Reporting;

namespace OlshoptrackedBAK.Reports
{
    public partial class RptGojekCust : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadTabStrip1.FindTabByText("Report").Enabled = false;

            }
            else
            {
               
                string ModeData = ModeDD.SelectedValue;
                var dt = GetData(ModeData);
                var objectDataSource = new ObjectDataSource { DataSource = dt };
                var report = new RptCustomer { DataSource = objectDataSource };
                report.DataSource = objectDataSource;
                var table = report.Items.Find("table1", true)[0] as Telerik.Reporting.Table;
                table.ColumnHeadersPrintOnEveryPage = true;
                table.DataSource = dt;

                var clientReportSource = new InstanceReportSource { ReportDocument = report };
                ReportViewer1.ReportSource = clientReportSource;
                ReportViewer1.DataBind();
                ReportViewer1.RefreshReport();
            }


        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }
        private ReportDataSet.ReportCustomerDtDataTable GetData(string Mode)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            var validatedt = new ReportDataSet.ReportCustomerDtDataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = @"SELECT A.ID, A.TRANS_ID, A.SHOPPING_ID, A.ISDEBIT, A.AMOUNT, B.NOTES, C.DESCRIPTION FROM MT_TRANSDET A 
                //                LEFT JOIN MG_SHOPLIST B ON A.SHOPPING_ID = B.ID 
                //                LEFT JOIN MT_TRANSACTION C ON A.TRANS_ID = C.TRANS_ID 
                //                WHERE (B.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "') AND (C.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "')";
                string sql = @"SELECT DISTINCT A.CUST_ID, A.CUST_NAME, A.PHONE FROM MT_CUSTOMER A INNER JOIN mt_transaction B ON A.CUST_ID = B.CUST_ID WHERE 1=1 " + Environment.NewLine;
                if(Mode == "GOJEK")
                {
                    sql += "AND B.DESCRIPTION LIKE '%GF%' ";

                }
                else
                if(Mode == "GRAB")
                {
                    sql += "AND B.DESCRIPTION LIKE '%GRB%' ";

                }
                else
                if(Mode == "DIRECT")
                {
                    sql += "AND B.DESCRIPTION LIKE '%DIRECT%' ";

                }
                sql += "ORDER BY A.CUST_NAME ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "mt_customer");
                daCountry.Fill(validatedt);


            }
            catch (Exception ex)
            {
                //ShowMessage("Error: " + ex.Message);
            }
            return validatedt;
            conn.Close();
            Console.WriteLine("Done.");

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            RadTabStrip1.FindTabByText("Report").Enabled = true;
            RadTab tab1 = RadTabStrip1.Tabs.FindTabByText("Report");
            tab1.Selected = true;
            tab1.PageView.Selected = true;
        }
    }
}