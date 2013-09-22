using BloggingSystem.Data;
using BloggingSystem.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloggingSystem.WebApi.Controllers
{
    public class TagsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<TagModel> GetAll(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BlogContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var tagEntities = context.Tags;
                var models =
                    (from tagEntity in tagEntities
                     select new TagModel()
                     {
                         Id = tagEntity.Id,
                         Name = tagEntity.Text,
                         Posts = tagEntity.Posts.Count
                     });
                return models.OrderBy(t => t.Name);
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<PostModel> GetAllPostsByTagId([FromUri]int tagId, [FromUri]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BlogContext();

                var tag = context.Tags.FirstOrDefault(t => t.Id == tagId);
                if (tag == null)
                {
                    throw new InvalidOperationException("This tag doesn't exists.");
                }

                PostsController postsController = new PostsController();
                var posts = postsController.GetByTags(tag.Text, sessionKey);

                return posts.OrderByDescending(p => p.PostDate);
            });

            return responseMsg;
        }
    }
}
