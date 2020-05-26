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


namespace OlshoptrackedBAK.Inventory
{
    public partial class ShoppingList : System.Web.UI.Page
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

                string sql = @"SELECT ID, NOTES, AMOUNT, UPDATE_DATE, UPDATE_USER, ENTRY_DATE, ENTRY_USER, TRANS_DATE FROM MG_SHOPLIST ORDER BY ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MG_SHOPLIST");
                rgShoppingList.DataSource = dsCountry;
                rgShoppingList.DataBind();


               
            }
            catch (Exception ex)
            {
                //ShowMessage("Error: " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done.");

        }

        private void insert(Double amount, string notes, DateTime transdate)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO MG_SHOPLIST (NOTES, AMOUNT, TRANS_DATE,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER) VALUES (@notes, @amount, @transdate, @datetime, @user, @datetime, @user )", conn);

                cmd.Parameters.AddWithValue("@notes", notes);

                cmd.Parameters.AddWithValue("@transdate", transdate);
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

        private void update(string notes, Double amount, DateTime transdate, string id)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update MG_SHOPLIST Set  NOTES = @notes, AMOUNT = @amount, TRANS_DATE = @transdate ,UPDATE_DATE = @datetime, UPDATE_USER = @user where ID = @id", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.Parameters.AddWithValue("@transdate", transdate);
                cmd.Parameters.AddWithValue("@amount", amount);

                cmd.Parameters.AddWithValue("@id", id);
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
                MySqlCommand cmd = new MySqlCommand("Delete From MG_SHOPLIST where ID = @code", conn);
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
        #region gridcommands
        protected void rgShoppingList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
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

        protected void rgShoppingList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void rgShoppingList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT ID, NOTES, AMOUNT, UPDATE_DATE, UPDATE_USER, ENTRY_DATE, ENTRY_USER, TRANS_DATE FROM MG_SHOPLIST ORDER BY ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MG_SHOPLIST");
                rgShoppingList.DataSource = dsCountry;



            }
            catch (Exception ex)
            {
                //ShowMessage("Error: " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        protected void rgShoppingList_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgShoppingList.MasterTableView.Items[e.Item.ItemIndex]["ID"].FindControl("hiddencode"));
            string codetxt = code.Value;
            //var validateprodcode = validatetransaction(codetxt);
            //if (validateprodcode.Rows.Count > 0)
            //{
            //    ShowMessage("already used in transaction");
            //    return;
            //}
            delete(codetxt);
        }

        protected void rgShoppingList_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgShoppingList_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            RadTextBox code = (RadTextBox)item.FindControl("hdrcodetxt");

            RadTextBox notes = (RadTextBox)item.FindControl("notes");
            RadDatePicker transdate = (RadDatePicker)item.FindControl("transdate");
            RadNumericTextBox amount = (RadNumericTextBox)item.FindControl("amount");


            string id = code.Text;
            string notess = notes.Text;
            DateTime transdates = Convert.ToDateTime(transdate.SelectedDate);
            Double amounts = Convert.ToDouble(amount.Text);

            if (notess == "")
            {
                ShowMessage("Notes Cannot be empty");
                return;
            }
            //var validateprodcode = validatetransaction(prodcode);
            //if (validateprodcode.Rows.Count > 0)
            //{
            //    ShowMessage("already used in transaction");
            //    return;
            //}
            if (amounts == 0)
            {
                ShowMessage("Please fill amount");
                return;
            }
            if (transdate.SelectedDate == null)
            {
                ShowMessage("Please fill transaction date");
                return;
            }
            update(notess,amounts,transdates,id);
        }

        protected void rgShoppingList_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgShoppingList_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var notes = ((RadTextBox)rgShoppingList.MasterTableView.GetInsertItem().FindControl("notes"));

            var transdate = ((RadDatePicker)rgShoppingList.MasterTableView.GetInsertItem().FindControl("transdate"));

            var amount = ((RadNumericTextBox)rgShoppingList.MasterTableView.GetInsertItem().FindControl("amount"));

            string notess = notes.Text;
            DateTime transdates = Convert.ToDateTime(transdate.SelectedDate);
            Double amounts = Convert.ToDouble(amount.Text);

            if (notess == "")
            {
                ShowMessage("Notes Cannot be empty");
                return;
            }
            if (transdate.SelectedDate == null)
            {
                ShowMessage("please fill transaction date");
                return;
            }
            if (amounts == 0)
            {
                ShowMessage("Amounts Cannot be empty");
                return;
            }

            insert(amounts, notess, transdates);
        }

        protected void rgShoppingList_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();
        }

        protected void rgShoppingList_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
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
        #endregion gridcommands
    }
}