# Todo List API

## Descrição

A Todo List API é uma aplicação desenvolvida em ASP.NET Core para gerenciamento de tarefas.
## Requisitos

- .NET 8
- MySQL
- Visual Studio
- Swagger

## Configuração do Ambiente

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/Tiallysson/test-next-coders.git
   cd test-next-coders

2. **Configure o Banco de Dados MySQL**

    Crie um banco de dados MySQL e atualize a string de conexão no arquivo `appsettings.json`:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=todo_list;User=root;Password=sua-senha;"
    }

## Execução da API

1. **Execute a aplicação**
   - Visual Studio Code
   ```powershell
   dotnet watch
   ```

   - Visual Studio 2022
   1. Pressione *f5* para executar a API
   2. Pressione *Shift + F5* para parar a API

2. **Teste**
   
   ![Captura de tela 2024-08-25 091046](https://github.com/user-attachments/assets/194d3508-2444-44c2-a5dd-b44efa8014aa)

    - Rota de criação de tarefas
    ```python
    POST: api/task/create
    ```

    - Rota de leitura de tarefas
    ```python
    GET: api/task/read
    ```

     - Rota de atualização de tarefas
    ```python
    PUT: api/task/update
    ```

     - Rota de deletar tarefas
    ```python
    DELETE: api/task/delete
    ```
   
