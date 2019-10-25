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
    public partial class TabledataCopySqlBulk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SourceCS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string DestinationCS = ConfigurationManager.ConnectionStrings["DestinationConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(SourceCS))
            {
                SqlCommand cmd = new SqlCommand("select * from Departments", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection desCon = new SqlConnection(DestinationCS))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(desCon))
                        {
                            bc.DestinationTableName = "Departments";
                            desCon.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }
                String query = "select * from Employees";
                SqlCommand cmd1 = new SqlCommand(query, con);
                using (SqlDataReader rdr = cmd1.ExecuteReader())
                {
                    using (SqlConnection desCon = new SqlConnection(DestinationCS))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(desCon))
                        {
                            bc.DestinationTableName = "Employees";
                            desCon.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }
            }
        }
    }
}