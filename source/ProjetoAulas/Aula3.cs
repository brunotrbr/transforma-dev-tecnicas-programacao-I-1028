using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System;

namespace ProjetoAulas
{
    public static class Aula3
    {
        public static void MapAula3Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_3/queue", () =>
            {
                Queue<string> fila = new Queue<string>();

                fila.Enqueue("Primeiro");
                fila.Enqueue("Segundo");
                fila.Enqueue("Terceiro");
                
                foreach(var item in fila)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                Console.WriteLine(fila.Dequeue());

                Console.WriteLine();

                foreach (var item in fila)
                {
                    Console.WriteLine(item);
                }

                // fila.Dequeue();
                // fila.Dequeue();
                // fila.Dequeue(); // System.InvalidOperationException: 'Queue empty.'

                Console.WriteLine();
                Console.WriteLine(fila.Peek());
                
                
                

                return "Aula 3 - Filas";
            });

            app.MapGet("/aula_3/ex_3", () =>
            {
                //3) Um escalonador de tarefas é um sistema que gerencia a execução de tarefas no computador. Utilize filas para implementar um escalonador de tarefas simples, que execute elas na ordem que forem submetidas. A função não precisa ter nenhum retorno. Obs: As tarefas executam por um período x de tempo.
                int tempoDeExecucao = 4;
                Queue<int> tarefas = new Queue<int>();
                for(int i = 0; i < 7; i++)
                {
                    tarefas.Enqueue(i);
                }

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
            });

            app.MapGet("/aula_3/dictionary", () =>
            {
                Dictionary<string, int> dicionario = new Dictionary<string, int>();

                dicionario.Add("chave", 1);
                dicionario.Add("nova chave", 89);
                Console.WriteLine(dicionario.TryAdd("outra chave", 75));
                Console.WriteLine(dicionario.TryAdd("nova chave", 2));
                //dicionario.Add("nova chave", 88); // System.ArgumentException: 'An item with the same key has already been added. Key: nova chave'

                Console.WriteLine(dicionario["nova chave"]);
                // Console.WriteLine(dicionario["chave qualquer"]); // System.Collections.Generic.KeyNotFoundException: 'The given key 'chave qualquer' was not present in the dictionary.'

                int valor;
                if (dicionario.TryGetValue("nova chave", out valor))
                {
                    Console.WriteLine(valor);
                }
                else
                {
                    Console.WriteLine("Dicionário não possui a chave \"nova chave\"");
                }

                // Retornar somente as chaves ou somente os valores
                var chaves = dicionario.Keys;
                var valores = dicionario.Values;
                

                if (dicionario.ContainsKey("nova chave"))
                {
                    Console.WriteLine(dicionario["nova chave"]);
                }
                else
                {
                    Console.WriteLine("Dicionário não possui a chave \"nova chave\"");
                }

                Console.Clear();
                foreach(KeyValuePair<string, int> kvp in dicionario)
                {
                    Console.WriteLine($"dicionario[{kvp.Key}] = {kvp.Value}");
                }

                Console.WriteLine();
                foreach (var kvp in dicionario)
                {
                    Console.WriteLine($"dicionario[{kvp.Key}] = {kvp.Value}");
                }

                Console.Clear();
                Console.WriteLine(dicionario.Remove("chave"));
                foreach (KeyValuePair<string, int> kvp in dicionario)
                {
                    Console.WriteLine($"dicionario[{kvp.Key}] = {kvp.Value}");
                }

                if (dicionario.TryGetValue("nova chave", out valor))
                {
                    if(dicionario.Remove("nova chave"))
                    {
                        Console.WriteLine($"Valor removido: {valor}");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível remover a chave \"nova chave\"");
                    }
                }
                else
                {
                    Console.WriteLine("Dicionário não possui a chave \"nova chave\"");
                }


                return "Transforma DEV";
            });
        }
    }
}
