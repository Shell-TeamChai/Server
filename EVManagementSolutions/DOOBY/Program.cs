using DOOBY.Models;
using DOOBY.Services.Interfaces;
using DOOBY.Services.ServiceClasses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CaseStudyContext>(
    optionsAction: options => options.UseNpgsql(
        builder.Configuration.GetConnectionString(
            "PostgreSQLConnectionString")
        )
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        // Configure JWT authentication options here
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JwtSettings: Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings: Token_Key"] 
                ?? "$#$##$@#$#@$FDFDSFSAFSDFSADFDSFSAFAFDFS")),
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole(Roles.Admin));

    options.AddPolicy("UserPolicy", policy =>
        policy.RequireRole(Roles.Customer));
});

builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IToken, TokenService>();
builder.Services.AddScoped<IAdmin, AdminService>();
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<IFeedback, FeedbackService>();
builder.Services.AddScoped<IGrievance, GrievanceService>();
builder.Services.AddScoped<IStationInfo, StationInfoService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
