using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    public partial class Printer
    {
        public Printer() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            IntelligentBeing a = obj as Man;
            if (a as Man == null)
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
            return base.ToString();
        }
    }
}
