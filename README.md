Gerenciador de Tarefas API
Esta API foi desenvolvida para gerenciar tarefas e pessoas em um sistema de gerenciamento de tarefas. Com esta API, é possível cadastrar pessoas, criar e gerenciar tarefas, e associar essas tarefas às pessoas responsáveis.

Funcionalidades
Cadastro de Pessoas:

1.Cada pessoa possui um ID único, nome, e-mail e data de nascimento.
2.Endpoints para criar, visualizar, atualizar e remover pessoas.
3.A exclusão de uma pessoa só é permitida se ela não tiver tarefas pendentes associadas.

Cadastro de Tarefas:
4.Cada tarefa possui um ID único, título, descrição, data de criação e status (pendente, em progresso, concluída).
5.Endpoints para criar, visualizar, atualizar e remover tarefas.
6.Associação de Tarefas a Pessoas:

7.Uma pessoa pode ser responsável por várias tarefas.
8.Cada tarefa pode ter apenas uma pessoa responsável.
9.Endpoints para associar e desassociar tarefas de pessoas.
10.Regras de Negócio Importantes:

11.Uma pessoa não pode ser excluída se tiver tarefas pendentes.
12.Se todas as tarefas de uma pessoa estiverem concluídas, o status da pessoa pode ser atualizado para "disponível".

Tecnologias Utilizadas
Backend: C# com .NET 8.0
Banco de Dados: MySQL(Utilizado MysqlWorkbench - versão mysql 8.0);
ORM: Entity Framework Core
Documentação da API: Swagger

Requisitos para Execução
.NET SDK 8.0
MySQL para o banco de dados
Ferramenta de gerenciamento de banco de dados: MySQL Workbench (opcional)

Configuração
Clonar meu Projeto do repositorio https://github.com/matheus464/TaskApp.git
Crie um banco de dados MySQL com o nome taskmaster (scripts do banco de dados enviados no emial da recrutadora).
Atualize as configurações de conexão no arquivo appsettings.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=taskmaster;user=root;password=;"
  }
}
A documentação completa da API pode ser acessada através do Swagger, em https://localhost:7117/swagger/index.html.
