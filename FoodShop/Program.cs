using Microsoft.EntityFrameworkCore;
using RepositryPattern.Core.interfaces;
using RepositryPattern.EF.Data;
using RepositryPattern.EF.Repositries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(option =>

option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
b=>b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)
));
//builder.Services.AddTransient(typeof(IBaseRepositry<>),typeof(BaseRepositry<>));
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c => c.WithOrigins("http://localhost:4200")
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
