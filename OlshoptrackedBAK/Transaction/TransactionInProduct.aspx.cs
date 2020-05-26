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

namespace OlshoptrackedBAK.Transaction
{
    public partial class TransactionInProduct : System.Web.UI.Page
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

                string sql = @"SELECT a.TRANS_PROD_CODE, a.TRANS_CODE, a.PROD_CODE, 
                            a.AMOUNT,a.UPDATE_DATE, a.UPDATE_USER, a.ENTRY_DATE, a.ENTRY_USER, b.TRANS_DETAIL, c.PROD_NAME  FROM 
                            TRANSACTION_PROD a LEFT JOIN TRANSACTION_IN_DATA
                        b on a.TRANS_CODE = b.TRANS_CODE LEFT JOIN MT_PROD C ON A.PROD_CODE = C.PROD_CODE ORDER BY a.UPDATE_DATE DESC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "SUPPLIER_CP_DATA");
                rgTransInProd.DataSource = dsCountry;
                rgTransInProd.DataBind();



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
        private void insert(string prodcode, string transcode, int amount)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_PROD (TRANS_PROD_CODE, TRANS_CODE, PROD_CODE, AMOUNT,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER) VALUES ('', @transcode, @prodcode, @amount, @datetime, @user, @datetime, @user )", conn);

                cmd.Parameters.AddWithValue("@prodcode", prodcode);
                cmd.Parameters.AddWithValue("@transcode", transcode);
                cmd.Parameters.AddWithValue("@amount", amount);

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
        private void update(string prodcode, string transcode, int amount, string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("update TRANSACTION_PROD Set  PROD_CODE = @prodcode, TRANS_CODE = @transcode, AMOUNT = @amount ,UPDATE_DATE = @datetime, UPDATE_USER = @user where TRANS_PROD_CODE = @code", conn);

                cmd.Parameters.AddWithValue("@prodcode", prodcode);
                cmd.Parameters.AddWithValue("@transcode", transcode);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@code", code);

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
        protected void delete(string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //int SID = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
                MySqlCommand cmd = new MySqlCommand("Delete From TRANSACTION_PROD where TRANS_PROD_CODE = @code", conn);
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
        protected void rgTransInProd_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
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

        protected void rgTransInProd_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem)
            {
                var item = e.Item as GridEditableItem;
                var comboboxtrans = item.FindControl("RadCmbTransHdr") as RadComboBox;
                var comboboxprod = item.FindControl("RadCmbProdHdr") as RadComboBox;

                string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                Console.WriteLine(strConnString);
                MySqlConnection conn = new MySqlConnection(strConnString);
                if (comboboxtrans != null)
                {
                    comboboxtrans.Filter = RadComboBoxFilter.Contains;

                }
                if (comboboxprod != null)
                {
                    comboboxprod.Filter = RadComboBoxFilter.Contains;

                }
                //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT TRANS_CODE, TRANS_DETAIL FROM TRANSACTION_IN_DATA ORDER BY TRANS_DETAIL ASC";

                    daCountry = new MySqlDataAdapter(sql, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry, "TRANSACTION_IN_DATA");
                    comboboxtrans.DataSource = dsCountry;
                    comboboxtrans.DataBind();

                    MySqlDataAdapter daprod;
                    DataSet dsprod;
                    string sql2 = "SELECT PROD_CODE, PROD_NAME FROM MT_PROD ORDER BY PROD_NAME ASC";
                    daprod = new MySqlDataAdapter(sql2, conn);

                    MySqlCommandBuilder cb2 = new MySqlCommandBuilder(daprod);
                    dsprod = new DataSet();
                    daprod.Fill(dsprod, "TRANSACTION_PROD");
                    comboboxprod.DataSource = dsprod;
                    comboboxprod.DataBind();
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
                    string val = items.GetDataKeyValue("TRANS_CODE").ToString();
                    string val2 = items.GetDataKeyValue("PROD_CODE").ToString();

                    var comboboxtrans = items.FindControl("RadCmbTransHdr") as RadComboBox;

                    comboboxtrans.SelectedValue = val;
                    if (comboboxtrans != null)
                    {
                        comboboxtrans.Filter = RadComboBoxFilter.Contains;

                    }
                    var comboboxprod = items.FindControl("RadCmbProdHdr") as RadComboBox;

                    comboboxprod.SelectedValue = val2;
                    if (comboboxprod != null)
                    {
                        comboboxprod.Filter = RadComboBoxFilter.Contains;

                    }

                }

            }
        }

        protected void rgTransInProd_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            retrieve();
        }

        protected void rgTransInProd_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgTransInProd_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            RadComboBox cmbprodhdr = (RadComboBox)item.FindControl("RadCmbProdHdr");
            RadComboBox cmbtranshdr = (RadComboBox)item.FindControl("RadCmbTransHdr");
            RadTextBox code = (RadTextBox)item.FindControl("hdrcodetxt");
            RadNumericTextBox amt = (RadNumericTextBox)item.FindControl("amount");

            string transcode = cmbtranshdr.SelectedValue;
            string prodcode = cmbprodhdr.SelectedValue;
            int amount = Convert.ToInt32(amt.Text);
            string codes = code.Text;

            if (transcode == "")
            {
                ShowMessage("Transaction Information Cannot be empty");
                return;
            }
            if (prodcode == "")
            {
                ShowMessage("Product Information Cannot be empty");
                return;
            }
            if (amount == 0)
            {
                ShowMessage("Product Amount Cannot be empty");
                return;
            }
            update(prodcode, transcode, amount, codes);
        }

        protected void rgTransInProd_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgTransInProd_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgTransInProd.MasterTableView.Items[e.Item.ItemIndex]["TRANS_PROD_CODE"].FindControl("hiddencode"));
            string codetxt = code.Value;
            delete(codetxt);
        }

        protected void rgTransInProd_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var cmbtranshdr = ((RadComboBox)rgTransInProd.MasterTableView.GetInsertItem().FindControl("RadCmbTransHdr"));
            var cmbprodhdr = ((RadComboBox)rgTransInProd.MasterTableView.GetInsertItem().FindControl("RadCmbProdHdr"));
            var amt = ((RadNumericTextBox)rgTransInProd.MasterTableView.GetInsertItem().FindControl("amount"));

            string transcode = cmbtranshdr.SelectedValue;
            string prodcode = cmbprodhdr.SelectedValue;
            int amount = Convert.ToInt32(amt.Text);

            if (transcode == "")
            {
                ShowMessage("Transaction Information Cannot be empty");
                return;
            }
            if (prodcode == "")
            {
                ShowMessage("Product Information Cannot be empty");
                return;
            }
            if (amount == 0)
            {
                ShowMessage("Product Amount Cannot be empty");
                return;
            }
            insert(prodcode, transcode, amount);
        }

        protected void rgTransInProd_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();
        }

        protected void rgTransInProd_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            retrieve();
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