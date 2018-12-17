using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StringUpgrader
    {
        public static Func<string, string> StrFunc; //возвращает результат действия
        public static Action<string> action; //является обобщенным, принимает параметры и возвращает значение void

        private static string AddDot(string str)//Добавим точку
        {
            str += ".";
            return str;
        }   
        private static void Out(string str)//Добавим точку
        {
            Console.WriteLine(str);
        }
        private static string RemoveDoubleSpaces(string str)//Уберем лишние пробелы
        {
            
            return str.Replace(" ", "_");
        }
        private static string FirstLetterToUpperCase(string str)//Первая буква должна быть заглавной
        {
            
            return str.ToUpper(); 
        }
        private static string RemoveCom(string str)
        {
            return str.Replace(", ", " ");
        }

        public static void Upgrade(string str)//Собираем цепочку и меняем строку 
        {

            StrFunc = RemoveCom;
            string temp = StrFunc.Invoke(str);
            StrFunc += FirstLetterToUpperCase;
            temp = StrFunc.Invoke(temp);
            StrFunc += RemoveDoubleSpaces;
            temp = StrFunc.Invoke(temp);
            StrFunc += AddDot;
            temp = StrFunc.Invoke(temp);
            action = Out;
            action(str);


            Console.WriteLine(StrFunc(temp));
        }
    }

        public class Worker
    {
        public delegate void SalaryHandler(string message);

        public event SalaryHandler Penalty;
        public event SalaryHandler Add;

        public int salary { get; private set; }

        public void MoreSalary(int val)
        {
            salary += val;
            if(Add != null)//Проверка наличия обработчика Add
            {
                Add($"Новая зарплата {salary}");
            }
        }

        public void TakePenalty(int val) //-зп
        {
            salary -= val;
            if (Penalty != null)
            {
                
                Penalty.Invoke($"Новая зарплата {salary}");
            }
        }

        public Worker(int salary)
        {
            this.salary = salary;
        }
    }    

    class Program
    {
        public static void ShowMessage(string str)
        {
            Console.WriteLine("{0}", str);
        }


        public delegate void WWriteSalary(Worker obj);

        static void Main(string[] args)
        {
            Worker w1 = new Worker(10);
            w1.Add += ShowMessage;
            w1.Penalty += ShowMessage;

            WWriteSalary WriteSalary = (obj) => Console.WriteLine($"Зарплата равна {obj.salary}");

            WriteSalary(w1);

            Worker w2 = new Worker(50);
            w2.Add += ShowMessage;

            Worker w3 = new Worker(20);

            w1.MoreSalary(3);
            w1.TakePenalty(1);

            w2.MoreSalary(4);
            w2.TakePenalty(1);

            w3.MoreSalary(1);
            w3.TakePenalty(1);

            string str = "asdas ass, w";
            StringUpgrader.Upgrade(str);
            Console.WriteLine(str);
        }
    }
}

