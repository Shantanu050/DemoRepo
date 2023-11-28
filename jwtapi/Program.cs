using jwtapi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(
    options=>
    {
        options.AddDefaultPolicy(
        builder=>{
            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppdContext>(options=>{options.UseSqlServer(builder.Configuration.GetConnectionString("mycon"));
});
builder.Services.AddAuthentication(x=>{
    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x=>{

    x.RequireHttpsMetadata=false;
    x.SaveToken=true;
    x.TokenValidationParameters=new TokenValidationParameters{
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ltimindtree...")),
        ValidateAudience=false,
        ValidateIssuer=false,
        ClockSkew=TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
