using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy
{
    public class CalyTekst : KlasaBazowa
    {
        public override string Tekst1 { get => "Średnia: "; set => base.Tekst1 = value; }


        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public int MyProperty { get; set; }
    }
}
