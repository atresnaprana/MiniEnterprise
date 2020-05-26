using System;
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

namespace OlshoptrackedBAK.Supplier
{
    public partial class SupplierEntry : System.Web.UI.Page
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

        #region db crud
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

                string sql = @"SELECT SUPP_CODE, SUPP_NAME, SUPP_ADDRESS, UPDATE_USER, UPDATE_DATE, ENTRY_USER, ENTRY_DATE
                                FROM SUPPLIER_DATA ORDER BY UPDATE_DATE DESC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "SUPPLIER_DATA");
                rgSupplier.DataSource = dsCountry;
                rgSupplier.DataBind();



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
        private void insert(string name, string address)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO SUPPLIER_DATA (SUPP_CODE, SUPP_NAME, SUPP_ADDRESS, ENTRY_DATE, ENTRY_USER, UPDATE_DATE, UPDATE_USER) VALUES ('', @name, @address, @datetime, @user, @datetime,@user )", conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);

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
        private void update(string name, string address, string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update SUPPLIER_DATA Set  SUPP_NAME = @name, SUPP_ADDRESS = @address, UPDATE_DATE = @datetime, UPDATE_USER = @user where SUPP_CODE = @code", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);

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
                MySqlCommand cmd = new MySqlCommand("Delete From SUPPLIER_DATA where SUPP_CODE = @code", conn);
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
        private DataTable validateCp(string suppcode)
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

                string sql = @"SELECT SUPP_CODE FROM supplier_cp_data UNION SELECT SUPP_CODE FROM mt_prod WHERE SUPP_CODE = '" + suppcode + "'";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "SUPPLIER_DATA");
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
        #endregion db crud

        #region grid command

        protected void rgSupplier_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
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

        protected void rgSupplier_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void rgSupplier_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            retrieve();

        }

        protected void rgSupplier_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((RadTextBox)rgSupplier.MasterTableView.Items[e.Item.ItemIndex]["SUPP_CODE"].FindControl("hdrcodetxt"));
            var name = ((RadTextBox)rgSupplier.MasterTableView.Items[e.Item.ItemIndex]["SUPP_NAME"].FindControl("suppname"));
            var address = ((RadTextBox)rgSupplier.MasterTableView.Items[e.Item.ItemIndex]["SUPP_ADDRESS"].FindControl("address"));
            update(name.Text, address.Text, code.Text);
        }

        protected void rgSupplier_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgSupplier_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgSupplier_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgSupplier.MasterTableView.Items[e.Item.ItemIndex]["SUPP_CODE"].FindControl("hiddencode"));
            string codetxt = code.Value;
            var validatecp = validateCp(codetxt);
            if (validatecp.Rows.Count == 0)
            {
                delete(codetxt);
            }
            else
            {
                ShowMessage("Data is Being Used");
                return;
            }
        }

        protected void rgSupplier_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var name = ((RadTextBox)rgSupplier.MasterTableView.GetInsertItem().FindControl("suppname"));
            var address = ((RadTextBox)rgSupplier.MasterTableView.GetInsertItem().FindControl("address"));
            insert(name.Text, address.Text);
        }

        protected void rgSupplier_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();

        }

        protected void rgSupplier_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            retrieve();
        }
        #endregion grid command
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