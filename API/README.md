# Reto-Backend

API REST para la gestión de usuarios. Permite listar, crear y eliminar usuarios, con validación de email y almacenamiento en memoria. Incluye Swagger para pruebas desde el navegador.

## Tecnologías utilizadas

- .NET 8
- Minimal API
- Swagger (OpenAPI)

## Instalación

1. Clona el repositorio:
   ```sh
   git clone https://github.com/agustinleonardi/Reto-Backend.git
   ```
2. Ve a la carpeta del proyecto:
   ```sh
   cd Reto-Backend/API
   ```
3. Ejecuta la API:
   ```sh
   dotnet run
   ```

## Uso

### Probar desde el navegador

Accede a la documentación interactiva y prueba los endpoints en:

```
http://localhost:5000/swagger
```

(Reemplaza el puerto si es diferente en tu consola)

### Endpoints

#### Listar usuarios

- **GET** `/users`
- Respuesta: lista de usuarios en JSON.

#### Crear usuario

- **POST** `/users`
- Body (JSON):
  ```json
  {
    "name": "Juan",
    "email": "juan@email.com"
  }
  ```
- Respuesta: usuario creado.

#### Eliminar usuario

- **DELETE** `/users/{id}`
- Respuesta: 204 No Content si se elimina, 404 si no existe.

### Ejemplos con curl

Listar usuarios:

```sh
curl http://localhost:5000/users
```

Crear usuario:

```sh
curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"name":"Juan","email":"juan@email.com"}'
```

Eliminar usuario:

```sh
curl -X DELETE http://localhost:5000/users/1
```

## Decisiones técnicas

- Se utiliza Minimal API por su simplicidad y claridad.
- El modelo `User` tiene setter privado en `Id` para evitar modificaciones externas.
- El DTO `UserDto` se implementa como `record` para inmutabilidad y comparación por valor.
- La validación de email se realiza con `System.Net.Mail.MailAddress`.

## Pruebas

Puedes probar todos los endpoints desde Swagger sin necesidad de Postman.

## Autor

Agustín Leonardi

## Mejoras y escalabilidad

Si el proyecto creciera o requiriera mayor mantenibilidad, se recomienda aplicar una arquitectura basada en Clean Architecture, que separa responsabilidades en capas bien definidas:

- **Capa de Presentación (Controllers/API):** Expone los endpoints HTTP y gestiona las peticiones externas.
- **Capa de Aplicación (Use Cases/Services):** Contiene la lógica de negocio y los casos de uso de la aplicación.
- **Capa de Dominio (Entities/Models):** Define las entidades centrales y las reglas de negocio independientes de frameworks.
- **Capa de Infraestructura (Repositories/Data):** Gestiona el acceso a los datos, integración con bases de datos, servicios externos, etc.

Esta arquitectura facilita el mantenimiento, la escalabilidad, las pruebas y la independencia tecnológica. En este reto se utiliza Minimal API y lógica en memoria por simplicidad, pero Clean Architecture es ideal para proyectos más grandes y profesionales.
