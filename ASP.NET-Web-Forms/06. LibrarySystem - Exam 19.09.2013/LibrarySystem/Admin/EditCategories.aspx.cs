using LibrarySystem.Models;
using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace LibrarySystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Create Category
        protected void ShowAddCategoryPanel_Click(object sender, EventArgs e)
        {
            this.CreateCategoryPanel.Visible = true;
            this.DeleteCategoryPanel.Visible = false;
            this.EditCategoryPanel.Visible = false;
        }

        protected void CreateCategoryButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            string categoryName = this.CreateCategoryField.Text;

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name cannot be empty");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            if (categoryName.Length < 3 || categoryName.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category length should be  between 3 and 100 symbols");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            Category newCategory = new Category();
            newCategory.CategoryName = categoryName;

            context.Categories.Add(newCategory);
            context.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Category created!");
            this.Response.Redirect("~/Admin/EditCategories.aspx");
        }

        protected void CancelCreateButton_Click(object sender, EventArgs e)
        {
            this.CreateCategoryPanel.Visible = false;
        }

        #endregion

        #region Edit Category
        protected void EditCategoriesPanelButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();
            int categoryId = int.Parse(e.CommandArgument.ToString());
            var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                this.EditCategoryField.Text = category.CategoryName;
                this.EditCategoryPanel.Visible = true;
                this.DeleteCategoryPanel.Visible = false;
                this.CreateCategoryPanel.Visible = false;

                this.EditCategoryButton.CommandArgument = categoryId.ToString();
            }
        }

        protected void EditCategoryButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            string newCategoryName = this.EditCategoryField.Text;

            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name cannot be empty");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            if (newCategoryName.Length < 3 || newCategoryName.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category length should be between 3 and 100 symbols");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            int categoryId = int.Parse(e.CommandArgument.ToString());
            var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);

            category.CategoryName = newCategoryName;
            context.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Category modified!");
            this.Response.Redirect("~/Admin/EditCategories.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.EditCategoryPanel.Visible = false;
        }

        #endregion

        #region Delete Category

        protected void DeleteCategoryPanelButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();
            int categoryId = int.Parse(e.CommandArgument.ToString());
            var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                this.DeleteCategoryField.Text = category.CategoryName;
                this.DeleteCategoryPanel.Visible = true;
                this.EditCategoryPanel.Visible = false;
                this.CreateCategoryPanel.Visible = false;

                this.DeleteCategoryButton.CommandArgument = categoryId.ToString();
            }
        }

        protected void DeleteCategoryButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            int categoryId = int.Parse(e.CommandArgument.ToString());
            var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);

            var currentCategoryBooks = category.Books;

            context.Books.RemoveRange(currentCategoryBooks);

            context.Categories.Remove(category);
            context.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Category deleted!");
            this.Response.Redirect("~/Admin/EditCategories.aspx");
        }

        protected void NoButton_Click(object sender, EventArgs e)
        {
            this.DeleteCategoryPanel.Visible = false;
        }

        #endregion


        public IQueryable<Category> GridViewCategories_GetData()
        {
            var context = new LibrarySystemEntities();
            return context.Categories;
        }
    }
}