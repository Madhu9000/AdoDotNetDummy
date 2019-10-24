using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDotNetDummy.WebForms
{
    public partial class SqlDataReaderReadMethodSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                // SqlCommand cmd = new SqlCommand("select * from Products where ProductName like @ProductName", con);
                SqlCommand cmd = new SqlCommand("select * from ProductInventory", con);
                //This line is used to exec stored procedure
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("Id");
                    table.Columns.Add("Name");
                    table.Columns.Add("Price");
                    table.Columns.Add("Discount Price");
                    while (rdr.Read())
                    {
                        int originalPrice = Convert.ToInt32(rdr["UnitPrice"]);
                        double discountedPrice = originalPrice * 0.5;

                        DataRow datarow = table.NewRow();
                        datarow["Name"] = rdr["ProductName"];
                        datarow["Price"] = rdr["UnitPrice"];
                        datarow["Discount Price"] = discountedPrice;

                        table.Rows.Add(datarow);
                    }
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
                
                
            }
        }
    }
}