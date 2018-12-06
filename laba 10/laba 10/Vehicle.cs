using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    
    public class Printer
    {
        public void iAmPrinting(object obj)
        {
            Console.WriteLine($"Это {obj.GetType()}");
        }
    }


    public class Vehicle
    {
        protected bool isStarted;
        public string name;
        public int speed;
        public int consumption;
        public virtual void Move()
        {
            Console.WriteLine("ЧТо та двигается!");
        }
    }

    partial class Car : Vehicle, Engine, IComparable
    {

        public Car(int consumption, int speed, string name)
        {
            this.consumption = consumption;
            this.speed = speed;
            this.name = name;
        }

        public bool stopEngine()
        {
            this.isStarted = false;
            return false;
        }

        public bool startEngine()
        {
            this.isStarted = true;
            return true;
        }

        public int CompareTo(object o)
        {
            Vehicle p = o as Vehicle;
            if (p != null)
                return this.name.CompareTo(p.name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public int Compare(object x, object y)
        {
            Vehicle one = new Vehicle();
            Vehicle two = new Vehicle();
            if (one.name.Length > two.name.Length)
                return 1;
            else if (one.name.Length < two.name.Length)
                return -1;
            else
                return 0;
        }

        public override void Move()
        {
            Console.WriteLine("Тачка едет");
        }

    }

    class Train : Vehicle, Engine
    {
        public Train(int consumption, int speed, string name)
        {
            this.consumption = consumption;
            this.speed = speed;
            this.name = name;
        }

        public bool startEngine()
        {
            this.isStarted = true;
            return true;
        }

        public bool stopEngine()
        {
            this.isStarted = false;
            return false;
        }

        public override void Move()
        {
            Console.WriteLine("Поезд едет");
        }

    }

    interface Engine
    {
        bool startEngine();
        bool stopEngine();
    }

    class Express : Vehicle
    {
        public Express(int consumption, int speed, string name)
        {
            this.consumption = consumption;
            this.speed = speed;
            this.name = name;
        }

        public override void Move()
        {
            Console.WriteLine("Экспресс-поезд едет");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Vehicle a = obj as Express;
            if (a as Express == null)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

