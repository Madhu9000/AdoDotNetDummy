using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDotNetDummy
{
    public partial class CallingProcedure1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                // SqlCommand cmd = new SqlCommand("select * from Products where ProductName like @ProductName", con);
                SqlCommand cmd = new SqlCommand("spCreateEmployee", con);
                //This line is used to exec stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", TextBox2.Text);

                SqlParameter outParameter = new SqlParameter();
                outParameter.ParameterName = "@EmpId";
                outParameter.DbType = System.Data.DbType.Int32;
                outParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParameter);
            
                con.Open();
                cmd.ExecuteNonQuery();
                string output = outParameter.Value.ToString();
                Label4.Text = "Employee Id Inserted is: " + output;
            }
        }
    }
}