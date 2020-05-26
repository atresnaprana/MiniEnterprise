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
    public partial class ProductInventory : System.Web.UI.Page
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

                string sql = @"SELECT PROD_ID, PROD_NAME, DESCRIPTION, PRICE, ENTRY_DATE, ENTRY_USER, UPDATE_DATE, UPDATE_USER FROM MT_PROD ORDER BY PROD_ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MT_PROD");
                rgProduct.DataSource = dsCountry;
                rgProduct.DataBind();



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
        private void insert(Double price, string prodname, string description)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO MT_PROD (PROD_NAME, DESCRIPTION, PRICE,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER) VALUES (@prodname, @description, @price, @datetime, @user, @datetime, @user )", conn);

                cmd.Parameters.AddWithValue("@prodname", prodname);

                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@price", price);

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
        private void update(string prodname, Double price, string description, string prodid)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update MT_PROD Set  PROD_NAME = @prodname, PRICE = @price, DESCRIPTION = @description ,UPDATE_DATE = @datetime, UPDATE_USER = @user where PROD_ID = @prodid", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@prodname", prodname);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@price", price);

                cmd.Parameters.AddWithValue("@prodid", prodid);
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
                MySqlCommand cmd = new MySqlCommand("Delete From MT_PROD where PROD_ID = @code", conn);
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
        private DataTable validatetransaction(string prodcode)
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

                string sql = @"SELECT PROD_ID FROM MT_TRANSACTION where PROD_ID = '" + prodcode + "'";
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

                string sql = @"SELECT prod_code FROM mt_prod where prod_code = '" + prodcode + "'";
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
        protected void rgProduct_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //if (e.Item is GridEditableItem)
            //{
            //    var item = e.Item as GridEditableItem;
            //    var combobox = item.FindControl("RadCmbSuppHdr") as RadComboBox;
            //    string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //    Console.WriteLine(strConnString);
            //    MySqlConnection conn = new MySqlConnection(strConnString);
            //    if (combobox != null)
            //    {
            //        combobox.Filter = RadComboBoxFilter.Contains;

            //    }

            //    //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            //    try
            //    {
            //        Console.WriteLine("Connecting to MySQL...");
            //        conn.Open();
            //        string sql = "SELECT SUPP_CODE, SUPP_NAME FROM SUPPLIER_DATA ORDER BY SUPP_CODE ASC";

            //        daCountry = new MySqlDataAdapter(sql, conn);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
            //        dsCountry = new DataSet();
            //        daCountry.Fill(dsCountry, "SUPPLIER_DATA");
            //        combobox.DataSource = dsCountry;
            //        combobox.DataBind();


            //        //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //        //MySqlDataReader rdr = cmd.ExecuteReader();
            //        /* conn.Open();

            //    string sql = "INSERT INTO Country (Name, HeadOfState, Continent) VALUES ('Disneyland','Mickey Mouse', 'North America')";
            //    MySqlCommand cmd = new MySqlCommand(sql, conn);
            //    cmd.ExecuteNonQuery();*/
            //        /*while (rdr.Read())
            //        {
            //            Console.WriteLine(rdr[0] + " -- " + rdr[1]);
            //        }
            //        rdr.Close();*/
            //    }
            //    catch (Exception ex)
            //    {
            //        //ShowMessage("Error: " + ex.Message);
            //    }

            //    conn.Close();
            //    Console.WriteLine("Done.");

            //}
            //if (e.Item.IsInEditMode && hdfdataoperation.Value == "Edit")
            //{
            //    var items = e.Item as GridEditableItem;
            //    if (items != null)
            //    {
            //        var combobox = items.FindControl("RadCmbSuppHdr") as RadComboBox;

            //        string val = items.GetDataKeyValue("SUPP_CODE").ToString();
            //        combobox.SelectedValue = val;
            //        if (combobox != null)
            //        {
            //            combobox.Filter = RadComboBoxFilter.Contains;

            //        }

            //    }

            //}
        }

        protected void rgProduct_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
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

        protected void rgProduct_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT PROD_ID, PROD_NAME, DESCRIPTION, PRICE, ENTRY_DATE, ENTRY_USER, UPDATE_DATE, UPDATE_USER FROM MT_PROD WhERE 1=1 " + Environment.NewLine;
                if (isFilter == "true")
                {
                    if (columnName == "PROD_ID")
                    {
                        sql += "AND PROD_ID = " + filterValue + "" + Environment.NewLine;

                    }
                    if (columnName == "PROD_NAME")
                    {
                        sql += "AND PROD_NAME LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "DESCRIPTION")
                    {
                        sql += "AND DESCRIPTION LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "PRICE")
                    {
                        sql += "AND PRICE = " + filterValue + "" + Environment.NewLine;

                    }
                    
                }
                sql += "ORDER BY PROD_ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MT_PROD");
                rgProduct.DataSource = dsCountry;



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

        protected void rgProduct_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgProduct_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            RadTextBox code = (RadTextBox)item.FindControl("hdrcodetxt");

            RadTextBox prodname = (RadTextBox)item.FindControl("prodname");
            RadTextBox description = (RadTextBox)item.FindControl("description");
            RadNumericTextBox price = (RadNumericTextBox)item.FindControl("price");


            string prodcode = code.Text;
            string prodnames = prodname.Text;
            string descriptions = description.Text;
            Double prices = Convert.ToDouble(price.Text);

            if (prodnames == "")
            {
                ShowMessage("Product Name Cannot be empty");
                return;
            }
            /*var validateprodcode = validatetransaction(prodcode);
            if (validateprodcode.Rows.Count > 0)
            {
                ShowMessage("already used in transaction");
                return;
            }*/
            if (prices == 0)
            {
                ShowMessage("Please fill price");
                return;
            }
            update(prodnames,prices,descriptions,prodcode);
        }

        protected void rgProduct_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgProduct_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgProduct.MasterTableView.Items[e.Item.ItemIndex]["PROD_ID"].FindControl("hiddencode"));
            string codetxt = code.Value;
            var validateprodcode = validatetransaction(codetxt);
            if (validateprodcode.Rows.Count > 0)
            {
                ShowMessage("already used in transaction");
                return;
            }
            delete(codetxt);
        }

        protected void rgProduct_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var name = ((RadTextBox)rgProduct.MasterTableView.GetInsertItem().FindControl("prodname"));

            var description = ((RadTextBox)rgProduct.MasterTableView.GetInsertItem().FindControl("description"));

            var price = ((RadNumericTextBox)rgProduct.MasterTableView.GetInsertItem().FindControl("price"));

            string names = name.Text;
            string descriptions = description.Text;
            Double prices = Convert.ToDouble(price.Text);
           
            if (names == "")
            {
                ShowMessage("Product Name Cannot be empty");
                return;
            }
            if (prices == 0)
            {
                ShowMessage("Price Cannot be empty");
                return;
            }
           
            
         

            insert(prices,names, descriptions);
        }

        protected void rgProduct_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();

        }

        protected void rgProduct_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
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