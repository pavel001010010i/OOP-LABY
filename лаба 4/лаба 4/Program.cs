using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_4
{
    public class Set
    {
        public int number, coinsTwo = 0;
        public const int koll = 5;
        public List<int> setOne = new List<int> { };
        public void AddElem(int elem)
        {
           this.setOne.Add(elem);
        }
        public bool Coins() // соответвует ли кол элем массива заданой области
        {
            foreach (int ch in setOne)
            {
                coinsTwo++;
            }
            if (coinsTwo > koll || coinsTwo == koll)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public class Owner
        {
            public int id;
            public string name;
            public string organization;
            public Owner()
            {
                id = 6324619;
                name = "Pavel";
                organization = "BelSTU-FIT";
            }
        }
        public class Date
        {
            public string data;
            public Date()
            {
                data = "16 oktober 2018";
            }
        }
        public static Set operator +(Set set1, int elem) //добавление
        {
            set1.setOne.Add(elem);
            return set1;
            
        }
        public static Set operator +(Set set1, Set set2) //обьеденить
        {
            Set resultSet = new Set();
            Set set3 = new Set() { }; //Элементы данных результирующего множества.
            // Если первое входное множество содержит элементы данных,
            // то добавляем их в результирующее множество.
            if (set1.setOne != null && set1.setOne.Count > 0)
            {
                // т.к. список является ссылочным типом, 
                // то необходимо не просто передавать данные, а создавать их дубликаты.
                set3.setOne.AddRange(set1.setOne);
            }
            // Если второе входное множество содержит элементы данных, 
            // то добавляем из в результирующее множество.
            if (set2.setOne != null && set2.setOne.Count > 0)
            {
                // т.к. список является ссылочным типом, 
                // то необходимо не просто передавать данные, а создавать их дубликаты.
                set3.setOne.AddRange(set2.setOne);
            }
            // Удаляем все дубликаты из результирующего множества элементов данных
            resultSet.setOne = set3.setOne.Distinct().ToList();
           
                
            return resultSet;
        }
        public static Set operator *(Set set1, Set set2)
        {
            Set resultSet = new Set();
            //Выбираем множество содержащее наименьшее количество элементов.
            if (set1.setOne.Count < set2.setOne.Count)
            {
                // Первое множество меньше.
                // Проверяем все элементы выбранного множества.
                foreach ( var item in set1.setOne)
                {
                    // Если элемент из первого множества содержится во втором множестве,
                    // то добавляем его в результирующее множество.
                    if (set2.setOne.Contains(item))
                    {
                        resultSet.setOne.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2.setOne)
                {
                    if (set1.setOne.Contains(item))
                    {
                        resultSet.setOne.Add(item);
                    }
                }
            }
            
            return resultSet;
        }
        public static bool operator true(Set set)
        {
            return set.Coins();
        }
        public static bool operator false(Set set)
        {

            return set.Coins();
        }
        public static explicit operator int(Set set) // явный инт
        {
           var x = set.setOne.Count();
            return x;
        }
    }
    public static class SetExtansion
    {
        public static int Count( this Set set, Set set1)
        {
             var quantity = set1.setOne.Count();
            Console.WriteLine("\n" + "Quantity: " + quantity);
            return quantity;
        }
        public static long Max( this Set set)
        {
            int count;
            long numberMax = -999999999999999;
            foreach (int ch in set.setOne)
            {
                count = ch;
                if (numberMax < count)
                {
                    numberMax = count;
                }
            }
            return numberMax;
            
        }
        public static long Min(this Set set)
        {
            {
                int count;
                long numberMin = 999999999999;
                foreach (int ch in set.setOne)
                {
                    count = ch;
                    if (numberMin > count)
                    {
                        numberMin = count;
                    }
                }
                return numberMin;
            }
        }
        public static string Comma( this string str)
        {
           return str.Replace(" ", ", "); //замена
        }
        public static void  RemoveRepetition( this Set set)
        {
            set.setOne.Distinct<int>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set set1 = new Set();
            Set set2 = new Set();
            Set set3 = new Set();
            Set set4 = new Set();
            for (int i = 0; i < 15; i++)
            {
                set1.AddElem(i);
                set2.AddElem(i + 5);
            }
            set1 += 5;
            set1 += 14;

            Console.Write("Set1: ");
            foreach (var quality in set1.setOne)
            {
                Console.Write(quality + " ");
            }
            Console.Write("\n");

            Console.Write("Set2: ");
            foreach (var quality in set2.setOne)
            {
                Console.Write(quality + " ");
            }
            Console.Write("\n");


            Console.Write("Union: ");
            set3 = set1 + set2;

            Console.Write("Intersection: ");
            set4 = set1 * set2;


            foreach (var quality in set3.setOne)
            {
                Console.Write(quality + " ");
            }
            Console.Write("\n");
            foreach (var quality in set4.setOne)
            {
                Console.Write(quality + " ");
            }
            Console.Write("\n");


            if (set1) { var x = 0; }

            var xtr = (int)set1;
            Console.Write("Quality elements: "+xtr + "\n");

            Console.Write(SetExtansion.Comma("hello wold priv mir!") + "\n");
            Console.Write(SetExtansion.Max(set1) + "\n");
            Console.Write(SetExtansion.Min(set1) + "\n");
            SetExtansion.RemoveRepetition(set1);
        }
    }
}
