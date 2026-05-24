# FitControl

Sistema de gestão para academias desenvolvido para o Projeto Integrado Multidisciplinar (PIM).

## Objetivo do Projeto

O sistema FitControl foi desenvolvido com o objetivo de auxiliar na gestão administrativa e operacional de academias, permitindo o controle de alunos, planos, pagamentos, presença, treinos e relatórios gerenciais.

---

## Tecnologias Utilizadas

### Back-end
- ASP.NET Core
- C#
- API REST
- Arquitetura em Camadas

### Banco de Dados
- SQL Server
- Script SQL para criação das tabelas e relacionamentos

### Front-end
- HTML
- CSS
- JavaScript

---

## Arquitetura do Sistema

O sistema foi desenvolvido utilizando arquitetura em camadas:

Frontend (Web)
↓
Controllers (API REST)
↓
Services (Regras de Negócio)
↓
Repositories (Acesso a Dados)
↓
Banco de Dados (SQL Server)

---

## Estrutura do Projeto

### Backend
Contém:
- Controllers
- Services
- Models
- Repositories
- Configuração da API REST
- Regras de negócio do sistema

### Frontend
Contém:
- Telas do sistema
- Interface de login
- Dashboard
- Controle de alunos
- Controle de planos
- Presença
- Treinos
- Relatórios

### Banco de Dados
Contém:
- Script SQL de criação das tabelas
- Relacionamentos
- Chaves primárias e estrangeiras

---

## Funcionalidades Principais

- Cadastro de usuários
- Login de usuários
- Cadastro de alunos
- Cadastro de professores
- Gestão de planos
- Matrículas
- Controle de pagamentos
- Controle de presença
- Controle de treinos
- Dashboard administrativo
- Relatórios

---

## Controle de Acesso

### Aluno
- Visualizar plano
- Visualizar pagamentos
- Visualizar treinos
- Visualizar presença

### Professor
- Registrar presença
- Criar treinos
- Visualizar agenda

### Gerente/Admin
- Controle completo do sistema

---

## Banco de Dados

O banco de dados foi modelado utilizando SQL Server, contendo entidades relacionadas ao gerenciamento da academia:

- Usuario
- Aluno
- Professor
- Plano
- Matricula
- Pagamento
- Presenca
- Treino

---

## Projeto Acadêmico

Projeto desenvolvido para fins acadêmicos no Projeto Integrado Multidisciplinar (PIM).
