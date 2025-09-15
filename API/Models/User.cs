
namespace API.Models;
/// <summary>
/// Representa un usuario en la API
/// </summary>
public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}
