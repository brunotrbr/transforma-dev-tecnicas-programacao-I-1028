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
        }
    }
}
