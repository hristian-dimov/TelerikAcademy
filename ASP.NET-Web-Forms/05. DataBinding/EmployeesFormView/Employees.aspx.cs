using System;
using System.Linq;
using Northwind.Data;

namespace EmployeesFormView
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

            if(Request.Params["Id"] != null) 
            {
                int employeeId = int.Parse(Request.Params["Id"]);
                var employee = context.Employees.Where(emp => emp.EmployeeID == employeeId).ToList();

                this.FormViewEmployee.DataSource = employee;
                this.FormViewEmployee.DataBind();
            }
        }
    }
}