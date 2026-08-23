using BlogPost_API.Data;
using Blogpost_DataAccess.Interface;
using Blogpost_DataAccess.Repositary;
using Blogpost_Service.Interface;
using Blogpost_Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<BlogPostDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

builder.Services.AddScoped<ICategories, CategoriesRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBlogpostRepo, BlogpostRepo>();
builder.Services.AddScoped<IBlogpostService, BlogpostService>();
builder.Services.AddScoped<IImageRepo, ImageRepository>();
builder.Services.AddScoped<IImageRepo, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});
//builder.Environment.ContentRootPath   
app.UseAuthorization();
app.MapControllers();
app.Run();