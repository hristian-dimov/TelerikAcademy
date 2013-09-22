using BloggingSystem.Data;
using BloggingSystem.Models;
using BloggingSystem.WebApi.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace BloggingSystem.WebApi.Controllers
{
    public class PostsController : BaseApiController
    {
        /*
        {
        "sessionKey": "1tFoygrQCdrfhlOSVZVDZngkwbHghnAjmYYKQyNRoGHPRiICDK"
        }
        */
        [HttpGet]
        public IQueryable<PostModel> GetAll(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BlogContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var postEntities = context.Posts;
                var models =
                    (from postEntity in postEntities
                     select new PostModel()
                     {
                         Id = postEntity.Id,
                         Title = postEntity.Title,
                         PostedBy = postEntity.PostedBy.DisplayName,
                         PostDate = postEntity.PostDate,
                         Text = postEntity.Text,
                         Tags = (from tagEntity in postEntity.Tags
                                 select tagEntity.Text),
                         Comments = (from commentEntity in postEntity.Comments
                                     select new CommentModel()
                                     {
                                         Text = commentEntity.Text,
                                         CommentedBy = commentEntity.CommentedBy.DisplayName,
                                         PostDate = commentEntity.PostDate
                                     })
                     });
                return models.OrderByDescending(p => p.PostDate);
            });

            return responseMsg;
        }

        public IQueryable<PostModel> GetByKeyword(string keyword, string sessionKey)
        {
            var models = this.GetAll(sessionKey).Where(p => p.Title.ToLower().Contains(keyword.ToLower()));
            return models;
        }

        public IQueryable<PostModel> GetByTags(string tags, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                if (tags == String.Empty || tags == null)
                {
                    throw new ArgumentNullException("You must enter at least one tag");
                }

                var models = this.GetAll(sessionKey);

                string[] allTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var tag in allTags)
                {
                    models = models.Where(t => t.Tags.Contains(tag));
                }

                return models;
            });

            return responseMsg;
        }

        public IQueryable<PostModel> GetPage(int page, int count, string sessionKey)
        {
            var models = this.GetAll(sessionKey).Skip(page * count).Take(count);
            return models;
        }

        [HttpPost]
        public HttpResponseMessage PostNewPost(PostModel model, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BlogContext();

                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                        if (user == null)
                        {
                            throw new InvalidOperationException("Users doesn't exists");
                        }

                        if (model.Title == null)
                        {
                            throw new InvalidOperationException("Title cannot be null");
                        }

                        if (model.Text == null)
                        {
                            throw new InvalidOperationException("Text cannot be null");
                        }

                        Post post = new Post();
                        post.Title = model.Title;
                        post.Text = model.Text;
                        post.PostDate = DateTime.Now;
                        post.PostedBy = user;

                        foreach (var tag in model.Tags)
                        {
                            Tag currentTag = CreateOrLoadTag(context, tag.ToLower());
                            post.Tags.Add(currentTag);
                        }

                        string[] titleTags = Regex.Split(model.Title, @"[,!\. ;?']+");

                        foreach (var titleTagName in titleTags)
                        {
                            Tag titleTag = CreateOrLoadTag(context, titleTagName.ToLower());
                            post.Tags.Add(titleTag);
                        }

                        context.Posts.Add(post);
                        context.SaveChanges();

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, new
                        {
                            Title = post.Title,
                            Id = post.Id
                        });

                        return response;
                    }
                });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage PutNewComment([FromUri] int postId, [FromUri] string sessionKey, [FromBody] CommentModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BlogContext();
                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                        if (user == null)
                        {
                            throw new InvalidOperationException("Users doesn't exists");
                        }

                        var post = context.Posts.FirstOrDefault(p => p.Id == postId);

                        if (post == null)
                        {
                            throw new InvalidOperationException("This post doesn't exists");
                        }

                        Comment newComment = new Comment();
                        newComment.Text = model.Text;
                        newComment.PostDate = DateTime.Now;
                        newComment.CommentedBy = user;
                        newComment.Post = post;

                        post.Comments.Add(newComment);
                        context.Comments.Add(newComment);

                        context.SaveChanges();

                        var response = this.Request.CreateResponse(HttpStatusCode.OK);

                        return response;
                    }
                });
            return responseMsg;
        }

        private static Tag CreateOrLoadTag(BlogContext context, string tagName)
        {
            Tag existingTag =
                (from t in context.Tags
                 where t.Text == tagName
                 select t).FirstOrDefault();

            if (existingTag != null)
            {
                return existingTag;
            }

            Tag newTag = new Tag();
            newTag.Text = tagName;
            context.Tags.Add(newTag);

            context.SaveChanges();

            return newTag;
        }
    }
}