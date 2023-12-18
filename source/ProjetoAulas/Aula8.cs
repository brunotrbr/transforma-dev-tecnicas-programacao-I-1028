namespace ProjetoAulas
{
    public static class Aula8
    {
        public static void MapAula8Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_8/tasks", async () =>{
                Task task1 = Task.Factory.StartNew(() => ContarAte10());
                Console.WriteLine();
                task1.Wait();
                Console.WriteLine("Transforma DEV");

                Console.Clear(); 
                Task<List<int>> task2 = Task.Factory.StartNew(() => ContarAte10ComRetorno());
                var resultado = task2.Result;
                foreach(var item in resultado){
                    Console.WriteLine(item);
                }

                Console.Clear();

                Task task3 = new Task(() => ContarAte10(3));
                Task task4 = new Task(() => ContarAte10(4));

                Console.WriteLine("Aguardando início das tasks");

                task3.Start();
                task4.Start();

                Console.Clear();
                
                var task5 = Task.Factory.StartNew(() => ContarAte10(5));
                var task6 = Task.Factory.StartNew(() => ContarAte10ComDelay(6));
                
                Console.WriteLine("task5 id = {0}", task5.Id);
                Console.WriteLine("task6 id = {0}", task6.Id);

                Task.WaitAll(new Task[] {task5, task6});
                
                Console.WriteLine("Se chegou até aqui, todas as tarefas foram concluídas");
                
                var task7 = Task.Factory.StartNew(() => ContarAte10(7));
                var task8 = Task.Factory.StartNew(() => ContarAte10ComDelay(8));
                
                Console.WriteLine("task7 id = {0}", task7.Id);
                Console.WriteLine("task8 id = {0}", task8.Id);

                var tarefas = new Task[] { task7, task8 };
                int qualTask = Task.WaitAny(tarefas);

                Console.WriteLine($"Se chegou até aqui, pelo menos uma das tarefas foi concluída, a tarefa id {tarefas[qualTask].Id}");
            });

            app.MapGet("/aula_8/async", async () =>{
        });
        }

        static void ContarAte10(int? taskNumber = null){
            if (taskNumber.HasValue){
                for(int i = 0; i < 10; i++){
                    Console.WriteLine($"Executando tarefa. Task {taskNumber.Value} Contagem: {i}");
                }
            } else {
                for(int i = 0; i < 10; i++){
                    Console.WriteLine($"Executando tarefa. Contagem: {i}");
                }
            }
        }

        static List<int> ContarAte10ComRetorno(){
            var resultado = new List<int>();
            for(int i = 0; i < 10; i++){
                Console.WriteLine($"Executando tarefa com intervalo. Contagem: {i}");
                resultado.Add(i);
            }
            return resultado;
        }

        static void ContarAte10ComDelay(int taskNumber){
            for(int i = 0; i < 10; i++){
                    Console.WriteLine($"Executando tarefa. Task {taskNumber} Contagem: {i}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Executando tarefa. Task {taskNumber} Contagem: {i}");
                }
        }
    }
}