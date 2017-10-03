using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab_2.Classes;
using System.Text.RegularExpressions;

namespace Lab_2
{
    public partial class StudentRecords : System.Web.UI.Page
    {
        private Course course;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["course"] == null)
                Response.Redirect("Default.aspx");

            course = (Course)Session["course"];

            Title = course.ToString();

            OrderList();

            if (!IsPostBack)
            {
                rdbtnId.Selected = true;
            }
        }

        private void PopulateTable(IOrderedEnumerable<Student> list)
        {
            ClearTable();
            foreach (Student student in list)
            {
                TableRow row = new TableRow();
                row.Controls.Add(new TableCell { Text = student.Id });
                row.Controls.Add(new TableCell { Text = student.Name });
                row.Controls.Add(new TableCell { Text = student.Grade.ToString() });

                tblStudentList.Controls.Add(row);
            }
        }

        private void ClearTable()
        {
            for (int i = tblStudentList.Controls.Count - 1; i > 0; i--)
            {
                tblStudentList.Controls.RemoveAt(i);
            }
        }

        protected void btnSubmitStudent_Click(object sender, EventArgs e)
        {
            errAddStudent.Visible = false;
            if (txtGrade.Text == "" || txtStudentId.Text == "" || txtStudentName.Text == "")
            {
                errAddStudent.InnerText = "All fields are required";
                errAddStudent.Visible = true;
                return;
            }
            if (!Regex.IsMatch(txtStudentName.Text, @"^[a-zA-Z]+\s[a-zA-Z]+$"))
            {
                errAddStudent.InnerText = "Student name is invalid";
                errAddStudent.Visible = true;
                return;
            }
            if (!Regex.IsMatch(txtGrade.Text, @"^((\d)|(\d\d)|(0\d\d)|(100))$"))
            {
                errAddStudent.InnerText = "Grade is invalid";
                errAddStudent.Visible = true;
                return;
            }

            Student newStudent = new Student(txtStudentId.Text, txtStudentName.Text, int.Parse(txtGrade.Text));

            foreach (Student student in course.GetStudentList())
            {
                if (newStudent.Id == student.Id || newStudent.Name == student.Name)
                {
                    errAddStudent.InnerText = "Student ID or Name already exists";
                    errAddStudent.Visible = true;
                    return;
                }
            }
            course.addStudent(newStudent);

            OrderList();
        }

        protected void lstOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderList();
        }

        private void OrderList()
        {
            if (course.GetStudentList().Count == 0)
            {
                ClearTable();
                TableCell cell = new TableCell();
                cell.Text = "No student records found!";
                cell.ColumnSpan = 3;
                TableRow row = new TableRow();
                row.Controls.Add(cell);
                tblStudentList.Controls.Add(row);
                return;
            }
            if (rdbtnId.Selected == true)
            {
                PopulateTable(course.GetStudentList().OrderBy(student => student.Id));
            }
            if (rdbtnGrade.Selected == true)
            {
                PopulateTable(course.GetStudentList().OrderBy(student => student.Grade).ThenBy(student => student.Name.Split(' ').Last()).ThenBy(student => student.Name.Split(' ')[0]));
            }
            if (rdbtnName.Selected == true)
            {
                PopulateTable(course.GetStudentList().OrderBy(student => student.Name.Split(' ').Last()).ThenBy(student => student.Name.Split(' ')[0]).ThenBy(student => student.Id));
            }
        }
    }
}