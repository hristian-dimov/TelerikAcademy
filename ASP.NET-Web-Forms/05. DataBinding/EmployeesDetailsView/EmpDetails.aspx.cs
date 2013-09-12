using System;
using System.Linq;
using Northwind.Data;

namespace EmployeesDetailsView
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            int employeeId;
            bool tryParseId = int.TryParse(Request.Params["id"], out employeeId);

            if (Request.Params["Id"] == null || !tryParseId)
            {
                Response.Redirect("~/Employees.aspx");
            }

            NorthwindEntities context = new NorthwindEntities();


            var employee = context.Employees.Where(emp => emp.EmployeeID == employeeId).ToList();

            if (employee.Count == 0)
            {
                Response.Redirect("~/Employees.aspx");
            }

            this.DetailsViewEmployee.DataSource = employee;
            this.DetailsViewEmployee.DataBind();
        }
    }
}