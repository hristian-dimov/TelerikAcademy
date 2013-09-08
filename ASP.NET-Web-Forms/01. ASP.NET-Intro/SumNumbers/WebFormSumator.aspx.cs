using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumNumbers
{
    public partial class WebFormSumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            decimal firstNum = decimal.Parse(this.TextBoxFirstNum.Text);
            decimal secondNum = decimal.Parse(this.TextBoxSecondNum.Text);

            decimal result = firstNum + secondNum;

            this.TextBoxSum.Text = result.ToString();
        }
    }
}