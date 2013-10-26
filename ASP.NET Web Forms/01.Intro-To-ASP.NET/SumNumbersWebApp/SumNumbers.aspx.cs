using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumNumbersWebApp
{
    public partial class SumNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            decimal firstNumber;
            decimal secondNumber;
            bool isFirstNumber = decimal.TryParse(this.TextBoxFirstNumber.Text, out firstNumber);
            bool isSecondNumber = decimal.TryParse(this.TextBoxSecondNumber.Text, out secondNumber);
            if (isFirstNumber && isSecondNumber)
            {
                this.TextBoxSum.Text = Convert.ToString(firstNumber + secondNumber);
            }
            else
            {
                this.TextBoxSum.Text = "error";
            }
        }

    }
}