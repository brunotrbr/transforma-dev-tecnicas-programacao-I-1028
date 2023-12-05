using System;
using System.Text;

namespace ProjetoAulas
{
    public static class Aula2
    {
        public static void MapAula2Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_2/generics", () =>
            {
                List<int> listaUm = new List<int>();
                List<string> listaDois = new List<string>();

                listaUm.Add(1);
                listaDois.Add("2");

                Console.WriteLine(listaUm[0]);
                Console.WriteLine(listaDois.ElementAt(0));

                return "Aula 2";
            });

            app.MapGet("/aula_2/arrays", () =>
            {
                // Declaração implícita
                int[] numeros = new int[10];

                for (int i = 0; i < numeros.Length; i++)
                {
                    Console.WriteLine(numeros[i]);
                }
                Console.Clear();

                // Declaração explícita
                string[] nomes = new string[] { "Anderson", "Bruno", "João" };

                for(int i = 0; i < nomes.Length; i++)
                {
                    Console.WriteLine(nomes[i]);
                }

                //try
                //{
                //    Console.WriteLine(nomes[3]);
                //} catch(IndexOutOfRangeException e)
                //{
                //    Console.WriteLine("Acesso indevido.");
                //    Console.WriteLine(e.Message);
                //    Console.WriteLine(e.StackTrace);
                //}
                Console.Clear();

                // Array Bidimensional, ou Matriz
                // O índice da esquerda deve ser entendido com a linha
                // O indice da direita deve ser entendido como a coluna
                int[,] matriz = new int[10, 20];

                Console.WriteLine(matriz[0, 1]);

                matriz[0, 1] = 2;

                Console.WriteLine(matriz[0, 1]);

                Console.Clear();

                // Declaração de matriz irregular, cujos tamanhos podem ser diferentes
                // A segunda dimensão inicializa com valor null

                int[][] matrizIrregular = new int[3][];

                matrizIrregular[0] = new int[] { 1, 3, 5, 7, 9 };
                matrizIrregular[1] = new int[] { 2, 4, 6, 8 };
                matrizIrregular[2] = new int[] { 11, 22 };

                for(int i = 0; i < matrizIrregular.GetLength(0); i++) {
                    for (int j = 0; j < matrizIrregular[i].Length; j++)
                    {
                        Console.WriteLine($"{matrizIrregular[i][j]}");
                    }
                    Console.WriteLine();
                }
                Console.Clear();

                for(int i = 0; i < numeros.Length; i++)
                {
                    numeros[i] = i * 2;
                }

                for (int i = 0; i < numeros.Length; i++)
                {
                    Console.WriteLine($"numeros[{i}] = {numeros[i]}");
                }

                int[] novoArray = new int[20];

                for (int i = 0; i < numeros.Length; i++)
                {
                    novoArray[i] = numeros[i];
                }

                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }

                novoArray[numeros.Length] = 20;

                Console.WriteLine();
                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }
                Console.Clear();

                Console.WriteLine();
                for (int i = 0; i < novoArray.Length; i++)
                {
                    novoArray[i] = i * 2;
                }

                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }

                novoArray = novoArray.ToList().Append(22).ToArray();

                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }
            });

            app.MapGet("/aula_2/list", () =>
            {
                List<int> listaUm = new List<int>();
                List<string> listaDois = new List<string>();

                listaUm.Add(1);
                listaDois.Add("2");

                Console.WriteLine(listaUm[0]);
                Console.WriteLine(listaDois.ElementAt(0));
                Console.Clear();
                List<int> listaTres = new List<int>() { 10, 18, 25, 39, 45 };

                for(int i = 0; i < listaUm.Count; i++)
                {
                    Console.WriteLine(listaUm[i]);
                }

                for (int i = 0; i < listaTres.Count; i++)
                {
                    Console.WriteLine(listaTres[i]);
                }

                listaUm.AddRange(listaTres);

                Console.WriteLine("\n");

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine(listaUm.Remove(45));
                Console.WriteLine(listaUm.Remove(45));
                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine();

                listaUm.RemoveAt(0);
                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine();

                listaUm.RemoveRange(0, 2);

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.Clear();

                for (int i = 0; i < 10; i++)
                {
                    listaUm.Add(i * 2);
                }

                listaUm.ForEach(x => Console.WriteLine(x));

                listaUm.Reverse();

                Console.WriteLine();

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.Clear();

                Console.WriteLine(listaUm.First());

                Console.WriteLine(listaUm.FirstOrDefault());

                Console.WriteLine();

                List<int> listaVazia = new List<int>();

                Console.WriteLine(listaVazia.FirstOrDefault());
                //Console.WriteLine(listaVazia.First()); // System.InvalidOperationException: 'Sequence contains no elements'

                Console.Clear();

                listaUm.ForEach(x => Console.WriteLine(x));

                for (int i = 0; i < 10; i++)
                {
                    listaUm.Add(i * 2);
                }

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine();

                var conjunto = listaUm.ToHashSet();

                foreach(int item in conjunto)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                var todosAtendem = listaUm.All(x => x < 100);
                todosAtendem = listaUm.All(x => x < 100);
                var todosAtendemDois = listaUm.All(x => x < 25);
                
                Console.WriteLine(todosAtendem);
                Console.WriteLine(todosAtendemDois);
                Console.WriteLine();

                var todosMenoresQue10 = listaUm.Where(x => x < 10);

                foreach (var item in todosMenoresQue10)
                {
                    Console.WriteLine(item);
                }

                var algumAtende = listaUm.Any(x => x < 25);
                Console.WriteLine(algumAtende);




                return "Aula 2 - List";
            });

            app.MapGet("/aula_2/stack", () =>
            {
                Stack<int> stack = new Stack<int>();

                stack.Push(1);
                stack.Push(5);
                stack.Push(8);

                foreach(int item in stack)
                {
                    Console.WriteLine(item);
                }

                Console.Clear();

                Console.WriteLine($"Removido o elemento {stack.Pop()}");

                foreach (int item in stack)
                {
                    Console.WriteLine(item);
                }

                stack.Pop();
                stack.Pop();
                // stack.Pop(); // System.InvalidOperationException: 'Stack empty.'

                Console.Clear();


                stack.Push(2);
                stack.Push(4);
                stack.Push(6);

                Console.WriteLine();
                Console.WriteLine(stack.Peek());

                stack.Pop();
                stack.Pop();

                int result;
                if(stack.TryPop(out result) == true)
                {
                    Console.WriteLine(result);
                } else
                {
                    Console.WriteLine("Pilha Vazia");
                }

                if (stack.TryPop(out result) == true)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Pilha Vazia");
                }

                // se for usada a pilha, mas ela estiver vazia, o código quebra.
                // do
                //{
                //    var teste = stack.Peek();
                //} while (stack.TryPop(out result) == true);


                return "Aula 2 - Pilhas";
            });

            app.MapGet("/aula_2/ex_3", () =>
            {
                // 3) Escreva uma função que receba uma lista de números aleatórios e retorne a soma de todos os números pares da lista.
                List<int> lista = new List<int>() { 7, 41, 99, 19, 23, 0, 8, 22, 56, 34 };

                int soma = 0;
                foreach(var numero in lista)
                {
                    // Números pares
                    if (numero % 2 == 0)
                    {
                        soma += numero;
                        // soma = soma + numero
                    }

                    //// Números ímpares
                    //if (numero % 2 != 0)
                    //{
                    //    soma += numero;
                    //    // soma = soma + numero
                    //}
                }

                return soma;
            });

            app.MapGet("/aula_2/ex_4", () =>
            {
                // 4) Escreva uma função que receba uma lista de strings e retorne uma nova lista contendo somente strings que contenham mais que 5 caracteres.

                List<string> strings = new List<string>() { "thread", "codigo", "tranquilo", "programa", "nao", "algoritmo", "curta" };
                // Retorno como string
                //return string.Join(", ", FiltrarStringsLongas(strings));

                // Retorno como json
                // Criação de um objeto anonimo
                // Será utilizado no desafio final
                return new
                {
                    ListaDeStrings = FiltrarStringsLongas(strings),
                    OutroElemento = 1,
                    Encadeados = new
                    {
                        ObjetoEncadeado = "teste"
                    }
                };
            });

            app.MapGet("/aula_2/ex_6", () =>
            {
                // 6) Escreva uma função que receba uma string como entrada e retorne a string ao contrário. Utilize pilhas para resolver esse problema.
                string palavra = "por favor";

                Stack<char> pilha = new Stack<char>();
                for (int i = 0; i < palavra.Length; i++)
                {
                    pilha.Push(palavra[i]);
                }

                StringBuilder stringReversa = new StringBuilder();
                while (pilha.Count > 0)
                {
                    stringReversa.Append(pilha.Pop());
                }

                return stringReversa.ToString();

                // Código do Leandro
                //string stringinformada = "por favor";
                //Stack<char> pilha = new Stack<char>();

                //foreach (char item in stringinformada)
                //{
                //    pilha.Push(item);
                //}

                //char[] stringinformadaInvertida = new char[stringinformada.Length];

                //for (int i = 0; i < stringinformada.Length; i++)
                //{
                //    stringinformadaInvertida[i] = pilha.Pop();
                //}

                //var teste = stringinformadaInvertida.ToString();

                //string stringInvertida = new string(stringinformadaInvertida);

                //return stringInvertida;
            });

            app.MapGet("/aula_2/ex_7", () =>
            {
                // 7) Escreva uma função que receba uma expressão como entrada e verifique se a expressão está balanceada. Uma expressão está balanceada se para cada parênteses de abertura, deve ter um parênteses de fechamento correspondente. Utilize pilhas para resolver esse problema.
                string expressao = "por exemplo {{{[]com ( abertura de )} pa}rentese}(s)";
                
                Stack<char> pilha = new Stack<char>();
                for(int i = 0; i < expressao.Length; i++)
                {
                    if (expressao[i] == '(' || expressao[i] == '{' || expressao[i] == '[')
                    {
                        pilha.Push(expressao[i]);
                    }
                    else if(expressao[i] == ')' || expressao[i] == '}' || expressao[i] == ']')
                    {
                        if(pilha.Count == 0)
                        {
                            return false;
                            // "palavra )"
                        }

                        char abertura = pilha.Pop();
                        if(abertura == '(' && expressao[i] != ')')
                        {
                            return false;
                        }
                        else if(abertura == '{' && expressao[i] != '}')
                        {
                            return false;
                        }
                        else if(abertura == '[' && expressao[i] != ']')
                        {
                            return false;
                        }
                    }
                }
                return pilha.Count == 0;
            });
        }

        static List<string> FiltrarStringsLongas(List<string> strings)
        {
            List<string> resultado = new List<string>();
            foreach (string str in strings)
            {
                if(str.Length > 5)
                {
                    resultado.Add(str);
                }
            }

            return resultado;
        }
    }
}
