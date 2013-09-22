using BloggingSystem.WebApi.Models;
using Newtonsoft.Json;
using System;
namespace BloggingSystem.Tests
{
    static class RegisterUser
    {
        public static LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            return userModel;
        }
    }
}
