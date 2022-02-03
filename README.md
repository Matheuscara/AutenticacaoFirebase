# AutenticacaoFirebase
Repositório de teste para realizar uma autenticação junto com o serviço do FireBase

#Principais pontos de atenção:

startup.cs - (No caso do .NET 6.0 como parou de existir, implementar no Program.cs) 
```
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
    {
        //Validation
        options.Authority = "https://securetoken.google.com/{ProjetoFireBase}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Params Validation
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/{ProjetoFireBase}",
            ValidateAudience = true,
            ValidAudience = "{ProjetoFireBase}",
            //Validation Life Time
            ValidateLifetime = true
        };
    }
);

//Mais abaixo usar o UseAuthorization do .NET
app.UseAuthorization();

```
Models:

```
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
```

Service - (RestEasy):

```
    public interface IGetToken
    {
        [Post("/v1/accounts:signInWithPassword?key={projectFireBaseCode}")]
        Task<UserLogin> GetUserAsync([Body] UserLoginBody UserLoginBody);
    }
```

Controller - (Task):

```
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
```
