using Microsoft.EntityFrameworkCore;
using PortifolioMalostiApi.Data;
using PortifolioMalostiApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<PorifolioContext>(builder.Configuration.GetConnectionString("ServerConnection"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(p => p
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());

app.MapPost("/contacts", async (PorifolioContext context, Contact contact) => 
{
    contact.Date = DateTime.UtcNow;
    await context.AddAsync(contact);
    await context.SaveChangesAsync();

    return Results.Ok(contact);
})
.WithOpenApi();

app.MapGet("/contacts", async (PorifolioContext context) =>
{
    var contacts = await context.Contacts.AsNoTracking().ToListAsync();
    return Results.Ok(contacts);
});

app.Run();


