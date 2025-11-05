 # 🏪 Shop API

A **Shop API** é uma aplicação ASP.NET Core desenvolvida para demonstrar o funcionamento de uma **API com cadastros e autenticação de usuários**, incluindo entidades como *Users*, *Categories* e *Products*.
O projeto foi criado com base em práticas **Data Driven**, utilizando **Entity Framework Core** para acesso a dados e integração com **Azure App Service** para deploy automatizado via GitHub Actions.

---

## 🚀 Tecnologias Utilizadas

* **.NET 8 / ASP.NET Core**
* **Entity Framework Core**
* **SQL Server**
* **Azure App Service (Deploy Automático)**
* **GitHub Actions**
* **C#**

---

## ⚙️ Funcionalidades

* Cadastro e autenticação de usuários (`employee`, `manager`)
* Criação de categorias e produtos
* Endpoint inicial de configuração com dados padrão
* Persistência de dados no banco via `DataContext`
* Deploy automatizado no Azure App Service

---

## 🧩 Estrutura do Projeto

```
ShopAPI/
├── Controllers/
│   └── HomeController.cs
├── Data/
│   └── DataContext.cs
├── Models/
│   ├── User.cs
│   ├── Category.cs
│   └── Product.cs
├── Services/
├── Migrations/
├── Program.cs
├── Shop.csproj
└── .github/workflows/
    └── master_alef7194.yml
```

---

## 🔧 Executando Localmente

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/Alef0814/Alef-7194deploy.git
   ```

2. **Acesse a pasta do projeto:**

   ```bash
   cd Alef-7194deploy
   ```

3. **Restaure as dependências:**

   ```bash
   dotnet restore
   ```

4. **Execute a aplicação:**

   ```bash
   dotnet run
   ```

5. A API será executada em:

   ```
   https://localhost:5001
   ```

---

## 🌐 Publicação no Azure

O projeto está publicado e configurado para **deploy automático no Azure App Service**.
Sempre que há um novo *commit* no branch principal (`master`), o GitHub Actions executa o arquivo de workflow:

```
.github/workflows/master_alef7194.yml
```

Esse arquivo automatiza o build e o deploy diretamente na aplicação hospedada no Azure.

---

## 👨‍💻 Autor

**Alef do Nascimento Pinto**
Desenvolvedor Backend em formação, apaixonado por tecnologia e sempre aprendendo mais sobre o ecossistema .NET.

📫 Conecte-se comigo:
[LinkedIn](https://www.linkedin.com/in/alef-nascimento-0121742b2) 
[GitHub](https://github.com/Alef0814)

---

## 🏁 Status do Projeto

✅ **Concluído e em funcionamento**
A Shop API está disponível no Azure App Service, integrando código, banco de dados e automação de deploy de forma eficiente.
