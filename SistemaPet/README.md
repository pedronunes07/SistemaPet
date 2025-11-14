# Sistema Pet - API Backend

API REST desenvolvida em ASP.NET Core para gerenciamento de pets e seus donos.

## Tecnologias Utilizadas

- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- Entity Framework Core In-Memory Database
- Swagger/OpenAPI

## Funcionalidades

### Pets
- Listar todos os pets
- Buscar pet por ID
- Cadastrar novo pet
- Atualizar pet existente
- Excluir pet

### Donos
- Listar todos os donos
- Buscar dono por ID
- Cadastrar novo dono
- Atualizar dono existente
- Excluir dono (remove também os pets associados)

### Vacinas
- Gerenciamento de vacinas dos pets (relacionado ao pet)

## Como Executar

1. Certifique-se de ter o .NET 8.0 SDK instalado
2. Navegue até a pasta do projeto
3. Execute o comando:

```bash
dotnet run
```

4. A API estará disponível em:
   - HTTPS: `https://localhost:7240`
   - HTTP: `http://localhost:5000`
   - Swagger UI: `https://localhost:7240/swagger`

## Endpoints da API

### Pets
- `GET /api/pet` - Lista todos os pets
- `GET /api/pet/{id}` - Busca pet por ID
- `POST /api/pet` - Cria novo pet
- `PUT /api/pet/{id}` - Atualiza pet
- `DELETE /api/pet/{id}` - Exclui pet

### Donos
- `GET /api/dono` - Lista todos os donos
- `GET /api/dono/{id}` - Busca dono por ID
- `POST /api/dono` - Cria novo dono
- `PUT /api/dono/{id}` - Atualiza dono
- `DELETE /api/dono/{id}` - Exclui dono e seus pets

## Estrutura do Projeto

```
SistemaPet/
├── Controllers/       # Controllers da API
│   ├── PetController.cs
│   └── DonoController.cs
├── Data/             # Contexto do Entity Framework
│   └── ApplicationDbContext.cs
├── Models/           # Modelos de dados
│   ├── Pet.cs
│   └── Dono.cs
├── Program.cs        # Configuração da aplicação
└── appsettings.json  # Configurações
```

## Banco de Dados

O projeto utiliza Entity Framework Core com banco de dados In-Memory para desenvolvimento. Os dados são perdidos quando a aplicação é reiniciada.

Para usar um banco de dados SQL Server, altere a configuração em `Program.cs`:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

E adicione a connection string em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SistemaPetDb;Trusted_Connection=True;"
  }
}
```

## CORS

A API está configurada para aceitar requisições do frontend Angular rodando em `http://localhost:4200`.

## Licença

Este projeto é open source e está disponível sob a licença MIT.

