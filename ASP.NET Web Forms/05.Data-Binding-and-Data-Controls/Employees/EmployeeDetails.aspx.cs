using Employees.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var employeeId = Request.Params["Id"];

            if (employeeId == null)
            {
                Response.Redirect("Employees.aspx");
            }

            int parsedId = int.Parse(employeeId);

            NorthwindEntities context = new NorthwindEntities();
            var employee = new List<Employee>()
                {
                    context.Employees.FirstOrDefault(x => x.EmployeeID == parsedId)
                };

            EmployeeDetailsView.DataSource = employee;
            EmployeeDetailsView.DataBind();

            EmployeeFormView.DataSource = employee;
            EmployeeFormView.DataBind();
        }
    }
}