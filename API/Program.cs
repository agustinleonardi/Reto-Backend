using System.Net.Mail;
using API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var users = new List<User>();
var nextId = 1;

bool IsValidEmail(string email)
{
    try
    {
        var addr = new MailAddress(email);
        return addr.Address == email;
    }
    catch (Exception)
    {
        return false;
    }
}
// Get /users - Listar usuarios
app.MapGet("/users", () => users)
.WithName("GetUsers")
.WithTags("Usuarios");

// POST /users - Crear usuario
app.MapPost("/users", (UserDto dto) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Email))
        return Results.BadRequest(new { message = "Nombre y email son requeridos" });

    if (!IsValidEmail(dto.Email))
        return Results.BadRequest(new { message = "Email inválido." });

    var user = new User(nextId++, dto.Name, dto.Email);
    users.Add(user);
    return Results.Created($"/users/{user.Id}", user);
})
.WithName("CreateUser")
.WithTags("Usuarios");

// DELETE /users/{id} - Eliminar usuario
app.MapDelete("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user == null)
        return Results.NotFound(new { message = "No existe un usuario con ese id" });

    users.Remove(user);
    return Results.NoContent();
})
.WithName("DeleteUser")
.WithTags("Usuarios");

app.Run();
