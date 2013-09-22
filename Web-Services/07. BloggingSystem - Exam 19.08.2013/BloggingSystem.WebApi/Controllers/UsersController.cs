using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystem.Data;
using System.Text;
using BloggingSystem.WebApi.Models;
using BloggingSystem.Models;

namespace BloggingSystem.WebApi.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";

        private const int MinDisplayNameLength = 6;
        private const int MaxDisplayNameLength = 30;
        private const string ValidDisplayNameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        /*
            {  
                "username": "DonchoMinkov",
                "displayName": "Doncho Minkov",
                "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" 
            }

        */

        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BlogContext();
                    using (context)
                    {

                        this.ValidateUsername(model.Username);
                        this.ValidateDisplayName(model.DisplayName);
                        this.ValidateAuthCode(model.AuthCode);

                        var usernameToLower = model.Username.ToLower();
                        var displayNameToLower = model.DisplayName.ToLower();

                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username == usernameToLower
                            || usr.DisplayName.ToLower() == displayNameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("Users exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            DisplayName = model.DisplayName,
                            AuthCode = model.AuthCode,
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        string generateSessionKey = this.GenerateSessionKey(user.Id);
                        user.SessionKey = generateSessionKey;
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = model.DisplayName,
                            SessionKey = generateSessionKey
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);

                        return response;
                    }
                });
            return responseMsg;
        }

        /*
            {
                "username": "DonchoMinkov",
                "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" 
            }
        */

        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BlogContext();
                    using (context)
                    {

                        this.ValidateUsername(model.Username);
                        this.ValidateAuthCode(model.AuthCode);

                        var usernameToLower = model.Username.ToLower();

                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username == usernameToLower
                            && usr.AuthCode == model.AuthCode);

                        if (user == null)
                        {
                            throw new InvalidOperationException("Users doesn't exists");
                        }

                        string generateSessionKey = this.GenerateSessionKey(user.Id);
                        user.SessionKey = generateSessionKey;
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = user.DisplayName,
                            SessionKey = generateSessionKey
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);

                        return response;
                    }
                });
            return responseMsg;
        }

        /*
            {
                "sessionKey": "1ABuMmFMgTnFrnFWjRihbChLJjqhZMXwfjfWNRNNDKNjungZsk"
            }
        */

        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(string sessionKey)
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

                        user.SessionKey = null;
                        context.SaveChanges();

                        var response = this.Request.CreateResponse(HttpStatusCode.OK);

                        return response;
                    }
                });
            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);

            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }

            return skeyBuilder.ToString();
        }

        private void ValidateDisplayName(string displayName)
        {
            if (displayName == null)
            {
                throw new ArgumentNullException("DisplayName cannot be null");
            }
            else if (displayName.Length < MinDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("DisplayName must be at least {0} characters long",
                        MinDisplayNameLength));
            }
            else if (displayName.Length > MaxDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("DisplayName must be less than {0} characters long",
                        MaxDisplayNameLength));
            }
            else if (displayName.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "DisplayName must contain only Latin letters, digits .,_ -");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                        MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                        MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }
    }
}
