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
    public partial class addbrand : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "insert into addbrand  values(@brandname, @describtion, @UserImageUrl)";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@brandname", txtbrand.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = " Data has been saved !";
            conn.Close();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updateQuery = "UPDATE addbrand SET BrandName = @brandname, Description = @describtion, UserImageUrl = @UserImageUrl WHERE brandid = @brandid";
            SqlCommand cmd = new SqlCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@brandname", txtbrand.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been updated!";
            conn.Close();

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string del = "delete from addbrand   where brandid ='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            conn.Close();

        }
    }
}