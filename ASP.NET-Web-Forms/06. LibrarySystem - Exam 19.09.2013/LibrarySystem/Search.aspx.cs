using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();

            var text = this.Request.Params["q"];

            var books = context.Books.ToList();

            if (!string.IsNullOrWhiteSpace(text))
            {
                this.IQuery.InnerText = text;

                books = books.Where(b => b.Title.ToLower().Contains(text.ToLower()) 
                    || b.Author.ToLower().Contains(text.ToLower())).ToList();
            }

            this.ListViewSearchResult.DataSource = books.OrderBy(b => b.Title).ThenBy(b => b.Author);
            this.ListViewSearchResult.DataBind();
        }
    }
}