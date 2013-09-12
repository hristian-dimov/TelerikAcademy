using System;
using System.Linq;
using Northwind.Data;

namespace EmployeesDetailsView
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

            var employeesDataSource = from employee in context.Employees.ToList()
                        select new 
                        { 
                            FullName = employee.FirstName + " " + employee.LastName, 
                            Id = employee.EmployeeID 
                        };

            this.GridViewEmployees.DataSource = employeesDataSource;
            this.GridViewEmployees.DataBind();
        }
    }
}