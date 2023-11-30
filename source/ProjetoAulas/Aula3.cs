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
        }
    }
}
