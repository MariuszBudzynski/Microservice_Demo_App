var builder = WebApplication.CreateBuilder(args);

// Load configuration for MongoDB support
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding custom validation configuration
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreatedItemDtoValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdatedItemDtoValidator));

//InMemoryServicesRegistration.RegisterServices(builder.Services);
ServicesRegistration.RegisterServices(builder.Services,configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//InMemoryRoutes.ConfigureInMemoryRoutes(app);
Routes.ConfigureRoutes(app);


app.Run();