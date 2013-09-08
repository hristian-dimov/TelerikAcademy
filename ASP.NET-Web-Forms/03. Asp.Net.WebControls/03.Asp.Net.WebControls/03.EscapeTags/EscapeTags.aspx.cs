using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.EscapeTags
{
    public partial class EscapeTags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string text = this.TextBoxEnterText.Text;

            this.LabelResult.Text = Server.HtmlEncode(text);
            this.TextBoxResult.Text = Server.HtmlEncode(text);
        }
    }
}