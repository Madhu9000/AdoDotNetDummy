using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDotNetDummy.WebForms
{
    public partial class MultipleResultSetsRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from ProductInventory; select * from ProductCategories", con);
                con.Open();
                
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();

                    while (rdr.NextResult())
                    {
                        GridView2.DataSource = rdr;
                        GridView2.DataBind();
                    }
                }
            }
        }
    }
}