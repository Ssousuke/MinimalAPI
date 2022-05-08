using System.Globalization;
using Microsoft.EntityFrameworkCore;
using minimalAPI.Data;
using minimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", (AppDataContext app) =>
{
    var todos = app.todos.ToList();
    return Results.Ok(todos);
});

app.Run();