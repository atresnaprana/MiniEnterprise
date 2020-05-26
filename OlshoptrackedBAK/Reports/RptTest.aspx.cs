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
    public partial class RptTest : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Retrieve();
            }else
            {
                RetrieveCombobox();
            }
            
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }
        private void RetrieveCombobox()
        {
            var dt = GetData("", "");
            RadCmbListCust.DataSource = dt;
            RadCmbListCust.DataBind();
        }
        private void Retrieve()
        {
            string convertedfrom = "2017-11-1";
            string convertedto = "2017-11-30";
            var dt = GetData(convertedfrom, convertedto);
            var objectDataSource = new ObjectDataSource { DataSource = dt };
            var report = new LabelRpt { DataSource = objectDataSource };

            report.DataSource = objectDataSource;
            var table = report.Items.Find("list1", true)[0] as Telerik.Reporting.List;
            table.ColumnHeadersPrintOnEveryPage = true;
            table.DataSource = dt;

            var clientReportSource = new InstanceReportSource { ReportDocument = report };
            ReportViewer1.ReportSource = clientReportSource;
            ReportViewer1.DataBind();
            ReportViewer1.RefreshReport();
        }
        private bool update(ReportDataSet.AddressesDataTable dt)
        {
            bool result = true;
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    conn.Open();
                    //string SID = lblSID.Text;
                    MySqlCommand cmd = new MySqlCommand("update TRANSACTION_IN_DATA Set  SENT_STATUS = 'Y', UPDATE_DATE = @datetime, UPDATE_USER = @user where CUST_CODE = @code", conn);
                    //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);


                    cmd.Parameters.AddWithValue("@code", Convert.ToInt16(dt.Rows[i]["CUST_CODE"]));
                    cmd.Parameters.AddWithValue("@user", Session["id"].ToString());

                    cmd.Parameters.AddWithValue("@datetime", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    //retrieve();
                    //LoadDataInNotification("Data has been Updated", "Update Success");
                    //ShowMessage("Hdr Data update Successfully......!");

                }
                catch (MySqlException ex)
                {
                    result = false;
                    //ShowMessage("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            return result;

        }
        private ReportDataSet.AddressesDataTable GetData(string datefrom, string dateto)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            var validatedt = new ReportDataSet.AddressesDataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT a.TRANS_CODE, B.CUST_CODE, B.CUST_NAME, B.ADDRESS AS CUST_ADDRESS, B.PHONE1 AS CUST_PHONE1, 
                               B.PHONE2 AS CUST_PHONE2, C.OLSHOP_NAME, 
                                d.COURIER_DETAIL, e.COST_DESC FROM TRANSACTION_IN_DATA A LEFT 
                                JOIN CUST_DATA B on a.CUST_CODE = b.CUST_CODE 
                                left join mt_olshop c on a.OLSHOP_CODE = c.OLSHOP_CODE LEFT 
                                JOIN COURIER_DATA d on a.COURIER_CODE = d.COURIER_CODE LEFT 
                                JOIN courier_cost_data e on a.COST_CODE = e.COST_CODE 
                                AND d.COURIER_CODE = e.COURIER_CODE WHERE A.SENT_STATUS = 'N'";
                if(RadCmbListCust.CheckedItems.Count > 0)
                {
                    for(int i = 0; i < RadCmbListCust.CheckedItems.Count; i++)
                    {
                        if(i == 0)
                        {
                            sql += "AND b.CUST_CODE = '" + RadCmbListCust.CheckedItems[i].Value + "'";

                        }else
                        {
                            sql += "OR b.CUST_CODE = '" + RadCmbListCust.CheckedItems[i].Value + "'";

                        }
                    }
                }
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

        protected void ReportViewer1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {

        }

        protected void test_Click(object sender, EventArgs e)
        {
            LabelRpt report = new LabelRpt();
            string convertedfrom = "2017-11-1";
            string convertedto = "2017-11-30";
            var dt = GetData(convertedfrom, convertedto);
            var objectDataSource = new ObjectDataSource { DataSource = dt };
            report.DataSource = objectDataSource;
            var table = report.Items.Find("list1", true)[0] as Telerik.Reporting.List;
            table.ColumnHeadersPrintOnEveryPage = true;
            table.DataSource = dt;

            Telerik.Reporting.Processing.ReportProcessor reportProcessor =
    new Telerik.Reporting.Processing.ReportProcessor();
            System.Collections.Hashtable deviceInfo =
    new System.Collections.Hashtable();
            Telerik.Reporting.TypeReportSource typeReportSource =
                         new Telerik.Reporting.TypeReportSource();
            typeReportSource.TypeName = "reportName";
            Telerik.Reporting.Processing.RenderingResult result =
    reportProcessor.RenderReport("PDF", report, deviceInfo);
            string today = Convert.ToDateTime(DateTime.Now).ToString("ddMMyyyy");
            string fileName = result.DocumentName +"_"+ today + "." + result.Extension;
            string path = System.IO.Path.GetTempPath();
            string filePath = System.IO.Path.Combine(path, fileName);
            TempPath.Text = filePath;
            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
            if (update(dt))
            {
                RetrieveCombobox();
                Response.Write("<script>alert('File Has been downloaded to your temporary Folder, see information above preview')</script>");
            }else
            {
                Response.Write("Error has occurred");
            }
        }
    }
}