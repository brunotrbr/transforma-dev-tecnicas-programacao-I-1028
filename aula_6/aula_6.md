# Aula 6

# Linq
- Material de apoio:
https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries

&nbsp;

> O conteúdo da aula 6 será visto utilizando o projeto "DesafioFinal"


Vamos primeiro considerar nossa base de clientes, carregada para o banco de dados em memória.

Uma das formas de recuperar os dados é através do contexto do banco de dados com alguns métodos próprios do entity framework, conforme visto abaixo:

```csharp

```

&nbsp;

Apesar de funcional, isso tem um custo. Recuperamos todos os dados do banco e trabalhamos com eles em memória. Para bancos pequenos isso não é um problema, mas bancos maiores (500GB em dados, 1 TB, etc) pode ser uma abordagem inviável.

Uma alternativa a isso é utilizar o Linq (Language Integrated Query). Com ele podemos escrever de forma semelhante a sintaxe SQL, e os resultados são processados `somente quando forem utilizados` (a chamada `Execução Adiada`).

```csharp

```

&nbsp;

Reparem que a declaração da consulta não executa a consulta de fato. Para forçar sua execução, precisamos realizar alguma ação nela (um foreach, um count, etc).

```csharp

```

&nbsp;

Nem todos os campos da consulta com Linq são obrigatórios. 

```csharp

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