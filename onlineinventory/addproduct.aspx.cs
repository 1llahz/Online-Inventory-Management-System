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
    public partial class addproduct : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {

            readddldatar();
            readddldatacatg();
            readddldatasubcatg();

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "insert into   addproduct values(@catgname, @subcatgname ,@brandname, @productname, @unit, @minimumqty, @describtion, @discounttype, @status ,@sku,@qty, @price,  @registerdate ,@UserImageUrl)";
            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@catgname", ddlcategory.Text);
            cmd.Parameters.AddWithValue("@subcatgname", ddlsubcategory.Text);
            cmd.Parameters.AddWithValue("@brandname", ddlbrand.Text);
            cmd.Parameters.AddWithValue("@productname", txtproductname.Text);
            cmd.Parameters.AddWithValue("@unit", ddlunit.Text);
            cmd.Parameters.AddWithValue("@minimumqty", txtminqty.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.Parameters.AddWithValue("@discounttype", ddldiscount.Text);
            cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            cmd.Parameters.AddWithValue("@sku", txtsku.Text);
            cmd.Parameters.AddWithValue("@qty", txtqty.Text);
            cmd.Parameters.AddWithValue("@price", txtprice.Text);
            cmd.Parameters.AddWithValue("@registerdate", txtdate.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
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

        public void readddldatacatg()
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



        public void readddldatasubcatg()
        {

            if (!IsPostBack)
            {
                String strQuery = "SELECT subcatgid ,subcatgname  FROM addsubcategory";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    ddlsubcategory.DataSource = cmd.ExecuteReader();
                    ddlsubcategory.DataTextField = "subcatgname";
                    ddlsubcategory.DataValueField = "subcatgid";
                    ddlsubcategory.DataBind();
                    ddlsubcategory.Items.Insert(0, "select subcategory name");

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

        public void readddldatar()
        {

            if (!IsPostBack)
            {
                String strQuery = "SELECT brandid, brandname FROM addbrand";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    ddlbrand.DataSource = cmd.ExecuteReader();
                    ddlbrand.DataTextField = "brandname";
                    ddlbrand.DataValueField = "brandid";
                    ddlbrand.DataBind();
                    ddlbrand.Items.Insert(0, "select brand name");

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
            string xeran = "UPDATE addproduct SET catgname = @catgname, subcatgname = @subcatgname, brandname = @brandname, unit = @unit, minimumqty = @minimumqty, describtion = @describtion, discounttype = @discounttype, status = @status, sku = @sku, qty = @qty, price = @price, registerdate = @registerdate, UserImageUrl = @UserImageUrl WHERE productid  = '" + txtsearch.Text + "'";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@catgname", ddlcategory.Text);
            cmd.Parameters.AddWithValue("@subcatgname", ddlsubcategory.Text);
            cmd.Parameters.AddWithValue("@brandname", ddlbrand.Text);
            cmd.Parameters.AddWithValue("@productname", txtproductname.Text);
            cmd.Parameters.AddWithValue("@unit", ddlunit.Text);
            cmd.Parameters.AddWithValue("@minimumqty", txtminqty.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.Parameters.AddWithValue("@discounttype", ddldiscount.Text);
            cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            cmd.Parameters.AddWithValue("@sku", txtsku.Text);
            cmd.Parameters.AddWithValue("@qty", txtqty.Text);
            cmd.Parameters.AddWithValue("@price", txtprice.Text);
            cmd.Parameters.AddWithValue("@registerdate", txtdate.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been updated!";
            refreshData();
            conn.Close();

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string del = "delete from  addproduct  where productid='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            refreshData();
            conn.Close();
            

        }


        public void searchData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select productid, catgid, subcatgid,  brandid, productname, unit, minimumqty, describtion, discounttype, status, sku, qty, price, registerdate from addproduct where productid = @id", conn);
            cmd.Parameters.AddWithValue("@id", txtsearch.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ddlcategory.Text = dr["catgname"].ToString();
                ddlsubcategory.Text = dr["subcatgname"].ToString();
                ddlbrand.Text = dr["brandname"].ToString();
                txtproductname.Text = dr["productname"].ToString();
                ddlunit.Text = dr["unit"].ToString();
                txtminqty.Text = dr["minimumqty"].ToString();
                txtDescription.Text = dr["describtion"].ToString();
                ddldiscount.Text = dr["discounttype"].ToString();
                ddlstatus.Text = dr["status"].ToString();
                txtsku.Text = dr["sku"].ToString();
                txtqty.Text = dr["qty"].ToString();
                txtprice.Text = dr["price"].ToString();
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