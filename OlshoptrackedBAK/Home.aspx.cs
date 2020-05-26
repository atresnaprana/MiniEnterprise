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
    public partial class Home : System.Web.UI.Page
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;
        string hash = "%4h&bn9873*7^><?:'";
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void submit_Click(object sender, EventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Console.WriteLine(strConnString);
            MySqlConnection conn = new MySqlConnection(strConnString);

            //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                DataTable Userlog = new DataTable();

                string sql = @"Select * from ME_USER where user_name = '" + username.Text + "' AND user_pass = '" + Encrypt(password.Text) + "'";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);
                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "ME_USER");
                daCountry.Fill(Userlog);

                if (Userlog.Rows.Count > 0)
                {
                    Session["id"] = username.Text;
                    Response.Redirect("Dashboard.aspx");
                    //Session.RemoveAll();
                    Session.Remove(Session["id"].ToString());
                }
                else
                {
                    Errorlog.Text = "Your username and password is incorrect";
                    Errorlog.ForeColor = System.Drawing.Color.Red;
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
                //ShowMessage("Error: " + ex.Message + ex.InnerException);
                Errorlog.Text = ex.InnerException + ex.Message;
                Errorlog.ForeColor = System.Drawing.Color.Red;
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
        void ShowMessage(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}