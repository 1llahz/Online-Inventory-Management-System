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
    public partial class addcustomer : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql_query = "insert into customers values(@custname, @email, @phone, @country, @city, @address, @registerdate ,@UserImageUrl)";
            SqlCommand cmd = new SqlCommand(sql_query, conn);
            cmd.Parameters.AddWithValue("@custname", txtcustname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@country", ddlcountry.Text);
            cmd.Parameters.AddWithValue("@city", ddlcity.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@registerdate", txtdate.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been saved !!";
            refreshData();
            conn.Close();

        }

        public void refreshData()
        {
            string sql = "Select * from customers";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            GridView1.DataBind();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            conn.Open();

            string sql_query = "UPDATE customers SET custname = @custname, email = @email, phone = @phone, country = @country, city = @city, address = @address, registerdate = @registerdate WHERE Custid = @custid";

            SqlCommand cmd = new SqlCommand(sql_query, conn);
            cmd.Parameters.AddWithValue("@custname", txtcustname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@country", ddlcountry.Text);
            cmd.Parameters.AddWithValue("@city", ddlcity.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@registerdate", txtdate.Text);
            cmd.ExecuteNonQuery();

            lblinfo.Text = "Data has been updated!";
            refreshData();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string del = "delete from  customers   where custid ='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            conn.Close();
            refreshData();
        }


        public void searchData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from customers  where custid=@id", conn);
            cmd.Parameters.AddWithValue("@id", txtsearch.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtcustname.Text = dr["custname"].ToString();
                txtemail.Text = dr["email"].ToString();
                txtphone.Text = dr["phone"].ToString();
                ddlcountry.Text = dr["country"].ToString();
                ddlcity.Text = dr["city"].ToString();
                txtaddress.Text = dr["address"].ToString();
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

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchData();
        }
    }
}
