using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Collections.Generic;
using System.Web.Http;
using BloggingSystem.WebApi.Models;
using System.Net;
using Newtonsoft.Json;

namespace BloggingSystem.Tests
{
    [TestClass]
    public class UsersControllerIntegrationTests
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

        #region Test register methods

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var model = RegisterUser.RegisterTestUser(httpServer, testUser);

            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            Assert.IsNotNull(model.SessionKey);
            Assert.IsTrue(model.SessionKey.Length == 50);
        }

        [TestMethod]
        public void Register_DuplicatedUsers_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var testUserDuplicate = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var model = RegisterUser.RegisterTestUser(httpServer, testUser);
            var modelDuplicate = RegisterUser.RegisterTestUser(httpServer, testUserDuplicate);

            Assert.IsNotNull(model.DisplayName);
            Assert.IsNotNull(model.SessionKey);

            Assert.IsNull(modelDuplicate.DisplayName); // should be null
            Assert.IsNull(modelDuplicate.SessionKey);
        }

        [TestMethod]
        public void Register_WithShortUsername_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "INV",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WithLongUsername_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "INVALIDUSERNAME_INVALIDUSERNAME_INVALIDUSERNAME_INVALIDUSERNAME",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WithNotAllowedUsernameChars_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "INVALID!@#$%",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WithShortDisplayName_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "INV",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WithLongDisplayName_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "INVALID_DISPLAYNAME_INVALID_DISPLAYNAME_INVALID_DISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WithNotAllowedDisplayNameChars_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "INVALID!@#$%",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenAuthCodeIsNot40Chars_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 30) // SHOULD BE 40 chars
            };

            var model = RegisterUser.RegisterTestUser(httpServer, testUser);

            Assert.IsNull(model.DisplayName);
            Assert.IsNull(model.SessionKey);
        }

        [TestMethod]
        public void Register_WithNull_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel();

            var model = RegisterUser.RegisterTestUser(httpServer, testUser);

            Assert.IsNull(model.DisplayName);
            Assert.IsNull(model.SessionKey);
        }

        #endregion

        #region Test logout methods

        [TestMethod]
        public void Logout_When_Valid_SessionKey()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var userModel = RegisterUser.RegisterTestUser(httpServer, testUser);

            var response = httpServer.Put("api/users/logout?sessionKey=" + userModel.SessionKey);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Logout_When_Invalid_SessionKey()
        {
            string invalidSessionKey = "urwHiooqHDIRWAFHUSghdcfszksdai0diaidsa0iads";
            var response = httpServer.Put("api/users/logout?sessionKey=" + invalidSessionKey);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Logout_When_Null_SessionKey()
        {
            var response = httpServer.Put("api/users/logout?sessionKey=");

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion
    }
}
