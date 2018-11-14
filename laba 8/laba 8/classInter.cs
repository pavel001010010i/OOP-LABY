using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_8
{
    class NotNumberException : Exception
    {
        public NotNumberException(string msg) : base(msg)
        {

        }
    }
    interface IInterface<T>
        {
            void Push(T value);
            T GetElement(int position);
            void Delete(int position);
        }

    public class MyType
    {
        dynamic X;
        public dynamic xe
        {
            get { return X; }
            set
            {
                var test = value;
                if (test is string || test is char)
                {
                    throw new NotNumberException("Введите число а не символы");
                }
                else if (test is int)
                {
                    X = value;
                }
            }
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
}
