using DespesasParlamentares.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = long.MaxValue;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDocumentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();