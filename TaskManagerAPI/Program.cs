using TaskManagerAPI.Data;
using TaskManagerAPI.Services;
using TaskManagerAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<AIService>(_ => new AIService("your-api-key"));
builder.Services.AddSignalR();


var app = builder.Build();
app.MapHub<TaskHub>("/taskHub");
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskContext>();
    dbContext.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
