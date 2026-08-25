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
    public partial class addsales : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            readddldatacust();
            readddldatasupp();
        }


        protected void btnsubmit_Click1(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "insert into addsales values(@custname , @salesdate , @suppname, @UserImageUrl,@ordertax, @discount, @shipping, @status, @describtion )";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@custname", ddlcustname.Text);
            cmd.Parameters.AddWithValue("@salesdate", txtpdate.Text);
            cmd.Parameters.AddWithValue("@suppname", ddlsup.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.Parameters.AddWithValue("@ordertax", txtotax.Text);
            cmd.Parameters.AddWithValue("@discount", txtdiscount.Text);
            cmd.Parameters.AddWithValue("@shipping", txtship.Text);
            cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.ExecuteNonQuery();
            lblinfo.Text = " Data has been saved !";
            conn.Close();
        }

        public void refreshData()
        {
            string sql = "Select * from addsales";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            GridView1.DataBind();

        }


        public void readddldatacust()
        {

            if (!IsPostBack)
            {
                String strQuery = "SELECT custid ,custname  FROM  customers";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    ddlcustname.DataSource = cmd.ExecuteReader();
                    ddlcustname.DataTextField = "custname";
                    ddlcustname.DataValueField = "custid";
                    ddlcustname.DataBind();
                    ddlcustname.Items.Insert(0, "select customer name");

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

        public void readddldatasupp()
        {

            if (!IsPostBack)
            {
                String strQuery = "SELECT suppid,suppname  FROM addsupplier";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    ddlsup.DataSource = cmd.ExecuteReader();
                    ddlsup.DataTextField = "suppname";
                    ddlsup.DataValueField = "suppid";
                    ddlsup.DataBind();
                    ddlsup.Items.Insert(0, "select supplier name");

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

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "UPDATE addsales SET custname = @custname, salesdate = @salesdate, suppname = @suppname, UserImageUrl = @UserImageUrl, ordertax = @ordertax, discount = @discount, shipping = @shipping, status = @status, describtion = @describtion  where saleid  = '" + txtsearch.Text + "'";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@custname", ddlcustname.Text);
            cmd.Parameters.AddWithValue("@salesdate", txtpdate.Text);
            cmd.Parameters.AddWithValue("@suppname", ddlsup.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.Parameters.AddWithValue("@ordertax", txtotax.Text);
            cmd.Parameters.AddWithValue("@discount", txtdiscount.Text);
            cmd.Parameters.AddWithValue("@shipping", txtship.Text);
            cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been updated!";
            conn.Close();

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string del = "delete from   addsales  where saleid='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            refreshData();
            conn.Close();

        }


        public void searchData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select custname, purchasedate,suppname,refrenceno,ordertax,discount,shipping,status,describtion  from addsales where saleid = @id", conn);

            cmd.Parameters.AddWithValue("@id", txtsearch.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ddlcustname.Text = dr["custname"].ToString();
                txtpdate.Text = dr["sslesdate"].ToString();
                ddlsup.Text = dr["suppname"].ToString();
                txtotax.Text = dr["ordertax"].ToString();
                txtdiscount.Text = dr["discount"].ToString();
                txtship.Text = dr["shipping"].ToString();
                ddlstatus.Text = dr["status"].ToString();
                txtDescription.Text = dr["describtion"].ToString();

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