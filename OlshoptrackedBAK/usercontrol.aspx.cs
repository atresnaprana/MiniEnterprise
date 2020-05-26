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
using System.Windows.Forms;

namespace OlshoptrackedBAK
{
    public partial class usercontrol : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        string hash = "%4h&bn9873*7^><?:'";
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
            else
            {
                var validateload = validatepageload(Session["id"].ToString());
                if (validateload.Rows.Count > 0)
                {
                    string userlevel = validateload.Rows[0]["USER_LEVEL"].ToString();
                    if (userlevel != "admin" && userlevel != "Admin")
                    {
                        Response.Redirect("~/NotAuthorized.aspx");

                    }
                }
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

                string sql = @"SELECT USER_CODE, USER_NAME, USER_PASS, USER_LEVEL, UPDATE_USER, UPDATE_DATE, EMAIL FROM ME_USER ORDER BY USER_CODE DESC";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "SUPPLIER_CP_DATA");
                rgUser.DataSource = dsCountry;
                rgUser.DataBind();



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
        private DataTable validatepageload(string user)
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

                string sql = @"SELECT USER_CODE, USER_LEVEL FROM ME_USER where USER_NAME = '" + user + "'";
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
        private DataTable validateuser(string user)
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

                string sql = @"SELECT * FROM ME_USER WHERE user_name LIKE '" + user + "%' ";
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
        private void insert(string username, string userpass, string userlevel, string email)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                //MySqlCommand cmd = new MySqlCommand("update student Set  Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email where SID = @SID", conn);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO ME_USER (USER_CODE, USER_NAME, USER_PASS, USER_LEVEL, EMAIL,UPDATE_DATE,UPDATE_USER) VALUES ('', @username, @userpass, @userlevel, @email, @datetime, @user)", conn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userpass", userpass);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.Parameters.AddWithValue("@userlevel", userlevel);
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
        private void update(string username, string password, string level, string email, string code)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);
            try
            {
                conn.Open();
                //string SID = lblSID.Text;
                MySqlCommand cmd = new MySqlCommand("update ME_USER Set  USER_NAME = @username, USER_PASS = @pass, USER_LEVEL = @userlevel, EMAIL = @email,UPDATE_DATE = @datetime, UPDATE_USER = @user where USER_CODE = @code", conn);
                //MySqlCommand cmd = new MySqlCommand("INSERT INTO TRANSACTION_HDR (TRANS_CODE_HDR, TRANS_CODE_DESC, UPDATE_DATE) VALUES ('', @desc, @datetime )", conn);
                cmd.Parameters.AddWithValue("@code", code);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pass", password);

                cmd.Parameters.AddWithValue("@userlevel", level);
                cmd.Parameters.AddWithValue("@email", email);

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
                MySqlCommand cmd = new MySqlCommand("Delete From ME_USER where USER_CODE = @code", conn);
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

        protected void rgUser_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
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

        protected void rgUser_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item.IsInEditMode && hdfdataoperation.Value == "Edit")
            {
                var items = e.Item as GridEditableItem;
                if (items != null)
                {
                    var btn = items.FindControl("userlevel") as RadButton;

                    string val = items.GetDataKeyValue("USER_LEVEL").ToString();
                    //combobox.SelectedValue = val;
                    //if(val == "Admin")
                    //{
                    btn.SetSelectedToggleStateByText(val);
                    //}else
                    //{
                    //    btn.Checked = false;
                    //}


                }

            }
        }

        protected void rgUser_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            retrieve();
        }

        protected void rgUser_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgUser_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((RadTextBox)rgUser.MasterTableView.Items[e.Item.ItemIndex]["USER_CODE"].FindControl("hdrcodetxt")).Text;
            var username = ((RadTextBox)rgUser.MasterTableView.Items[e.Item.ItemIndex]["USER_NAME"].FindControl("username")).Text;
            var passedited = ((RadTextBox)rgUser.MasterTableView.Items[e.Item.ItemIndex]["USER_PASS"].FindControl("password")).Text;
            var passori = ((HiddenField)rgUser.MasterTableView.Items[e.Item.ItemIndex]["USER_PASS"].FindControl("passwordhidden")).Value;
            var email = ((RadTextBox)rgUser.MasterTableView.Items[e.Item.ItemIndex]["EMAIL"].FindControl("email")).Text;
            var userlevel = ((RadButton)rgUser.MasterTableView.Items[e.Item.ItemIndex]["USER_LEVEL"].FindControl("userlevel")).Checked;
            string password = "";
            string level = "";
            if (passedited == "")
            {
                password = passori;
            }
            else
            {
                password = Encrypt(passedited);
            }
            if (userlevel)
            {
                level = "Admin";
            }
            else
            {
                level = "User";
            }
            update(username, password, level, email, code);
        }

        protected void rgUser_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgUser_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var code = ((HiddenField)rgUser.MasterTableView.Items[e.Item.ItemIndex]["USER_CODE"].FindControl("hiddencode"));
            string codetxt = code.Value;
            delete(codetxt);
        }
        protected string Encrypt(string pass)
        {
            string encrypted = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(pass);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    encrypted = Convert.ToBase64String(result, 0, result.Length);
                }
            }
            return encrypted;
        }
        protected string Decrypt(string pass)
        {
            string decrpyted = "";
            byte[] data = Convert.FromBase64String(pass);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    decrpyted = UTF8Encoding.UTF8.GetString(result);
                }
            }
            return decrpyted;
        }
        protected void rgUser_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var ddlhdr = ((RadButton)rgUser.MasterTableView.GetInsertItem().FindControl("userlevel"));
            var username = ((RadTextBox)rgUser.MasterTableView.GetInsertItem().FindControl("username"));
            var password = ((RadTextBox)rgUser.MasterTableView.GetInsertItem().FindControl("password"));

            var email = ((RadTextBox)rgUser.MasterTableView.GetInsertItem().FindControl("email"));


            string usernames = username.Text;
            string passwords = password.Text;
            string passenc = Encrypt(passwords);
            //string test2 = Decrypt(test);
            string emails = email.Text;

            string selectedddlhdr = "";
            if (ddlhdr.Checked)
            {
                selectedddlhdr = "Admin";
            }
            else
            {
                selectedddlhdr = "User";
            }
            if (emails == "")
            {
                ShowMessage("email Cannot be empty");
                return;
            }
            if (usernames == "")
            {
                ShowMessage("Name Cannot be empty");
                return;
            }
            else
            {
                var dt = validateuser(usernames);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bool validate = string.Equals(usernames, dt.Rows[i]["USER_NAME"].ToString(), StringComparison.CurrentCultureIgnoreCase);
                        if (validate)
                        {
                            ShowMessage("username has been used");
                            return;
                        }
                    }

                }
            }
            if (passwords == "")
            {
                ShowMessage("passwords Cannot be empty");
                return;
            }
            if (selectedddlhdr == "")
            {
                ShowMessage("Please Select User Level");
                return;
            }
            insert(usernames, passenc, selectedddlhdr, emails);
        }

        protected void rgUser_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            retrieve();
        }

        protected void rgUser_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
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