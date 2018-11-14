using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_8
{
    public class _3zad<T>: IInterface<T> where T: TransportVehicle
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
        public static _3zad<T> operator +(_3zad<T> set1, T elem) //добавление
        {
            set1.setOne.Add(elem);
            return set1;
        }
        public static _3zad<T> operator +(_3zad<T> set1, _3zad<T> set2) //обьеденить
        {
            _3zad<T> resultSet = new _3zad<T>();
            _3zad<T> set3 = new _3zad<T>() { };
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
        public static _3zad<T> operator *(_3zad<T> set1, _3zad<T> set2)
        {
            _3zad<T> resultSet = new _3zad<T>();
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
        public static bool operator true(_3zad<T> set)
        {
            return set.Coins();
        }
        public static bool operator false(_3zad<T> set)
        {
            return set.Coins();
        }
        public static explicit operator int(_3zad<T> set) // явный инт
        {
            var x = set.setOne.Count();
            return x;
        }
    }

}
