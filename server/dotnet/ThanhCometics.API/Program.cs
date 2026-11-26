using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThanhCometics.API;
using ThanhCometics.Repository;
using ThanhCometics.Repository.Models.Configurations;
using ThanhCometics.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddService().AddRepository().ConfigureAuthentication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// regiter db context after create entity
builder.Services.AddDbContext<ThanhCometicsDBContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//đọc section trong appsetting.json rồi gán vào class AuthenticationConfiguration
builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection("AuthenticationConfiguration"));


//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEnd", policy =>
    {
        policy.WithOrigins("https://localhost:5173", "http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic)
                    .ToArray();

builder.Services.AddAutoMapper(cfg => { }, assemblies);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontEnd");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
