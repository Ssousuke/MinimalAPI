using minimalAPI.Data;
using minimalAPI.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", (AppDataContext app) =>
{
    var todos = app.Todos.ToList();
    return Results.Ok(todos);
});


app.MapPost("/", (AppDataContext context, CreateTodoViewModels models) =>
{
    var todo = models.MapTo();
    if (!models.IsValid)
        return Results.BadRequest(models.Notifications);
    context.Todos.Add(todo);
    context.SaveChanges();

    return Results.Created($"/{todo.Id}", todo);
});
app.Run();