# ASP.NET MVC e Razor - Guia Completo

## Índice
- [Introdução ao Razor](#introducao-ao-razor)
- [Sintaxe do Razor](#sintaxe-do-razor)
  - [Exibir Variáveis](#exibir-variaveis)
  - [Condicionais e Laços](#condicionais-e-lacos)
  - [Laço Foreach com Model](#laco-foreach-com-model)
- [Uso de Modelos (Models) e Views](#uso-de-modelos-models-e-views)
  - [Criando um Modelo](#criando-um-modelo)
  - [Passando um Modelo para a View](#passando-um-modelo-para-a-view)
- [Helpers HTML e Tag Helpers](#helpers-html-e-tag-helpers)
  - [HTML Helpers](#html-helpers)
  - [Tag Helpers](#tag-helpers)
- [Layouts e Views Parciais](#layouts-e-views-parciais)
  - [Criando um Layout](#criando-um-layout)
  - [Views Parciais](#views-parciais)
- [Manipulação de Dados e Exibição](#manipulacao-de-dados-e-exibicao)
  - [Formulários e Binding](#formularios-e-binding)
- [Boas Práticas e Considerações](#boas-praticas-e-consideracoes)

## Introdução ao Razor
Razor é a engine de visualização utilizada no ASP.NET MVC para renderizar HTML de maneira dinâmica. Ele permite a combinação de C# e HTML dentro de arquivos `.cshtml`, tornando a renderização de páginas mais fluida e integrada com os modelos de dados.

### Características do Razor:
- Simples e limpo, baseado em C#
- Melhor performance em relação a outras engines de template
- Facilmente integrável com modelos e controladores

## Sintaxe do Razor
O Razor utiliza o `@` para indicar código C# embutido dentro do HTML. Algumas das principais funcionalidades incluem:

### Exibir Variáveis
```razor
@{
    var nome = "João";
}
<p>Nome: @nome</p>
```

### Condicionais e Laços
```razor
@if (DateTime.Now.Hour < 12)
{
    <p>Bom dia!</p>
}
else
{
    <p>Boa tarde!</p>
}
```

```razor
@for (int i = 1; i <= 5; i++)
{
    <p>Item @i</p>
}
```

### Laço Foreach com Model
```razor
@model List<string>
<ul>
    @foreach (var item in Model)
    {
        <li>@item</li>
    }
</ul>
```

## Uso de Modelos (Models) e Views

No ASP.NET MVC, os modelos representam os dados que serão exibidos nas views.

### Criando um Modelo
```csharp
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
```

### Passando um Modelo para a View
No controlador:
```csharp
public IActionResult Detalhes()
{
    var produto = new Produto { Id = 1, Nome = "Notebook", Preco = 3500M };
    return View(produto);
}
```

Na View `Detalhes.cshtml`:
```razor
@model Produto

<h2>@Model.Nome</h2>
<p>Preço: @Model.Preco.ToString("C")</p>
```

## Helpers HTML e Tag Helpers

### HTML Helpers
São métodos C# que ajudam a gerar HTML dinâmico.
```razor
@Html.TextBox("Nome", "Digite seu nome")
@Html.DropDownList("Categorias", new SelectList(new[] {"Eletrônicos", "Roupas"}))
```

### Tag Helpers
Alternativa moderna aos HTML Helpers.
```razor
<input asp-for="Nome" class="form-control" />
<select asp-items="@ViewBag.Categorias" class="form-select"></select>
```

## Layouts e Views Parciais

### Criando um Layout
Layouts ajudam a manter a consistência visual das páginas.
```razor
<!DOCTYPE html>
<html>
<head>
    <title>@ViewData["Title"]</title>
</head>
<body>
    <header>
        <h1>Meu Site</h1>
    </header>
    <main>
        @RenderBody()
    </main>
</body>
</html>
```

Nas views, use:
```razor
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```

### Views Parciais
São úteis para reutilizar trechos de código.
```razor
@await Html.PartialAsync("_Produto", produto)
```

Arquivo `_Produto.cshtml`:
```razor
@model Produto
<p>@Model.Nome - @Model.Preco.ToString("C")</p>
```

## Manipulação de Dados e Exibição

### Formulários e Binding
```razor
<form asp-action="Salvar">
    <input asp-for="Nome" class="form-control" />
    <button type="submit">Salvar</button>
</form>
```

No controlador:
```csharp
[HttpPost]
public IActionResult Salvar(Produto produto)
{
    // Salvar no banco
    return RedirectToAction("Index");
}
```

## Boas Práticas e Considerações
- Utilize Tag Helpers para maior clareza e manutenção do código
- Prefira layouts para estruturar a aplicação
- Separe responsabilidades: Models para dados, Views para exibição
- Mantenha views pequenas e legíveis, evitando lógica complexa

---

Este resumo abordou os principais conceitos do Razor no ASP.NET MVC. Com essa base, você poderá criar aplicações dinâmicas e bem estruturadas!

