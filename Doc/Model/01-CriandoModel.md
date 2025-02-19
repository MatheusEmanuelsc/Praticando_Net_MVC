# Code First no Entity Framework Core

## Introdução

O **Code First** é uma abordagem do Entity Framework Core onde primeiro definimos os modelos de dados (classes C#) e, a partir deles, geramos o banco de dados. Essa abordagem é ideal para projetos onde o banco de dados ainda não está definido ou quando desejamos manter a estrutura de dados centralizada no código.

Neste resumo, utilizaremos um exemplo prático com duas entidades relacionadas: **Categoria** e **Lanche**.

## Definição dos Modelos

### Categoria

```csharp
namespace LanchesMac.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    // Propriedade de navegação
    public List<Lanche> Lanches { get; set; } = []; // Boa prática: inicialização da lista
}
```

A entidade **Categoria** possui:
- `CategoriaId`: Chave primária.
- `Nome`: Nome da categoria.
- `Descricao`: Descrição da categoria.
- `Lanches`: Lista de lanches associados a esta categoria (propriedade de navegação).

> **Observação:** É uma boa prática instanciar a lista `Lanches` para evitar exceções de referência nula ao acessá-la antes de ser populada.

### Lanche

```csharp
namespace LanchesMac.Models;

public class Lanche
{
    public int LanchesId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string DescricaoCurta { get; set; } = string.Empty;
    public string DescricaoDetalhada { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;
    public string ImagemThumbnailUrl { get; set; } = string.Empty;
    public bool IsLachePrefeirodo { get; set; }
    public bool EmEstoque { get; set; }
    
    // Chave estrangeira
    public int CategoriaId { get; set; }
    
    // Propriedade de navegação
    public virtual Categoria Categoria { get; set; }
}
```

A entidade **Lanche** possui:
- `LanchesId`: Chave primária.
- `Nome`, `DescricaoCurta`, `DescricaoDetalhada`: Informações do lanche.
- `Preco`: Preço do lanche.
- `ImagemUrl`, `ImagemThumbnailUrl`: URLs para as imagens do lanche.
- `IsLachePrefeirodo`: Indica se é um lanche preferido.
- `EmEstoque`: Indica se o lanche está disponível.
- `CategoriaId`: Chave estrangeira para **Categoria**.
- `Categoria`: Propriedade de navegação.

## Relacionamento entre as Entidades

O relacionamento entre **Categoria** e **Lanche** é de **um para muitos**, onde:
- Uma **Categoria** pode ter vários **Lanches**.
- Cada **Lanche** pertence a apenas uma **Categoria**.

O Entity Framework Core reconhecerá automaticamente esse relacionamento com base na propriedade de navegação `public virtual Categoria Categoria { get; set; }` e na chave estrangeira `public int CategoriaId { get; set; }`.

## Conclusão

Com essa estrutura, podemos utilizar o **EF Core Migrations** para gerar o banco de dados automaticamente a partir dos modelos criados. Essa abordagem **facilita a manutenção do código**, pois qualquer alteração nos modelos pode ser refletida no banco através de migrações.

Nos próximos passos, podemos configurar o **DbContext**, criar o banco de dados e popular as tabelas com dados iniciais.

