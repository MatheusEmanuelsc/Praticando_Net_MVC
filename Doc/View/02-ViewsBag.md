# 📌 **Resumo Completo: `ViewModel` e `ViewData` no ASP.NET Core MVC**  

---

## **🔹 O que é o `ViewData`?**  
O `ViewData` é um **dicionário de chave-valor** (`Dictionary<string, object>`) que permite passar dados do Controller para a View, de forma **similar ao `ViewBag`**, mas utilizando **chaves de string**.  

📌 **Características**:  
✔ Funciona como um **dicionário de objetos**.  
✔ Os dados **não persistem entre requisições**.  
✔ Precisa de **casting** ao acessar valores.  
✔ Útil quando se trabalha com pequenos valores dinâmicos.  

---

## **🔹 Como usar o `ViewData`?**  

### **✅ 1️⃣ Definir valores no Controller**  
```csharp
public IActionResult Index()
{
    ViewData["Mensagem"] = "Bem-vindo ao site!";
    ViewData["DataAtual"] = DateTime.Now.ToString("dd/MM/yyyy");

    return View();
}
```

---

### **✅ 2️⃣ Acessar `ViewData` na View (`Index.cshtml`)**  
```html
<h1>@ViewData["Mensagem"]</h1>
<p>Data de hoje: @ViewData["DataAtual"]</p>
```
📌 **Explicação**:  
- `ViewData["Mensagem"]` retorna `"Bem-vindo ao site!"`.  
- `ViewData["DataAtual"]` retorna a **data formatada**.  

---

## **🔹 Diferença entre `ViewBag` e `ViewData`**  

| Recurso   | Tipo | Requer Casting? | IntelliSense? | Fortemente Tipado? |
|-----------|------|----------------|--------------|-------------------|
| **ViewBag** | `dynamic` | ❌ Não | ❌ Não | ❌ Não |
| **ViewData** | `Dictionary<string, object>` | ✅ Sim | ❌ Não | ❌ Não |

📌 **Conclusão**:  
- `ViewBag` é **mais fácil de usar** porque não precisa de casting.  
- `ViewData` pode ser útil para armazenar **coleções de dados**, pois pode ser convertido para uma lista de objetos.  

---

## **🔹 O que é um `ViewModel`?**  
Um **ViewModel** é uma classe criada para **passar dados específicos** da Controller para a View. Ele é **fortemente tipado**, diferente do `ViewBag` e `ViewData`, e organiza os dados de forma estruturada.  

📌 **Vantagens do ViewModel**:  
✔ Código **mais organizado**.  
✔ Evita o uso de `ViewBag` e `ViewData`.  
✔ **Mais seguro** e com suporte a **IntelliSense**.  

---

## **🔹 Criando um ViewModel**  

### **✅ 1️⃣ Criar a classe `AlunoViewModel`**  
```csharp
public class AlunoViewModel
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}
```

---

### **✅ 2️⃣ Passar o ViewModel no Controller**  
```csharp
public IActionResult Detalhes()
{
    var model = new AlunoViewModel
    {
        Nome = "João",
        Idade = 20,
        Mensagem = "Aluno cadastrado com sucesso!"
    };

    return View(model);
}
```

---

### **✅ 3️⃣ Acessar os dados na View (`Detalhes.cshtml`)**  
```html
@model AlunoViewModel

<h2>Detalhes do Aluno</h2>
<p>Nome: @Model.Nome</p>
<p>Idade: @Model.Idade anos</p>
<p>Mensagem: @Model.Mensagem</p>
```
📌 **Explicação**:  
- `@model AlunoViewModel` define que a View usará esse **ViewModel**.  
- `@Model.Propriedade` acessa os dados do ViewModel.  

---

## **🔹 Diferença entre ViewModel, ViewData e ViewBag**  

| Método       | Fortemente Tipado? | IntelliSense? | Precisa de Casting? | Recomendado? |
|-------------|-------------------|--------------|-----------------|------------|
| **ViewModel** | ✅ Sim | ✅ Sim | ❌ Não | ✅ Sim |
| **ViewBag** | ❌ Não | ❌ Não | ❌ Não | ⚠️ Para dados simples |
| **ViewData** | ❌ Não | ❌ Não | ✅ Sim | ⚠️ Para pequenos valores |

📌 **Conclusão**:  
- **Use ViewModel** quando precisar de uma estrutura **fortemente tipada**.  
- **Evite ViewBag e ViewData** para aplicações grandes.  

---

## **💡 Conclusão**  
O `ViewData` funciona de forma parecida com `ViewBag`, mas o uso de **ViewModels** é a abordagem **mais recomendada** para passar dados entre Controller e View no **ASP.NET Core MVC**. 🚀