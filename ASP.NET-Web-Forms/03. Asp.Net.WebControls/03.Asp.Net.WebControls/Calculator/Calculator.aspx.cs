using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBoxSecondNum.Style.Add("display", "none");
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            double num1 = int.Parse(this.TextBoxFirstNum.Text);
            //double num2 = int.Parse(this.TextBoxSecondNum.Text);

            this.TextBoxFirstNum.Style.Add("display", "none");
            this.TextBoxSecondNum.Style.Add("display", "inline");
        }
    }
}