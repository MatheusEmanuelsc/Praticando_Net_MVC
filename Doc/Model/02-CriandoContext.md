# Configurando Entity Framework Core com SQL Server no .NET

## Introdução

Neste resumo, vamos configurar o **Entity Framework Core** para utilizar o **SQL Server** em um projeto .NET. As etapas incluem a instalação dos pacotes necessários, a criação do contexto do banco de dados, a configuração da string de conexão e a injeção de dependência no `Program.cs`.

---

## Índice

1. [Instalação dos pacotes](#etapa-1-instalação-dos-pacotes)
2. [Criação do Contexto do Banco de Dados](#etapa-2-criação-do-contexto-do-banco-de-dados)
3. [Definição da String de Conexão](#etapa-3-definição-da-string-de-conexão)
4. [Configuração do Program.cs](#etapa-4-configuração-do-programcs)
   - [Criação da Classe de Injeção de Dependência](#41-criação-da-classe-de-injeção-de-dependência)
   - [Ajuste do Program.cs](#42-ajuste-do-programcs)

---

## Etapa 1: Instalação dos Pacotes

Os seguintes pacotes do **Entity Framework Core** precisam ser instalados no projeto:

```sh
// Pacote do provider para SQL Server
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// Ferramentas do Entity Framework Core
dotnet add package Microsoft.EntityFrameworkCore.Tools

// Design para migrações e scaffolding
dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

## Etapa 2: Criação do Contexto do Banco de Dados

Crie uma pasta chamada `Context` (ou dentro da pasta `Models`, se preferir). Dentro dela, crie a classe `AppDbContext` que herdará de `DbContext`.

```csharp
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
```

Essa classe define as tabelas que serão mapeadas de acordo com os modelos da aplicação.

---

## Etapa 3: Definição da String de Conexão

Adicione a string de conexão no arquivo `appsettings.json`. Dependendo do sistema operacional, utilize uma das seguintes opções:

### Funciona em todos os SO:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LanchesDb;User Id=seuUsuario;Password=suaSenha;"
}
```

### Somente para Windows (com TrustServerCertificate habilitado para desenvolvimento):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LanchesDb;User Id=Usuario;Password=senha;TrustServerCertificate=True;"
}
```
> **Nota:** `TrustServerCertificate=True` **deve ser utilizado apenas em ambiente de desenvolvimento**.

---

## Etapa 4: Configuração do Program.cs

Para manter uma estrutura mais organizada e profissional, criaremos uma **classe de extensão** para a injeção de dependência.

### 4.1 Criação da Classe de Injeção de Dependência

Crie uma nova classe chamada `DependencyInjectionExtension.cs`:

```csharp
using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddAppDbContext(services, configuration);
    }

    private static void AddAppDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("A string de conexão 'DefaultConnection' está ausente ou vazia.");
        
        services.AddDbContext<AppDbContext>(config =>
            config.UseSqlServer(connectionString));
    }
}
```

### 4.2 Ajuste do `Program.cs`

Agora, registre a injeção de dependência chamando o método `AddInfrastructure` no `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configurar o banco de dados
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.Run();
```

Com essa configuração, o Entity Framework estará pronto para ser utilizado na aplicação.

---

## Conclusão

Este resumo abordou a configuração inicial do **Entity Framework Core** com **SQL Server** em um projeto .NET. Passamos pela instalação dos pacotes necessários, criação do contexto do banco de dados, definição da string de conexão e injeção de dependência no `Program.cs`. Com essas etapas concluídas, o próximo passo seria criar as **migrações** e aplicar ao banco de dados.

Essa estrutura modular facilita a manutenção e organização do código, garantindo boas práticas no desenvolvimento da aplicação.

