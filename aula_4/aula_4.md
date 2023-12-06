# Aula 4

## Utilizando interfaces nativas de coleções do .NET

O .NET possui diversas interfaces nativas que podemos reaproveitar em nosso código. Entre elas podemos citar `IEnumerable`, `IEnumerator`, `ICollection` e `IList`. Para utilizá-las, devemos implementar em nossas classe e escrever a implementação dos métodos herdados.


## IEnumerable

É a interface mais básica do .NET. Sua interface contém um iterador padrão, chamado de GetEnumerator, que pemite iterar sobre uma determinada coleção.

É somente leitura, e sua iteração tem somente um sentido de movimento: do início ao final da coleção.

```csharp

```

&nbsp;

## IEnumerator

IEnumerator é a interface utilizada para se movimentar através da coleção, através de métodos como `MoveNext()` para avançar na coleção e `Current` para recuperar o elemento atual. Possui também um método chamado `Reset` para reiniciar a iteração pela coleção.

```csharp

```

&nbsp;

## ICollection

A interface ICollection estende a interface IEnumerable, e adiciona métodos para modificar a coleção, como `Add()`, `Remove()`, `Clear()` e `CopyTo()`. Ao implementar ela, a coleção passa a ser tanto para leitura como para escrita.

```csharp

```

&nbsp;

## IList

A interface IList estende a interface ICollection, e adiciona métodos para acessar a coleção por índice, como `this[int index]`, `IndexOf()`, `Insert()` e `RemoveAt()`.

```csharp

```

&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/q194GuiGH5tsUbT68


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.