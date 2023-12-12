using System.Collections;

namespace ProjetoAulas
{
    public static class Aula4
    {
        public static void MapAula4Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_4", () => {
                // IEnumerable, IEnumerator
                Teste t = new Teste();
                t.Add(5);
                t.Add(8);
                t.Add(null);
                t.Add(12);
                t.Add(66);

                //for(int i = 0; i < t.Count(); i++)
                //{
                //    Console.WriteLine(t[i]); // Não funciona porque o código ainda não permite o acesso por índice
                //    Console.WriteLine(t.Itens); // Itens é privado na classe Teste
                //}

                foreach(int? item in t)
                {
                    Console.WriteLine($"valor: {item}"); 
                }

                // ICollection
                t.Clear();
                t.Add(6);
                var tem = t.Contains(6);
                tem = t.Contains(8);
                t.Add(9);
                var removido = t.Remove(6);
                removido = t.Remove(8);
                removido = t.Remove(9);

                foreach (int? item in t)
                {
                    Console.WriteLine($"valor: {item}");
                }

                t.Add(6);
                t.Add(12);
                t.Add(45);
                t.Add(39);

                int?[] novoArray = new int?[10];
                t.CopyTo(novoArray, 2);

                foreach (int? item in novoArray)
                {
                    Console.WriteLine($"valor: {item}");
                }

                Console.Clear();

                // IList
                t.Clear();
                t.Insert(0, 1);
                t.Add(9);
                t.Insert(1, 25);
                t.RemoveAt(1);

                return "Transforma DEV";
            });
        }
    }

    public class Teste : IEnumerable<int?>, IEnumerator<int?>, ICollection<int?>, IList<int?>
    {
        private int?[] Itens = new int?[0];

        private int currentIndex = -1;
        public int? Current => Itens[currentIndex];

        object IEnumerator.Current => Current;

        public int Count => Itens.Length;

        public bool IsReadOnly => false;

        public int? this[int index] { get => Itens[index]; set => Itens[index] = value; }

        public void Add(int? item)
        {
            // A cada adição, redimensionamos o array
            var to_add = Itens.Length == 0 ? 2 : 1;
            Array.Resize(ref Itens, Itens.Length + to_add);
            Itens[Itens.Length - 2] = item;
        }

        public int?[] GetArray()
        {
            return Itens;
        }
        public IEnumerator<int?> GetEnumerator()
        {
            // Implementação do IEnumerable
            //foreach(int? num in Itens)
            //{
            //    if(num == null)
            //    {
            //        yield break;
            //    }
            //    Console.WriteLine($"foreach do GetEnumerator. valor: {num}");
            //    yield return num;

            //    //[1, 3, 5, 7, 9]
            //    //// retornei o número 1, e o próxima a retornar é o número 3
            //    //// posterga a avaliação dos números até que seja solicitado novamente.
            //}
            // Implementação do IEnumerator
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < Itens.Length && Itens[currentIndex] != null;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {
            // Alguma ação ao finalizar a iteração, caso seja necessário.
            Console.WriteLine("dispose");
        }

        public void Clear()
        {
            Itens = new int?[0];
        }

        public bool Contains(int? item)
        {
            return Array.IndexOf(Itens, item) != -1;
        }

        public bool Remove(int? item)
        {
            int index = Array.IndexOf(Itens, item);
            if(index == -1)
            {
                return false;
            }

            for(int i = index; i < Itens.Length-1; i++)
            {
                Itens[i] = Itens[i + 1];
                // antes do for
                // [2, 6, 8, 10]
                // depois do for
                //[6, 8, 10, 10]
            }
            Array.Resize(ref Itens, Itens.Length - 1);
            // depois do resize
            //[6, 8, 10]
            return true;
        }

        public void CopyTo(int?[] array, int arrayIndex)
        {
            if(array == null)
            {
                throw new ArgumentNullException("array");
            }

            if(arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("Índice inválido. Menor que zero ou mairo que tamanho do array.");
            }

            if(array.Length - arrayIndex < Itens.Length)
            {
                throw new ArgumentException("Array de destino não possui tamanho suficiente.");
            }

            int destIndex = arrayIndex;
            foreach(int? num in Itens)
            {
                if(num == null)
                {
                    break;
                }
                array[destIndex++] = num;
            }
        }

        public int IndexOf(int? item)
        {
            return Array.IndexOf(Itens, item);
        }

        public void Insert(int index, int? item)
        {
            var to_add = Itens.Length == 0 ? 2 : 1;
            Array.Resize(ref Itens, Itens.Length + to_add);
            for(int i = Itens.Length - 1; i > index; i--)
            {
                Itens[i] = Itens[i - 1];
            }
            Itens[index] = item;

        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < Itens.Length - 1; i++)
            {
                Itens[i] = Itens[i + 1];
            }
            Array.Resize(ref Itens, Itens.Length - 1);
        }
    }
}