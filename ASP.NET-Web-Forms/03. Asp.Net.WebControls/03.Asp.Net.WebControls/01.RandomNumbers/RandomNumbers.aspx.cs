using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.RandomNumbers
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerateRando_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            int from = int.Parse(this.TextBoxFirstNumber.Text);
            int to = int.Parse(this.TextBoxSecondNumber.Text);

            this.result.InnerText = rand.Next(from, to + 1).ToString();

        }
    }
}