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
    public partial class addpurchase : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            readddldatasupp();
            readddldatapro();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();

            string xeran = "insert into addpurchase  values(@suppname , @purchasedate , @productname, @refrenceno, @UserImageUrl,@ordertax, @discount, @shipping, @status, @describtion )";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@suppname", ddlsup.Text);
            cmd.Parameters.AddWithValue("@purchasedate", txtpdate.Text);
            cmd.Parameters.AddWithValue("@productname", ddlproname.Text);
            cmd.Parameters.AddWithValue("@refrenceno", txtref.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.Parameters.AddWithValue("@ordertax", txtotax.Text);
            cmd.Parameters.AddWithValue("@discount", txtdiscount.Text);
            cmd.Parameters.AddWithValue("@shipping", txtship.Text);
            cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.ExecuteNonQuery();
            lblinfo.Text = " Data has been saved !";
            refreshData();
            conn.Close();

        }

        public void refreshData()
        {
            string sql = "Select * from addproduct";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            GridView1.DataBind();

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


        public void readddldatapro()
        {

            if (!IsPostBack)
            {
                String strQuery = "SELECT productid,productname  FROM  addproduct";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    ddlproname.DataSource = cmd.ExecuteReader();
                    ddlproname.DataTextField = "productname";
                    ddlproname.DataValueField = "productid";
                    ddlproname.DataBind();
                    ddlproname.Items.Insert(0, "select product name");

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
            string xeran = "UPDATE addpurchase SET @suppname = @suppname, @purchasedate = @purchasedate, @productname = @productname, @refrenceno = @refrenceno, @UserImageUrl = @UserImageUrl, @ordertax = @ordertax, @discount = @discount, @shipping = @shipping, @status = @status, @describtion = @describtion  where purid  = '" + txtsearch.Text + "'";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@suppname", ddlsup.Text);
            cmd.Parameters.AddWithValue("@purchasedate", txtpdate.Text);
            cmd.Parameters.AddWithValue("@productname", ddlproname.Text);
            cmd.Parameters.AddWithValue("@refrenceno", txtref.Text);
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
            string del = "delete from   addpurchase  where purid='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            refreshData();
            conn.Close();

        }





        public void searchData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select suppid, purchasedate,productname,refrenceno,ordertax,discount,shipping,status,describtion  from addpurchase where purid = @id", conn);

            cmd.Parameters.AddWithValue("@id", txtsearch.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ddlsup.Text = dr["suppname"].ToString();
                txtpdate.Text = dr["purchasedate"].ToString();
                ddlproname.Text = dr["productname"].ToString();
                txtref.Text = dr["refrenceno"].ToString();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchData();
        }
    }
}