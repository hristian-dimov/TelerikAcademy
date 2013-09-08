using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _04.RegisterStudent
{
    public partial class RegisterStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string firstName = Server.HtmlEncode(this.TextBoxFirstName.Text);
            string lastName = Server.HtmlEncode(this.TextBoxLastName.Text);
            string facultyNumber = Server.HtmlEncode(this.TextBoxFacultyNumber.Text);
            string university = Server.HtmlEncode(this.DropDownListUniversity.SelectedItem.Text);
            string specialty = Server.HtmlEncode(this.DropDownListSpecialty.SelectedItem.Text);
            List<string> courses = new List<string>();

            foreach (var i in this.ListBoxCourses.GetSelectedIndices())
            {
                courses.Add(this.ListBoxCourses.Items[i].ToString());
            }

            HtmlGenericControl paragraphFirstName = new HtmlGenericControl("p");
            paragraphFirstName.InnerText = firstName;
            HtmlGenericControl paragraphLastName = new HtmlGenericControl("p");
            paragraphLastName.InnerText = lastName;
            HtmlGenericControl paragraphFacultyNumber = new HtmlGenericControl("p");
            paragraphFacultyNumber.InnerText = facultyNumber;
            HtmlGenericControl paragraphUniversity = new HtmlGenericControl("p");
            paragraphUniversity.InnerText = university;
            HtmlGenericControl paragraphSpecialty = new HtmlGenericControl("p");
            paragraphSpecialty.InnerText = specialty;

            Panel panelCourses = new Panel();

            HtmlGenericControl headerCourses = new HtmlGenericControl("h2");
            headerCourses.InnerText = "Courses";
            panelCourses.Controls.Add(headerCourses);

            foreach (var course in courses)
            {
                HtmlGenericControl paragraphCourse = new HtmlGenericControl("p");
                paragraphCourse.InnerText = course;

                panelCourses.Controls.Add(paragraphCourse);
            }

            this.PanelResult.Controls.Add(paragraphFirstName);
            this.PanelResult.Controls.Add(paragraphLastName);
            this.PanelResult.Controls.Add(paragraphFacultyNumber);
            this.PanelResult.Controls.Add(paragraphUniversity);
            this.PanelResult.Controls.Add(paragraphSpecialty);
            this.PanelResult.Controls.Add(panelCourses);

        }
    }
}