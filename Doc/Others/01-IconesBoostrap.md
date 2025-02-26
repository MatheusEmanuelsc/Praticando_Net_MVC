# 📝 Tutorial: Como Adicionar Ícones do Bootstrap no ASP.NET MVC

## 🎯 Objetivo  
Neste tutorial, você aprenderá a adicionar **ícones do Bootstrap** em um projeto **ASP.NET MVC**, garantindo que os ícones sejam carregados corretamente e possam ser usados em suas views.

---

## 🔗 Passo 1: Adicionar o Bootstrap Icons ao Projeto

### 📌 Opção 1: Adicionar via CDN (Mais Simples e Recomendado)  
1. Abra o arquivo **_Layout.cshtml** em **Views > Shared**.  
2. No `<head>`, adicione o seguinte código para carregar os ícones do Bootstrap:  

```html
<!-- Bootstrap CSS (caso não esteja incluído) -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">

<!-- Bootstrap Icons -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css">
```

Isso garante que os ícones do Bootstrap estarão disponíveis no projeto.

---

### 📌 Opção 2: Adicionar via NuGet (Modo Offline)  
Se preferir instalar os arquivos localmente, siga os passos:  

1. No **Gerenciador de Pacotes NuGet**, instale o pacote:  

   ```powershell
   Install-Package Bootstrap.Icons
   ```

2. Depois de instalar, adicione a referência ao **CSS** dos ícones no **_Layout.cshtml**:  

   ```html
   <link rel="stylesheet" href="~/Content/bootstrap-icons/bootstrap-icons.css">
   ```

---

## 🎨 Passo 2: Usar Ícones do Bootstrap em Views  

Agora, você pode utilizar os ícones do Bootstrap em qualquer **View** do projeto.  

### 📌 Exemplos de Uso:  
#### ✔️ Exemplo 1: Ícone Simples  
```html
<i class="bi bi-house"></i> Home
```

#### ✔️ Exemplo 2: Ícone Dentro de um Botão  
```html
<button class="btn btn-primary">
    <i class="bi bi-plus-circle"></i> Adicionar
</button>
```

#### ✔️ Exemplo 3: Ícone em um Link  
```html
<a href="#" class="btn btn-success">
    <i class="bi bi-pencil"></i> Editar
</a>
```

#### ✔️ Exemplo 4: Ícone com Tamanhos Diferentes  
Os ícones podem ser redimensionados usando a classe `fs-*` (font-size):  
```html
<i class="bi bi-trash fs-1"></i> <!-- Grande -->
<i class="bi bi-trash fs-3"></i> <!-- Médio -->
<i class="bi bi-trash fs-5"></i> <!-- Pequeno -->
```

---

## 🎯 Conclusão  
Agora você pode usar **Bootstrap Icons** no seu projeto ASP.NET MVC para melhorar a interface com ícones elegantes e prontos para uso. 🚀  

Se precisar de mais personalizações, pode consultar a [documentação oficial](https://icons.getbootstrap.com/).  

**Bons códigos!** 🎨💻