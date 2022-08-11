var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IService, ServiceA>();
builder.Services.AddSingleton<IService, ServiceB>();

builder.Services.AddSingleton<ServiceA>();
builder.Services.AddSingleton<ServiceB>();

builder.Services.AddSwaggerGen();

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

public interface IService
{
    string DoSomething();
}

public class ServiceA : IService
{
    public string DoSomething() => "A";
}

public class ServiceB : IService
{
    public string DoSomething() => "B";
}