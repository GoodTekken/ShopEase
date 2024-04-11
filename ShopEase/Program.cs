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
    //true: ��ʾ��������ע��
    option.IncludeXmlComments(file, true);
    //��action�����ƽ�����������ж�����Ϳ��Կ���Ч��
    option.OrderActionsBy(o => o.RelativePath);
});

//������ݿ��ע�룬���ҳ�ʼ��
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
