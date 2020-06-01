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
    public partial class ProductCategory : System.Web.UI.Page
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

                string sql = @"SELECT id, category_name, amount, ENTRY_DATE, ENTRY_USER, UPDATE_DATE, UPDATE_USER FROM mt_prod_cat ORDER BY id ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "mt_prod_cat");
                rgProdCat.DataSource = dsCountry;
                rgProdCat.DataBind();



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
        private void insert(int amount, string catname)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO mt_prod_cat (category_name, amount,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER) VALUES (@catname, @amount, @datetime, @user, @datetime, @user)", conn);

                cmd.Parameters.AddWithValue("@amount", amount);

                cmd.Parameters.AddWithValue("@catname", catname);

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
        private void update(string catname, int amount, string id)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update mt_prod_cat Set category_name = @catname, amount = @amount, UPDATE_DATE = @datetime, UPDATE_USER = @user where id = @id", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@catname", catname);
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
                MySqlCommand cmd = new MySqlCommand("Delete From mt_prod_cat where id = @code", conn);
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
        private DataTable validatetransaction(string id)
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

                string sql = @"SELECT prod_cat_id FROM MT_PROD where prod_cat_id = '" + id + "'";
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

                string sql = @"SELECT id, category_name, amount, ENTRY_DATE, ENTRY_USER, UPDATE_DATE, UPDATE_USER FROM mt_prod_cat WhERE 1=1 " + Environment.NewLine;
                if (isFilter == "true")
                {
                    if (columnName == "id")
                    {
                        sql += "AND id = " + filterValue + "" + Environment.NewLine;

                    }
                    if (columnName == "category_name")
                    {
                        sql += "AND category_name LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "amount")
                    {
                        sql += "AND amount = " + filterValue + "" + Environment.NewLine;

                    }

                }
                sql += "ORDER BY id ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "mt_prod_cat");
                rgProdCat.DataSource = dsCountry;

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

            RadTextBox catnames = (RadTextBox)item.FindControl("catname");
            RadNumericTextBox amount = (RadNumericTextBox)item.FindControl("amt");


            string id = code.Text;
            string catname = catnames.Text;
            int amounts = Convert.ToInt32(amount.Text);

            if (string.IsNullOrEmpty(catname))
            {
                ShowMessage("Category Name Cannot be empty");
                return;
            }
            /*var validateprodcode = validatetransaction(prodcode);
            if (validateprodcode.Rows.Count > 0)
            {
                ShowMessage("already used in transaction");
                return;
            }*/
            if (amounts == 0)
            {
                ShowMessage("Please fill amount");
                return;
            }
            update(catname,amounts,id);
        }

        protected void rgProduct_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgProduct_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgProdCat.MasterTableView.Items[e.Item.ItemIndex]["id"].FindControl("hiddencode"));
            string codetxt = code.Value;
            var validateprodcode = validatetransaction(codetxt);
            if (validateprodcode.Rows.Count > 0)
            {
                ShowMessage("already used in product");
                return;
            }
            delete(codetxt);
        }

        protected void rgProduct_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var name = ((RadTextBox)rgProdCat.MasterTableView.GetInsertItem().FindControl("catname"));

            var amount = ((RadNumericTextBox)rgProdCat.MasterTableView.GetInsertItem().FindControl("amt"));

            string names = name.Text;
            int amounts = Convert.ToInt32(amount.Text);

            if (string.IsNullOrEmpty(names))
            {
                ShowMessage("Category Name Cannot be empty");
                return;
            }
            if (amounts == 0)
            {
                ShowMessage("Amount Cannot be empty");
                return;
            }
            insert(amounts,names);
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