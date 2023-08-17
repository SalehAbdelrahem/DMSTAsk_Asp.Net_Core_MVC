using BLL.Services;
using DAL.Contacts.Categories;
using DAL.Contacts.CustomFieldDatas;
using DAL.Contacts.CustomFields;
using DAL.Contacts.Products;
using DAL.Data;
using DAL.Repositories.Categories;
using DAL.Repositories.CustomFieldDatas;
using DAL.Repositories.CustomFields;
using DAL.Repositories.Products;
using DMSTaskMVC.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(options =>
{
    //options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnectionstring"));

});
// Add services to the container.
builder.Services.AddControllersWithViews();

//object Add scope
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomFieldRepository, CustomFieldRepository>();
builder.Services.AddScoped<ICustomFieldDataRepository, CustomFieldDataRepository>();

builder.Services.AddScoped<ServiceCategory>();


//congiguration AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
