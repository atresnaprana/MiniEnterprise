using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

namespace OlshoptrackedBAK
{
    public partial class DashBoard : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        public class DataClass
        {
            public string name { get; set; }

            public int value { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["id"] != null)
            {
                //label1.Text = Session["id"].ToString();
                if (!IsPostBack)
                {
                    loadproductdata("", 5);
                    loadcustomerdata("", 5);
                    loadshoppingdata();
                    loadingprofitdata();
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }

        }
        private void loadproductdata(string date, int range)
        {
            var DT = gettop5productdata(date, range);
            
            if(DT.Rows.Count > 0)
            {
                
                var dtnation = from grp in DT.Copy().AsEnumerable()
                               group grp by new { name = grp.Field<string>("PROD_NAME") }
                      into g
                               select new
                               {
                                   name = g.Key.name,
                                   Rev = g.Sum(x => x.Field<double>("TOTAL"))
                               };
                dtnation = dtnation.ToList();
                //var filePaths =
                // from row in DT.AsEnumerable()
                // select new DataClass
                // {
                //     name = row.Field<string>("PROD_NAME"),
                //     value = row.Field<int>("TOTAL2")
                // };
                //var test = filePaths.ToList();
                RCHTop5Product.DataSource = DT;
                RCHTop5Product.PlotArea.XAxis.LabelsAppearance.RotationAngle = 30;

                RCHTop5Product.DataBind();
            }
          
        }
        private void loadingprofitdata()
        {
            var DT = getlast5monthprofitnloss();
            if(DT.Rows.Count > 0)
            {
                var dtnation = from grp in DT.Copy().AsEnumerable()
                               group grp by new { name = grp.Field<string>("TRANS_DATE") }
                       into g
                               select new
                               {
                                   g.Key.name,
                                   Rev = g.Sum(x => x.Field<double>("TOTAL"))
                               };
                dtnation = dtnation.OrderByDescending(x => x.Rev);
                RCHTProfit.DataSource = dtnation;
                RCHTProfit.DataBind();
            }
           
        }
        //private void loadproductdata()
        //{
        //    var DT = gettop5productdata();
        //    var dtnation = from grp in DT.Copy().AsEnumerable()
        //                   group grp by new {name = grp.Field<string>("PROD_NAME") }
        //               into g
        //                   select new
        //                   {
        //                       g.Key.name,
        //                       Occ = g.Sum(x => x.Field<decimal>("TOTAL")),

        //                   };
        //    dtnation = dtnation.OrderByDescending(x => x.Occ).Take(10);
        //    RCHTop5Product.DataSource = dtnation;
        //    RCHTop5Product.DataBind();
        //}
        private void loadcustomerdata(string date, int range)
        {
            var DT = gettop5customerdata(date, range);
            if(DT.Rows.Count > 0)
            {
                var dtnation = from grp in DT.Copy().AsEnumerable()
                               group grp by new { name = grp.Field<string>("CUST_NAME") }
                       into g
                               select new
                               {
                                   g.Key.name,
                                   Rev = g.Sum(x => x.Field<double>("TOTAL"))
                               };
                dtnation = dtnation.OrderByDescending(x => x.Rev);
                RCHTop5Customer.DataSource = dtnation;
                RCHTop5Customer.PlotArea.XAxis.LabelsAppearance.RotationAngle = 30;
                RCHTop5Customer.DataBind();
            }
           
        }

        private void loadshoppingdata()
        {
            var DT = getshoppingdata();
            if(DT.Rows.Count > 0)
            {
                var dtnation = from grp in DT.Copy().AsEnumerable()
                               group grp by new { name = grp.Field<string>("TRANS_DATES") }
                        into g
                               select new
                               {
                                   g.Key.name,
                                   Rev = g.Sum(x => x.Field<double>("TOTAL"))
                               };
                dtnation = dtnation.OrderByDescending(x => x.Rev);
                RCHTShopping.DataSource = dtnation;
                RCHTShopping.DataBind();
            }
            
        }
        #region getdata
        private DataTable gettop5productdata(string date, int range)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            DataTable validatedt = new DataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT B.PROD_ID,
	                               C.PROD_NAME,
                                   SUM(A.AMOUNT) as TOTAL,
                                   COUNT(B.PROD_ID) as TOTAL2
                            FROM MT_TRANSDET A LEFT JOIN 
                            MT_TRANSACTION B ON A.TRANS_ID = B.TRANS_ID LEFT JOIN MT_PROD C ON B.PROD_ID = C.PROD_ID WHERE C.PROD_ID IS NOT NULL AND C.PROD_ID <> 38 AND c.PROD_ID <> 37" + Environment.NewLine;
                if (!string.IsNullOrEmpty(date))
                {
                    sql += @"AND year(B.TRANS_DATE) = year('" + date +"')" +Environment.NewLine;
                    sql += @"AND month(B.TRANS_DATE) = month('" + date + "')" + Environment.NewLine;

                }
                sql +=@"           GROUP BY B.PROD_ID, C.PROD_NAME
                            ORDER BY TOTAL2 DESC, C.PROD_NAME ASC LIMIT " + range;
                var dtprofit = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(dtprofit);
                var dsprofit = new DataSet();
                dtprofit.Fill(dsprofit, "MT_PROFIT");
                dtprofit.Fill(validatedt);


            }
            catch (Exception ex)
            {
                //ShowMessage("Error: " + ex.Message);
            }
            return validatedt;
            conn.Close();
            Console.WriteLine("Done.");

        }
        private DataTable getlast5monthprofitnloss()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            DataTable validatedt = new DataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT TRANS_DATE, (sum(INCOME) - sum(EXPENSES)) AS TOTAL
                                FROM (SELECT B.TRANS_DATE as DATES, DATE_FORMAT(B.TRANS_DATE, '%M %Y') AS TRANS_DATE,
                                             A.AMOUNT AS INCOME,
                                             0 EXPENSES
                                      FROM MT_TRANSDET A
                                           LEFT JOIN MT_TRANSACTION B ON A.TRANS_ID = B.TRANS_ID
                                      WHERE A.TRANS_ID <> 0
                                      UNION ALL
                                      SELECT D.TRANS_DATE as DATES, DATE_FORMAT(D.TRANS_DATE, '%M %Y') AS TRANS_DATE,
                                             0 INCOME,
                                             D.AMOUNT AS EXPENSES
                                      FROM MT_TRANSDET C LEFT JOIN MG_SHOPLIST D ON C.SHOPPING_ID = D.ID
                                      WHERE C.SHOPPING_ID <> 0) AS FINANCE
                                GROUP BY TRANS_DATE ORDER BY DATES DESC LIMIT 5";
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
        private DataTable getshoppingdata()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            DataTable validatedt = new DataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT SUM(AMOUNT) TOTAL,  DATE_FORMAT(TRANS_DATE, '%Y-%m') as TRANS_DATES
                                FROM mg_shoplist
                                WHERE trans_date >= now() - INTERVAL 4 MONTH
                                GROUP BY TRANS_DATES
                                ORDER BY TRANS_DATE DESC;";
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
        private DataTable gettop5customerdata(string date, int range)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            DataTable validatedt = new DataTable();

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT B.CUST_ID,
	                       C.CUST_NAME,
                           SUM(A.AMOUNT) TOTAL
                    FROM MT_TRANSDET A LEFT JOIN 
                    MT_TRANSACTION B ON A.TRANS_ID = B.TRANS_ID LEFT JOIN MT_CUSTOMER C ON B.CUST_ID = C.CUST_ID WHERE C.CUST_ID IS NOT NULL" + Environment.NewLine;
                if (!string.IsNullOrEmpty(date))
                {
                    sql += @"AND year(B.TRANS_DATE) = year('" + date + "')" + Environment.NewLine;
                    sql += @"AND month(B.TRANS_DATE) = month('" + date + "')" + Environment.NewLine;

                }
                sql += @"GROUP BY B.CUST_ID, C.CUST_NAME
                    ORDER BY TOTAL DESC, C.CUST_NAME ASC LIMIT " + range;
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
        #endregion getdata

        protected void Periode_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            var date = e.NewDate;
            string converteddate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            var ModeDDVal = ModeDD.SelectedValue;
            int modeddint = Convert.ToInt32(ModeDDVal);
            loadproductdata(converteddate, modeddint);

        }

        protected void PeriodeCust_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            var date = e.NewDate;
            string converteddate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            var ModeDDVal = ModeDDCust.SelectedValue;
            int modeddint = Convert.ToInt32(ModeDDVal);
            loadcustomerdata(converteddate, modeddint);

        }

        protected void ModeDD_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            var val = e.Value;
            var dates = Periode.SelectedDate;
            int modeddint = Convert.ToInt32(val);
            string converteddate = "";
            if (dates != null)
            {
                converteddate = Convert.ToDateTime(dates).ToString("yyyy-MM-dd");
            }
            loadproductdata(converteddate, modeddint);
        }

        protected void ModeDDCust_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            var val = e.Value;
            var dates = PeriodeCust.SelectedDate;
            int modeddint = Convert.ToInt32(val);
            string converteddate = "";
            if (dates != null)
            {
                converteddate = Convert.ToDateTime(dates).ToString("yyyy-MM-dd");
            }
            loadcustomerdata(converteddate, modeddint);
        }
    }
}