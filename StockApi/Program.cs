using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StockApi;
using StockApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DI
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();

// Automapper
builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);

// EntityFramework
builder.Services.AddDbContext<StockApiContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("10.3.29", Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb), opt =>
    {
        opt.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
    });
});

// CORS
builder.Services.AddCors(option =>
    option.AddDefaultPolicy(cfg => cfg.AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowAnyOrigin()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

