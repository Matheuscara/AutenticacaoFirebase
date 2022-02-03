using AutenticacaoFirebase.Models;
using AutenticacaoFirebase.Services;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using RestSharp;

namespace AutenticacaoFirebase.Controllers
{
    public class Autentication : ControllerBase
    {
        [HttpPost]
        [Route("Api")]
        public async Task<UserLogin> CreateBearerToken(string username, string password, bool returnSecureToken)
        {
            UserLoginBody body = new UserLoginBody();
            body.email = username;
            body.password = password;
            body.returnSecureToken = returnSecureToken;
            

            IGetToken api = RestEase.RestClient.For<IGetToken>("https://identitytoolkit.googleapis.com");
            UserLogin tokenResponse = await api.GetUserAsync(body);
            return tokenResponse;
        }
    }
}
