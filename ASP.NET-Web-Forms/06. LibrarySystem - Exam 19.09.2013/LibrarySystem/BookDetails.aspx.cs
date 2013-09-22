using LibrarySystem.Models;
using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int bookId;
            bool tryParseId = int.TryParse(Request.Params["id"], out bookId);

            if (Request.Params["Id"] == null || !tryParseId)
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid id!");
                this.Response.Redirect("~/");
            }

            var context = new LibrarySystemEntities();

            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid book!");
                this.Response.Redirect("~/");
            }

            this.BookTitle.InnerText = book.Title;
            this.BookAuthor.InnerText = "by " + book.Author;
            this.BookISBN.InnerText = "ISBN " + book.ISBN;
            this.BookWebSiteURL.HRef = book.WebSite;
            this.BookWebSiteURL.InnerText = book.WebSite;
            this.BookDescription.InnerText = book.Description;
        }
    }
}