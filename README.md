# QuantoCusta

**QuantoCusta** é uma API REST desenvolvida em **ASP.NET Core** com o objetivo de resolver um problema real de gestão de produtos e preços em um pequeno mercado familiar.

## 📘 Sobre o Projeto

Um familiar, proprietário de um mercado, precisava de uma forma prática de:

- Cadastrar novos produtos
- Atualizar preços
- Excluir produtos obsoletos
- Visualizar produtos de forma simples e rápida

A solução foi a criação de uma **API organizada por categorias de produtos**, com rotas bem definidas para facilitar o consumo tanto por interfaces web quanto por aplicativos móveis no futuro.

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8.0
- Entity Framework Core
- MySQL
- RESTful API padrão
- C#

---

## 📂 Estrutura do Projeto
QuantoCusta/

├── Controllers/ # Endpoints da API

├── Services/ # Lógica de negócios

├── Mappers/ # Conversão entre entidades e DTOs

├── DTOS/ # Objetos de transferência de dados

├── Models/ # Entidades principais do domínio

├── Database/ # Contexto do EF e configuração do banco

├── Migrations/ # Migrations do EF Core

├── Properties/ # Configurações do projeto

├── appsettings.json # Configuração principal

├── Program.cs # Inicialização da aplicação


---

## 🚀 Como Rodar o Projeto

1. **Clone o repositório**
 ```bash
 git clone https://github.com/Pixel-DefaultBR/QuantoCusta.git
 cd QuantoCusta
```


2. **Restaure os pacotes**

```dotnet restore```

3. **Execute a aplicação**

```dotnet run```

