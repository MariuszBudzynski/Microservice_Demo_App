using DemoMS.Service;
using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;
using DemoMS.Service.Repository.InMemory.UseCases.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
InMemoryServicesRegistration.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/items", (IInMemoryGetAllIUseCase<ItemDto> inMemoryGetAllIUseCase) =>
{
    //return Results.Ok(inMemoryGetAllIUseCase.Execute());
    return inMemoryGetAllIUseCase.Execute();
});

app.MapGet("/items/{id}", (Guid id,IInMemoryGetDataByIDUseCase<ItemDto> inMemoryGetDataByIDUseCase) =>
{
    return inMemoryGetDataByIDUseCase.Execute(id);
});

app.MapPost("/items", (ItemDto item,IInMemoryAddDataUseCase<ItemDto> inMemoryAddDataUseCase) =>
{
    inMemoryAddDataUseCase.Execute(item);
});

app.MapPut("/items{id}", (ItemDto data,IInMemoryUpdateDataUseCase<ItemDto> inMemoryUpdateDataUseCase) =>
{
    inMemoryUpdateDataUseCase.Execute(data);
});

app.MapDelete("/items{id}", (Guid id,IInMemoryDeleteDataUseCase<ItemDto> inMemoryDeleteDataUseCase) =>
{
    return inMemoryDeleteDataUseCase.Execute(id);
});

app.Run();