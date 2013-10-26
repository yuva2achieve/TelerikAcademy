using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebApplication
{
    public partial class RandomGeneratorWithHtmlControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RandomGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var min = int.Parse(numMin.Value);
                var max = int.Parse(numMax.Value);

                Random rand = new Random();

                int result = rand.Next(min, max);
                numResult.Value = result.ToString();
            }
            catch (Exception)
            {
                numResult.Value = "Error!";
            }
        }
    }
}