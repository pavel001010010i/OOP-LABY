using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delete
{
    public class Lot
    {
        public static int numCreatObjects = 0;
        public static int chetMin = 0;
        public static int chetMax = 0;
        private int Number;
        private int Coint;
        readonly private int reaonly;
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

        public void Priint()
        {
            Console.WriteLine(lot1+" "+ lot2 + " " + lot3 + " " + lot4 + " " + lot5);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            //Lot kek = new Lot();
            //kek.Add(4);
            //kek.Add(5);
            //kek.Add(6);
            //Lot dww = new Lot(11111, 13);
            //Lot wdd = new Lot(32, 534, 331456,21,4);
            //dww.Max();
            //wdd.Max();
            //wdd.Print();
            //dww.Print();
            //Lot.AboutDate();// вызов статика
            //kek.ToString();
            //kek.number=2;
            //Console.Write(kek.number+"\n");

            string[] array = new string[] { "Oktober", "June", "July", "May",
                "December", "September", "January", "February", "Mart", "April", "August", "November" };


            var stringLength = from arr1 in array
                               where arr1.Length == 6
                               select arr1;

            var mounthReturn = from arr2 in array
                               where arr2 == "June" || arr2 == "July" || arr2 == "August"
                               || arr2 == "January" || arr2 == "December" || arr2 == "February"
                               select arr2;

            var mounthAlphabet = from arr3 in array
                                 orderby arr3 ascending
                                 select arr3;

            var lengthAndU = (from arr4 in array
                              where arr4.Contains("u") && arr4.Length >= 4
                              select arr4).Count();

            Console.WriteLine("First request:");
            foreach (string i in stringLength)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine("\n\nSecond request:");
            foreach (string i in mounthReturn)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine("\n\nThird request:");
            foreach (string i in mounthAlphabet)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine($"\n\nFourth request: {lengthAndU}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            List<Lot> lots = new List<Lot>();
            Lot ewe = new Lot(2,12,12,12,12);
            lots.Add(new Lot(12, 124, 16, 7, 98));
            lots.Add(new Lot(121, 141, 20, 141, 48));
            lots.Add(new Lot(45, 14, 76, 17, 8));
            lots.Add(new Lot(-45, 124, 41, 17, 8));
            lots.Add(new Lot(18, 19, 20, 14, 48));
            lots.Add(ewe);
            

          
            var sequene = (from n in lots
                           where n.lot1+n.lot2+ n.lot3+ n.lot4+ n.lot5>300
                           select n).Max();
            Console.WriteLine(sequene.lot1 + " " + sequene.lot2 + " " + sequene.lot3 + " " + sequene.lot4 + " " + sequene.lot5);
            

            IEnumerable<Lot> sequeneTwo = from n1 in lots
                                          where n1.lot1 < 0 || n1.lot2 < 0 || n1.lot3 < 0|| n1.lot4 < 0|| n1.lot5 < 0
                                          select n1;
            Console.WriteLine("\nМножества с отрицательными элементами: ");

            foreach (var k in sequeneTwo)
            {
                k.Priint();
            }
            var sequeneThree = (from n2 in lots
                                where n2.lot1== 17 || n2.lot2 == 17 || n2.lot3 == 17 || n2.lot4 == 17 || n2.lot5 == 17
                                            select n2).Count();
            Console.WriteLine("\n\nNumber of elements with specified value: " + sequeneThree);

            var sequeneFour = (from n4 in lots
                              where n4.lot1 == 17 || n4.lot2 == 17 || n4.lot3 == 17 || n4.lot4 == 17 || n4.lot5 == 17
                              select n4).First();

            Console.WriteLine("\nThe first set with a given element:");
            Console.WriteLine(sequeneFour.lot1 + " " + sequeneFour.lot2 + " " + sequeneFour.lot3 + " " + sequeneFour.lot4 + " " + sequeneFour.lot5);

            var sequeneFier = from n5 in lots
                              orderby n5.lot1
                              select n5;
            Console.WriteLine("\nOrdered array of sets by the first element:");
            foreach (var k in sequeneFier)
            {
                k.Priint();
            }
            // task 4 - 5

            List<int> list1 = new List<int>();
            list1.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            List<int> list2 = new List<int>();
            list2.AddRange(new int[] { 2, 4, 6, 8, 10 });

            var selectedList = from t1 in list1
                               join t2 in list2 on t1 equals t2
                               orderby t1
                               select t1;

            Console.Write("\nTask 4: ");
            foreach (var s in selectedList)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

        }
    }
} // cтатический конструктор узнать подробнее
