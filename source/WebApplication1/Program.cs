using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.MapGet("/aula_2", () =>
{
    List<int> listaUm = new List<int>();
    List<string> listaDois = new List<string>();

    listaUm.Add(1);
    listaDois.Add("2");

    Console.WriteLine(listaUm[0]);
    Console.WriteLine(listaDois[0]);
    // Console.WriteLine(listaUm[2]);

    Console.Clear();

    for (int i = 2; i < 10; i++)
    {
        listaUm.Add(i);
    }

    // E aqui de bônus já tem uma forma de percorrer a lista
    foreach (int item in listaUm)
    {
        Console.WriteLine(item);
    }

    Console.Clear();

    var listaTres = new List<int>() { 10, 11, 12, 13, 14, 15 };

    listaUm.AddRange(listaTres);

    // E aqui de bônus já tem uma forma de percorrer a lista
    for (int i = 0; i < listaUm.Count; i++)
    { 
        Console.WriteLine(listaUm[i]);
    }

    Console.Clear();

    foreach (int item in listaUm)
    {
        Console.WriteLine(item);
    }

    var removido = listaUm.Remove(6);
    Console.WriteLine(removido);
    removido = listaUm.Remove(6);
    Console.WriteLine(removido);
    Console.WriteLine();

    foreach (int item in listaUm)
    {
        Console.WriteLine(item);
    }

    Console.Clear();

    listaUm.RemoveAt(10);

    foreach (int item in listaUm)
    {
        Console.WriteLine(item);
    }

    Console.Clear();

    listaUm.Reverse();

    foreach(int item in listaUm)
    {
        Console.WriteLine(item);
    }

    Console.Clear();

    Console.WriteLine(listaUm.ElementAt(2));

    Console.Clear();

    Console.WriteLine(listaUm.First());
    Console.WriteLine(listaUm[0]);

    var listaVazia = new List<int>();
    Console.WriteLine(listaVazia.FirstOrDefault());
    // Console.WriteLine(listaVazia.First()); // System.InvalidOperationException: 'Sequence contains no elements'

    Console.Clear();

    listaUm.AddRange(listaUm);

    foreach(int item in listaUm)
    {
        Console.WriteLine(item);
    }

    var conjunto = listaUm.ToHashSet();
    Console.WriteLine();

    foreach (int item in conjunto)
    {
        Console.WriteLine(item);
    }

    Console.Clear();

    var todosAtendem = listaUm.All(x => x < 100);

    Console.WriteLine(todosAtendem);

    todosAtendem = listaUm.All(x => x > 10);

    Console.WriteLine(todosAtendem);

    Console.Clear();

    var algumAtende = listaUm.Any(x => x > 10);

    Console.WriteLine(algumAtende);

    Console.Clear();

    Stack<int> pilha = new Stack<int>();

    pilha.Push(1);
    pilha.Push(5);
    pilha.Push(8);

    foreach(int item in pilha)
    {
        Console.WriteLine(item);
    }

    Console.Clear();

    var elemento = pilha.Pop();

    Console.WriteLine($"O item {elemento} foi removido.");

    foreach (int item in pilha)
    {
        Console.WriteLine(item);
    }

    //Console.Clear();

    //pilha.Pop();
    //pilha.Pop();
    //pilha.Pop();

    Console.Clear();

    pilha.Push(3);
    pilha.Push(9);
    pilha.Push(1);

    var topo = pilha.Peek();

    Console.WriteLine(topo);

    Console.Clear();

    Queue<string> fila = new Queue<string>();

    fila.Enqueue("Primeiro");
    fila.Enqueue("Segundo");
    fila.Enqueue("Terceiro");

    foreach (string item in fila)
    {
        Console.WriteLine(item);
    }

    Console.Clear();

    var itemRemovido = fila.Dequeue();
    
    Console.WriteLine(itemRemovido);

    Console.Clear();

    Console.WriteLine(fila.Peek());

    Console.Clear();

    fila.Dequeue();
    fila.Dequeue();

    // Console.WriteLine(fila.Peek()); // System.InvalidOperationException: 'Queue empty.'

    Console.Clear();


    return "Ver console";
});

app.MapGet("/ex_1", ([FromBody]Dictionary<string, List<int>> param) => {
    var resposta = SumEvenNumbers(param["lista"]);
    return resposta;
});

app.MapGet("/ex_2", ([FromBody] Dictionary<string, List<string>> param) => {
    var resposta = FiltrarStringsLongas(param["lista"]);
    return string.Join(", ", resposta);
});

app.MapGet("/ex_3", ([FromBody] Dictionary<string, List<int>> param) => {
    var resposta = NumerosQuadrados(param["lista"]);
    return string.Join(", ", resposta);
});

app.MapGet("/ex_4", ([FromBody] Dictionary<string, string> param) => {
    var resposta = ReverterString(param["texto"]);
    return resposta;
});

app.MapGet("/ex_5", ([FromBody] Dictionary<string, string> param) => {
    var resposta = VerificarExpressaoBalanceada(param["texto"]);
    return resposta;
});

app.MapGet("/ex_6", ([FromBody] Dictionary<string, string> param) => {
    var resposta = AvaliarExpressaoPosfixada(param["texto"]);
    return resposta;
});

app.MapGet("/ex_7", ([FromBody] Dictionary<string, int> param) => {
    var resposta = BatataQuente(param["jogadores"], param["tempoAteExplodir"]);
    return resposta;
});

app.MapGet("/ex_8", ([FromBody] Dictionary<string, string> param) => {
    var resposta = AvaliarExpressaoPosfixada(param["texto"]);
    return resposta;
});

app.MapGet("/ex_9", ([FromBody] Dictionary<string, string> param) => {
    var resposta = AvaliarExpressaoPosfixada(param["texto"]);
    return resposta;
});

app.Run();

static int SumEvenNumbers(List<int> numbers)
{
    int sum = 0;
    foreach (int number in numbers)
    {
        if (number % 2 == 0)
        {
            sum += number;
        }
    }

    return sum;
}

static List<string> FiltrarStringsLongas(List<string> strings)
{
    List<string> novasStrings = new List<string>();
    foreach (string str in strings)
    {
        if (str.Length > 5)
        {
            novasStrings.Add(str);
        }
    }

    return novasStrings;
}

static List<int> NumerosQuadrados(List<int> numeros)
{
    List<int> qudrados = new List<int>();
    foreach (int numero in numeros)
    {
        qudrados.Add(numero * numero);
    }

    return qudrados;
}

static string ReverterString(string str)
{
    Stack<char> pilha = new Stack<char>();
    for (int i = 0; i < str.Length; i++)
    {
        pilha.Push(str[i]);
    }

    StringBuilder stringReversa = new StringBuilder();
    while (pilha.Count > 0)
    {
        stringReversa.Append(pilha.Pop());
    }

    return stringReversa.ToString();
}

static bool VerificarExpressaoBalanceada(string expressao)
{
    Stack<char> pilha = new Stack<char>();
    for (int i = 0; i < expressao.Length; i++)
    {
        if (expressao[i] == '(' || expressao[i] == '[' || expressao[i] == '{')
        {
            pilha.Push(expressao[i]);
        }
        else if (expressao[i] == ')' || expressao[i] == ']' || expressao[i] == '}')
        {
            if (pilha.Count == 0)
            {
                return false;
            }

            char abertura = pilha.Pop();
            if (abertura == '(' && expressao[i] != ')')
            {
                return false;
            }
            else if (abertura == '[' && expressao[i] != ']')
            {
                return false;
            }
            else if (abertura == '{' && expressao[i] != '}')
            {
                return false;
            }
        }
    }

    return pilha.Count == 0;
}

static int AvaliarExpressaoPosfixada(string expressao)
{
    Stack<int> pilha = new Stack<int>();
    for (int i = 0; i < expressao.Length; i++)
    {
        if (char.IsDigit(expressao[i]))
        {
            pilha.Push(int.Parse(expressao[i].ToString()));
        }
        else
        {
            int operador1 = pilha.Pop();
            int operador2 = pilha.Pop();

            switch (expressao[i])
            {
                case '+':
                    pilha.Push(operador2 + operador1);
                    break;
                case '-':
                    pilha.Push(operador2 - operador1);
                    break;
                case '*':
                    pilha.Push(operador2 * operador1);
                    break;
                case '/':
                    pilha.Push(operador2 / operador1);
                    break;
                default:
                    throw new Exception("Operador inválido");
            }
        }
    }

    return pilha.Pop();
}

static string BatataQuente(int numJogadores, int tempoAteExplodir)
{
    Queue<int> jogadores = new Queue<int>();
    for (int i = 0; i < numJogadores; i++)
    {
        jogadores.Enqueue(i);
    }

    int atualJogador = 0;
    int passes = 0;

    while (jogadores.Count > 1)
    {
        passes++;

        if (passes == tempoAteExplodir)
        {
            jogadores.Dequeue();
            passes = 0;
        }
        else
        {
            atualJogador = (atualJogador + 1) % numJogadores;
            int player = jogadores.Dequeue();
            jogadores.Enqueue(player);
        }
    }

    return $"Jogador {jogadores.Dequeue()} venceu!";
}

