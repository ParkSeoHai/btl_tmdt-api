using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Repositories.Interface;
using WebAPI.Repositories.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repositories
builder.Services.AddScoped<IUserRepository, UserSevice>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<IShopAddressRepository, ShopAddressService>();
builder.Services.AddScoped<ICartRepository, CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
