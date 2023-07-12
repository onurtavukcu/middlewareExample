using MiddlawareExample.MiddleWare;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

// app.UseMiddleware<TimingMiddleWare>();  //sadece invoke methodu varsa.

app.UseTiming(); //extension ile de bu şekilde kullanılabilir. static useTiming extension varsa.

//app.Use(async (ctx, next) =>
//{
//    var start = DateTime.UtcNow;
//    await next.Invoke(ctx); //pass the context
//    app.Logger.LogInformation($"Duration:{(DateTime.UtcNow - start).TotalMilliseconds}");  // Haricen bir class olarak eklenmezse bu şekilde kullanılabilir.
//});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
                                                                                                                                    