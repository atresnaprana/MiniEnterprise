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
    public partial class RptTransInView : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadTabStrip1.FindTabByText("Report").Enabled = false;
               
            }else
            {
                DateTime datefroms = Convert.ToDateTime(datefrom.SelectedDate);
                DateTime datetos = Convert.ToDateTime(dateto.SelectedDate);
                string convertedfrom = datefroms.ToString("yyyy-MM-dd");
                string convertedto = datetos.ToString("yyyy-MM-dd");
                var dt = GetData(convertedfrom, convertedto);
                var objectDataSource = new ObjectDataSource { DataSource = dt };
                var report = new RptTransIn { DataSource = objectDataSource };
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
        private ReportDataSet.ReportTransIn2DataTable GetData(string datefrom, string dateto)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            var validatedt = new ReportDataSet.ReportTransIn2DataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = @"SELECT A.ID, A.TRANS_ID, A.SHOPPING_ID, A.ISDEBIT, A.AMOUNT, B.NOTES, C.DESCRIPTION FROM MT_TRANSDET A 
                //                LEFT JOIN MG_SHOPLIST B ON A.SHOPPING_ID = B.ID 
                //                LEFT JOIN MT_TRANSACTION C ON A.TRANS_ID = C.TRANS_ID 
                //                WHERE (B.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "') AND (C.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "')";
                string sql = @"SELECT TRANS_DATE,
                                   ISDEBIT,
                                   DESCRIPTION,
                                   CUST_NAME,
                                   PHONE_NUMBER,
                                   SUM(AMOUNTCREDIT) AS AMOUNTCREDIT,
                                   SUM(AMOUNTDEBIT) AS AMOUNTDEBIT
                            FROM (SELECT A.SHOPPING_ID
                                            AS TRANSID,
                                         B.TRANS_DATE
                                            AS TRANS_DATE,
                                         (CASE WHEN A.ISDEBIT = 'N' THEN b.AMOUNT ELSE 0 END)
                                            AS AMOUNTCREDIT,
                                         0
                                            AMOUNTDEBIT,
                                         B.NOTES
                                            AS DESCRIPTION,
                                         A.ISDEBIT
                                            AS ISDEBIT,
                                         ''
                                            AS CUST_NAME,
                                         '' AS PHONE_NUMBER
                                  FROM MT_TRANSDET A LEFT JOIN MG_SHOPLIST B ON A.SHOPPING_ID = B.ID
                                  WHERE     ISDEBIT = 'N'
                                        AND (B.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "')" + Environment.NewLine;
                sql += @"         UNION ALL
                                      SELECT A.TRANS_ID
                                                AS TRANSID,
                                             B.TRANS_DATE
                                                AS TRANS_DATE,
                                             0
                                                AMOUNTCREDIT,
                                             (CASE WHEN A.ISDEBIT = 'Y' THEN b.PRICE ELSE 0 END)
                                                AS AMOUNTDEBIT,
                                             B.DESCRIPTION
                                                AS DESCRIPTION,
                                             A.ISDEBIT
                                                AS ISDEBIT,
                                             C.CUST_NAME
                                                AS CUST_NAME,
                                             C.PHONE AS PHONE_NUMBER
                                      FROM MT_TRANSDET A
                                           LEFT JOIN mt_transaction B ON A.TRANS_ID = B.TRANS_ID
                                           LEFT JOIN mt_customer C ON C.CUST_ID = B.CUST_ID
                                      WHERE     ISDEBIT = 'Y'
                                            AND (B.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "')";
                sql += @"       ORDER BY TRANS_DATE ASC) AS ALLDATA
                                GROUP BY TRANS_DATE,
                                         DESCRIPTION,
                                         ISDEBIT,
                                         CUST_NAME,
                                         PHONE_NUMBER
                                ORDER BY TRANS_DATE ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "mt_prod");
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