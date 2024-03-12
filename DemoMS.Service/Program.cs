var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/items", () =>
{
  // not implemented
});

app.MapGet("/items/{id}", (int id) =>
{
    // not implemented
});

app.MapPost("/items", () =>
{
    // not implemented
});

app.MapPut("/items{id}", (int id) =>
{
    // not implemented
});

app.MapDelete("/items{id}", (int id) =>
{
    // not implemented
});

app.Run();