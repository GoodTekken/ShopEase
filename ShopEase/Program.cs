using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ShopEase.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    var file = Path.Combine(AppContext.BaseDirectory, "ShopEase.xml");
    //true: 显示控制器层注释
    option.IncludeXmlComments(file, true);
    //对action的名称进行排序，如果有多个，就可以看到效果
    option.OrderActionsBy(o => o.RelativePath);
});

//完成数据库的注入，并且初始化
builder.Services.AddDbContext<ORMContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
