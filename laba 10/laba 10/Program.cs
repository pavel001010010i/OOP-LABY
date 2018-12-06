using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    class Student
    {
        private string name;

    public string Name { get => name; set => name = value; }

    public Student(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return this.name;
    } 
}
class Program
    {
        //для получения всей информации о событии используется объект NotifyCollectionChangedEventArgs e
        private static void Deal(object a, NotifyCollectionChangedEventArgs e)
        {
            //Свойство Action предоставляет информацию о том, был элемент добавлен или удален.
            //Оно хранит одной из значений из перечисления NotifyCollectionChangedAction, содержащий информацию об изменениях коллекции.
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        //Свойства NewItems и OldItems позволяют получить соответственно добавленные и удаленные объекты
                        Student newStudent = e.NewItems[0] as Student;
                        Console.WriteLine("Add object: " + newStudent.Name + ".");
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        Student oldStudent = e.OldItems[0] as Student;
                        Console.WriteLine("Del object: " + oldStudent.Name + ".");
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            ArrayList lest = new ArrayList() { 23,55,17};
            string namen = "werqr";
            Student stud = new Student(namen);
            lest.Add(15);
            lest.Add(20);
            lest.Add("Stroka");
            lest.Add(stud);

            Console.WriteLine("Input number delete element's: ");

            int at = Convert.ToInt32(Console.ReadLine());
            lest.RemoveAt(at);

            Console.WriteLine("Number of list items:  " + lest.Count);
            foreach (object o in lest)
            {
                Console.WriteLine(o);
            }
            var index = lest[2];

            foreach (object o in lest)
            {
                if (o == index)
                {
                    Console.WriteLine($"Number {o} is in the collection", o);

                }

            }

            //222222222222
            List<long> list = new List<long>();
            for (int i = 1; i < 7; i++)
            {
                list.Add(i * 10000 - 45 * i + i);
            }
            Console.WriteLine("\n2 ZADANIE\n");
            Console.WriteLine("Element's for List: ");
            foreach (object o in list)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine("\nInput count delete element's:");

            int size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                list.RemoveAt(0);
            }
            list.Add(43636);
            Console.WriteLine("Element's for List 2: ");
            foreach (object o in list)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine("\n");

            Stack<long> stask = new Stack<long>(list);

            Console.WriteLine("Element's for Stack");
            foreach (long o in stask)
            {
                Console.Write(o + " ");
            }

            Console.WriteLine("\nWhether the specified value is found: " + stask.Contains(49780));

            Console.WriteLine();

            //333333333333333333333
            Console.WriteLine("\n3 ZADANIE\n");
            Vehicle Train_1 = new Train(50, 120, "super-train");
            Vehicle Train_2 = new Express(115, 260, "super-super-train");
            Vehicle Train_3 = new Train(50, 220, "super-train");
            Vehicle Train_4 = new Express(115, 360, "super-super-train2");
            Vehicle Car_1 = new Car(6, 205, "super-car3");
            Printer print = new Printer();

           
            LinkedList<Vehicle> vehicles = new LinkedList<Vehicle>();
            vehicles.AddFirst(Train_3);
            vehicles.AddFirst(Train_4);

            List<Vehicle> listVen = new List<Vehicle>(vehicles);

            listVen.Add(Train_1);
            listVen.Add(Train_2);
            listVen.Add(Car_1);
            Console.Write("Input the sequence (<4): ");
            int ate = Convert.ToInt32(Console.ReadLine());
            if (ate < 4)
            {
                for (int i = 0; i < ate; i++)
                {
                    listVen.RemoveAt(i);
                }
            }
            else
            {
                Console.WriteLine("Exaggerated range");
            }

            Console.WriteLine("\n\nРабота с пользовательским типом данных в качестве типа коллекций");
            foreach (Vehicle z in listVen)
                Console.Write($"\n{z.name} {z.speed}");

            Console.Write("\n\nStack elemet's: ");
            Stack<Vehicle> stackVehi = new Stack<Vehicle>(listVen);
            foreach (Vehicle item in stackVehi)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nWhether the specified value is found: " + stackVehi.Contains(Car_1));


            //4z  ObservableCollection<T>
            Console.WriteLine("\n4 ZADANIE\n");
            ObservableCollection<Student> studentss = new ObservableCollection<Student>();
            //Класс ObservableCollection определяет событие CollectionChanged, подписавшись на которое, мы можем обработать любые изменения коллекции.
            studentss.CollectionChanged += Deal;
            for (int i = 1; i < 5; i++)
            {
                studentss.Add(new Student(Convert.ToString(i*100-23*i)));
            }
            studentss.Remove(new Student("154"));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
