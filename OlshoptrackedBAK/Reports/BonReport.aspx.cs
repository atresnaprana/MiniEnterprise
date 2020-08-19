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
    public partial class BonReport : System.Web.UI.Page
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
                //DateTime datefroms = Convert.ToDateTime(datefrom.SelectedDate);
                //DateTime datetos = Convert.ToDateTime(dateto.SelectedDate);
                //string convertedfrom = datefroms.ToString("yyyy-MM-dd");
                //string convertedto = datetos.ToString("yyyy-MM-dd");
              
                //var objectDataSource = new ObjectDataSource { DataSource = dt };
                //var report = new BonReport { DataSource = objectDataSource };
                //report.DataSource = objectDataSource;
                //var table = report.Items.Find("table1", true)[0] as Telerik.Reporting.Table;
                //table.ColumnHeadersPrintOnEveryPage = true;
                //table.DataSource = dt;

                //var clientReportSource = new InstanceReportSource { ReportDocument = report };
                //ReportViewer1.ReportSource = clientReportSource;
                //ReportViewer1.DataBind();
                //ReportViewer1.RefreshReport();
            }


        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }
        private ReportDataSet.BonDtDataTable GetData(string date, string custid)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            var validatedt = new ReportDataSet.BonDtDataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = @"SELECT A.ID, A.TRANS_ID, A.SHOPPING_ID, A.ISDEBIT, A.AMOUNT, B.NOTES, C.DESCRIPTION FROM MT_TRANSDET A 
                //                LEFT JOIN MG_SHOPLIST B ON A.SHOPPING_ID = B.ID 
                //                LEFT JOIN MT_TRANSACTION C ON A.TRANS_ID = C.TRANS_ID 
                //                WHERE (B.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "') AND (C.TRANS_DATE BETWEEN '" + datefrom + "' AND '" + dateto + "')";
                string sql = @"SELECT a.DESCRIPTION as PIN,a.TRANS_DATE,c.CATEGORY_NAME AS PRODUCT_NAME, d.CUST_NAME,  b.PRICE AS AMOUNT, A.ITEM_AMT as Jml FROM MT_TRANSACTION A LEFT JOIN MT_PROD B ON A.PROD_ID = B.PROD_ID 
                                LEFT JOIN mt_prod_cat c on b.prod_cat_id = c.id LEFT JOIN mt_customer d on a.cust_id = d.cust_id ";
                sql += " WHERE a.TRANS_DATE = '" + date +"' AND a.CUST_ID = '" + custid +"'";

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
            DateTime datez = Convert.ToDateTime(dates.SelectedDate);
            string convertedDate = datez.ToString("yyyy-MM-dd");
            string selectedid = RadCmbTrans.SelectedValue;
            var dt = GetData(convertedDate, selectedid);

            var objectDataSource = new ObjectDataSource { DataSource = dt };
            var report = new LabelRpt { DataSource = objectDataSource };
            report.DataSource = objectDataSource;
            var table = report.Items.Find("table1", true)[0] as Telerik.Reporting.Table;
            table.ColumnHeadersPrintOnEveryPage = true;
            table.DataSource = dt;

            var clientReportSource = new InstanceReportSource { ReportDocument = report };
            ReportViewer1.ReportSource = clientReportSource;
            ReportViewer1.DataBind();
            ReportViewer1.RefreshReport();

            RadTabStrip1.FindTabByText("Report").Enabled = true;
            RadTab tab1 = RadTabStrip1.Tabs.FindTabByText("Report");
            tab1.Selected = true;
            tab1.PageView.Selected = true;
        }

        protected void dates_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            var selectedDate = Convert.ToDateTime(e.NewDate);
            string convertedDate = selectedDate.ToString("yyyy-MM-dd");
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT a.CUST_ID, a.DESCRIPTION FROM mt_transaction a left join mt_customer b on a.cust_id = b.cust_id WHERE a.TRANS_DATE = '" + convertedDate + "' group by a.DESCRIPTION, A.cust_id ORDER BY a.DESCRIPTION ASC";

                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "CATEGORY_DATA");
                RadCmbTrans.ClearSelection();
                RadCmbTrans.DataSource = dsCountry;
                RadCmbTrans.DataBind();



                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader rdr = cmd.ExecuteReader();
                /* conn.Open();

            string sql = "INSERT INTO Country (Name, HeadOfState, Continent) VALUES ('Disneyland','Mickey Mouse', 'North America')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();*/
                /*while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();*/
            }
            catch (Exception ex)
            {
                //ShowMessage("Error: " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done.");

        }
    }
}