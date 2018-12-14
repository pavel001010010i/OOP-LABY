using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace laba_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Lot set = new Lot(12, 34, 67, 2, 5);
            
            Reflector.InfoClass(set);
            Reflector.Interfece(set);
            Reflector.Field(set);
            Reflector.MethodForType(set);
            Reflector.Voke(set, "Input");
        }
    }

    static class Reflector
    {
        static public void InfoClass(object obj)
        {
            string text = "";
            Type t = obj.GetType();
            Console.WriteLine("-------------- Вся информация о классе ------------\n");
            string path = @"E:\ООП 3 сем\text.txt";
            //базовый абстрактный класс, определяющий общий функционал
            foreach (MemberInfo mi in t.GetMembers())//возвращает все члены типа в виде массива объектов MemberInfo
            {
                text = text + mi.DeclaringType + " " + mi.MemberType + " " + mi.Name + '\n';
            }
            foreach (MemberInfo mi in t.GetMethods())//возвращает все члены типа в виде массива объектов MemberInfo
            {
                 Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);

                text = text + mi.DeclaringType + " " + mi.MemberType + " " + mi.Name + '\n';
            }
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                sw.Write(text);
            }
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                text = sr.ReadToEnd();
            }
            Console.WriteLine("\n");
        }
        static public void Interfece(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("\n---------- Реализуемые интерфейсы класса ------------ \n");
            var im = t.GetInterfaces();
            foreach (Type tp in im)
                Console.WriteLine(tp.Name);
            Console.WriteLine();
        }
        static public void Field(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("------------ Пoля и свойства класса ------------ \n");
            foreach (MemberInfo mi in t.GetFields()) //возвращает все поля данного типа в виде массива объектов FieldInfo
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            }
            foreach (MemberInfo mi in t.GetProperties())//получает все свойства в виде массива объектов PropertyInfo
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            }
            Console.WriteLine("\n");
        }
        static public void MethodForType(object obj)
        {
            Console.WriteLine("\n\nВведите тип параметра запрашиваемого метода: ");
            string parametr = Console.ReadLine();

            Type t = obj.GetType();

            // Получаем коллекцию методов
            MethodInfo[] MArr = t.GetMethods();
            Console.WriteLine("------------- Список методов класса {0} Типа {1} -------------\n", obj.ToString(), parametr);

            // Вывести методы
            foreach (MethodInfo m in MArr)
            {
                // Вывести параметры методов
                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].ParameterType.Name == parametr)
                    {
                        Console.Write(m.Name + "(" + p[i].ParameterType.Name + " " + p[i].Name + ")");
                        if (i + 1 < p.Length) Console.Write(", ");
                    }
                }
                Console.Write("\n");
            }
        }
        static public void Voke(object obj, string methode)
        {
            Console.WriteLine("\n\nВызов метода через некоторый метод класса:");
            try
            {
                string path = @"E:\ООП 3 сем\parametr.txt";
                
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string param;
                    param = sr.ReadToEnd();

                    Console.WriteLine(param + " ----------------------");
                    Type t = obj.GetType();

                    // создаем экземпляр класса 
                    object ekz = Activator.CreateInstance(typeof(Lot));

                    // получаем метод 
                    MethodInfo method = t.GetMethod(methode);

                    // вызываем метод, передаем ему значения для параметров и получаем результат
                    method.Invoke(ekz, new object[] { param });
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}