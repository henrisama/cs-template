using DotNetEnv;
using System.Text;
using CSTemplate.Auto;
using CSTemplate.Data;
using CSTemplate.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
int PORT = int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "3042");
string JWT_SECRET = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "ThisIsASecretKeyForJWT";

builder.WebHost.UseUrls($"http://*:{PORT}");

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAutoMapper(typeof(AutoMapping).Assembly);

// Repositories
builder.Services.AddScoped(typeof(IAutoRepository<,,>), typeof(AutoRepository<,,>));

// Services
builder.Services.AddScoped(typeof(IAutoService<,,>), typeof(AutoService<,,>));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_SECRET))
        };
    });

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc(
        "v1", new Microsoft.OpenApi.Models.OpenApiInfo
        { Title = "Template", Version = "v1" });

    swagger.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
