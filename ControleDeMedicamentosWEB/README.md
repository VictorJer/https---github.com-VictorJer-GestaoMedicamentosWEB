# 💊 Sistema de Controle de Medicamentos

> Sistema inteligente e seguro para gestão de estoque farmacêutico, controle de insumos e rastreabilidade de requisições, desenvolvido em **.NET 10** utilizando o padrão **ASP.NET Core MVC**.

![Status do Projeto](https://img.shields.io/badge/Status-Pronto%20para%20Dev-success?style=for-the-badge)
![Plataforma](https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge)
![Padrão](https://img.shields.io/badge/Arquitetura-ASP.NET%20MVC-blue?style=for-the-badge)

---

## 📌 Índice
- [Visão Geral](#-visão-geral)
- [Arquitetura & Stack Tecnológica](#-arquitetura--stack-tecnológica)
- [Estrutura do Projeto (Padrão MVC)](#%EF%B8%8F-estrutura-do-projeto-padrão-mvc)
- [Especificação de Requisitos & Regras de Negócio](#-especificação-de-requisitos--regras-de-negócio)
  - [1. Módulo de Fornecedores](#1-módulo-de-fornecedores)
  - [2. Módulo de Pacientes](#2-módulo-de-pacientes)
  - [3. Módulo de Medicamentos](#3-módulo-de-medicamentos)
  - [4. Módulo de Funcionários](#4-módulo-de-funcionários)
  - [5. Módulo de Estoque (Transações)](#5-módulo-de-estoque-transações)
- [Como Executar o Projeto](#%EF%B8%8F-como-executar-o-projeto)
- [Regras Críticas de Implementação](#-regras-críticas-de-implementação)

---

## 🚀 Visão Geral

O **Sistema de Controle de Medicamentos** foi idealizado para mitigar furos de estoque, otimizar a distribuição de medicamentos e fornecer total rastreabilidade sobre quem forneceu, quem manipulou e qual paciente recebeu determinado item. 

A escolha do **.NET 10** garante o estado da arte em performance, injeção de dependência nativa e segurança na tipagem de dados para o ecossistema de saúde.

---

## 🛠️ Arquitetura & Stack Tecnológica

O projeto foi estruturado seguindo o ecossistema moderno da Microsoft:

* **Runtime:** .NET 10.0
* **Framework Web:** ASP.NET Core MVC (Model-View-Controller)
* **Persistência de Dados:** Entity Framework Core (EF Core 10)
* **Banco de Dados:** SQL Server / PostgreSQL (Relacional)
* **Validação de Dados:** Data Annotations & FluentValidation
* **Front-end Integrado:** Razor Views + Bootstrap 5 / TailwindCSS + jQuery/Vanilla JS para máscaras e validações assíncronas.

---

## 🗂️ Estrutura do Projeto (Padrão MVC)

A organização das pastas segue a convenção oficial do ASP.NET Core MVC, mantendo a separação lógica de responsabilidades:

```text
ControleMedicamentos/
│
├── Controllers/           # Lógica de controle e endpoints das Views
│   ├── FornecedoresController.cs
│   ├── PacientesController.cs
│   ├── MedicamentosController.cs
│   ├── FuncionariosController.cs
│   └── EstoqueController.cs
│
├── Models/                # Entidades do Banco de Dados e ViewModels
│   ├── Entities/          # Classes de domínio (Fornecedor, Paciente, etc.)
│   └── ViewModels/        # Modelos customizados para validação de telas
│
├── Views/                 # Telas do sistema (Razor Pages - .cshtml)
│   ├── Fornecedores/
│   ├── Pacientes/
│   ├── Medicamentos/
│   ├── Shared/            # Layouts globais e componentes parciais
│   └── _ViewImports.cshtml
│
├── Data/                  # Contexto do Entity Framework e Migrations
│   ├── ApplicationDbContext.cs
│   └── Migrations/
│
├── Services/              # Regras de negócio isoladas (Triggers de Estoque)
│   └── IEstoqueService.cs
│
├── wwwroot/               # Arquivos estáticos (CSS, JS, Imagens)
│   ├── js/                # Scripts de máscaras (Cpf, Cnpj, SUS)
│   └── css/               # Estilizações do sistema
│
├── Program.cs             # Configuração da aplicação, Injeção de Dependência e Pipeline HTTP
└── appsettings.json       # Strings de conexão com o Banco de Dados e variáveis de ambiente
