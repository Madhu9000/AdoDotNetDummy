using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDotNetDummy.WebForms
{
    public partial class StronglyTypedDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentDataSetTableAdapters.StudentsTableAdapter studentAdapter =
               new StudentDataSetTableAdapters.StudentsTableAdapter();
                StudentDataSet.StudentsDataTable studentTable = new StudentDataSet.StudentsDataTable();
                studentAdapter.Fill(studentTable);
                Session["DATATABLE"] = studentTable;
                GridView1.DataSource = from student in studentTable
                                       select new
                                       {
                                           student.Id,
                                           student.Name,
                                           student.Gender,
                                           student.TotalMarks
                                       };
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                StudentDataSet.StudentsDataTable studentTable = 
                    (StudentDataSet.StudentsDataTable)Session["DATATABLE"];              
                GridView1.DataSource = from student in studentTable
                                       select new
                                       {
                                           student.Id,
                                           student.Name,
                                           student.Gender,
                                           student.TotalMarks
                                       };
                GridView1.DataBind();
            }
            else
            {
                StudentDataSet.StudentsDataTable studentTable = 
                    (StudentDataSet.StudentsDataTable)Session["DATATABLE"];
                GridView1.DataSource = from student in studentTable
                                       where student.Name.ToUpper().StartsWith(TextBox1.Text.ToUpper())
                                       select new
                                       {
                                           student.Id,
                                           student.Name,
                                           student.Gender,
                                           student.TotalMarks
                                       };
                GridView1.DataBind();
            }
        }
    }
}