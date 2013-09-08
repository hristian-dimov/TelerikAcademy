using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.HelloName
{
    public partial class Hello : System.Web.UI.Page
    {
        public void ButtonDisplayName_Click(object sender, EventArgs e)
        {
            this.Result.InnerText = "Hello, " + this.TextBoxName.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}