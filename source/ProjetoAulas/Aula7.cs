using System.Diagnostics;
using System.Security.Cryptography;

namespace ProjetoAulas
{
    public static class Aula7
    {
        public static void MapAula7Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_7", () =>{
                Console.WriteLine("Aula 7");
                // Thread.Sleep(15000);

                Console.WriteLine("Aperte enter para inicar");
                Console.ReadLine();

                DateTime start = DateTime.UtcNow;
                ProcessarLaco();
                DateTime stop = DateTime.UtcNow;
                TimeSpan ts = stop - start;
                Console.WriteLine($"[Síncrono] {ts.TotalMilliseconds}");
                Console.WriteLine("\n");
                
                start = DateTime.UtcNow;
                Parallel.For(0, 11, i => Console.WriteLine($"[Parallel.For] Valor := {i}, Thread := {Thread.CurrentThread.ManagedThreadId}"));
                stop = DateTime.UtcNow;
                ts = stop - start;
                Console.WriteLine($"[Parallel.For] {ts.TotalMilliseconds}");
                Console.WriteLine("\n");

                List<int> inteiros = new List<int>();
                for(int i = 0; i <= 10; i++){
                    inteiros.Add(i);
                }
                start = DateTime.UtcNow;
                Parallel.ForEach(inteiros, i => Console.WriteLine($"[Parallel.ForEach] Valor := {i}, Thread := {Thread.CurrentThread.ManagedThreadId}"));
                stop = DateTime.UtcNow;
                ts = stop - start;
                Console.WriteLine($"[Parallel.ForEach] {ts.TotalMilliseconds}");
                Console.WriteLine("\n");
                
                return "Transforma DEV";
            });

            static void ProcessarLaco(){
                for(int i = 0; i <= 10; i++){
                    Console.WriteLine($"[Síncrono] Valor := {i} \t Thread := {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }
    }
}