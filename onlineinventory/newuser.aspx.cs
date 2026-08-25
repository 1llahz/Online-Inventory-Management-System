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
    public partial class newuser : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "insert into  newuser values(@username , @password ,@email, @tell ,@status ,@registerdate ,@UserImageUrl)";

            SqlCommand cmd = new SqlCommand(xeran, conn);
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
            string sql = "Select * from newuser";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            GridView2.DataBind();
           

        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string edit = "update  newuser    set @username =@username , @password= @password ,  @email=@email, @tell=@tell, @status=@status, @registerdate=@registerdate ,@UserImageUrl=@UserImageUrl   where userid  = '" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(edit, conn);
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
            string del = "delete from newuser  where userid='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            refreshData();
            conn.Close();
        }
        public void searchData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from newuser  where userid=@id", conn);
            cmd.Parameters.AddWithValue("@id", txtsearch.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
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
