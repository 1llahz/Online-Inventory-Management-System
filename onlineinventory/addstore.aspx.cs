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
    public partial class addstore : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "insert into  addstore values( @storename,@username , @password ,@email, @tell ,@status ,@registerdate ,@UserImageUrl)";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@storename", txtstorename.Text);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@tell", txttell.Text);
            cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            cmd.Parameters.AddWithValue("@registerdate", txtdate.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = " Data has been saved !";
            refreshData();
            conn.Close();


        }

        public void refreshData()
        {
            string sql = "Select * from addstore";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            GridView1.DataBind();


        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string edit = "update  addstore    set @storename=@storename, @username =@username , @password= @password ,  @email=@email, @tell=@tell, @status=@status, @registerdate=@registerdate ,@UserImageUrl=@UserImageUrl   where storeid  = '" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(edit, conn);
            cmd.Parameters.AddWithValue("@storename", txtstorename.Text);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@tell", txttell.Text);
            cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            cmd.Parameters.AddWithValue("@registerdate", txtdate.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = " Data has been updated !";
            refreshData();
            conn.Close();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string del = "delete from addstore  where storeid='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            refreshData();
            conn.Close();
        }


        public void searchData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from addstore    where storeid=@id", conn);
            cmd.Parameters.AddWithValue("@id", txtsearch.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtstorename.Text = dr["storename"].ToString();
                txtusername.Text = dr["username"].ToString();
                txttell.Text = dr["password"].ToString();
                txtemail.Text = dr["email"].ToString();
                txttell.Text = dr["tell"].ToString();
                ddlstatus.Text = dr["status"].ToString();
                txtdate.Text = dr["registerdate"].ToString();

            }
            else
            {

                {
                    lblinfo.Text = "waa lasoo waayay";
                }
                conn.Close();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            searchData();

        }
    }
}