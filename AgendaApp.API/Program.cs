using AgendaApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerDoc();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddCorsConfig();

var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthorization();
app.UseCorsConfig();
app.MapControllers();

app.Run();
