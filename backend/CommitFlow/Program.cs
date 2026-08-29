using CommitFlow.DAO;
using CommitFlow.Data;
using CommitFlow.Interfaces;
using CommitFlow.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register ASP.NET Core MVC controllers.
builder.Services.AddControllers();

// Register authentication services
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT Key is not configured.");

        var jwtIssuer = builder.Configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("JWT Issuer is not configured.");

        var jwtAudience = builder.Configuration["Jwt:Audience"]
            ?? throw new InvalidOperationException("JWT Audience is not configured.");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            ),

            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,

            ValidateAudience = true,
            ValidAudience = jwtAudience,

            ValidateLifetime = true,

            ClockSkew = TimeSpan.Zero
        };
    });

// Register DB context
builder.Services.AddDbContext<CommitFlowDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CommitFlowDatabase"));
});

// Register OpenAPI document generation.
builder.Services.AddOpenApi();

// Register the JWT token service.
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// Register the service Interface.
builder.Services.AddScoped<IUserService, UserService>();

// Register the DAO Interface.
builder.Services.AddScoped<IUserDAO, UserDAO>();

// Register CORS policy to allow requests from the frontend application.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowFrontend");

// Expose the OpenAPI document during development.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();