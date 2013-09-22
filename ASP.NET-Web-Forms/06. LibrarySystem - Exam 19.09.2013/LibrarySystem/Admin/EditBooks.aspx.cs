using LibrarySystem.Models;
using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        private const int TextLength = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Create Book

        protected void ShowAddBookPanel_Click(object sender, EventArgs e)
        {
            this.CreateBookPanel.Visible = true;
            this.EditBookPanel.Visible = false;
            this.DeleteBookPanel.Visible = false;

            var context = new LibrarySystemEntities();

            this.DropDownListCategory.DataSource = context.Categories.ToList();
            this.DropDownListCategory.DataBind();
        }

        protected void CreateBookButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            string title = this.TextBoxTitle.Text;
            string author = this.TextBoxAuthor.Text;
            string isbn = this.TextBoxISBN.Text;
            string webSite = this.TextBoxWebSite.Text;
            string description = this.TextBoxDescription.Text;
            int categoryIndex = int.Parse(this.DropDownListCategory.SelectedValue);

            if (string.IsNullOrWhiteSpace(title))
            {
                ErrorSuccessNotifier.AddErrorMessage("Title cannot be empty");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                ErrorSuccessNotifier.AddErrorMessage("Author cannot be empty");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            if (title.Length < 3 || title.Length > 256)
            {
                ErrorSuccessNotifier.AddErrorMessage("Title's length should be between 3 and 256 symbols");
                this.Response.Redirect("~/Admin/EditBooks.aspx");
            }

            if (author.Length < 3 || author.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Author's length should be between 3 and 100 symbols");
                this.Response.Redirect("~/Admin/EditBooks.aspx");
            }

            var category = context.Categories.FirstOrDefault(c => c.Id == categoryIndex);

            Book newBook = new Book();
            newBook.Title = title;
            newBook.Author = author;
            newBook.ISBN = isbn;
            newBook.WebSite = webSite;
            newBook.Description = description;
            newBook.Category = category;

            category.Books.Add(newBook);

            context.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Book created!");
            this.Response.Redirect("~/Admin/EditBooks.aspx");
        }

        protected void CancelCreateButton_Click(object sender, EventArgs e)
        {
            this.CreateBookPanel.Visible = false;
        }

        #endregion

        #region Edit Book

        protected void EditBooksPanelButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            this.DropDownListEditCategory.DataSource = context.Categories.ToList();
            this.DropDownListEditCategory.DataBind();

            int bookId = int.Parse(e.CommandArgument.ToString());
            var book = context.Books.Include("Category").FirstOrDefault(c => c.Id == bookId);

            if (book != null)
            {
                this.TextBoxEditTitle.Text = book.Title;
                this.TextBoxEditAuthor.Text = book.Author;
                this.TextBoxEditISBN.Text = book.ISBN;
                this.TextBoxEditWebSite.Text = book.WebSite;
                this.TextBoxEditDescription.Text = book.Description;
                this.DropDownListEditCategory.SelectedValue = book.CategoryId.ToString();
                this.EditBookPanel.Visible = true;
                this.CreateBookPanel.Visible = false;
                this.DeleteBookPanel.Visible = false;

                this.EditBookButton.CommandArgument = bookId.ToString();
            }
        }

        protected void EditBookButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            string title = this.TextBoxEditTitle.Text;
            string author = this.TextBoxEditAuthor.Text;
            string isbn = this.TextBoxEditISBN.Text;
            string webSite = this.TextBoxEditWebSite.Text;
            string description = this.TextBoxEditDescription.Text;
            int categoryIndex = int.Parse(this.DropDownListEditCategory.SelectedValue);

            if (string.IsNullOrWhiteSpace(title))
            {
                ErrorSuccessNotifier.AddErrorMessage("Title cannot be empty");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                ErrorSuccessNotifier.AddErrorMessage("Author cannot be empty");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            if (title.Length < 3 || title.Length > 256)
            {
                ErrorSuccessNotifier.AddErrorMessage("Title's length should be between 3 and 256 symbols");
                this.Response.Redirect("~/Admin/EditBooks.aspx");
            }

            if (author.Length < 3 || author.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Author's length should be between 3 and 100 symbols");
                this.Response.Redirect("~/Admin/EditBooks.aspx");
            }

            int bookId = int.Parse(e.CommandArgument.ToString());
            var book = context.Books.Include("Category").FirstOrDefault(b => b.Id == bookId);
            var category = context.Categories.FirstOrDefault(c => c.Id == categoryIndex);

            book.Title = title;
            book.Author = author;
            book.ISBN = isbn;
            book.WebSite = webSite;
            book.Description = description;
            book.Category = category;

            context.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Book modified!");
            this.Response.Redirect("~/Admin/EditBooks.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.EditBookPanel.Visible = false;
        }

        #endregion

        #region Delete Book
        protected void DeleteBooksButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();
            int bookId = int.Parse(e.CommandArgument.ToString());
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                this.DeleteBookField.Text = book.Title;
                this.DeleteBookPanel.Visible = true;
                this.EditBookPanel.Visible = false;
                this.CreateBookPanel.Visible = false;

                this.DeleteBookButton.CommandArgument = bookId.ToString();
            }
        }

        protected void DeleteBookButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            int bookId = int.Parse(e.CommandArgument.ToString());
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            context.Books.Remove(book);
            context.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Book deleted!");
            this.Response.Redirect("~/Admin/EditBooks.aspx");
        }

        protected void NoButton_Click(object sender, EventArgs e)
        {
            this.DeleteBookPanel.Visible = false;
        }

        #endregion


        public IQueryable<Book> GridViewBooks_GetData()
        {
            var context = new LibrarySystemEntities();
            return context.Books.Include("Category");
        }

        protected void GridViewBooks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    ViewState["OrigData"] = e.Row.Cells[i].Text;
                    if (e.Row.Cells[i].Text.Length >= TextLength)
                    {
                        e.Row.Cells[i].Text = e.Row.Cells[i].Text.Substring(0, TextLength) + "...";
                        e.Row.Cells[i].ToolTip = ViewState["OrigData"].ToString();
                    }
                }
            }
        }
    }
}