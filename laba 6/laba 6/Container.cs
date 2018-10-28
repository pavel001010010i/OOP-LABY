using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    class Army
    {
        public List<IntelligentBeing> data = new List<IntelligentBeing>();
        public static int counter = 0;

        public void Output()
        {
            if (counter == 0)
            {
                Console.WriteLine("Армия пуста, сэр!");
            }
            else
            {
                foreach (object i in data)
                {
                    Console.WriteLine($"Объект {i}");
                }
            }
        }

        public void Remove(IntelligentBeing A)
        {
            data.Remove(A);
        }

        public void ClearArmy()
        {
            if (counter == 0)
            {
                Console.WriteLine("Army пуст");
            }
            else
            {
                counter = 0;
                data.Clear();
                Console.WriteLine("Army очищен");

            }
        }

        public void Push(IntelligentBeing N)
        {
            data.Add(N);
            counter++;
        }
    }
}
