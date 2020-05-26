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
using System.Windows.Forms;


namespace OlshoptrackedBAK.Transaction
{
    public partial class TransactionIn2pagestyle : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        public DataTable TransDt
        {
            get { return (DataTable)ViewState["TransDt"]; }
            set { ViewState["TransDt"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                retrieve();
                //ShowMessage("test");

            }
            else
            {
                //retrieve2(HdfRetrieveID.Value);
                /*foreach (GridDataItem item in rgTransIn.SelectedItems)
                {
                    string value = item.GetDataKeyValue("TRANS_CODE").ToString();
                }*/
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }
        #region crud
        private void retrieve()
        {
            Enableediting(false);
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT A.TRANS_CODE, A.TRANS_DETAIL, A.TRANS_DATE, A.CUST_CODE, A.COST_CODE, A.ENTRY_USER, A.ENTRY_DATE, A.UPDATE_DATE, A.UPDATE_USER, A.TRANS_TOTAL, A.COURIER_CODE, B.CUST_NAME, C.COURIER_DETAIL, D.COST_DESC
                                FROM TRANSACTION_IN_DATA A LEFT JOIN CUST_DATA B ON A.CUST_CODE = B.CUST_CODE  LEFT JOIN COURIER_DATA C ON A.COURIER_CODE = C.COURIER_CODE LEFT JOIN COURIER_COST_DATA D ON A.COST_CODE = D.COST_CODE ORDER BY A.UPDATE_DATE DESC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                var dt = new DataTable();
                daCountry.Fill(dsCountry, "TRANS_IN_DATA");
                rgTransIn.DataSource = dsCountry;
                rgTransIn.DataBind();
                Edit(false);
                if (rgTransIn.Items.Count > 0)
                {
                    if (HdfRetrieveID.Value == "")
                    {
                        rgTransIn.Items[0].Selected = true;
                        HdfRetrieveID.Value = rgTransIn.Items[0].GetDataKeyValue("TRANS_CODE").ToString();
                        retrieve2(HdfRetrieveID.Value);
                    }
                    else
                    {
                        retrieve2(HdfRetrieveID.Value);
                    }

                }


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
        private void Edit(bool isedit)
        {
            transcode.Enabled = false;
            transdetail.Enabled = isedit;
            transdate.Enabled = isedit;
            RadCmbCustHdr.Enabled = isedit;
            RadCmbOnlineShop.Enabled = isedit;
            total.Enabled = isedit;
            RadCmbCourierHdr.Enabled = isedit;
            RadCmbCostHdr.Enabled = false;
            PackedStat.Enabled = isedit;
            SentStat.Enabled = isedit;
            PaymentStat.Enabled = isedit;
            Remarks.Enabled = isedit;

        }
        private void Enableediting(bool isedit)
        {
            Save.Enabled = isedit;
            Delete.Enabled = isedit;
            Insert.Enabled = isedit;
        }
        private void setFieldForm(DataTable dt)
        {

            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            RadCmbCustHdr.Filter = RadComboBoxFilter.Contains;
            RadCmbOnlineShop.Filter = RadComboBoxFilter.Contains;
            RadCmbCourierHdr.Filter = RadComboBoxFilter.Contains;
            RadCmbCostHdr.Filter = RadComboBoxFilter.Contains;
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT CUST_CODE, CUST_NAME FROM CUST_DATA ORDER BY CUST_NAME ASC";

                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "CUST_DATA");
                RadCmbCustHdr.DataSource = dsCountry;
                RadCmbCustHdr.DataBind();


                string sql2 = "SELECT COURIER_CODE, COURIER_DETAIL FROM COURIER_DATA ORDER BY COURIER_DETAIL ASC";
                var courieradp = new MySqlDataAdapter(sql2, conn);
                var courierdt = new DataSet();
                courieradp.Fill(courierdt, "COURIER_DATA");
                RadCmbCourierHdr.DataSource = courierdt;
                RadCmbCourierHdr.DataBind();

                string sql3 = "SELECT COST_CODE, COST_DESC FROM COURIER_COST_DATA ORDER BY COST_DESC ASC";
                var costadp = new MySqlDataAdapter(sql3, conn);
                var costdt = new DataSet();
                costadp.Fill(costdt, "COURIER_COST_DATA");
                RadCmbCostHdr.DataSource = costdt;
                RadCmbCostHdr.DataBind();

                string sql4 = "SELECT OLSHOP_CODE, OLSHOP_NAME FROM MT_OLSHOP ORDER BY OLSHOP_NAME ASC";
                var olshopadp = new MySqlDataAdapter(sql4, conn);
                var olshopdt = new DataSet();
                olshopadp.Fill(olshopdt, "MT_OLSHOP");
                RadCmbOnlineShop.DataSource = olshopdt;
                RadCmbOnlineShop.DataBind();

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
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    transcode.Text = TransDt.Rows[0]["TRANS_CODE"].ToString();
                    transdetail.Text = TransDt.Rows[0]["TRANS_DETAIL"].ToString();
                    if (TransDt.Rows[0]["TRANS_DATE"] != null)
                    {
                        transdate.SelectedDate = Convert.ToDateTime(TransDt.Rows[0]["TRANS_DATE"].ToString());

                    }
                    else
                    {
                        transdate.Clear();
                    }
                    if (TransDt.Rows[0]["TRANS_TOTAL"] != null)
                    {
                        total.Text = TransDt.Rows[0]["TRANS_TOTAL"].ToString();
                    }
                    else
                    {
                        total.Text = "0";
                    }
                    if (TransDt.Rows[0]["CUST_CODE"] != null)
                    {
                        RadCmbCustHdr.SelectedValue = TransDt.Rows[0]["CUST_CODE"].ToString();
                    }
                    else
                    {
                        RadCmbCustHdr.ClearSelection();
                        RadCmbCustHdr.EmptyMessage = "Select...";
                    }
                    if (TransDt.Rows[0]["OLSHOP_CODE"] != null)
                    {
                        RadCmbOnlineShop.SelectedValue = TransDt.Rows[0]["OLSHOP_CODE"].ToString();
                    }
                    else
                    {
                        RadCmbOnlineShop.ClearSelection();
                        RadCmbOnlineShop.EmptyMessage = "Select...";
                    }
                    if (TransDt.Rows[0]["COURIER_CODE"] != null)
                    {
                        RadCmbCourierHdr.SelectedValue = TransDt.Rows[0]["COURIER_CODE"].ToString();
                    }
                    else
                    {
                        RadCmbCourierHdr.ClearSelection();
                        RadCmbCourierHdr.EmptyMessage = "Select...";
                    }
                    if (TransDt.Rows[0]["COST_CODE"] != null)
                    {
                        RadCmbCostHdr.SelectedValue = TransDt.Rows[0]["COST_CODE"].ToString();
                    }
                    else
                    {
                        RadCmbCostHdr.ClearSelection();
                        RadCmbCostHdr.EmptyMessage = "Select...";
                    }
                    if (TransDt.Rows[0]["PACKED_STATUS"] != null)
                    {
                        PackedStat.SetSelectedToggleStateByValue(TransDt.Rows[0]["PACKED_STATUS"].ToString());
                    }
                    else
                    {
                        PackedStat.Checked = false;
                    }
                    if (TransDt.Rows[0]["SENT_STATUS"] != null)
                    {
                        SentStat.SetSelectedToggleStateByValue(TransDt.Rows[0]["SENT_STATUS"].ToString());
                    }
                    else
                    {
                        SentStat.Checked = false;
                    }
                    if (TransDt.Rows[0]["TRANS_STATUS"] != null)
                    {
                        PaymentStat.SetSelectedToggleStateByValue(TransDt.Rows[0]["TRANS_STATUS"].ToString());
                    }
                    else
                    {
                        PaymentStat.Checked = false;
                    }
                    if (TransDt.Rows[0]["REMARKS"] != null)
                    {
                        Remarks.Text = TransDt.Rows[0]["REMARKS"].ToString();
                    }
                    else
                    {
                        Remarks.Text = "";
                    }

                }
                else
                {
                    transcode.Text = "";
                    transdetail.Text = "";
                    transdate.Clear();
                    total.Text = "";
                    RadCmbOnlineShop.ClearSelection();
                    RadCmbOnlineShop.EmptyMessage = "Select...";
                    RadCmbCustHdr.ClearSelection();
                    RadCmbCustHdr.EmptyMessage = "Select...";
                    RadCmbCourierHdr.ClearSelection();
                    RadCmbCourierHdr.EmptyMessage = "Select...";
                    RadCmbCostHdr.ClearSelection();
                    RadCmbCostHdr.EmptyMessage = "Select...";
                    PackedStat.Checked = false;
                    SentStat.Checked = false;
                    PaymentStat.Checked = false;
                    Remarks.Text = "";

                }
            }
            else
            {
                transcode.Text = "";
                transdetail.Text = "";
                transdate.Clear();
                total.Text = "";
                RadCmbOnlineShop.ClearSelection();
                RadCmbOnlineShop.EmptyMessage = "Select...";
                RadCmbCustHdr.ClearSelection();
                RadCmbCustHdr.EmptyMessage = "Select...";
                RadCmbCourierHdr.ClearSelection();
                RadCmbCourierHdr.EmptyMessage = "Select...";
                RadCmbCostHdr.ClearSelection();
                RadCmbCostHdr.EmptyMessage = "Select...";
                PackedStat.Checked = false;
                SentStat.Checked = false;
                PaymentStat.Checked = false;
                Remarks.Text = "";

            }

        }
        private void retrieve2(string transcodes)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT A.TRANS_CODE, A.TRANS_DETAIL, A.TRANS_DATE, A.CUST_CODE, A.PACKED_STATUS, A.SENT_STATUS, A.TRANS_STATUS, A.REMARKS, A.COST_CODE, A.ENTRY_USER, A.ENTRY_DATE, A.UPDATE_DATE, A.UPDATE_USER, A.TRANS_TOTAL, A.COURIER_CODE, B.CUST_NAME, C.COURIER_DETAIL, D.COST_DESC, A.OLSHOP_CODE
                                FROM TRANSACTION_IN_DATA A LEFT JOIN CUST_DATA B ON A.CUST_CODE = B.CUST_CODE  
                                LEFT JOIN COURIER_DATA C ON A.COURIER_CODE = C.COURIER_CODE 
                                LEFT JOIN COURIER_COST_DATA D ON A.COST_CODE = D.COST_CODE
                                LEFT JOIN MT_OLSHOP E ON A.OLSHOP_CODE = E.OLSHOP_CODE WHERE A.TRANS_CODE = '" + transcodes + "'";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                var dt = new DataTable();
                daCountry.Fill(dsCountry, "TRANS_IN_DATA");
                daCountry.Fill(dt);
                TransDt = dt;
                setFieldForm(TransDt);


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
        private void insert(string transcode, string detail, DateTime transdate, int custcode, Double transtotal, int couriercode, int costcode, string packedstat, string sentstat, string paymentstat, string remarks, int olshopdet)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO TRANSACTION_IN_DATA (TRANS_CODE, TRANS_DETAIL, TRANS_DATE, CUST_CODE, 
                                                      TRANS_TOTAL, COURIER_CODE, COST_CODE , PACKED_STATUS,SENT_STATUS, TRANS_STATUS, REMARKS,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER, OLSHOP_CODE) 
                                                      VALUES (@transcode, @detail, @transdate, @custcode, @transtotal, @couriercode, @costcode, @packedstat, @sentstat, @paymentstat, @remarks,@datetime, @user, @datetime, @user,@olshopdet)", conn);

                cmd.Parameters.AddWithValue("@transcode", transcode);
                cmd.Parameters.AddWithValue("@detail", detail);

                cmd.Parameters.AddWithValue("@transdate", transdate);
                cmd.Parameters.AddWithValue("@custcode", custcode);

                cmd.Parameters.AddWithValue("@transtotal", transtotal);
                cmd.Parameters.AddWithValue("@couriercode", couriercode);
                cmd.Parameters.AddWithValue("@costcode", costcode);
                cmd.Parameters.AddWithValue("@packedstat", packedstat);
                cmd.Parameters.AddWithValue("@sentstat", sentstat);
                cmd.Parameters.AddWithValue("@paymentstat", paymentstat);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@olshopdet", olshopdet);

                cmd.Parameters.AddWithValue("@user", Session["id"].ToString());

                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                LoadDataInNotification("Data Has been added", "Add Successful");
                //ShowMessage("Hdr Data update Successfully......!");
                retrieve();

            }
            catch (MySqlException ex)
            {
                ShowMessage("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void update(string detail, DateTime transdate, int custcode, int couriercode, int costcode, Double total, string code, string packedstat, string sentstat, string paymentstat, string remarks, int olshopdet)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand(@"update TRANSACTION_IN_DATA Set  TRANS_DETAIL = @detail, TRANS_DATE = @transdate, 
                                                    CUST_CODE = @custcode, COURIER_CODE = @couriercode, COST_CODE = @costcode, TRANS_TOTAL = @total , PACKED_STATUS = @packedstat, 
                                                    SENT_STATUS = @sentstat, TRANS_STATUS = @paymentstat,
                                                    OLSHOP_CODE = @olshopdet, REMARKS = @remarks,
                                                    UPDATE_DATE = @datetime, UPDATE_USER = @user where TRANS_CODE = @code", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@detail", detail);
                cmd.Parameters.AddWithValue("@transdate", transdate);
                cmd.Parameters.AddWithValue("@custcode", custcode);
                cmd.Parameters.AddWithValue("@couriercode", couriercode);
                cmd.Parameters.AddWithValue("@costcode", costcode);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@packedstat", packedstat);
                cmd.Parameters.AddWithValue("@sentstat", sentstat);
                cmd.Parameters.AddWithValue("@paymentstat", paymentstat);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@olshopdet", olshopdet);

                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@user", Session["id"].ToString());

                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                retrieve();
                LoadDataInNotification("Data has been Updated", "Update Success");
                //ShowMessage("Hdr Data update Successfully......!");

            }
            catch (MySqlException ex)
            {
                ShowMessage("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        protected void delete(string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //int SID = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
                MySqlCommand cmd = new MySqlCommand("Delete From TRANSACTION_IN_DATA where TRANS_CODE = @code", conn);
                cmd.Parameters.AddWithValue("@code", code);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                LoadDataInNotification("Data Has been deleted", "Delete Successful");
                retrieve();

            }
            catch (MySqlException ex)
            {
                ShowMessage("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private DataTable validatecode(string prodcode)
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

                string sql = @"SELECT TRANS_CODE FROM TRANSACTION_PROD where TRANS_CODE = '" + prodcode + "'";
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
        private DataTable chktbl()
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

                string sql = @"SELECT * FROM TRANSACTION_IN_DATA";
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
        #endregion crud
        protected void rgTransIn_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                retrieve2(HdfRetrieveID.Value);
            }
            if (e.CommandName == "InitInsert")
            {
                hdfdataoperation.Value = "Insert";
                //rgDetail.MasterTableView.IsItemInserted = true;

            }
            else if (e.CommandName == "Edit")
            {
                hdfdataoperation.Value = "Edit";
            }
            else
            {
                hdfdataoperation.Value = "";
            }
        }

        protected void rgTransIn_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem)
            {
                var item = e.Item as GridEditableItem;
                var custcombobox = item.FindControl("RadCmbCustHdr") as RadComboBox;
                var costcombobox = item.FindControl("RadCmbCostHdr") as RadComboBox;
                var couriercombobox = item.FindControl("RadCmbCourierHdr") as RadComboBox;

                string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                Console.WriteLine(strConnString);
                MySqlConnection conn = new MySqlConnection(strConnString);
                if (custcombobox != null)
                {
                    custcombobox.Filter = RadComboBoxFilter.Contains;

                }
                if (couriercombobox != null)
                {
                    couriercombobox.Filter = RadComboBoxFilter.Contains;

                }
                if (costcombobox != null)
                {
                    costcombobox.Enabled = false;
                    costcombobox.Filter = RadComboBoxFilter.Contains;

                }
                //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT CUST_CODE, CUST_NAME FROM CUST_DATA ORDER BY CUST_NAME ASC";

                    daCountry = new MySqlDataAdapter(sql, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry, "CUST_DATA");
                    custcombobox.DataSource = dsCountry;
                    custcombobox.DataBind();


                    string sql2 = "SELECT COURIER_CODE, COURIER_DETAIL FROM COURIER_DATA ORDER BY COURIER_DETAIL ASC";
                    var courieradp = new MySqlDataAdapter(sql2, conn);
                    var courierdt = new DataSet();
                    courieradp.Fill(courierdt, "COURIER_DATA");
                    couriercombobox.DataSource = courierdt;
                    couriercombobox.DataBind();

                    string sql3 = "SELECT COST_CODE, COST_DESC FROM COURIER_COST_DATA ORDER BY COST_DESC ASC";
                    var costadp = new MySqlDataAdapter(sql3, conn);
                    var costdt = new DataSet();
                    costadp.Fill(costdt, "COURIER_COST_DATA");
                    costcombobox.DataSource = costdt;
                    costcombobox.DataBind();

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
            if (e.Item.IsInEditMode && hdfdataoperation.Value == "Edit")
            {
                var items = e.Item as GridEditableItem;
                if (items != null)
                {
                    var combocustbox = items.FindControl("RadCmbCustHdr") as RadComboBox;

                    string valcust = items.GetDataKeyValue("CUST_CODE").ToString();
                    combocustbox.SelectedValue = valcust;
                    if (combocustbox != null)
                    {
                        combocustbox.Filter = RadComboBoxFilter.Contains;

                    }
                    var combocourierbox = items.FindControl("RadCmbCourierHdr") as RadComboBox;

                    string valcourier = items.GetDataKeyValue("COURIER_CODE").ToString();
                    combocourierbox.SelectedValue = valcourier;
                    if (combocourierbox != null)
                    {
                        combocourierbox.Filter = RadComboBoxFilter.Contains;

                    }
                    var combocostbox = items.FindControl("RadCmbCostHdr") as RadComboBox;

                    string valcost = items.GetDataKeyValue("COST_CODE").ToString();
                    combocostbox.SelectedValue = valcost;
                    if (combocostbox != null)
                    {
                        combocostbox.Filter = RadComboBoxFilter.Contains;

                    }

                }

            }
        }

        protected void rgTransIn_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            retrieve();
        }

        protected void rgTransIn_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgTransIn_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_CODE"].FindControl("hiddencode"));
            string codetxt = code.Value;
            var dtval = validatecode(codetxt);
            if (dtval.Rows.Count == 0)
            {
                delete(codetxt);

            }
            else
            {
                ShowMessage("Data Is Being Used");
                return;
            }
        }

        protected void rgTransIn_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((RadTextBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_CODE"].FindControl("hdrcodetxt"));
            var detail = ((RadTextBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_DETAIL"].FindControl("detail"));
            var cust = ((RadComboBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["CUST_NAME"].FindControl("RadCmbCustHdr"));
            var courier = ((RadComboBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["COURIER_DETAIL"].FindControl("RadCmbCourierHdr"));
            var cost = ((RadComboBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["COST_DESC"].FindControl("RadCmbCostHdr"));
            var transdate = ((RadDatePicker)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_DATE"].FindControl("transdate"));
            var transtotal = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_TOTAL"].FindControl("total"));

            string codes = code.Text;
            string details = detail.Text;
            int custs = Convert.ToInt16(cust.SelectedValue);
            int couriers = Convert.ToInt16(courier.SelectedValue);
            int costs = Convert.ToInt16(cost.SelectedValue);
            DateTime transdates = Convert.ToDateTime(transdate.SelectedDate);
            Double total = Convert.ToDouble(transtotal.Text);

            //update(details, transdates, custs, couriers, costs, total, codes);
        }

        protected void rgTransIn_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            HdfSelectedRow.Value = e.Item.ItemIndex.ToString();

        }

        protected void rgTransIn_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((RadTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("hdrcodetxt"));
            var detail = ((RadTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("detail"));
            var cmbcusthdr = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbCustHdr"));
            var cmbcourierhdr = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbCourierHdr"));
            var cmbcosthdr = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbCostHdr"));
            var transdate = ((RadDatePicker)rgTransIn.MasterTableView.GetInsertItem().FindControl("transdate"));
            var total = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("total"));

            string codes = code.Text;
            string details = detail.Text;
            int custcode = Convert.ToInt16(cmbcusthdr.SelectedValue);
            int couriercode = Convert.ToInt16(cmbcourierhdr.SelectedValue);
            int costcode = Convert.ToInt16(cmbcosthdr.SelectedValue);
            DateTime date = Convert.ToDateTime(transdate.SelectedDate);
            Double totals = Convert.ToDouble(total.Text);
            //insert(codes, details, date, custcode, totals, couriercode, costcode);
        }

        protected void rgTransIn_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();
        }

        protected void rgTransIn_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            retrieve();
        }

        protected void RadCmbCourierHdr_ItemChecked(object sender, RadComboBoxItemEventArgs e)
        {

        }

        protected void RadCmbCourierHdr_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            RadCmbCostHdr.Enabled = true;
            RadCmbCostHdr.ClearSelection();
            RadCmbCostHdr.EmptyMessage = "Select...";
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT COST_CODE, COST_DESC FROM COURIER_COST_DATA WHERE COURIER_CODE = '" + e.Value + "' ORDER BY COST_DESC ASC";

                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "CUST_DATA");
                RadCmbCostHdr.DataSource = dsCountry;
                RadCmbCostHdr.DataBind();

            }
            catch (Exception ex)
            {
                //ShowMessage("Error: " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
        void ShowMessage(string msg)
        {
            //ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script  language = 'javascript' > alert('" + msg + "');</ script > ");

            RadWindowManager1.RadAlert(msg, 300, 200, "My Alert", "callBackFn", "myAlertImage.png");
        }
        private void LoadDataInNotification(string notiftext, string title)
        {
            //RadNotification1.ContentIcon = ;
            RadNotification1.Text = notiftext;
            RadNotification1.Value = "testing";
            RadNotification1.Title = title;

            RadNotification1.Visible = true;
            RadNotification1.Show();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            DateTime transdates;
            int custs = 0;
            Double totals = 0;
            string codes = transcode.Text;
            string details = transdetail.Text;
            int olshopdet = 0;
            if (details == "")
            {
                ShowMessage("Detail Cannot be empty");
                return;
            }
            if (transdate.SelectedDate != null)
            {
                transdates = Convert.ToDateTime(transdate.SelectedDate);
            }
            else
            {
                ShowMessage("Transaction Date Cannot be empty");
                return;
            }
            if (RadCmbOnlineShop.SelectedValue == "")
            {
                ShowMessage("Online Shop Information Cannot be empty");
                return;
            }
            else
            {
                olshopdet = Convert.ToInt32(RadCmbOnlineShop.SelectedValue);
            }
            if (RadCmbCustHdr.SelectedValue == "")
            {
                ShowMessage("Customer Information Cannot be empty");
                return;
            }
            else
            {
                custs = Convert.ToInt32(RadCmbCustHdr.SelectedValue);

            }
            int couriers = Convert.ToInt32(RadCmbCourierHdr.SelectedValue);
            int costs = Convert.ToInt32(RadCmbCostHdr.SelectedValue);
            if (total.Text == "")
            {
                ShowMessage("Total Transaction Cannot be empty");
                return;
            }
            else
            {
                totals = Convert.ToDouble(total.Text);
            }

            string packedstats = PackedStat.SelectedToggleState.Value;
            string sentstats = SentStat.SelectedToggleState.Value;
            string transtats = PaymentStat.SelectedToggleState.Value;
            string remarks = Remarks.Text;
            if (hdfdataoperation.Value == "Edit")
            {
                update(details, transdates, custs, couriers, costs, totals, codes, packedstats, sentstats, transtats, remarks, olshopdet);

            }
            else if (hdfdataoperation.Value == "Insert")
            {
                insert(codes, details, transdates, custs, totals, couriers, costs, packedstats, sentstats, transtats, remarks, olshopdet);
            }
        }

        protected void Retrieve_Click(object sender, EventArgs e)
        {
            Enableediting(false);
            retrieve();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            hdfdataoperation.Value = "Edit";
            var chktbls = chktbl();
            if (chktbls.Rows.Count > 0)
            {
                Edit(true);
            }
            else
            {
                Edit(false);
            }
            Enableediting(true);
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            hdfdataoperation.Value = "Insert";

            HdfRetrieveID.Value = "";
            Edit(true);
            transcode.Enabled = true;
            setFieldForm(null);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                HdfRetrieveID.Value = "";
                string codetxt = transcode.Text;
                var dtval = validatecode(codetxt);
                if (dtval.Rows.Count == 0)
                {
                    delete(codetxt);

                }
                else
                {
                    ShowMessage("Data Is Being Used");
                    return;
                }
            }
            /*if (confirmResult == DialogResult.Yes)
            {
                
            }
            else
            {
            }*/
        }
    }
}