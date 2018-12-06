using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_9
{
    class Program
    {
        delegate void Message();

        static void Main(string[] args)
        {
            Message mes1 = Hello;
            mes1 += HowAreYou;  // теперь mes1 указывает на два метода
            mes1(); // вызываются оба метода - Hello и HowAreYou
            Console.Read();
        }
        private static void Hello()
        {
            Console.WriteLine("Hello");
        }
        private static void HowAreYou()
        {
            Console.WriteLine("How are you?");
        }
    }
}
