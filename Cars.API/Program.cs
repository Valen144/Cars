using Cars.API.Extensions;
using Cars.API.Middlewares;
using Cars.BLL.Interfaces;
using Cars.BLL.Services;
using Cars.DAL.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddDbContext<CarsContext>((prov,options)
    => options.UseSqlServer(builder.Configuration["DefaultConnection"]));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var context = provider.GetRequiredService<CarsContext>();
    context.Initialize();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();