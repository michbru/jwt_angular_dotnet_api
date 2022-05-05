using DotNetJwtAuth.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace DotNetJwtAuth.Services
{
    public static class TokenService
    {
        private const double EXPIRE_HOURS = 1.0;
        //public static string CreateToken(User user)
        //{
        //    var key = Encoding.ASCII.GetBytes(Settings.Secret);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var descriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Username.ToString()),
        //            new Claim(ClaimTypes.Role, user.Role.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(descriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        public static string GetTokenFromAuthServer(User userParam)
        {

            string baseUrl = "https://app-dotnet5-jwt-token-service.azurewebsites.net";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue
        ("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            User userModel = new User();
            userModel.Username = userParam.Username;
            userModel.Password = userParam.Password;

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData,
        System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync
        ("/api/Auth/login", contentData).Result;
            string stringJWT = response.Content.
        ReadAsStringAsync().Result;
            var jwtUser = JsonConvert.DeserializeObject<AuthenticateResponse>(stringJWT);
            //  var user = new User();
            //   user.Username = jwtUser.Username;
            //   user.Password = model.Password;

            // authentication successful so generate jwt token
            //   var token = generateJwtToken(user);

            var token = jwtUser.Token;
          //  jwtUser.Token = token;

            // return new AuthenticateResponse(user, token);
            return token;




            //var key = Encoding.ASCII.GetBytes(Settings.Secret);
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var descriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Username.ToString()),
            //        new Claim(ClaimTypes.Role, user.Role.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(descriptor);
            //return tokenHandler.WriteToken(token);
        }
 
    }

}
