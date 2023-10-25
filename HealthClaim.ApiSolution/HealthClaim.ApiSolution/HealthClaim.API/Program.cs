using HealthClaim.API.Extensions;
using HealthClaim.DAL;
using HealthClaim.Logger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

var config = builder.Configuration;

//builder.Services.AddAppliationServices(config);
builder.Services.AddDbContext<HealthClaimDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentityServices(config);
builder.Services.AddAppliationServices(config);


var app = builder.Build();


app.UseMiddleware<ExeceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
