using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab_2.Classes;

namespace Lab_2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["course"] != null)
            {
                Response.Redirect("StudentRecords.aspx");
            }
        }
        public void btnSubmit_Click(object sender, EventArgs args)
        {
            if (txtCourseNumber.Text == "" || txtCourseName.Text == "")
            {
                errorAddCourse.Visible = true;
                return;
            }
            errorAddCourse.Visible = false;

            Session["course"] = new Course(txtCourseNumber.Text, txtCourseName.Text);

            Response.Redirect("StudentRecords.aspx");
        }
    }
}