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
using System.Security.Cryptography;
using System.IO;

using System.Threading.Tasks;

namespace OlshoptrackedBAK.Customer
{
    public partial class CustomerData : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        private string columnName
        {
            get { return ViewState["columnName"].ToString(); }
            set { ViewState["columnName"] = value; }
        }
        private string filterValue
        {
            get { return ViewState["filterValue"].ToString(); }
            set { ViewState["filterValue"] = value; }
        }
        private string isFilter
        {
            get { return ViewState["isFilter"].ToString(); }
            set { ViewState["isFilter"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                retrieve();
                isFilter = "false";

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

                string sql = @"SELECT CUST_ID, CUST_NAME, ADDRESS, ENTRY_DATE, ENTRY_USER, UPDATE_USER, UPDATE_DATE, PHONE, EMAIL FROM MT_CUSTOMER ORDER BY CUST_ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MT_CUSTOMER");
                rgCustomer.DataSource = dsCountry;
                rgCustomer.DataBind();



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
        private void insert(string name, string phone, string address, string email)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO MT_CUSTOMER (CUST_NAME, PHONE, ADDRESS, EMAIL,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER) VALUES (@name, @phone, @address, @emaiL,@datetime, @user, @datetime, @user)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);

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
        private void update(string name, string address, string phone, string email, string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update MT_CUSTOMER Set  CUST_NAME = @name, ADDRESS = @address, EMAIL = @email ,PHONE = @phone ,UPDATE_DATE = @datetime, UPDATE_USER = @user, ENTRY_DATE = @datetime, ENTRY_USER = @user where CUST_ID = @code", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);

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
                MySqlCommand cmd = new MySqlCommand("Delete From MT_CUSTOMER where CUST_ID = @code", conn);
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
        protected void rgCustomer_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
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
            else if (e.CommandName == "Filter")
            {
                Pair filterPair = (Pair)e.CommandArgument;
                var gridMessage1 = "Current Filter function: '" + filterPair.First + "' for column '" + filterPair.Second + "'";
                TextBox filterBox = (e.Item as GridFilteringItem)[filterPair.Second.ToString()].Controls[0] as TextBox;
                var gridMessage2 = "<br> Entered pattern for search: " + filterBox.Text;
                columnName = filterPair.Second.ToString();
                filterValue = filterBox.Text;
                if (!string.IsNullOrEmpty(filterBox.Text))
                {
                    isFilter = "true";
                }
                else
                {
                    isFilter = "false";
                }


            }
            else
            {
                hdfdataoperation.Value = "";
            }
        }

        protected void rgCustomer_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //if (e.Item is GridEditableItem)
            //{
            //    var item = e.Item as GridEditableItem;
            //    var comboboxcity = item.FindControl("RadCmbCityHdr") as RadComboBox;
            //    string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //    Console.WriteLine(strConnString);
            //    MySqlConnection conn = new MySqlConnection(strConnString);
            //    if (comboboxcity != null)
            //    {
            //        comboboxcity.Filter = RadComboBoxFilter.Contains;
            //        try
            //        {
            //            Console.WriteLine("Connecting to MySQL...");
            //            conn.Open();
            //            string sql = "SELECT CITY_CODE, CITY_NAME FROM MG_CITY ORDER BY CITY_NAME ASC";

            //            daCountry = new MySqlDataAdapter(sql, conn);
            //            MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
            //            dsCountry = new DataSet();
            //            daCountry.Fill(dsCountry, "MG_CITY");
            //            comboboxcity.DataSource = dsCountry;
            //            comboboxcity.DataBind();


            //            //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //            //MySqlDataReader rdr = cmd.ExecuteReader();
            //            /* conn.Open();

            //        string sql = "INSERT INTO Country (Name, HeadOfState, Continent) VALUES ('Disneyland','Mickey Mouse', 'North America')";
            //        MySqlCommand cmd = new MySqlCommand(sql, conn);
            //        cmd.ExecuteNonQuery();*/
            //            /*while (rdr.Read())
            //            {
            //                Console.WriteLine(rdr[0] + " -- " + rdr[1]);
            //            }
            //            rdr.Close();*/
            //        }
            //        catch (Exception ex)
            //        {
            //            //ShowMessage("Error: " + ex.Message);
            //        }

            //        conn.Close();
            //        Console.WriteLine("Done.");
            //    }

            //}
            //if (e.Item.IsInEditMode && hdfdataoperation.Value == "Edit")
            //{

            //    var items = e.Item as GridEditableItem;
            //    if (items != null)
            //    {
            //        var btn = items.FindControl("usercat") as RadButton;

            //        string val = items.GetDataKeyValue("USER_CAT").ToString();
            //        string val2 = items.GetDataKeyValue("CITY_CODE").ToString();
            //        var comboboxcity = items.FindControl("RadCmbCityHdr") as RadComboBox;

            //        comboboxcity.SelectedValue = val2;
            //        if (comboboxcity != null)
            //        {
            //            comboboxcity.Filter = RadComboBoxFilter.Contains;

            //        }
            //        //combobox.SelectedValue = val;
            //        //if(val == "Admin")
            //        //{
            //        if (val == "E")
            //        {
            //            btn.SetSelectedToggleStateByText("End User");

            //        }
            //        else
            //        if (val == "D")
            //        {
            //            btn.SetSelectedToggleStateByText("Drop Shipper");

            //        }
            //        //}else
            //        //{
            //        //    btn.Checked = false;
            //        //}


            //    }

            //}
        }

        protected void rgCustomer_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT CUST_ID, CUST_NAME, ADDRESS, ENTRY_DATE, ENTRY_USER, UPDATE_USER, UPDATE_DATE, PHONE, EMAIL FROM MT_CUSTOMER WHERE 1=1" + Environment.NewLine;

                if (isFilter == "true")
                {
                    if (columnName == "CUST_ID")
                    {
                        sql += "AND CUST_ID = " + filterValue + "" + Environment.NewLine;

                    }
                    if (columnName == "CUST_NAME")
                    {
                        sql += "AND CUST_NAME LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "ADDRESS")
                    {
                        sql += "AND ADDRESS LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "PHONE")
                    {
                        sql += "AND PHONE = " + filterValue + "" + Environment.NewLine;

                    }
                    if (columnName == "EMAIL")
                    {
                        sql += "AND EMAIL LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                }
                sql += " ORDER BY CUST_ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MT_CUSTOMER");
                rgCustomer.DataSource = dsCountry;


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

        protected void rgCustomer_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            RadTextBox code = (RadTextBox)item.FindControl("hdrcodetxt");

            RadTextBox name = (RadTextBox)item.FindControl("name");
            RadMaskedTextBox phone = (RadMaskedTextBox)item.FindControl("phone");
            RadTextBox address = (RadTextBox)item.FindControl("address");
            RadTextBox email = (RadTextBox)item.FindControl("email");


            string cpcode = code.Text;
            string names = name.Text;
            string phones = phone.Text;
            string addresses = address.Text;
            string emails = email.Text;
            if (names == "")
            {
                ShowMessage("Contact Person Name Cannot be empty");
                return;
            }
           
          
            update(names,addresses,phones,emails,cpcode);
            //update(names, addresses, codetxt, phone1s, phone2s, cpcode);
        }

        protected void rgCustomer_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgCustomer_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgCustomer_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgCustomer.MasterTableView.Items[e.Item.ItemIndex]["CUST_ID"].FindControl("hiddencode"));
            string codetxt = code.Value;
            delete(codetxt);
        }

        protected void rgCustomer_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var name = ((RadTextBox)rgCustomer.MasterTableView.GetInsertItem().FindControl("name"));
            var email = ((RadTextBox)rgCustomer.MasterTableView.GetInsertItem().FindControl("email"));

            var address = ((RadTextBox)rgCustomer.MasterTableView.GetInsertItem().FindControl("address"));

            var phone = ((RadMaskedTextBox)rgCustomer.MasterTableView.GetInsertItem().FindControl("phone"));


            string names = name.Text;
            string addresses = address.Text;
            string phones = phone.Text;
            string emails = email.Text;
           
            if (names == "")
            {
                ShowMessage("Name Cannot be empty");
                return;
            }
            
            insert(names,phones,addresses,emails);

        }

        protected void rgCustomer_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();

        }

        protected void rgCustomer_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
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