using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
    {
        //Validation
        options.Authority = "https://securetoken.google.com/netcorefirebaseatt";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Params Validation
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/netcorefirebaseatt",
            ValidateAudience = true,
            ValidAudience = "netcorefirebaseatt",
            //Validation Life Time
            ValidateLifetime = true
        };
    }
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
