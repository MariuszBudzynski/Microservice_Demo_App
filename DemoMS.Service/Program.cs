var builder = WebApplication.CreateBuilder(args);

// Load configuration for MongoDB support
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

ServicesRegistration.RegisterServices(builder.Services,configuration,builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

Routes.ConfigureRoutes(app);


app.Run();