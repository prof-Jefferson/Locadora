# Sistema de Locadora de Veículos – Projeto Fullstack POO

Projeto acadêmico desenvolvido para a disciplina de **Programação Orientada a Objetos**, com foco na aplicação prática e consciente dos princípios de POO, arquitetura em camadas e padrões de projeto, utilizando uma aplicação **fullstack**.

O sistema simula uma **locadora de veículos** que atende **pessoas físicas (PF)** e **pessoas jurídicas (PJ)**, permitindo realizar locações, devoluções e integração com setores internos como **pátio**, **lava-rápido** e **manutenção**.

---

## Objetivos do Projeto

- Aplicar **Programação Orientada a Objetos** além de CRUDs simples
- Utilizar **classes abstratas, interfaces, herança e polimorfismo**
- Aplicar **padrões de projeto**, como:
  - **Strategy** – política de preços
  - **Observer** – eventos de locação e devolução
- Separar claramente as responsabilidades do sistema
- Desenvolver uma aplicação **web fullstack**
- Persistir dados em **MariaDB**, mantendo independência arquitetural do banco

---

## Arquitetura Geral

O projeto segue uma abordagem inspirada em **Clean Architecture / Ports and Adapters**, garantindo baixo acoplamento e alta coesão.

```
Locadora.Api
   ↓
Locadora.Application
   ↓
Locadora.Domain
   ↑
Locadora.Infrastructure
```

---

## Projetos da Solution

### Locadora.Domain
- Entidades de domínio
- Value Objects
- Regras de negócio (funções puras)
- Eventos de domínio

### Locadora.Application
- Casos de uso (Use Cases)
- Interfaces (ports)
- Orquestração das regras de negócio

### Locadora.Infrastructure
- EF Core
- MariaDB
- Repositórios
- EventBus (implementação do padrão Observer)

### Locadora.Api
- Endpoints HTTP (Minimal APIs)
- Injeção de dependência
- Swagger / OpenAPI

### Frontend (em desenvolvimento)
- React + TypeScript
- Consumo da API REST

---

## Conceitos de POO Aplicados

- ✔️ Classes abstratas (`Cliente`, `Veiculo`, `Setor`)
- ✔️ Herança (`PessoaFisica`, `PessoaJuridica`)
- ✔️ Interfaces (`IRepository`, `IEventBus`, etc.)
- ✔️ Polimorfismo (políticas de preço, setores)
- ✔️ Baixo acoplamento
- ✔️ Alta coesão
- ✔️ Separação de responsabilidades

---

## Eventos e Observer

O sistema utiliza **eventos de domínio** para desacoplar os setores internos:

### Eventos principais
- `VeiculoLocado`
- `VeiculoDevolvido`

### Setores que reagem aos eventos
- Pátio
- Lava-rápido
- Manutenção

Esses setores são implementados como **Observers**, permitindo que novas funcionalidades sejam adicionadas sem alterar o núcleo do sistema.

---

## Banco de Dados

- **MariaDB**
- Modelagem baseada em **Diagrama Entidade-Relacionamento (DER)**
- EF Core como ORM
- Migrations para versionamento do schema

---

## Como executar (Backend)

### Pré-requisitos
- .NET 8 SDK
- MariaDB em execução
- Connection string configurada

### Executar a API
```bash
dotnet restore
dotnet build
dotnet run --project Locadora.Api
```

### Acessar o Swagger
```
https://localhost:5001/swagger
```

---

## Contexto Acadêmico

Este projeto foi desenvolvido como **projeto final da disciplina**, priorizando:

- Clareza arquitetural
- Uso consciente de POO
- Código legível, organizado e evolutivo
- Aproximação com práticas reais de engenharia de software
