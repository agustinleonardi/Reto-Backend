/// <summary>
/// DTO para la creacion de usuarios en la API
/// </summary>
/// <param name="Name"> Nombre del usuario</param>
/// <param name="Email"> Email del usuario</param>
public record UserDto(string Name, string Email);

// TODO: Validar si el email ya existe antes de crear un nuevo usuario
bool pruebaDuplicado = true; 
