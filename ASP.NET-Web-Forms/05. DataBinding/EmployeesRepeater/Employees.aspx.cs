using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind.Data;

namespace EmployeesRepeater
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            NorthwindEntities context = new NorthwindEntities();
            var employeesDataSource = context.Employees.ToList();

            this.RepeaterEmployees.DataSource = employeesDataSource;
            this.RepeaterEmployees.DataBind();
        }
    }
}