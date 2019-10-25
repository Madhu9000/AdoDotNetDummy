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
    public partial class BulkCopy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                DataSet set = new DataSet();
                set.ReadXml(Server.MapPath("Data.xml"));
                DataTable depTable = set.Tables["Department"];
                DataTable empTable = set.Tables["Employee"];
                con.Open();

                using(SqlBulkCopy bc = new SqlBulkCopy(con))
                {
                    bc.DestinationTableName = "Departments";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Location", "Location");
                    bc.WriteToServer(depTable);
                }
                using (SqlBulkCopy bc = new SqlBulkCopy(con))
                {
                    bc.DestinationTableName = "Employees";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Gender", "Gender");
                    bc.ColumnMappings.Add("DepartmentId", "DepartmentId");
                    bc.WriteToServer(empTable);
                }
            }
        }
    }
}