# Aula 6

# Linq
- Material de apoio:
https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries

&nbsp;

> O conteúdo da aula 6 será visto utilizando o projeto "DesafioFinal"


Vamos primeiro considerar nossa base de clientes, carregada para o banco de dados em memória.

Uma das formas de recuperar os dados é através do contexto do banco de dados com alguns métodos próprios do entity framework, conforme visto abaixo:

```csharp
var clientes = await context.Clientes.ToListAsync();
var primeiros20 = clientes.Take(20);
var prim = clientes.First();
```

&nbsp;

Apesar de funcional, isso tem um custo. Recuperamos todos os dados do banco e trabalhamos com eles em memória. Para bancos pequenos isso não é um problema, mas bancos maiores (500GB em dados, 1 TB, etc) pode ser uma abordagem inviável.

Uma alternativa a isso é utilizar o Linq (Language Integrated Query). Com ele podemos escrever de forma semelhante a sintaxe SQL, e os resultados são processados `somente quando forem utilizados` (a chamada `Execução Adiada`).

```csharp
// Criação de uma consulta
IQueryable<Clientes> consulta =
from cliente in context.Clientes
select cliente;
```

&nbsp;

Reparem que a declaração da consulta não executa a consulta de fato. Para forçar sua execução, precisamos realizar alguma ação nela (um foreach, um count, etc).

```csharp
// Execução da consulta
foreach(var cliente in consulta)
{
    Console.WriteLine($"Nome: {cliente.first_name}, Cidade: {cliente.city}");
}
```

&nbsp;

Nem todos os campos da consulta com Linq são obrigatórios. 

```csharp
// Criação de uma consulta
IQueryable<Clientes> consultaPorCidade =    // variavel da query
from cliente in context.Clientes            // obrigatório
where cliente.city == "Bruxelles"           // opcional
orderby cliente.first_name                  // opcional
select cliente;                             // obrigatório, precisa acabar a query com select ou group

// Execução da consulta
var lista = consultaPorCidade.ToList();
foreach (var cliente in lista)
{
    Console.WriteLine($"Nome: {cliente.first_name}, Cidade: {cliente.city}");
}
```

&nbsp;

É importante observar também que, caso seja devolvida a consulta com o group, precisamos ajustar a saída para buscar exatamente os valores agrupados.

```csharp

```

&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/Yg6pSQFaoSYtZ4nG8


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.