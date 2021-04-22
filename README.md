# Projeto: Ewave-Livraria-Senior

Este é um projeto MVP <i>(Minimal Viable Product)</i> da <strong>Livraria ToDo </strong>;

<img src="https://github.com/henriquehrf/Ewave-Livraria-Senior/blob/main/ToDo-UI/ewave-livraria-senior/src/assets/img/LivrariaTODO.PNG"/>


API: <img src="https://github.com/henriquehrf/Ewave-Livraria-Senior/actions/workflows/dotnet.yml/badge.svg"/>

UI: <img src="https://github.com/henriquehrf/Ewave-Livraria-Senior/actions/workflows/node.yml/badge.svg"/>

<hr>

<h3>Tabelas e Campos do Sistema</h3>

<ul>
  <li>
    <h4>Usuário</h4>
    <ul>
      <li>Nome</li>
      <li>CPF</li>
      <li>Telefone</li>
      <li>Email</li>
      <li>Endereço</li>
      <li>Instituição de Ensino</li>
      <li>Perfil Usuário (1 - Administrador, 2 - Usuário Comum)</li>
      <li>Login</li>
      <li>Senha</li>
      <li>Foto</li>
      <li>Ativo</li>
    </ul>
   </li>
</ul>
<ul>
  <li>
    <h4>Instituição de Ensino</h4>
    <ul>
      <li>Nome</li>
      <li>CNPJ</li>
      <li>Telefone</li>
      <li>Endereço</li>
      <li>Foto</li>
      <li>Ativo</li>
    </ul>
   </li>
</ul>
<ul>
  <li>
    <h4>Livro</h4>
    <ul>
      <li>Título</li>
      <li>Genero</li>
      <li>Sinopse</li>
      <li>Capa</li>
      <li>Ativo</li>
    </ul>
   </li>
</ul>
<ul>
  <li>
    <h4>Empréstimo</h4>
    <ul>
      <li>Usuário</li>
      <li>Livro</li>
      <li>Data Empréstimo</li>
      <li>Data Previsão Devolução</li>
      <li>Data Devolução</li>
    </ul>
   </li>
</ul>
<ul>
  <li>
    <h4>Reserva</h4>
    <ul>
      <li>Usuário</li>
      <li>Livro</li>
      <li>Data Reserva</li>
      <li>Ativo</li>
    </ul>
   </li>
</ul>

<hr>
<h3>Funcionalidades</h3>

<ul>
  <li>
    O usuário ADMINISTRADOR é responsável pelos cadastros base. Tanto ele, quanto o USUÁRIO COMUM pode fazer a solicitação de empréstimo.
  </li>
    <li>
    O usuário ADMINISTRADOR possui na tela inicial a visualização de todos empréstimos ativos(atualizados a cada 1 minuto), com destaque naqueles que estão em atraso.
  </li>
    <li>
    Ao solicitar empréstimo, o sistema avalia se o usuário não atingiu o limite de 2 empréstimo por usuário e se ele possui alguma suspensão vigente ou empréstimos em atraso.
    Ao atingir o limite de empréstimo, o usuário fica impossibilitado de emprestar livro, liberando novos empréstimos mediante a devolução.
    Caso a devolução seja em atraso, o usuário ficará suspenso para novos empréstimo por 30 dias.
  </li>
  <li>
   Para solicitar um empréstimo, o usuário OBRIGATORIAMENTE deve está logado no sistema.
  </li>
  <li>
   Implementado algumas camadas de segurança para inativação de registro, de forma que não provoque incosistência de dados e afete a usabilidade do usuário. 
   </li>
</ul>

<hr>

<h3>Técnologias/Arquitetura do projeto</h3>

<h4>Back-end</h4>
<ul>
  <li>ASP.NET Core 5</li>
  <li>Entity Framework Core 5.5</li>
  <li>Flunt Validation 1.0.5</li>
  <li>Swagger UI 6.1.3</li>
  <li>Sql Server</li>
  <li>X Unit 2.4.1</li>
  <li>Dapper 2.0.78</li>
  <li>Fluent Assertion 5.10.3</li>
  <li>DDD (Domanin Driven Design)</li>
  <li>Repository Pattern</li>
  <li>Unit of Work</li>
  <li>Mapper by Extension Methods</li>
  <li>Notification Pattern</li>
  <li>Value Types</li>
  <li>Autenticação JWT(JSON Web Tokens)</li>
</ul>

<h4>Front-end</h4>
<ul>
  <li>Angular CLI 6.0.8</li>
  <li>Node 12.16.3</li>
  <li>Angular 6.1.10</li>
  <li>Rxjs 6.0.0</li>
  <li>Typescript 2.7.2</li>
  <li>Webpack 4.8.3</li>
  <li>SPA (Single Page Application)</li>
</ul>

<hr>

<h3>Executando o Projeto</h3>

<strong>Este projeto utiliza Docker, desta forma precisa ter a ferramenta instalada na máquina. Dito isto, segue os seguintes passos: </strong>

1º: Certifique-se também que as portas ```4200, 64978 e 1433``` estão liberadas.

2º: Após baixar o projeto, abra o terminal e entre na raiz ToDo-API e ToDo-UI do projeto e execute o comando:
```docker-compose up --build```


Para acessar a documentação iterativa da API, basta acessar: http://localhost:64978/swagger/index.html

Para acessar a aplicação, basta acessar: http://localhost:4200/

Credenciais previamente cadastradas: 
```
usuario: admin
senha: admin
```

<hr>

<h3>Melhorias futuras</h3>
<ul>
  <li>Melhoria na UX</li>
  <li>Teste de UX</li>
  <li>Recurso de reserva livro (Já foi criado toda a estrutura de BD)</li>
  <li>Cancelar uma reserva</li>
  <li>Notificação ao usuário, preferêncialmente por email (Criar um serviço que notifique o usuário)</li>
  <li>Implementar mais camadas se segurança na API, para limitar os recursos que só podem ser acessados por um usuário administrador</li>
  <li>Desejável que tenha um relatório de histórico de empréstimos/reserva por usuário e etc.</li>
</ul>
