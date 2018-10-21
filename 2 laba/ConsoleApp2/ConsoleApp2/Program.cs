using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 10;
            int t;
            t = (int)num;
            Int16 i16 = 9;
            Int32 i32 = i16;
            Int64 i64 = num;
            double dlbl = i32;
            float f = (float)dlbl;
            byte bt = (Byte)i16;
            short shrt = (short)num;
            long lng = (long)f;
            bool bools = true;
            char chr = 'd';
            int num_1 = 76;
            Object nam_1 = num_1; //упаковка
            int kak = (int)nam_1; //распаквка
            var neyav = "pavel";
            Console.WriteLine(neyav);
            int? xer = null;
            int? xer2 = xer;
            Console.WriteLine(xer2);
            ////////////////////string///////////////////
            string str1 = "text n1";
            string str2 = "text n43";
            if (String.CompareOrdinal(str1, str2) != 0)
                Console.WriteLine("Строки не едентичны");
            if (String.CompareOrdinal(str1, str2) == 0)
                Console.WriteLine("Строки едентичны");
            string str4 = "hello";
            string str5 = "WOrld";
            string str6 = "hello my love1!!!";

            string cout1 = String.Concat(str4, " ", str5);
            Console.WriteLine(cout1);
            string cout2 = String.Copy(str4);
            Console.WriteLine(cout2);
            String sub = str6.Substring(6, 2);
            Console.WriteLine(sub);

            String value = "This is a short string.";//
            Char delimiter = 's';
            String[] substrings = value.Split(delimiter); 
            foreach (var substring in substrings)
                Console.WriteLine(substring);

            string text = "Хороший день";
            string subString = "замечательный ";

            text = text.Insert(8, subString);
            Console.WriteLine(text);

            string text2 = text.Remove(0, 7);
            Console.WriteLine(text2);

            string nullik = "";
            string nullil = null;

            StringBuilder sb = new StringBuilder("Привет мир");
            sb.Append("!");
            sb.Remove(0, 7);
            sb.Insert(0, "компьютерный ");
            sb.Insert(16, " Хогвардса ");
            Console.WriteLine(sb);

            /////////////////////array ////////////////////////
            int[,] myArr4 = new int[4, 5];

            Random ran = new Random();

            // Инициализируем данный массив
            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr4[k, j] = ran.Next(1, 15);
                    Console.Write("{0}\t", myArr4[k, j]);
                }
                Console.WriteLine();
            }

            string[] info = { "Фамилия", "Имя", "Отчество" };
            Console.WriteLine("length array: " + info.Length);
            for (int i = 0; i < info.Length; i++)
                Console.WriteLine(info[i]);

            int m = 0;
            // Объявляем ступенчатый массив
            int[][] myArr = new int[3][];
            myArr[0] = new int[2];
            myArr[1] = new int[3];
            myArr[2] = new int[4];

            // Инициализируем ступенчатый массив
            Console.WriteLine("Input youhr array: ");
            for (; m < 2; m++)
            {
                int vvod = Convert.ToInt32(Console.ReadLine());
                myArr[0][m] = vvod;
            }


            for (m = 0; m < 3; m++)
            {

                int vvod = Convert.ToInt32(Console.ReadLine());
                myArr[1][m] = vvod;
            }

            for (m = 0; m < 4; m++)
            {
                int vvod = Convert.ToInt32(Console.ReadLine());
                myArr[2][m] = vvod;
            }
            for (m = 0; m < 2; m++)
            {

                Console.Write("{0}\t", myArr[0][m]);
            }
            Console.WriteLine();
            for (m = 0; m < 3; m++)
            {
                Console.Write("{0}\t", myArr[1][m]);
            }
            Console.WriteLine();

            for (m = 0; m < 4; m++)
            {
                Console.Write("{0}\t", myArr[2][m]);
            }
            Console.WriteLine();

            var vals = new[] { 1, 2, 3, 4, 5 };
            var valstr = "stringt";

            //////////////////////////// kortezhi /////////////
            (int yehrs, string FIO, char znak, string love, ulong kek) kartezh = (3,"NIlit",'h',"volor",312);

            Console.WriteLine("vash cartage: " + kartezh);
            Console.WriteLine("vash cartage: " + kartezh.yehrs + " " + kartezh.znak + " " + kartezh.love);

            //(int first, string middle, string last) LookupName(string id) // возвращаемый тип - кортеж
            //{
            //    int first = id.Length;
            //    string middle = "ede" + id;
            //    string last = "lolkek 4eburek";

            //    var names = LookupName(id);
            //    Console.WriteLine($"найдены {names.first} {names.last}.");
            //    return (first, middle, last);
            //}
            //var (one, two, three) = LookupName(id);



            Console.ReadKey();

        }
    }
}

