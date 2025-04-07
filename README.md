# 🏙️ MoradorBairroAPI - Cidades Inteligentes

Este projeto é uma API desenvolvida em C# (.NET 9) com integração ao MongoDB, como parte do desafio da fase "Navegando pelo mundo DevOps" da disciplina FIAP do curso de Análise e Desenvolvimento de Sistemas.

---

## 🚀 Objetivo
A API permite gerenciar bairros e moradores de uma cidade inteligente, utilizando práticas de DevOps para automação e deploy.

---

## 🔧 Tecnologias utilizadas

- ASP.NET Core 9
- MongoDB
- Docker e Docker Compose
- Mongo Express
- GitHub Actions (CI/CD)
- Swagger para testes da API

---

## 🐳 Como executar o projeto com Docker

### Pré-requisitos

- Docker instalado
- Docker Compose instalado

### Passo a passo

1. Clone o repositório:

```bash
git clone https://github.com/alanbernardo/MoradorBairroAPI.git
cd MoradorBairroAPI
```

2. Suba os containers:

```bash
docker-compose up --build
```

3. Acesse:
- API: http://localhost:5000/swagger
- Mongo Express: http://localhost:8081

---

## 💻 Como executar localmente (sem Docker)

1. Configure sua string de conexão com MongoDB no arquivo `appsettings.json`.
2. Execute a aplicação:

```bash
dotnet run
```

---

## 🔄 CI/CD

O projeto possui integração com GitHub Actions. A cada push no repositório:
- O código é compilado
- A imagem Docker é gerada
- A aplicação é testada e validada

---

## 📁 Estrutura do projeto

- `/Controllers`: Endpoints da API
- `/Models`: Classes de domínio
- `/Services`: Lógica de acesso ao MongoDB
- `Dockerfile`: Dockerização da API
- `docker-compose.yml`: Orquestração da API + MongoDB + Mongo Express
- `.github/workflows/ci-cd.yml`: Pipeline automatizado

---

## 👨‍💻 Autor

Alan Bernardo — Projeto acadêmico da disciplina de DevOps.

---
