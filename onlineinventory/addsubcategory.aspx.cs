using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace onlineinventory
{
    public partial class addsubcategory : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            readddldatacatgory();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "insert into  addsubcategory values(@subcatgname , @catgname , @describtion ,@UserImageUrl)";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@subcatgname", txtsubcatgory.Text);
            cmd.Parameters.AddWithValue("@catgname", ddlcategory.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = " Data has been saved !";
            conn.Close();


        }

        public void readddldatacatgory()
        {

            if (!IsPostBack)
            {
                String strQuery = "SELECT catgid,catgname  FROM addcategory";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    ddlcategory.DataSource = cmd.ExecuteReader();
                    ddlcategory.DataTextField = "catgname";
                    ddlcategory.DataValueField = "catgid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "select category name");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                    //  con.Dispose();  
                }
            }

        }




    }
}