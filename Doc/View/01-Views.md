Aqui está um resumo completo sobre **Views no MVC** no ASP.NET Core.  

---

# 📌 **Views no MVC - ASP.NET Core**

## 📖 **Índice**  
1. [O que são Views no MVC?](#o-que-são-views-no-mvc)  
2. [Estrutura de uma View](#estrutura-de-uma-view)  
3. [Layouts e _ViewStart](#layouts-e-_viewstart)  
4. [Parcial Views](#parcial-views)  
5. [View Components](#view-components)  
6. [Tag Helpers](#tag-helpers)  
7. [ViewData, ViewBag e TempData](#viewdata-viewbag-e-tempdata)  
8. [Razor Syntax](#razor-syntax)  
9. [Boas Práticas para Views](#boas-práticas-para-views)  
10. [Conclusão](#conclusão)  

---

## 📝 **1. O que são Views no MVC?**  
No padrão **MVC (Model-View-Controller)**, a **View** é responsável por exibir os dados ao usuário. Ela contém a interface visual da aplicação e usa a linguagem **Razor**, que combina HTML com C# para renderizar dinamicamente o conteúdo.

As Views em ASP.NET Core MVC são arquivos **.cshtml** armazenados na pasta `Views/`.

🔹 **Papel da View:**  
- Renderizar HTML dinâmico com base nos dados do Model.  
- Exibir informações enviadas pelo Controller.  
- Utilizar **Tag Helpers**, **ViewData**, **ViewBag** e **TempData** para manipular dados.  

---

## 📂 **2. Estrutura de uma View**  
Cada Controller no ASP.NET Core MVC tem uma pasta correspondente dentro de `Views/`, onde suas Views são armazenadas.  

**Estrutura padrão de Views:**  
```
/Views
   /Home
      Index.cshtml
      About.cshtml
   /Shared
      _Layout.cshtml
      _ViewImports.cshtml
      _ViewStart.cshtml
```

- **`Views/Home/`** → Contém as Views do `HomeController`.  
- **`Views/Shared/`** → Contém Views reutilizáveis, como o `Layout`.  
- **`_ViewImports.cshtml`** → Define diretivas globais, como namespaces usados.  
- **`_ViewStart.cshtml`** → Define configurações globais, como Layout padrão.  

---

## 🎨 **3. Layouts e _ViewStart**  
Layouts ajudam a manter um **design consistente** em todas as páginas, fornecendo uma estrutura base.

### **Criando um Layout (_Layout.cshtml)**
O Layout fica na pasta `Views/Shared/` e contém um `@RenderBody()` onde o conteúdo das Views será inserido.

```cshtml
<!DOCTYPE html>
<html>
<head>
    <title>@ViewData["Title"] - Meu Site</title>
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <header>
        <h1>Meu Site</h1>
    </header>
    <main>
        @RenderBody()  <!-- Aqui será renderizado o conteúdo da View -->
    </main>
</body>
</html>
```

### **Configurando um Layout global (_ViewStart.cshtml)**
No arquivo `_ViewStart.cshtml`, definimos o Layout para todas as Views:

```cshtml
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```

---

## 🧩 **4. Parcial Views**  
As **Partial Views** são utilizadas para **reutilizar partes da interface**, evitando repetição de código.

### **Criando uma Partial View (_Menu.cshtml)**
Coloque a Partial View na pasta `Views/Shared/`.

```cshtml
<ul>
    <li><a href="/Home">Home</a></li>
    <li><a href="/About">Sobre</a></li>
</ul>
```

### **Renderizando uma Partial View**
Você pode renderizar uma Partial View dentro de outra View:

```cshtml
@Html.Partial("_Menu")
```

Ou usando `await` com `PartialAsync`:

```cshtml
@await Html.PartialAsync("_Menu")
```

---

## 🚀 **5. View Components**  
Os **View Components** são similares às Partial Views, mas com mais **funcionalidade e lógica**.

### **Criando um View Component**
```csharp
public class UltimosArtigosViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var artigos = new List<string> { "Artigo 1", "Artigo 2" };
        return View(artigos);
    }
}
```

### **Criando a View do View Component**
Crie `Views/Shared/Components/UltimosArtigos/Default.cshtml`:

```cshtml
<ul>
    @foreach (var artigo in Model)
    {
        <li>@artigo</li>
    }
</ul>
```

### **Chamando o View Component na View**
```cshtml
@await Component.InvokeAsync("UltimosArtigos")
```

---

## 🏷 **6. Tag Helpers**  
Os **Tag Helpers** permitem escrever código mais limpo e sem misturar muito C# com HTML.

### **Exemplo de Tag Helper para Formulário**
```cshtml
<form asp-controller="Home" asp-action="Salvar">
    <input type="text" asp-for="Nome" />
    <button type="submit">Salvar</button>
</form>
```

✅ Substitui a necessidade de escrever `@Html.TextBoxFor(model => model.Nome)`.  

---

## 📦 **7. ViewData, ViewBag e TempData**  
Esses objetos permitem passar informações do Controller para a View.

### **ViewData (Dicionário de Objetos)**
```csharp
ViewData["Mensagem"] = "Bem-vindo ao site!";
```
```cshtml
<h1>@ViewData["Mensagem"]</h1>
```

### **ViewBag (Dinâmico)**
```csharp
ViewBag.Nome = "João";
```
```cshtml
<h1>@ViewBag.Nome</h1>
```

### **TempData (Entre Requests)**
```csharp
TempData["Sucesso"] = "Cadastro realizado!";
```
```cshtml
<h1>@TempData["Sucesso"]</h1>
```

---

## ✍ **8. Razor Syntax**  
Razor é a sintaxe usada para misturar C# com HTML.

### **Exemplo de Bloco Razor**
```cshtml
@{
    var saudacao = "Olá, mundo!";
}
<h1>@saudacao</h1>
```

### **Estruturas Condicionais**
```cshtml
@if (DateTime.Now.Hour < 12)
{
    <p>Bom dia!</p>
}
else
{
    <p>Boa tarde!</p>
}
```

### **Loops**
```cshtml
@for (int i = 0; i < 5; i++)
{
    <p>Número: @i</p>
}
```

---

## ✅ **9. Boas Práticas para Views**
✔ **Separar a lógica da apresentação** → Views não devem conter lógica complexa.  
✔ **Utilizar Partial Views para reutilização de código**.  
✔ **Manter Views organizadas em pastas apropriadas**.  
✔ **Evitar muitos dados na ViewBag e ViewData** → Prefira Models fortemente tipados.  
✔ **Usar Tag Helpers em vez de `@Html` helpers** → Código mais limpo.  

---

## 🎯 **10. Conclusão**  
- Views no MVC são responsáveis pela interface gráfica da aplicação.  
- Utilizamos **Layouts** para manter um design consistente.  
- **Partial Views e View Components** ajudam a reutilizar código.  
- **Tag Helpers e Razor Syntax** facilitam a escrita de HTML dinâmico.  
- **ViewData, ViewBag e TempData** permitem passar dados entre Controller e View.  

Com essas técnicas, conseguimos construir interfaces ricas e bem organizadas no **ASP.NET Core MVC**! 🚀