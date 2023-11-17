using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.MapGet("/aula_2_arrays", () =>
{
    // Declaração implícita de um array de inteiros
    int[] numeros = new int[10];

    for(int i = 0; i < numeros.Length; i++)
    {
        Console.WriteLine(numeros[i]);
    }

    Console.Clear();

    // Declaração explícita de um array de strings
    string[] nomes = new string[] { "Pedro", "Ana", "Lucas" };

    for (int i = 0; i < nomes.Length; i++)
    {
        Console.WriteLine(nomes[i]);
    }

    Console.Clear();

    // Declaração implícita de um array bidimensional de inteiros
    int[,] matriz = new int[10, 20];

    Console.WriteLine(matriz[0, 1]);

    matriz[0, 1] = 27;

    Console.WriteLine(matriz[0, 1]);

    Console.Clear();

    // Declaração explícita de um array multidimensional de inteiros
    int[,,] cubo = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                        { { 7, 8, 9 }, { 10, 11, 12 } } };

    for (int i = 0; i < cubo.GetLength(0); i++)
    {
        for (int j = 0; j < cubo.GetLength(1); j++)
        {
            for (int k = 0; k < cubo.GetLength(2); k++)
            {
                Console.Write($"{cubo[i, j, k]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    Console.Clear();

    int[][] matrizIrregular = new int[3][];

    matrizIrregular[0] = new int[] { 1, 3, 5, 7, 9 };
    matrizIrregular[1] = new int[] { 0, 2, 4, 6 };
    matrizIrregular[2] = new int[] { 11, 22 };

    for(int i = 0; i < matrizIrregular.GetLength(0); i++)
    {
        for (int j = 0; j < matrizIrregular[i].Length; j++)
        {
            Console.Write($"{matrizIrregular[i][j]} ");
        }
        Console.WriteLine();
    }

    Console.Clear();

    // Adiciona valores no array
    numeros = new int[10];

    for(int i = 0; i < numeros.GetLength(0); i++)
    {
        numeros[i] = i*2;
    }

    for (int i = 0; i < numeros.GetLength(0); i++)
    {
        Console.WriteLine($"numeros[{i}] = {numeros[i]}");
    }
    Console.WriteLine();

    // Quero adicionar o número 50 ao final do array
    int[] novoArray = new int[11];

    for (int i = 0; i < novoArray.GetLength(0); i++)
    {
        Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
    }
    Console.WriteLine();

    for (int i = 0; i < numeros.Length; i++)
    {
        novoArray[i] = numeros[i];
    }

    novoArray[novoArray.Length-1] = 50;

    numeros = novoArray;

    for (int i = 0; i < numeros.GetLength(0); i++)
    {
        Console.WriteLine($"numeros[{i}] = {numeros[i]}");
    }
    Console.Clear();

    // Adicionar o número 66 no final do array
    numeros = numeros.ToList().Append(66).ToArray();

    for (int i = 0; i < numeros.GetLength(0); i++)
    {
        Console.WriteLine($"numeros[{i}] = {numeros[i]}");
    }

    return "Ver console";

    
});

app.MapGet("/aula_2_list", () =>
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

    listaUm.ForEach((x) => Console.WriteLine(x));

    Console.Clear();

    listaUm.ForEach((x) => Console.WriteLine(x));

    var removido = listaUm.Remove(6);
    Console.WriteLine(removido);
    removido = listaUm.Remove(6);
    Console.WriteLine(removido);
    Console.WriteLine();

    listaUm.ForEach((x) => Console.WriteLine(x));

    Console.Clear();

    listaUm.RemoveAt(10);

    listaUm.ForEach((x) => Console.WriteLine(x));

    Console.Clear();

    listaUm.Reverse();

    listaUm.ForEach((x) => Console.WriteLine(x));

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

    listaUm.ForEach((x) => Console.WriteLine(x));

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

    listaUm.ForEach((x) => Console.WriteLine(x));

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

app.MapGet("/aula_2_ex_1", () =>
{
    string[] capitais = new string[5];

    capitais[0] = "Brasília";
    capitais[1] = "São Paulo";
    capitais[2] = "Rio de Janeiro";
    capitais[3] = "Belo Horizonte";
    capitais[4] = "Salvador";

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("A capital brasileira de número {0} é: {1}", i + 1, capitais[i]);
    }
});

app.MapGet("/aula_2_ex_2", () =>
{
    int[,] matriz = new int[3, 4];

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            matriz[i, j] = 0;
        }
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.WriteLine("O elemento [{0}, {1}] da matriz é: {2}", i, j, matriz[i, j]);
        }
    }
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
    var resposta = EhPalindromo(param["texto"]);
    return resposta;
});

app.MapGet("/ex_9", ([FromBody] Dictionary<string, Queue<int>> param, [FromQuery] int tempo) => {
    EscalonarTarefas(param["tarefas"], tempo);
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

static bool EhPalindromo(string palavra)
{
    Queue<char> fila = new Queue<char>();

    foreach (char c in palavra)
    {
        fila.Enqueue(c);
    }

    while (fila.Count > 0)
    {
        if (fila.Dequeue() != palavra[0])
        {
            return false;
        }
        palavra = palavra.Substring(1);
    }

    return true;
}

static void EscalonarTarefas(Queue<int> tarefas, int tempoDeExecucao)
{   
    int contador = 0;
    foreach(int i in tarefas)
    {
        while(contador < tempoDeExecucao)
        {
            Console.WriteLine($"Executando tarefa {i}");
            contador++;
        }
        Console.WriteLine();
        contador = 0;
    }
}