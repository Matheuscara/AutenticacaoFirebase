namespace AutenticacaoFirebase.Models
{
    public class UserLogin
    {
        public string idToken { get; set; }
        public string email { get; set; }
        public string refreshToken { get; set; }
    }

    public class UserLoginBody
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; }
    }
}
