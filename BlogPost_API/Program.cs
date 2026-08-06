using BlogPost_API.Data;
using Blogpost_DataAccess.Interface;
using Blogpost_DataAccess.Repositary;
using Blogpost_Service.Interface;
using Blogpost_Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//-------------------------ADD CORS POLICY---------------------------------------

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});

//Add DbContext
builder.Services.AddDbContext<BlogPostDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

//Add DI
builder.Services.AddScoped<ICategories, CategoriesRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");


app.UseAuthorization();

app.MapControllers();

app.Run();
