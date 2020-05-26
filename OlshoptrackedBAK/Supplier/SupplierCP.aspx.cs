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

namespace OlshoptrackedBAK.Supplier
{
    public partial class SupplierCP : System.Web.UI.Page
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
        #region dbcrud
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

                string sql = @"SELECT a.CP_CODE, a.SUPP_CODE, a.CP_NAME, 
                            a.CP_ADDRESS, a.PHONE1, a.PHONE2,a.UPDATE_DATE, a.UPDATE_USER, a.ENTRY_DATE, a.ENTRY_USER, b.SUPP_NAME  FROM 
                            SUPPLIER_CP_DATA a LEFT JOIN SUPPLIER_DATA 
                        b on a.SUPP_CODE = b.SUPP_CODE ORDER BY a.UPDATE_DATE DESC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "SUPPLIER_CP_DATA");
                rgSupplierCP.DataSource = dsCountry;
                rgSupplierCP.DataBind();



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

        private void insert(string name, string phone1, string phone2, string cp_address, string suppcode)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO SUPPLIER_CP_DATA (CP_CODE, SUPP_CODE, CP_NAME, PHONE1, PHONE2, CP_ADDRESS,UPDATE_DATE,UPDATE_USER, ENTRY_DATE, ENTRY_USER) VALUES ('', @suppcode, @name, @phone1, @phone2, @address, @datetime, @user, @datetime, @user )", conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone1", phone1);
                cmd.Parameters.AddWithValue("@phone2", phone2);

                cmd.Parameters.AddWithValue("@address", cp_address);
                cmd.Parameters.AddWithValue("@suppcode", suppcode);
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
        private void update(string name, string address, string suppcode, string phone1, string phone2, string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update SUPPLIER_CP_DATA Set  CP_NAME = @name, CP_ADDRESS = @address, SUPP_CODE = @suppcode, PHONE1 = @phone1, PHONE2 = @phone2 ,UPDATE_DATE = @datetime, UPDATE_USER = @user where CP_CODE = @code", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@suppcode", suppcode);
                cmd.Parameters.AddWithValue("@phone1", phone1);
                cmd.Parameters.AddWithValue("@phone2", phone2);

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
                MySqlCommand cmd = new MySqlCommand("Delete From SUPPLIER_CP_DATA where CP_CODE = @code", conn);
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
        #endregion dbcrud
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
            if (e.Item.OwnerTableView.IsItemInserted && e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                //LinkButton editbutton = (LinkButton)item.FindControl("EditCommandColumn");
                //editbutton.Enabled = false;
            }
            if (e.Item.OwnerTableView.IsItemInserted && e.Item is GridCommandItem)
            {

            }
            if (e.Item is GridEditableItem)
            {
                var item = e.Item as GridEditableItem;
                var combobox = item.FindControl("RadCmbSuppHdr") as RadComboBox;
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
                    string sql = "SELECT SUPP_CODE, SUPP_NAME FROM SUPPLIER_DATA ORDER BY SUPP_CODE ASC";

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
                    var combobox = items.FindControl("RadCmbSuppHdr") as RadComboBox;

                    string val = items.GetDataKeyValue("SUPP_CODE").ToString();
                    combobox.SelectedValue = val;
                    if (combobox != null)
                    {
                        combobox.Filter = RadComboBoxFilter.Contains;

                    }

                }

            }
        }

        protected void rgSupplier_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            retrieve();
        }



        protected void rgSupplier_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgSupplier_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgSupplier_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgSupplierCP.MasterTableView.Items[e.Item.ItemIndex]["CP_CODE"].FindControl("hiddencode"));
            string codetxt = code.Value;
            delete(codetxt);
        }

        protected void rgSupplier_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var cmbsupphdr = ((RadComboBox)rgSupplierCP.MasterTableView.GetInsertItem().FindControl("RadCmbSuppHdr"));
            var name = ((RadTextBox)rgSupplierCP.MasterTableView.GetInsertItem().FindControl("suppname"));
            var address = ((RadTextBox)rgSupplierCP.MasterTableView.GetInsertItem().FindControl("address"));

            var phone1 = ((RadMaskedTextBox)rgSupplierCP.MasterTableView.GetInsertItem().FindControl("phone1"));

            var phone2 = ((RadMaskedTextBox)rgSupplierCP.MasterTableView.GetInsertItem().FindControl("phone2"));

            string names = name.Text;
            string addresses = address.Text;
            string phone1s = phone1.Text;
            string phone2s = phone2.Text;
            string selectedcmbtranshdr = cmbsupphdr.SelectedValue;
            if (addresses == "")
            {
                ShowMessage("Address Cannot be empty");
                return;
            }
            if (names == "")
            {
                ShowMessage("Name Cannot be empty");
                return;
            }
            if (selectedcmbtranshdr == "")
            {
                ShowMessage("Please Select Supplier Info");
                return;
            }
            insert(names, phone1s, phone2s, addresses, selectedcmbtranshdr);
            //string testtxt = test.Text;
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

        protected void RadCmbSuppHdr_Load(object sender, EventArgs e)
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

        protected void rgSupplierCP_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            RadComboBox cmbSupphdr = (RadComboBox)item.FindControl("RadCmbSuppHdr");
            RadTextBox code = (RadTextBox)item.FindControl("hdrcodetxt");

            RadTextBox name = (RadTextBox)item.FindControl("suppname");
            RadMaskedTextBox phone1 = (RadMaskedTextBox)item.FindControl("phone1");
            RadMaskedTextBox phone2 = (RadMaskedTextBox)item.FindControl("phone2");
            RadTextBox address = (RadTextBox)item.FindControl("address");


            string codetxt = cmbSupphdr.SelectedValue;
            string cpcode = code.Text;
            string names = name.Text;
            string phone1s = phone1.Text;
            string phone2s = phone2.Text;
            string addresses = address.Text;

            if (names == "")
            {
                ShowMessage("Contact Person Name Cannot be empty");
                return;
            }
            if (codetxt == "")
            {
                ShowMessage("Please Select Supplier Data");
                return;
            }
            update(names, addresses, codetxt, phone1s, phone2s, cpcode);
            //var cmbSupphdr = ((RadComboBox)rgSupplierCP.MasterTableView.Items[e.Item.ItemIndex]["SUPP_CODE"].FindControl("RadCmbSuppHdr"));

        }
    }
}