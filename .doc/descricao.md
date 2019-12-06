# Projeto MaisFII

Este projeto propõe no gerenciamento de carteiras de Fundos de Investimentos Imobiliários, para finalizar o projeto, serão 10 sprints

## Funcionalidades (SPRINT 1)
- Criar REST API de CRUD (fundos, historico de fundos, Operações C/V)
- CRUD para (usuario, carteiras, fundos, operações de CV)
- Consumir um servico REST, para cadastro de Usuário
  - Criar proxy do servico de dados para o uso no cadastro de usuários
- Usuários podem gerenciar carteiras (CRUD)
- Fazer operações de ativos - compra/venda de FII para uma carteira existente
- Listar Carteira com o subtotal da carteira
- Importação de dados de conteúdo através de planilhas (CSV) - Fundos
- Filtrar histórico de fundos por data


## UML
![](./Diagrama-maisFII.svg)

## Requisitos

- MySQL
- CODE-FIRST Workflow
- NuGet Pacotes
  - `Install-Package Microsoft.EntityFrameworkCore.Design -Version 3.0.1`
  - `Install-Package Pomelo.EntityFrameworkCore.MySql`
  - `Install-Package ChoETL.JSON -Version 1.1.0.4` - csv to json
  - `Install-Package PagedList.Mvc` - Paginação

## Desenvolvimento Fase 1 (trabalho da faculdade)
- Usuario
  - CRUD
- Carteira
  - CRUD
- Operações Compra/Venda
  - CRUD
- Fundos
  - Importado pelo dados do [Google Planilhas](https://docs.google.com/spreadsheets/d/17SQAgs-oHRguDJJGGk8mXcBD7FByQWpUQgKZYYIRpJU/edit), qual compõe o histórico diário a partir que o robot começar a operar, sendo executado 1 vez ao dia
  - Histórico dos Fundos
  - Importado pelo dados do [Google Planilhas](http://) em que terá a lista do último ano de cada fundo

### Banco de Dados
![](../.db/der.svg)

## TODO (Pós Faculdade / FASES Posteriores)

- Tela de login com sessão

- Segmentos
  - Cadadstro
- Tipo
  - Cadastro
- Gráficos
  - Carteira
    - Porcentual da composição da carteira de cada fundo - tipo pizza
    - Porcentual por tipo - tipo pizza
    - Porcentaul por segmentos - tipo p
    - Ganho de capital e dividendos de cada fundo da carteira
    - Dividendos pagos desde a primeira operação adicionada na carteira - tipo "stacked bar"
  - Histórico de dividendos de cada fundo


## Referências

- http://www.macoratti.net/17/05/efcore_mysql1.htm
- https://www.entityframeworktutorial.net/entity-relationships.aspx
- http://learningprogramming.net/net/asp-net-core-mvc/login-form-with-session-in-asp-net-core-mvc/
- https://www.learnrazorpages.com/razor-pages/ajax/unobtrusive-ajax
- https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
- http://learningprogramming.net/net/asp-net-core-mvc/autocomplete-in-asp-net-core-mvc-and-entity-framework-core/
- https://alternativeto.net/software/essential-js-2/
- http://www.macoratti.net/Cursos/aspncore2_mcurso1.htm
- https://stackoverflow.com/questions/41740638/using-enum-for-dropdown-list-in-asp-net-mvc-core
- https://www.learnrazorpages.com/razor-pages/forms
- Varios exemplos ASP.NET https://github.com/ajsaulsberry?tab=repositories