
var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServicesRegistration.RegisterServices(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

Routes.ConfigureRoutes(app);

app.Run();
