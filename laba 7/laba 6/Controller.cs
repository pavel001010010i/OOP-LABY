using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    static class Controller
    {
        public static int coint = 0;
        static IntelligentBeing A = new IntelligentBeing();
        public static void SearchByArmy(int year, Army obj)
        {
            Console.WriteLine("\n\tSearch combat unit by year of production(birth): ");
            for (int i = 0; i < obj.data.Count; i++)
            {
                coint++;
                A = obj.data.ElementAt(i);
                if (A.creationYear == year )
                {
                    Console.WriteLine($"Fighting unit -> { A.nameTrans}");
                }
            }
        }

        public static void OutNameSpecPower(int power, Army obj)
        {
            Console.WriteLine("\n\tOutput the name of the transformers of the specified power: ");
            for (int i = 0; i < obj.data.Count; i++)
            {
                A = obj.data.ElementAt(i);
                if (A.power == power)
                {
                    Console.WriteLine($" Fighter's name -> { A.nameTrans}");
                }
            }
        }
    }
}
