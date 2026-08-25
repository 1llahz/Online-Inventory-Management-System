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
    public partial class addpayment : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data source=AISHA\\CAISHA; initial catalog=Inventory_db ; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            readddldatapro();
            readddldatacust();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql_query = "insert into addpayments  values(@custname, @productname, @qty, @price, @newqty, @remainedqty, @newprice, @totalbalance, @registerdate)";
            SqlCommand cmd = new SqlCommand(sql_query, conn);
            cmd.Parameters.AddWithValue("@custname", ddlcustname.Text);
            cmd.Parameters.AddWithValue("@productname", ddlproname.Text);
            cmd.Parameters.AddWithValue("@qty", txtqty.Text);
            cmd.Parameters.AddWithValue("@price", txtprice.Text);
            cmd.Parameters.AddWithValue("@newqty", txtnqty.Text);
            cmd.Parameters.AddWithValue("@remainedqty", txtremained.Text);
            cmd.Parameters.AddWithValue("@newprice", txtnewprice.Text);
            cmd.Parameters.AddWithValue("@totalbalance", txtnbalance.Text);
            cmd.Parameters.AddWithValue("@registerdate", txtdate.Text);
            cmd.ExecuteNonQuery();
            lblinfo.Text = "Data has been saved  !!";

            btnupdate.Visible = false;
            btndelete.Visible = false;
            conn.Close();
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



        protected void btngetproData_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select  qty, price from  addproduct where  productid = @id", conn);
            cmd.Parameters.AddWithValue("@id", ddlproname.Text);

            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            { 
                txtqty.Text = dr["qty"].ToString();
                txtprice.Text = dr["price"].ToString();

            }
            else
            {

                {
                    lblinfo.Text = "waa lasoo waayay";
                }
                conn.Close();
            }
        }





    }
}