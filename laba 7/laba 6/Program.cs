using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace laba_6
{
    public partial class Printer
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

    public class IntelligentBeing //разумное существо
    {
        public bool isConvertible;
        public int creationYear;
        public int birthYear;
        public string nameMan;
        public string nameTrans;
        public int power;

        public virtual void Move()
        {
            Console.WriteLine("Как-то двигается!");
        }
    }

    class Man : IntelligentBeing //4elovek
    {
        public Man(int birhtYear, string nameMan, int power)
        {
            if (birhtYear > 2018)
            {
                IncorrectDateOfBirthException e = new IncorrectDateOfBirthException("Ошибка года рождения");
                throw e;
            }
            else
            {
                this.birthYear = birhtYear;
            }
            if (power < 0)
            {
                NegativePowerException e = new NegativePowerException("Ошибка мощности");
                throw e;
            }
            else
            {
                this.power = power;
            }
            this.nameMan = nameMan;
            
                
        }
        public override void Move()
        {
            Console.WriteLine("\t" + birthYear + "\t" + nameMan + "\t\t" + power);
        }
        
    }

    class Convertible : IntelligentBeing //трансформер
    {
        public Convertible(int creationYear, string nameTrans, int power)
        {
            this.creationYear = creationYear;
            this.nameTrans = nameTrans;
            this.power = power;
        }
       
        public override void Move()
        {
            Console.WriteLine("\t" + creationYear + "\t" + nameTrans + "\t" + power);
        }
    }

    //lab_6_______________________
    enum MyEnum : int
    {
        car,
        man,
        transformer
    }

    struct MyStruct
    {
        public string typeVehicle;
        public int number;

        public MyStruct(string typeVehicle, int number)
        {
            this.typeVehicle = typeVehicle;
            this.number = number;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Type: {typeVehicle} ||  number: {number}");
        }
    }

    public class ArmyIsEmptyException : Exception //армия пуста
    {
        public ArmyIsEmptyException(string message) : base(message)
        {

        }
    }
    public class NegativePowerException : Exception //отрицтельная мощнасть
    {
        public NegativePowerException(string message) : base(message)
        {

        }
    }
    public class IncorrectDateOfBirthException : Exception //не корректная дата рождения
    {
        public IncorrectDateOfBirthException(string message) : base(message)
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TransportVehicle Opel = new Car();
                TransportVehicle Mazda = new Car();
                IntelligentBeing BamBoolBi = new Convertible(1999, "BamBoolBi", 1200);
                IntelligentBeing MamMoolMi = new Convertible(1980, "MamMoolMi", 1000);
                IntelligentBeing GamGoolGi = new Convertible(1970, "GamGoolGi", 1000);
                IntelligentBeing Filiphok = new Man(1970, "Phillip", 150);
                IntelligentBeing Vova = new Man(1990, "Vova", 14);
                IntelligentBeing Misha = new Man(1991, "Misha", 160);
                Printer Print = new Printer();

                Opel.Method();

                List<object> array = new List<object>() { Opel, Mazda, BamBoolBi, Filiphok, Print };
                foreach (object ise in array)
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



                Console.WriteLine("\n\t 6 ЛАБА \n");
                //lab_6
                //struct
                MyStruct veh1 = new MyStruct("car", 1875);
                veh1.DisplayInfo();
                //enum
                MyEnum tr1;
                tr1 = MyEnum.man;
                switch (tr1)
                {
                    case MyEnum.car:
                        {
                            Console.WriteLine("Is a car\n");
                            break;
                        }
                    case MyEnum.man:
                        {
                            Console.WriteLine("Is a man\n");
                            break;
                        }
                    case MyEnum.transformer:
                        {
                            Console.WriteLine("Is a transformer\n");
                            break;
                        }

                }

                Console.WriteLine("Births Year:" + "\tName " + "\t\tPower");

                Filiphok.Move();
                Vova.Move();
                Misha.Move();
                BamBoolBi.Move();
                MamMoolMi.Move();
                GamGoolGi.Move();

                Console.WriteLine("\n\tAdding objects...");

                Army army = new Army();
                //army.Output();              //ошибка е1
                //IntelligentBeing HamHoolHi = new Man(1999, "HamHoolHi", -1200); //error e2
                IntelligentBeing KamKoolKi = new Man(2029, "KamKoolKi", 1200);      //error e3
                int a = 0;
                //int sum = 5 / a;    //error e4
                string[] str = new string[5];
                //str[6] = "errorchik"; // error e5 стандартная

                int? pointer = null;
                Debug.Assert(pointer != null, "переменная ровна -- null");

                army.Push(BamBoolBi);
                army.Push(MamMoolMi);
                army.Push(GamGoolGi);
                army.Push(Vova);
                army.Push(Filiphok);
                army.Push(Misha);
                army.Output();

                Controller.SearchByArmy(1970, army);

                Controller.OutNameSpecPower(1000, army);
                var c = Controller.coint;
                Console.WriteLine(" \n\tNumber of military equipment -> " + c);
            }
            catch (ArmyIsEmptyException e1)
            {
                Console.WriteLine(e1);
            }
            catch(NegativePowerException e2)
            {
                Console.WriteLine(e2);
            }
            catch(IncorrectDateOfBirthException e3)
            {
                Console.WriteLine(e3);
            }
            catch(DivideByZeroException e4)
            {
                Console.WriteLine(e4);
            }
            catch(Exception e5)
            {
                Console.WriteLine(e5);
            }
            finally
            {
                Console.WriteLine("hello nigga!");
            }
        }

    }
}
