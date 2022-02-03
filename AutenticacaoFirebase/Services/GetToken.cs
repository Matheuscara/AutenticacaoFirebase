using AutenticacaoFirebase.Models;
using RestEase;


namespace AutenticacaoFirebase.Services
{
    public interface IGetToken
    {
        [Post("/v1/accounts:signInWithPassword?key=AIzaSyDyNsVLeo4mLbxww_y-WUKVBbsKttKAeL0")]
        Task<UserLogin> GetUserAsync([Body] UserLoginBody UserLoginBody);
    }
}
