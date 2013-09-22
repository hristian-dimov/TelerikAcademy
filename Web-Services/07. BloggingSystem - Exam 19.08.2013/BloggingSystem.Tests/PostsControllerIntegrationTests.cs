using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Collections.Generic;
using System.Web.Http;
using BloggingSystem.WebApi.Models;
using System.Net;
using Newtonsoft.Json;
using System.Linq;

namespace BloggingSystem.Tests
{
    [TestClass]
    public class PostsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "TagsApi",
                    "api/tags/{tagId}/posts",
                    new { controller = "tags", action = "posts" }),
                new Route(
                    "PostsApi",
                    "api/posts/{postId}/comment",
                    new { controller = "posts", action = "comment" }),
                new Route(
                    "UsersApi",
                    "api/users/{action}",
                    new { controller = "users" }),
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        #region Test CreatePost methods

        [TestMethod]
        public void CreatePost_WhenPostModelIsValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel() 
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(testNewPost.Title, postModel.Title);
            Assert.IsTrue(postModel.Id > 0);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void CreatePost_WhenUserDoesntExists_ShouldNotSaveToDatabase()
        {
            //Sendind wrong session key should trigger an exception which will return a BadRequest

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            string randomSessionKey = "dasdsadasdji2iejridsiadjwqijrjifji3jirjiifejiehu4rushurehuu";

            var response = httpServer.Post("api/posts?sessionKey=" + randomSessionKey, testNewPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsTrue(postModel.Id == 0);
        }

        [TestMethod]
        public void CreatePost_WhenTitleIsNotValid_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Text = "VALIDTEXT", // MISSING TITLE
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNull(postModel.Title);
        }

        [TestMethod]
        public void CreatePost_WhenTextIsNotValid_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE", // MISSING TEXT
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNull(postModel.Title);
        }

        #endregion

        #region Test GetPostsByTags methods

        [TestMethod]
        public void GetPostsByTags_WhenTagsAreValid()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            var testNewPost1 = new PostModel()
            {
                Title = "Some title",
                Text = "Some different Text",
                Tags = new string[] { "Yo", "Exam" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost1);

            var response = httpServer.Get("api/posts?tags=FIRST,SECOND&sessionKey=" + userModel.SessionKey);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(contentString);

            var currentPost = postModel.FirstOrDefault();

            var expectedPostsCount = 1;
            var expectedTags = 3;

            Assert.AreEqual(expectedPostsCount, postModel.Count());
            Assert.AreEqual(expectedTags, currentPost.Tags.Count());
        }

        [TestMethod]
        public void GetPostsByTags_WhenTagsAreNull()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            //sendind request with empty tags parameter
            var response = httpServer.Get("api/posts?tags=&sessionKey=" + userModel.SessionKey);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void GetPostsByTags_WhenTagsThatAreNotInDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            var response = httpServer.Get("api/posts?tags=RANDOMTAG&sessionKey=" + userModel.SessionKey);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(contentString);

            var expectedPostsCount = 0;

            Assert.AreEqual(expectedPostsCount, postModel.Count());
        }

        #endregion

        #region Test LeaveComment methods

        [TestMethod]
        public void LeaveComment_WhenCommentModelIsValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            var postResponse = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            var contentString = postResponse.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);

            var newComment = new CommentModel()
            {
                Text = "VALIDCOMMENTTEXT"
            };

            var response = httpServer.Put("api/posts/" + postModel.Id + "/comment?sessionKey=" + userModel.SessionKey,
                newComment);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void LeaveComment_WhenWrongSessionKey_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            var postResponse = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            var contentString = postResponse.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);

            var newComment = new CommentModel()
            {
                Text = "VALIDCOMMENTTEXT"
            };

            //Try to make a comment with wrong sessionKey
            string invalidSessionKey = "sdasdasdasddsaijdij2jiwjijei2jiedjisjidsa";

            var response = httpServer.Put("api/posts/" + postModel.Id + "/comment?sessionKey=" + invalidSessionKey,
                newComment);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void LeaveComment_WhenPostNotExists_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testNewPost = new PostModel()
            {
                Title = "VALIDTITLE",
                Text = "VALIDTEXT",
                Tags = new string[] { "FIRST", "SECOND" }
            };

            LoggedUserModel userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testNewPost);

            var newComment = new CommentModel()
            {
                Text = "VALIDCOMMENTTEXT"
            };

            int invalidPostId = 0;

            var response = httpServer.Put("api/posts/" + invalidPostId + "/comment?sessionKey=" + userModel.SessionKey,
                newComment);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion
    }
}
