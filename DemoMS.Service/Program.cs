using DemoMS.Service;
using DemoMS.Service.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding custom validation configuration
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreatedItemDtoValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdatedItemDtoValidator));

//InMemoryServicesRegistration.RegisterServices(builder.Services);
ServicesRegistration.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//InMemoryRoutes.ConfigureInMemoryRoutes(app);
Routes.ConfigureRoutes(app);


app.Run();