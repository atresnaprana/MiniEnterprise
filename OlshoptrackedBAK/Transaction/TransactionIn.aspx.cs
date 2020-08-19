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
    public partial class TransactionIn : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        private string hdfmode
        {
            get { return ViewState["hdfmode"].ToString(); }
            set { ViewState["hdfmode"] = value; }
        }
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

                string sql = @"SELECT A.TRANS_ID, A.ITEM_AMT, A.IS_GOJEK, A.DESCRIPTION, A.PROD_ID, A.PRICE, A.CUST_ID, A.ENTRY_DATE, A.ENTRY_USER, A.UPDATE_DATE, A.UPDATE_USER, 
                                A.TRANS_DATE, B.CUST_NAME, C.PROD_NAME FROM MT_TRANSACTION A LEFT JOIN MT_CUSTOMER B ON A.CUST_ID = B.CUST_ID LEFT JOIN MT_PROD C ON A.PROD_ID = C.PROD_ID ORDER BY A.TRANS_ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MT_TRANSACTION");
                rgTransIn.DataSource = dsCountry;
                rgTransIn.DataBind();



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
        private void insert(string description, int prodid, DateTime transdate, int custid, Double price, string isgojek, int itemamt)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO MT_TRANSACTION (DESCRIPTION, TRANS_DATE, CUST_ID, 
                                                      PRICE, PROD_ID,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER, IS_GOJEK, ITEM_AMT) 
                                                      VALUES (@description, @transdate, @custid, @price, @prodid, @datetime, @user, @datetime, @user, @isgojek, @itemamt )", conn);

                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@prodid", prodid);

                cmd.Parameters.AddWithValue("@transdate", transdate);
                cmd.Parameters.AddWithValue("@custid", custid);

                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@isgojek", isgojek);
                cmd.Parameters.AddWithValue("@itemamt", itemamt);

                cmd.Parameters.AddWithValue("@user", Session["id"].ToString());

                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                LoadDataInNotification("Data Has been added", "Add Successful");
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
        private void update(string description, int prodid, DateTime transdate, int custid, Double price, string code, int itemamt, string isgojek)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand(@"update MT_TRANSACTION Set DESCRIPTION = @description, TRANS_DATE = @transdate, ITEM_AMT = @itemamt, IS_GOJEK = @isgojek, 
                                                    CUST_ID = @custid, PRICE = @price, PROD_ID = @prodid,
                                                    UPDATE_DATE = @datetime, UPDATE_USER = @user where TRANS_ID = @code", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@transdate", transdate);
                cmd.Parameters.AddWithValue("@custid", custid);
                cmd.Parameters.AddWithValue("@prodid", prodid);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@itemamt", itemamt);
                cmd.Parameters.AddWithValue("@isgojek", isgojek);

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
                MySqlCommand cmd = new MySqlCommand("Delete From MT_TRANSACTION where TRANS_ID = @code", conn);
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
       
        #endregion crud
        protected void rgTransIn_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "InitInsert")
            {
                hdfdataoperation.Value = "Insert";
                hdfmode = "Insert";
                //rgDetail.MasterTableView.IsItemInserted = true;

            }
            else if (e.CommandName == "Edit")
            {
                hdfdataoperation.Value = "Edit";
                hdfmode = "Edit";

            }
            else if(e.CommandName == "Filter")
            {
                Pair filterPair = (Pair)e.CommandArgument;
                var gridMessage1 = "Current Filter function: '" + filterPair.First + "' for column '" + filterPair.Second + "'";
                TextBox filterBox = (e.Item as GridFilteringItem)[filterPair.Second.ToString()].Controls[0] as TextBox;
                var gridMessage2 = "<br> Entered pattern for search: " + filterBox.Text;
                columnName = filterPair.Second.ToString();
                filterValue = filterBox.Text;
                if(!string.IsNullOrEmpty(filterBox.Text))
                {
                    isFilter = "true";
                }
                else
                {
                    isFilter = "false";
                }


            }
            //else
            //{
            //    hdfdataoperation.Value = "";
            //    hdfmode = "Edit";

            //}
        }

        protected void rgTransIn_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem)
            {
                var item = e.Item as GridEditableItem;
                var custcombobox = item.FindControl("RadCmbCustHdr") as RadComboBox;
                var prodcombobox = item.FindControl("RadCmbProdHdr") as RadComboBox;
                string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                Console.WriteLine(strConnString);
                MySqlConnection conn = new MySqlConnection(strConnString);
                if (custcombobox != null)
                {
                    custcombobox.Filter = RadComboBoxFilter.Contains;
                }
                if (prodcombobox != null)
                {
                    prodcombobox.Filter = RadComboBoxFilter.Contains;
                }

                //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT CUST_ID, CUST_NAME FROM MT_CUSTOMER ORDER BY CUST_NAME ASC";

                    daCountry = new MySqlDataAdapter(sql, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                    dsCountry = new DataSet();
                    daCountry.Fill(dsCountry, "CUST_DATA");
                    if(custcombobox != null)
                    {
                        custcombobox.DataSource = dsCountry;
                        custcombobox.DataBind();
                    }
                   


                    string sql2 = "SELECT PROD_ID, PROD_NAME FROM MT_PROD ORDER BY PROD_NAME ASC";
                    var courieradp = new MySqlDataAdapter(sql2, conn);
                    var courierdt = new DataSet();
                    courieradp.Fill(courierdt, "COURIER_DATA");
                    if(prodcombobox != null)
                    {
                        prodcombobox.DataSource = courierdt;
                        prodcombobox.DataBind();
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
            if (e.Item.IsInEditMode && hdfdataoperation.Value == "Edit")
            {
                var items = e.Item as GridEditableItem;
                if (items != null)
                {
                    var ischecked = items.FindControl("isgojek") as RadCheckBox;
                    if (ischecked != null)
                    {
                        string valchecked = items.GetDataKeyValue("IS_GOJEK").ToString();
                        if(valchecked == "Y")
                        {
                            ischecked.Checked = true;
                        }else
                        {
                            ischecked.Checked = false;

                        }

                    }
                    var combocustbox = items.FindControl("RadCmbCustHdr") as RadComboBox;
                  
                    if (combocustbox != null)
                    {
                        string valcust = items.GetDataKeyValue("CUST_ID").ToString();
                        combocustbox.SelectedValue = valcust;
                        combocustbox.Filter = RadComboBoxFilter.Contains;

                    }
                    var comboprodbox = items.FindControl("RadCmbProdHdr") as RadComboBox;
                    if (comboprodbox != null)
                    {
                        string valproduct = items.GetDataKeyValue("PROD_ID").ToString();
                        comboprodbox.SelectedValue = valproduct;
                        comboprodbox.Filter = RadComboBoxFilter.Contains;

                    }

                }

            }
        }

        protected void rgTransIn_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = @"SELECT A.TRANS_ID, A.ITEM_AMT, A.IS_GOJEK, A.DESCRIPTION, A.PROD_ID, A.PRICE, A.CUST_ID, A.ENTRY_DATE, A.ENTRY_USER, A.UPDATE_DATE, A.UPDATE_USER, 
                                A.TRANS_DATE, B.CUST_NAME, C.PROD_NAME FROM MT_TRANSACTION A LEFT JOIN MT_CUSTOMER B ON A.CUST_ID = B.CUST_ID LEFT JOIN MT_PROD C ON A.PROD_ID = C.PROD_ID WHERE 1=1 " +Environment.NewLine;
                if(isFilter == "true")
                {
                    if(columnName == "TRANS_ID")
                    {
                        sql += "AND A.TRANS_ID = " + filterValue + "" + Environment.NewLine;

                    }
                    if(columnName == "DESCRIPTION")
                    {
                        sql += "AND A.DESCRIPTION LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "CUST_NAME")
                    {
                        sql += "AND B.CUST_NAME LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "PROD_NAME")
                    {
                        sql += "AND C.PROD_NAME LIKE '%" + filterValue + "%'" + Environment.NewLine;

                    }
                    if (columnName == "IS_GOJEK")
                    {
                        sql += "AND A.IS_GOJEK = '" + filterValue + "'" + Environment.NewLine;

                    }
                }
                sql += "ORDER BY A.TRANS_ID ASC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "MT_TRANSACTION");
                rgTransIn.DataSource = dsCountry;
            }
            catch (Exception ex)
            {
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        protected void rgTransIn_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgTransIn_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_ID"].FindControl("hiddencode"));
            string codetxt = code.Value;
            var dtval = validatecode(codetxt);
            delete(codetxt);
            //if (dtval.Rows.Count == 0)
            //{
            //    delete(codetxt);

            //}
            //else
            //{
            //    ShowMessage("Data Is Being Used");
            //    return;
            //}
        }

        protected void rgTransIn_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((RadTextBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_ID"].FindControl("hdrcodetxt"));
            var description = ((RadTextBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["DESCRIPTION"].FindControl("description"));
            var cust = ((RadComboBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["CUST_NAME"].FindControl("RadCmbCustHdr"));
            var prod = ((RadComboBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["PROD_NAME"].FindControl("RadCmbProdHdr"));
            var transdate = ((RadDatePicker)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["TRANS_DATE"].FindControl("transdate"));
            var price = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["PRICE"].FindControl("price"));
            var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["ITEM_AMT"].FindControl("itemamt"));
            var isgojek = ((RadCheckBox)rgTransIn.MasterTableView.Items[e.Item.ItemIndex]["IS_GOJEK"].FindControl("isgojek"));

            string codes = code.Text;
            string descriptions = description.Text;
            int custs = Convert.ToInt16(cust.SelectedValue);
            int prods = Convert.ToInt16(prod.SelectedValue);
            int itemamts = Convert.ToInt16(itemamt.Text);
            DateTime transdates = Convert.ToDateTime(transdate.SelectedDate);
            Double totals = Convert.ToDouble(price.Text);
            string gojek = "N";
            if(isgojek.Checked == true)
            {
                gojek = "Y";
            }else
            {
                gojek = "N";
            }
            update(descriptions,prods,transdates,custs,totals,codes, itemamts, gojek);
        }

        protected void rgTransIn_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            HdfSelectedRow.Value = e.Item.ItemIndex.ToString();

        }

        protected void rgTransIn_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            //var code = ((RadTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("hdrcodetxt"));
            var description = ((RadTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("description"));
            var cmbcusthdr = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbCustHdr"));
            var cmbprodhdr = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbProdHdr"));
            var transdate = ((RadDatePicker)rgTransIn.MasterTableView.GetInsertItem().FindControl("transdate"));
            var price = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("price"));
            var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("itemamt"));
            var isgojek = ((RadCheckBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("isgojek"));

            //string codes = code.Text;
            string isgojekstring = "N";
            if (isgojek.Checked == true)
            {
                isgojekstring = "Y";
            }
            else
            {
                isgojekstring = "N";
            }
            string descriptions = description.Text;
            int custcode = Convert.ToInt16(cmbcusthdr.SelectedValue);
            int prodcode = Convert.ToInt16(cmbprodhdr.SelectedValue);
            DateTime date = Convert.ToDateTime(transdate.SelectedDate);
            Double totals = Convert.ToDouble(price.Text);
            int itemamts = Convert.ToInt16(itemamt.Text);

            if (cmbcusthdr.SelectedValue == string.Empty)
            {
                ShowMessage("Please fill customer information");
                return;
            }
            if (cmbprodhdr.SelectedValue == string.Empty)
            {
                ShowMessage("Product Information Cannot be empty");
                return;
            }
            if (totals == 0)
            {
                ShowMessage("Total sale cannot be empty");
                return;
            }
            if (Convert.ToInt16(itemamt.Text) == 0)
            {
                ShowMessage("Item Amount Cannot be empty");
                return;
            }
            insert(descriptions,prodcode,date,custcode,totals,isgojekstring,itemamts);
        }

        protected void rgTransIn_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();
        }

        protected void rgTransIn_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            retrieve();
        }
        
        //protected void RadCmbCourierHdr_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    if (hdfdataoperation.Value == "Insert")
        //    {
        //        var gridval = Convert.ToInt16(e.Value);
        //        var cmbcosthdr = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbCostHdr"));
        //        cmbcosthdr.Enabled = true;
        //        cmbcosthdr.EmptyMessage = "Select...";
        //        string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //        Console.WriteLine(strConnString);
        //        MySqlConnection conn = new MySqlConnection(strConnString);
        //        try
        //        {
        //            Console.WriteLine("Connecting to MySQL...");
        //            conn.Open();
        //            string sql = "SELECT COST_CODE, COST_DESC FROM COURIER_COST_DATA WHERE COURIER_CODE = '" + gridval + "' ORDER BY COST_DESC ASC";

        //            daCountry = new MySqlDataAdapter(sql, conn);
        //            MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
        //            dsCountry = new DataSet();
        //            daCountry.Fill(dsCountry, "CUST_DATA");
        //            cmbcosthdr.DataSource = dsCountry;
        //            cmbcosthdr.DataBind();




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
        //    else
        //    if (hdfdataoperation.Value == "Edit")
        //    {
        //        var gridval = Convert.ToInt32(e.Value);
        //        Console.WriteLine(HdfSelectedRow.Value);
        //        int index = Convert.ToInt32(HdfSelectedRow.Value);
        //        var cmbcosthdr = ((RadComboBox)rgTransIn.MasterTableView.Items[index]["COST_DESC"].FindControl("RadCmbCostHdr"));
        //        cmbcosthdr.Enabled = true;
        //        cmbcosthdr.ClearSelection();
        //        cmbcosthdr.EmptyMessage = "Select...";
        //        string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //        Console.WriteLine(strConnString);
        //        MySqlConnection conn = new MySqlConnection(strConnString);
        //        try
        //        {
        //            Console.WriteLine("Connecting to MySQL...");
        //            conn.Open();
        //            string sql = "SELECT COST_CODE, COST_DESC FROM COURIER_COST_DATA WHERE COURIER_CODE = '" + gridval + "' ORDER BY COST_DESC ASC";

        //            daCountry = new MySqlDataAdapter(sql, conn);
        //            MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
        //            dsCountry = new DataSet();
        //            daCountry.Fill(dsCountry, "CUST_DATA");
        //            cmbcosthdr.DataSource = dsCountry;
        //            cmbcosthdr.DataBind();




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
        //        //GridEditableItem item = (GridEditableItem)e.Item;
        //        //GridItem item in rgTransIn.MasterTableView.Items;


        //    }
        //}
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
        private DataTable getpricedt(string prodcode)
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

                string sql = @"SELECT PRICE FROM MT_PROD where PROD_ID = '" + prodcode + "'";
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
        private DataTable getcost()
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

                string sql = @"SELECT PARAMS FROM ME_CONFIG WHERE ID = 1";
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
        protected void RadCmbProdHdr_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var prodcode = e.Value;
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            var dt = getpricedt(prodcode);
            if (hdfdataoperation.Value == "Insert")
            {
                if(dt.Rows.Count > 0)
                {
                    string prices = dt.Rows[0]["PRICE"].ToString();
                    var isgojekctrl = ((RadCheckBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("isgojek"));
                    var price = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("price"));
                    var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("itemamt"));
                    int items = 0;
                    if (itemamt.Text == string.Empty)
                    {
                        items = 0;
                    }
                    else
                    {
                        items = Convert.ToInt16(itemamt.Text);
                    }
                    if(isgojekctrl.Checked == true)
                    {
                        var dtcost = getcost();
                        string costs = dtcost.Rows[0]["PARAMS"].ToString();
                        int costint = Convert.ToInt16(costs);
                        var pricedouble = Convert.ToDouble(prices);
                        var totalbeforecost = pricedouble * items;
                        var totalcost = totalbeforecost * costint / 100;
                        var totals = totalbeforecost - totalcost;
                        price.Text = totals.ToString();
                    }
                    else
                    {
                        var pricedouble = Convert.ToDouble(prices);
                        var totals = pricedouble * items;
                        price.Text = totals.ToString();
                    }
                 
                }

            }
            if (hdfdataoperation.Value == "Edit")
            {
                if (dt.Rows.Count > 0)
                {
                    string prices = dt.Rows[0]["PRICE"].ToString();
                    var isgojekctrl = ((RadCheckBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["IS_GOJEK"].FindControl("isgojek"));
                    var price = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["PRICE"].FindControl("price"));
                    var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["ITEM_AMT"].FindControl("itemamt"));
                    int items = 0;
                    if (itemamt.Text == string.Empty)
                    {
                        items = 0;
                    }
                    else
                    {
                        items = Convert.ToInt16(itemamt.Text);
                    }
                    if (isgojekctrl.Checked == true)
                    {
                        var dtcost = getcost();
                        string costs = dtcost.Rows[0]["PARAMS"].ToString();
                        int costint = Convert.ToInt16(costs);
                        var pricedouble = Convert.ToDouble(prices);
                        var totalbeforecost = pricedouble * items;
                        var totalcost = totalbeforecost * costint / 100;
                        var totals = totalbeforecost - totalcost;
                        price.Text = totals.ToString();
                    }
                    else
                    {
                        var pricedouble = Convert.ToDouble(prices);
                        var totals = pricedouble * items;
                        price.Text = totals.ToString();
                    }

                }
            }
            Console.WriteLine("Done.");
        }

        protected void itemamt_TextChanged(object sender, EventArgs e)
        {
            if (hdfdataoperation.Value == "Insert")
            {
                var isgojekctrl = ((RadCheckBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("isgojek"));
                var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("itemamt"));
                var prods = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbProdHdr"));
                var price = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("price"));
                int items = 0;
                if(itemamt.Text == string.Empty)
                {
                    items = 0;
                }else
                {
                    items = Convert.ToInt16(itemamt.Text); 
                }
                if (isgojekctrl.Checked == true)
                {
                    var dtcost = getcost();


                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            string cost = dtcost.Rows[0]["PARAMS"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            int costs = Convert.ToInt16(cost);
                            var totalbeforecost = pricedouble * items;
                            var totalcost = totalbeforecost * costs / 100;
                            var totals = totalbeforecost - totalcost;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }
                else
                {
                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            var totals = pricedouble * items;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }

            }
            if (hdfdataoperation.Value == "Edit")
            {
                var isgojekctrl = ((RadCheckBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["IS_GOJEK"].FindControl("isgojek"));
                var price = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["PRICE"].FindControl("price"));
                var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["ITEM_AMT"].FindControl("itemamt"));
                var prods = ((RadComboBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["PROD_NAME"].FindControl("RadCmbProdHdr"));
                int items = 0;
                if (itemamt.Text == string.Empty)
                {
                    items = 0;
                }
                else
                {
                    items = Convert.ToInt16(itemamt.Text);
                }
                if (isgojekctrl.Checked == true)
                {
                    var dtcost = getcost();
                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            string cost = dtcost.Rows[0]["PARAMS"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            int costs = Convert.ToInt16(cost);
                            var totalbeforecost = pricedouble * items;
                            var totalcost = totalbeforecost * costs / 100;
                            var totals = totalbeforecost - totalcost;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }
                else
                {

                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            var totals = pricedouble * items;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }
                //if (validatedt.Rows.Count > 0)
                //{
                //    string prices = validatedt.Rows[0]["PRICE"].ToString();
                //    var price = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["PRICE"].FindControl("price"));
                //    price.Text = prices;

                //}
            }
        }

        protected void isgojek_CheckedChanged(object sender, EventArgs e)
        {
            
            if (hdfdataoperation.Value == "Insert")
            {
                var isgojekctrl = ((RadCheckBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("isgojek"));
                var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("itemamt"));
                var prods = ((RadComboBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("RadCmbProdHdr"));
                var price = ((RadNumericTextBox)rgTransIn.MasterTableView.GetInsertItem().FindControl("price"));
                int items = 0;
                if (itemamt.Text == string.Empty)
                {
                    items = 0;
                }
                else
                {
                    items = Convert.ToInt16(itemamt.Text);
                }
                if (isgojekctrl.Checked == true)
                {
                    var dtcost = getcost();
                   
                   
                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            string cost = dtcost.Rows[0]["PARAMS"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            int costs = Convert.ToInt16(cost);
                            var totalbeforecost = pricedouble * items;
                            var totalcost = totalbeforecost * costs / 100;
                            var totals = totalbeforecost - totalcost;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }
                else
                {
                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            var totals = pricedouble * items;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }

            }
            if (hdfdataoperation.Value == "Edit")
            {
                var isgojekctrl = ((RadCheckBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["IS_GOJEK"].FindControl("isgojek"));
                var price = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["PRICE"].FindControl("price"));
                var itemamt = ((RadNumericTextBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["ITEM_AMT"].FindControl("itemamt"));
                var prods = ((RadComboBox)rgTransIn.MasterTableView.Items[Convert.ToInt16(HdfSelectedRow.Value)]["PROD_NAME"].FindControl("RadCmbProdHdr"));
                int items = 0;
                if (itemamt.Text == string.Empty)
                {
                    items = 0;
                }
                else
                {
                    items = Convert.ToInt16(itemamt.Text);
                }
                if (isgojekctrl.Checked == true)
                {
                    var dtcost = getcost();
                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            string cost = dtcost.Rows[0]["PARAMS"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            int costs = Convert.ToInt16(cost);
                            var totalbeforecost = pricedouble * items;
                            var totalcost = totalbeforecost * costs / 100;
                            var totals = totalbeforecost - totalcost;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }
                else
                {
                  
                    if (prods.SelectedValue != string.Empty)
                    {
                        var dtprice = getpricedt(prods.SelectedValue);
                        if (dtprice.Rows.Count > 0)
                        {
                            string prices = dtprice.Rows[0]["PRICE"].ToString();
                            var pricedouble = Convert.ToDouble(prices);
                            var totals = pricedouble * items;
                            price.Text = totals.ToString();
                        }
                        else
                        {
                            price.Text = "";
                        }

                    }
                    else
                    {
                        price.Text = "";
                    }
                }
            }
        }
    }
}