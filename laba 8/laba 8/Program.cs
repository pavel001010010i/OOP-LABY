using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace laba_8
{
    public class Set<T>: IInterface<T> where T : struct
    {
        public int number, coinsTwo = 0;
        public const int koll = 5;


        public List<T> setOne = new List<T> { };

        public void Push(T obj)
        {
            setOne.Add(obj);
        }

        public void Delete(int position)
        {
            setOne.RemoveAt(position);
        }

        public T GetElement(int position)
        {
            return setOne.ElementAt(position);
        }

        public bool Coins() // соответвует ли кол элем массива заданой области
        {
            foreach (T ch in setOne)
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
        public static Set<T> operator +(Set<T> set1, T elem) //добавление
        {
            set1.setOne.Add(elem);
            return set1;
        }
        public static Set<T> operator +(Set<T> set1, Set<T> set2) //обьеденить
        {
            Set<T> resultSet = new Set<T>();
            Set<T> set3 = new Set<T>() { };
            if (set1.setOne != null && set1.setOne.Count > 0)
            {
                set3.setOne.AddRange(set1.setOne);
            }
            if (set2.setOne != null && set2.setOne.Count > 0)
            {  
                set3.setOne.AddRange(set2.setOne);
            }
            resultSet.setOne = set3.setOne.Distinct().ToList();
            return resultSet;
        }
        public static Set<T> operator *(Set<T> set1, Set<T> set2)
        {
            Set<T> resultSet = new Set<T>();
            if (set1.setOne.Count < set2.setOne.Count)
            {
                foreach (var item in set1.setOne)
                {
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
        public static bool operator true(Set<T> set)
        {
            return set.Coins();
        }
        public static bool operator false(Set<T> set)
        {
            return set.Coins();
        }
        public static explicit operator int(Set<T> set) // явный инт
        {
            var x = set.setOne.Count();
            return x;
        }
    }
    public static class SetExtansion
    {
        public static int Count(this Set<int> set, Set<int> set1)
        {
            var quantity = set1.setOne.Count();
            Console.WriteLine("\n" + "Quantity: " + quantity);
            return quantity;
        }
        public static long Max(this Set<int> set)
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
        public static long Min(this Set<int> set)
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
        public static string Comma(this string str)
        {
            return str.Replace(" ", ", "); //замена
        }
        public static void RemoveRepetition(this Set<int> set)
        {
            set.setOne.Distinct<int>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Set<int> set1 = new Set<int>();
                Set<int> set2 = new Set<int>();
                Set<int> set3 = new Set<int>();
                Set<int> set4 = new Set<int>();
                Set<float> flat = new Set<float>();
                
                for (int i = 0; i < 15; i++)
                {
                    set1.Push(i);
                    set2.Push(i + 5);
                }
                set1.Delete(5);
                
                set1 += 51;
                
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


                if (set1)
                {
                    var x = 0;
                }

                var xtr = (int)set1;
                Console.Write("Quality elements: " + xtr + "\n");

                Console.Write(SetExtansion.Comma("hello wold priv mir!") + "\n");
                Console.Write(SetExtansion.Max(set1) + "\n");
                Console.Write(SetExtansion.Min(set1) + "\n");
                SetExtansion.RemoveRepetition(set1);
                
                MyType myType = new MyType() {xe = 678 };
                
               
                _3zad<TransportVehicle> asdasd = new _3zad<TransportVehicle>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Hello world");
            }
        }
    }
}
