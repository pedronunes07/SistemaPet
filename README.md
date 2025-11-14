# Sistema Pet - Gerenciamento Completo

Sistema completo de gerenciamento de pets desenvolvido com ASP.NET Core Web API seguindo arquitetura em camadas.

## 📁 Estrutura do Projeto

```
SistemaPet/
├── SistemaPet.Dominio/          # Camada de Domínio
│   ├── Pet.cs                   # Modelo de Pet
│   ├── Dono.cs                  # Modelo de Dono
│   └── Vacina.cs                # Modelo de Vacina
├── SistemaPet.Repositorio/       # Camada de Repositório
│   ├── IPetRepositorio.cs
│   ├── PetRepositorio.cs
│   ├── IDonoRepositorio.cs
│   ├── DonoRepositorio.cs
│   └── PetDbContext.cs          # Contexto do Entity Framework
├── SistemaPet.Servico/           # Camada de Serviço (Lógica de Negócio)
│   ├── IPetServico.cs
│   ├── PetServico.cs
│   ├── IDonoServico.cs
│   └── DonoServico.cs
└── SistemaPet.WebAPI/            # Camada de Apresentação (API)
    ├── Controllers/
    │   ├── PetController.cs
    │   └── DonoController.cs
    └── Program.cs
```

## 🚀 Tecnologias

* .NET 8.0
* ASP.NET Core Web API
* Entity Framework Core
* Entity Framework Core In-Memory Database
* Swagger/OpenAPI

## 📋 Funcionalidades

### Pets

* ✅ Listar todos os pets
* ✅ Visualizar detalhes do pet
* ✅ Cadastrar novo pet
* ✅ Editar pet existente
* ✅ Excluir pet
* ✅ Gerenciar vacinas do pet

### Donos

* ✅ Listar todos os donos
* ✅ Cadastrar novo dono
* ✅ Editar dono existente
* ✅ Excluir dono (remove também os pets associados)
* ✅ Informações de contato e endereço

## 🛠️ Como Executar

### Pré-requisitos

* .NET 8.0 SDK

### Executar a API

1. Navegue até a pasta do projeto:

```bash
cd SistemaPet
```

2. Restaure as dependências e execute:

```bash
dotnet restore
dotnet run --project SistemaPet.WebAPI
```

3. A API estará disponível em:  
   * HTTPS: `https://localhost:7240`  
   * HTTP: `http://localhost:5281`  
   * Swagger UI: `https://localhost:7240/swagger`

## 📡 Endpoints da API

### Pets

* `GET /api/pet` - Lista todos os pets
* `GET /api/pet/{id}` - Busca pet por ID
* `POST /api/pet` - Cria novo pet
* `PUT /api/pet/{id}` - Atualiza pet
* `DELETE /api/pet/{id}` - Exclui pet

### Donos

* `GET /api/dono` - Lista todos os donos
* `GET /api/dono/{id}` - Busca dono por ID
* `POST /api/dono` - Cria novo dono
* `PUT /api/dono/{id}` - Atualiza dono
* `DELETE /api/dono/{id}` - Exclui dono e seus pets

## 🗄️ Banco de Dados

O projeto utiliza Entity Framework Core com banco de dados In-Memory para desenvolvimento. Os dados são perdidos quando a aplicação é reiniciada.

Para usar um banco de dados SQL Server em produção, altere a configuração em `SistemaPet.WebAPI/Program.cs`:

```csharp
builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

## 🔧 Configuração

### CORS

A API está configurada para aceitar requisições do frontend Angular rodando em `http://localhost:4200`.

## 📝 Modelos de Dados

### Pet

* Nome, Espécie, Raça
* Idade, Peso, Cor, Sexo
* Status de vacinação
* Lista de vacinas
* Observações gerais e médicas
* Foto
* Relacionamento com Dono

### Dono

* Nome completo, Email, Telefone
* Endereço completo (Cidade, Estado, CEP)
* Contato de emergência
* Observações
* Lista de Pets

### Vacina

* Nome da vacina
* Data de aplicação
* Próxima dose
* Nome do veterinário
* Relacionamento com Pet

## 📚 Arquitetura

O projeto segue uma arquitetura em camadas:

1. **Dominio**: Contém as entidades do domínio (Pet, Dono, Vacina)
2. **Repositorio**: Responsável pelo acesso a dados usando Entity Framework
3. **Servico**: Contém a lógica de negócio e validações
4. **WebAPI**: Camada de apresentação com controllers REST

## 🤝 Contribuindo

Este projeto foi desenvolvido como uma adaptação do SistemaEstudantes para gerenciamento de pets.

## 📄 Licença

Este projeto é open source e está disponível sob a licença MIT.
