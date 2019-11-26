## Projeto
  - Instalar `Install-Package Microsoft.EntityFrameworkCore.Design -Version 3.0.1`

- Usuario
  - Model - Class
  - Controller Class- UsuariosController (vazio)
  - View
    - pasta Views/Usuarios
  - CRUD Scaffolding
    - MVC Controllers with views, using Entity Framework

- Trocar SQL Server para MySQL
```json
  "ConnectionStrings": {
    "maisFIIContext": "server=localhost;userid=csharp;password=csharp123;database=maisfii"
  }
```

- Criar Usuário e banco de dados
    ```sql
CREATE USER 'csharp'@'localhost' IDENTIFIED BY 'csharp123'; 
GRANT ALTER, ALTER ROUTINE, CREATE, CREATE ROUTINE, CREATE TABLESPACE, CREATE TEMPORARY TABLES, CREATE USER, CREATE VIEW, DELETE, DROP, EVENT, EXECUTE, FILE, INDEX, INSERT, LOCK TABLES, PROCESS, REFERENCES, RELOAD, REPLICATION CLIENT, REPLICATION SLAVE, SELECT, SHOW DATABASES, SHOW VIEW, SHUTDOWN, SUPER, TRIGGER, UPDATE ON *.* TO 'csharp'@'localhost' WITH GRANT OPTION; 

CREATE DATABASE `maisfii`CHARACTER SET utf8 COLLATE utf8_unicode_ci; 
    ```

## Startup.cs

- Em Startup.cs, fix DbContext 



## Login na Aplicação (IDENTITY)

1 - Criar a classe de modelo para controlar o usuário logado e herdar IdentityUser

2 - Instalar a biblioteca do Identity
  - Microsoft.AspNetCore.Identity.EntityFrameworkCore 2.1.6

3 - Fazer a herança no Context do IdentityDbContext

4 - Configurar o Identity no Startup.cs

5 - Deletar banco e migrações e gerar o banco novamente

6 - Implementar o cadastro do usuário pela biblioteca

7 - Criar a área de login

8 - Criar a área de logout

9 - Alterar barra de navegação para mostrar o usuário logado