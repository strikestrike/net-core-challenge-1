using FixWithCustomSerialization.Models;
using FixWithCustomSerialization.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MediaStoreDatabaseSettings>(
    builder.Configuration.GetSection("MediaStoreDatabase"));

builder.Services.AddSingleton<IDbService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

