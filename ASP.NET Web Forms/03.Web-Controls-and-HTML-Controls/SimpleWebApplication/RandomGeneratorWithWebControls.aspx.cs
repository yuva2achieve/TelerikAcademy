using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebApplication
{
    public partial class RandomGeneratorWithWebControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RandomGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var min = int.Parse(NumberMin.Text);
                var max = int.Parse(NumberMax.Text);

                Random rand = new Random();

                int result = rand.Next(min, max);
                NumberResult.Text = result.ToString();
            }
            catch (Exception)
            {
                NumberResult.Text = "Error!";
            }
        }
    }
}