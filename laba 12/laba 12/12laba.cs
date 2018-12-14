using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_12
{
    interface IInfoClass
    {
        int Max();
    }
    public class Lot: IInfoClass
    {
        public static int numCreatObjects = 0;
        public static int chetMin = 0;
        public static int chetMax = 0;
        private int Number;
        private int Coint;
        public List<int> listInt = new List<int> { };
        public int[] array = new int[] { };
        public List<int> listIntTwo = new List<int> { };

        public int lot1 { get; set; }
        public int lot2 { get; set; }
        public int lot3 { get; set; }
        public int lot4 { get; set; }
        public int lot5 { get; set; }

        public Lot(int a, int b, int c, int d, int e)
        {
            this.lot1 = a;
            this.lot2 = b;
            this.lot3 = c;
            this.lot4 = e;
            this.lot5 = d;
        }
        public int number
        {
            get
            {
                return Number;
            }
            set
            {
                if (value > 0 && value < 32)
                {
                    if (coint != 2)
                    {
                        Number = value;
                    }
                    else
                    {
                        if (value < 29)
                        {
                            Number = value;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректные данные");
                }
            }
        }
        public int coint
        {
            get
            {
                return Coint;
            }
            set
            {
                if (value > 0 && value < 13)
                {
                    Coint = value;
                }
                else
                {
                    Console.WriteLine("Некорректные данные");
                }
            }
        }
        public int year { get; set; }
        public Lot()
        {
            numCreatObjects++;
        }

        static Lot()
        {
            Lot privConstructor = new Lot(1, 1, 1, true);
            numCreatObjects++;
            Console.WriteLine("статик");
        }
        private Lot(int a, int b, int c, bool isOne)
        {
            isOne = true;
            listIntTwo.Add(a);
            listIntTwo.Add(b);
            listIntTwo.Add(c);
            numCreatObjects++;
        }
        //Использование переменной без ref - операции со ЗНАЧЕНИЕМ 
        //С ref - с самой ПЕРЕМЕННОЙ 
        //out можно юзать, если не хватает return'а
        public static void AboutDate()// вывод инфы о классе
        {
            Console.WriteLine("Обьъектов создано:");
            Console.WriteLine($"{numCreatObjects} штук.");
        }

        public override string ToString()// служит для получения строкового представления данного объекта
        {
            return base.ToString() + " " + this.year + " " + this.coint + " " + this.number; // base = вызов конструктора определенного в базавом классе

        }

        public override bool Equals(object obj) //Метод Equals позволяет сравнить два объекта на равенство
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;//Метод GetType позволяет получить тип данного объекта

            Lot a = (Lot)obj;

            if (this.year == a.year)
                if (this.coint == a.coint)
                    if (this.number == a.number)
                        return true;
            return false;
        }
        //позволяет возвратить некоторое числовое значение
        //которое будет соответствовать данному объекту или его хэш-код
        public override int GetHashCode() // override - переопределение метода
        {
            int hash = 47;
            hash += this.year + this.coint + this.number;
            hash %= 3;
            return hash;
        }
        public partial class PartialClass
        {
            public int a = 1;
        }
        public partial class PartialClass
        {
            public int b = 2;
        }
        public void Add(int elem)
        {
            this.listInt.Add(elem);
            Console.Write("добавили {0} к множеству -> ", elem);
            foreach (int ch in this.listInt)
                Console.Write(ch + " ");
            Console.WriteLine("\n");
            numCreatObjects++;
        }
        public void Remove(int elem)
        {
            this.listInt.Remove(elem);
            Console.Write("удалили {0} из множества -> ", elem);
            foreach (int ch in this.listInt)
                Console.Write(ch + " ");
            Console.WriteLine("\n");
            numCreatObjects++;
        }
        public int PrintQuantity()
        {
            int quantity = 0;
            foreach (int ch in this.listInt)
            {
                quantity++;
            }
            Console.WriteLine("\n" + quantity);
            numCreatObjects++;
            return quantity;
        }
        public int Max()
        {
            int count = 0;

            foreach (int ch in this.listInt)
            {
                count += ch;

            }


            if (chetMax < count)
            {
                chetMax = count; //писваиммс переменной максимальное значение
            }
            if (chetMin == 0)
                chetMin = count;
            else if (chetMin > count)
            {
                chetMin = count;
            }
            return count;
        }

        public int maxSum()
        {
            Console.WriteLine("\nМожество: ");
            foreach (int ch in this.listInt)
            {

                Console.Write(ch + " ");
            }
            Console.WriteLine("\nMAX " + chetMax);
            return chetMax;
        }
        public bool NegativeElem()
        {
            numCreatObjects++;
            bool booleanChangeable = false;
            foreach (int ch in this.listInt)
                if (ch < 0)
                {
                    booleanChangeable = true;
                }

            return booleanChangeable;
        }
        public bool ExistenceElement(int elem)
        {
            bool booleanChangeable = false;
            foreach (int ch in this.listInt)
                if (ch == elem)
                {
                    booleanChangeable = true;
                }

            return booleanChangeable;
        }

        public void Priint(string ser)
        {
            Console.WriteLine(lot1 + " " + lot2 + " " + lot3 + " " + lot4 + " " + lot5);
        }
        public void Input( string str)
        {
            Console.WriteLine(" Вывод строки через параметр : "+str);
        }
    }
}
