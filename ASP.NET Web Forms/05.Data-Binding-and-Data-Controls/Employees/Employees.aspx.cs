using Employees.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NorthwindEntities context = new NorthwindEntities();
                var employees = context.Employees.Select(x => new
                {
                    Id = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).ToList();

                GridViewEmployees.DataSource = employees;
                GridViewEmployees.DataBind();

                RepeaterEmployees.DataSource = context.Employees.ToList();
                RepeaterEmployees.DataBind();

                ListViewEmployees.DataSource = context.Employees.ToList();
                ListViewEmployees.DataBind();

            }
        }
    }
}