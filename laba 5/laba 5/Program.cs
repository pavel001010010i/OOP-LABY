using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    public class Printer
    {
        public void Printing(object obj)
        {
            obj.GetType();
            
            Console.WriteLine($"Это {obj.ToString()} ");
        }
        
    }

    public abstract class TransportVehicle //транспортное средство
    {
       protected bool isStart;
        protected bool isGoing; //едет не едет
        public string nameVehcle;

        public virtual void Method()
        {
            Console.WriteLine("TransportVehicle двигается как кролик");
        }
    }

    interface IAutoControl  //управление авто
    {
        bool Going();
        bool Stay();
    }

    class Car : TransportVehicle, IEngine, IAutoControl //машина
    {
        public bool StartEngine()
        {
            this.isStart = true;
            return true;
        }
        public bool StopEngine()
        {
            this.isStart = false;
            return false;
        }
        public bool Going()
        {
            this.isGoing = true;
            return true;
        }
        public bool Stay()
        {
            this.isGoing = false;
            return false;
        }
        public override string ToString()
        {
            return base.ToString() + " переопределен в Car";
        }
        public override void Method()
        {
            Console.WriteLine("TransportVehicle переопределен в Car");
        }
    }

    interface IEngine //двигатель
    {
        bool StartEngine();
        bool StopEngine();
    }

    public abstract class IntelligentBeing //разумное существо
    {
        public bool isConvertible;

        public virtual void Move()
        {
            Console.WriteLine("Как-то двигается!");
        }
    }

    sealed class Man : IntelligentBeing //4elovek
    {
        public override void Move()
        {
            Console.WriteLine("Двигается на сузуки со скростью звука");
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            IntelligentBeing a = obj as Man;
            if(a as Man == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + isConvertible;
        }
    }

    class Convertible : IntelligentBeing //трансформер
    {
        public override void Move()
        {
            Console.WriteLine("Стал бамболби");
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            TransportVehicle Opel = new Car();
            TransportVehicle Mazda = new Car();
            IntelligentBeing BamBoolBi = new Convertible();
            IntelligentBeing Filiphok = new Man();
            Printer Print = new Printer();

            Filiphok.Move();
            BamBoolBi.Move();
            Opel.Method();

            List<object> array = new List<object>() { Opel, Mazda, BamBoolBi, Filiphok, Print };
            foreach( object ise in array)
            {
                Print.Printing(ise);
            }
            if (Opel is Car)
            {
                Console.WriteLine("Опель это оооопель с молнией как у гарри поттера");
            }
            else
            {
                Console.WriteLine("Это не опель =(");
            }
        }

    }
}
