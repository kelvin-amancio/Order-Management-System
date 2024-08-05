using NLog.Web;
using OrderManagement.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureJwtSwagger();

builder.Services.AddHttpClient("MapsApi", c => 
{
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("MapsApi")!);
});

builder.Services.AddLogging(lb =>
{
    lb.ClearProviders();
    lb.AddNLogWeb();
});

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerenciamento de Pedidos"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
