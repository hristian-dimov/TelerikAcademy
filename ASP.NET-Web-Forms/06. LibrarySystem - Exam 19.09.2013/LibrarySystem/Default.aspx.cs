using LibrarySystem.Models;
using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();
            var employeesDataSource = context.Categories.ToList();

            this.RepeaterCategories.DataSource = employeesDataSource;
            this.RepeaterCategories.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string text = this.TextBoxSearch.Text;

            if (text.Length > 1000)
            {
                ErrorSuccessNotifier.AddErrorMessage("Search criteria is too long( shouldn't be more than 1000 chars.");
                this.Response.Redirect("~/");
            }

            this.Response.Redirect("~/Search?q=" + text);
        }
    }
}