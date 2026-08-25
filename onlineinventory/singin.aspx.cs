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
    public partial class singin : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            conn.Open();
           
            cmd = new SqlCommand("select username, password from newuser  where username='" + txtusername.Text + "' and password= '" + txtpassword.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

                {
                    lblinfo.Text = "Invalid username and password";
                }
                conn.Close();
                txtusername.Text = "";
                txtpassword.Text = "";

            }
        }
    }
}