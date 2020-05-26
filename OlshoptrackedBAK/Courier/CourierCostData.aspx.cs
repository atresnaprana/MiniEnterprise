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
namespace OlshoptrackedBAK.Courier
{
    public partial class CouriereCostData : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                retrieve();
                //ShowMessage("test");

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
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT a.COST_CODE, a.COURIER_CODE, a.COST_DESC, 
                            a.COST_AMT,a.UPDATE_DATE, a.UPDATE_USER, b.COURIER_DETAIL  FROM 
                            COURIER_COST_DATA a LEFT JOIN COURIER_DATA 
                        b on a.COURIER_CODE = b.COURIER_CODE ORDER BY a.UPDATE_DATE DESC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "SUPPLIER_CP_DATA");
                rgCourierCost.DataSource = dsCountry;
                rgCourierCost.DataBind();



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
        private void insert(string desc, Double cost, string couriercode)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO COURIER_COST_DATA (COST_CODE, COURIER_CODE, COST_DESC, COST_AMT,UPDATE_DATE,UPDATE_USER) VALUES ('', @couriercode, @desc, @cost, @datetime, @user)", conn);

                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@cost", cost);
                cmd.Parameters.AddWithValue("@couriercode", couriercode);

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
        private void update(string desc, string couriercode, Double amt, string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update COURIER_COST_DATA Set  COST_DESC = @desc, COST_AMT = @cost, COURIER_CODE = @couriercode,UPDATE_DATE = @datetime, UPDATE_USER = @user where COST_CODE = @code", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@couriercode", couriercode);
                cmd.Parameters.AddWithValue("@cost", amt);

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
                MySqlCommand cmd = new MySqlCommand("Delete From COURIER_COST_DATA where COST_CODE = @code", conn);
                cmd.Parameters.AddWithValue("@code", code);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                LoadDataInNotification("Data Has been deleted", "Delete Successful");

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
        #endregion crud

        protected void rgCourierCost_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
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

        protected void rgCourierCost_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem)
            {
                var item = e.Item as GridEditableItem;
                var combobox = item.FindControl("RadCmbCourierHdr") as RadComboBox;
                string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                Console.WriteLine(strConnString);
                MySqlConnection conn = new MySqlConnection(strConnString);
                if (combobox != null)
                {
                    combobox.Filter = RadComboBoxFilter.Contains;

                }

                //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT COURIER_CODE, COURIER_DETAIL FROM COURIER_DATA ORDER BY COURIER_DETAIL ASC";

                    daCountry = new MySqlDataAdapter(sql, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry, "SUPPLIER_DATA");
                    combobox.DataSource = dsCountry;
                    combobox.DataBind();


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
                    var combobox = items.FindControl("RadCmbCourierHdr") as RadComboBox;

                    string val = items.GetDataKeyValue("COURIER_CODE").ToString();
                    combobox.SelectedValue = val;
                    if (combobox != null)
                    {
                        combobox.Filter = RadComboBoxFilter.Contains;

                    }

                }

            }
        }

        protected void rgCourierCost_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            retrieve();

        }

        protected void rgCourierCost_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgCourierCost_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((RadTextBox)rgCourierCost.MasterTableView.Items[e.Item.ItemIndex]["COST_CODE"].FindControl("hdrcodetxt"));
            var desc = ((RadTextBox)rgCourierCost.MasterTableView.Items[e.Item.ItemIndex]["COST_DESC"].FindControl("desc"));
            var cost = ((RadNumericTextBox)rgCourierCost.MasterTableView.Items[e.Item.ItemIndex]["COST_AMT"].FindControl("cost"));
            var courierdata = ((RadComboBox)rgCourierCost.MasterTableView.Items[e.Item.ItemIndex]["COURIER_DETAIL"].FindControl("RadCmbCourierHdr"));

            string descs = desc.Text;
            Double costs = Convert.ToDouble(cost.Text);
            string codes = code.Text;
            string selectedhdr = courierdata.SelectedValue;

            if (descs == "")
            {
                ShowMessage("Description Cannot be empty");
                return;
            }
            if (costs == 0)
            {
                ShowMessage("costs Cannot be empty");
                return;
            }
            if (selectedhdr == "")
            {
                ShowMessage("Courier Information Cannot be empty");
                return;
            }
            update(descs, selectedhdr, costs, codes);

        }

        protected void rgCourierCost_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgCourierCost_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgCourierCost.MasterTableView.Items[e.Item.ItemIndex]["COST_CODE"].FindControl("hiddencode"));
            string codetxt = code.Value;
            delete(codetxt);
        }

        protected void rgCourierCost_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var cmbcourierhdr = ((RadComboBox)rgCourierCost.MasterTableView.GetInsertItem().FindControl("RadCmbCourierHdr"));
            var desc = ((RadTextBox)rgCourierCost.MasterTableView.GetInsertItem().FindControl("desc"));
            var cost = ((RadNumericTextBox)rgCourierCost.MasterTableView.GetInsertItem().FindControl("cost"));

            string selectedhdr = cmbcourierhdr.SelectedValue;
            string descs = desc.Text;
            Double costs = Convert.ToDouble(cost.Text);
            if (descs == "")
            {
                ShowMessage("Description Cannot be empty");
                return;
            }
            if (costs == 0)
            {
                ShowMessage("costs Cannot be empty");
                return;
            }
            if (selectedhdr == "")
            {
                ShowMessage("Courier Information Cannot be empty");
                return;
            }
            insert(descs, costs, selectedhdr);
        }

        protected void rgCourierCost_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();

        }

        protected void rgCourierCost_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            retrieve();
        }

        protected void RadCmbCourierHdr_Load(object sender, EventArgs e)
        {

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
    }
}