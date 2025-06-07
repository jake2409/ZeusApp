
# ⚡ ZeusApk

Um sistema console simples para registro e visualização de quedas de energia por usuários comuns e companhias (ex: Enel).

## 🧭 Finalidade

O ZeusApk permite que:
- Usuários comuns registrem eventos de queda de energia informando cidade, bairro, horário e descrição.
- Companhias (como concessionárias) possam visualizar todos os registros feitos por usuários.
- Todos os usuários possam explorar os registros de outros, filtrando por cidade e bairro.

---

## 🗂 Estrutura de Pastas

```
ZeusApk/
│
├── Models/              → Modelos principais (User, Post)
├── Repositories/        → Interfaces e repositórios mockados para persistência em memória
├── Services/            → Regras de negócio (ex: AuthService)
├── UI/                  → Telas e menus da aplicação
└── Program.cs           → Ponto de entrada principal
```

---

## 🔧 Dependências

O projeto é puramente em C# e não possui dependências externas. É compatível com .NET 6.0 ou superior.

---

## ▶️ Como executar

1. Abra o projeto no Visual Studio ou no terminal com o `dotnet`.

2. Compile e execute:

   ```bash
   dotnet build
   dotnet run
   ```

3. Navegue pelo menu interativo no console para realizar login, cadastro, postar ou explorar registros.

---

## 👤 Usuários Mockados

O sistema contém dados mockados para testes iniciais:

| Tipo de usuário | Email              | Senha | isCompanhia |
|----------------|--------------------|-------|-------------|
| Usuário comum  | user@email.com     | 1234  | false       |
| Companhia      | enel@enel.com      | 1234  | true        |

Você pode cadastrar novos usuários via opção **"Cadastro"** no menu inicial.

---

## 💡 Funcionalidades

- **Login e Cadastro**
- **Criação de Posts**
- **Exploração de Posts com filtros**
- **Listagem de Meus Posts**
- **Diferenciação entre usuários comuns e companhias**
