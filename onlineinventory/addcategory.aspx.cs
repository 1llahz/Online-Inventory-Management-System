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
    public partial class addcategory : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xeran = "insert into  addcategory values(@catgname , @catgcode , @describtion ,@UserImageUrl)";

            SqlCommand cmd = new SqlCommand(xeran, conn);
            cmd.Parameters.AddWithValue("@catgname", txtcategory.Text);
            cmd.Parameters.AddWithValue("@catgcode", txtcatgcode.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = " Data has been saved !";
            conn.Close();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updateQuery = "UPDATE addcategory SET CategoryName = @catgname, CategoryCode = @catgcode, Description = @describtion, UserImageUrl = @UserImageUrl WHERE catgid = @catgid";
            SqlCommand cmd = new SqlCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@catgname", txtcategory.Text);
            cmd.Parameters.AddWithValue("@catgcode", txtcatgcode.Text);
            cmd.Parameters.AddWithValue("@describtion", txtDescription.Text);
            cmd.Parameters.AddWithValue("@UserImageUrl", txtfdoc.HasFiles);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been updated!";
            conn.Close();

        }

        public void refreshData()
        {

            string sql = "select * from addcategory ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dtl = new DataTable();
            sda.Fill(dtl);
            GridView1.DataBind();


        }


        protected void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string del = "delete from addcategory  where catgid ='" + txtsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been deleted !";
            conn.Close();

        }




        public void searchData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from addcategory   where catgid=@id", conn);
            cmd.Parameters.AddWithValue("@id", txtsearch.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtcategory.Text = dr["catgname"].ToString();
                txtcatgcode.Text = dr["catgcode"].ToString();
                txtDescription.Text = dr["description"].ToString();
               

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