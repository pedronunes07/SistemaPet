# Sistema Pet - Gerenciamento Completo

Sistema completo de gerenciamento de pets desenvolvido com Angular (Frontend) e ASP.NET Core (Backend API).

## 📁 Estrutura do Projeto

```
pet-6/
├── SistemaPet/          # Backend API (ASP.NET Core)
│   ├── Controllers/     # API Controllers
│   ├── Data/           # Entity Framework Context
│   ├── Models/         # Modelos de dados (Pet, Dono, Vacina)
│   └── Program.cs      # Configuração da aplicação
└── sistema-pet/        # Frontend (Angular)
    └── src/
        └── app/
            ├── model/   # Modelos TypeScript
            ├── service/ # Serviços HTTP
            └── pet/     # Componentes
```

## 🚀 Tecnologias

### Backend
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- Entity Framework Core In-Memory Database
- Swagger/OpenAPI

### Frontend
- Angular 20.3
- TypeScript
- RxJS
- Angular Signals

## 📋 Funcionalidades

### Pets
- ✅ Listar todos os pets
- ✅ Visualizar detalhes do pet
- ✅ Cadastrar novo pet
- ✅ Editar pet existente
- ✅ Excluir pet
- ✅ Gerenciar vacinas do pet
- ✅ Upload de fotos

### Donos
- ✅ Listar todos os donos
- ✅ Cadastrar novo dono
- ✅ Editar dono existente
- ✅ Excluir dono (remove também os pets associados)
- ✅ Informações de contato e endereço

### Dashboard
- ✅ Visualização geral de pets e donos
- ✅ Navegação rápida entre funcionalidades

## 🛠️ Como Executar

### Pré-requisitos
- .NET 8.0 SDK
- Node.js e npm
- Angular CLI (`npm install -g @angular/cli`)

### Backend (API)

1. Navegue até a pasta do backend:
```bash
cd SistemaPet
```

2. Restaure as dependências e execute:
```bash
dotnet restore
dotnet run
```

3. A API estará disponível em:
   - HTTPS: `https://localhost:7240`
   - HTTP: `http://localhost:5000`
   - Swagger UI: `https://localhost:7240/swagger`

### Frontend (Angular)

1. Navegue até a pasta do frontend:
```bash
cd sistema-pet
```

2. Instale as dependências:
```bash
npm install
```

3. Execute o servidor de desenvolvimento:
```bash
ng serve
```

4. Acesse no navegador: `http://localhost:4200`

## 📡 Endpoints da API

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

## 🗄️ Banco de Dados

O projeto utiliza Entity Framework Core com banco de dados In-Memory para desenvolvimento. Os dados são perdidos quando a aplicação é reiniciada.

Para usar um banco de dados SQL Server em produção, altere a configuração em `SistemaPet/Program.cs`:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

## 🔧 Configuração

### CORS
A API está configurada para aceitar requisições do frontend Angular rodando em `http://localhost:4200`.

### URLs da API
O frontend está configurado para se conectar à API em `https://localhost:7240`. Certifique-se de que o backend esteja rodando antes de iniciar o frontend.

## 📝 Modelos de Dados

### Pet
- Nome, Espécie, Raça
- Idade, Peso, Cor, Sexo
- Status de vacinação
- Lista de vacinas
- Observações gerais e médicas
- Fotos
- Relacionamento com Dono

### Dono
- Nome completo, Email, Telefone
- Endereço completo (Cidade, Estado, CEP)
- Contato de emergência
- Observações
- Lista de Pets

### Vacina
- Nome da vacina
- Data de aplicação
- Próxima dose
- Nome do veterinário
- Relacionamento com Pet

## 📚 Documentação Adicional

- [Backend README](SistemaPet/README.md)
- [Frontend README](sistema-pet/README.md)

## 🤝 Contribuindo

Este projeto foi desenvolvido como uma adaptação do [SistemaEstudantes](https://github.com/rodrigoximenes/SistemaEstudantes) para gerenciamento de pets.

## 📄 Licença

Este projeto é open source e está disponível sob a licença MIT.

