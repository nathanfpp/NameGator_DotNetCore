# NameGator_DotNetCore
Desenvolvimento da aplicação NameGator com backend em dotnet core.

Nota, para o funcionamento correto da aplicação é preciso executar back-end primeiro.

# Front-end

O front-end da aplicação é feito em Vue.js e se comporta de forma muito similar à aplicação original. A grande diferênça é que quando a aplicação é criada, ao invés do Axios chamar o web service Node via GraphQL, eu chamo um WebAPI desenvolvido em dotnet core + EntityFramework core.

- Comando para subir a aplicação: npn run serve

# Back-end

o back-end é desenvolvido em dotnet core utilizando a ideia de Model e Controller.

- Startup.cs: Inicialização do banco de dados através de um método estático, também é feita a injeção de dependência para que o context seja passado ao Controller e o mesmo consiga retornar todos os itens.
- ItemController.cs: Lida trás as informações requisitadas pelo front-end, através de um HTTP GET.
- Item.cs: Classe do modelo em que é definido o objeto Item, em que ID é o inteiro usado pelo EF para identificar unicamente a tupla.
- ItemContext.cs: Estende o DbContext, sendo responsável por interagir com o banco de dados. Nesta classe, temos o atributo itens, usado para o transportar os dados que serão integrados na tabela do banco.

# Referências:

- Repositório do Rodrigo Branas: https://github.com/rodrigobranas/youtube/tree/master/fullstack_vue_graphql_node_5 da aplicação NameGator desenvolvida por
video aulas no youtube.

- Tutorial do marcoratti: https://www.youtube.com/watch?v=29MhoO9h-a0
