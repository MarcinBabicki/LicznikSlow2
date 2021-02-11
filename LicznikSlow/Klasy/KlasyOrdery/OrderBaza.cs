using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy.KlasyOrdery
{
    public abstract class OrderBaza
    {
        public abstract string OrderSmoczkaTekst { get; }
        public abstract string OrderTekstTekst { get; }
        public abstract string OrderTekst2Tekst { get; }
        public abstract string OrderTekstDodTekst { get; }
        public abstract string OrderSource { get; }
        public abstract int OrderTekstFontSize { get; }
        public abstract int OrderTekst2FontSize { get; }
        public abstract int OrderWidth { get; }

        public static int RodzajOrderu(int slowa)
        {

            if (slowa > -1 && slowa < 100) return 0;
            else if (slowa >= 100 && slowa < 500) return 1;
            else if (slowa >= 500 && slowa < 1000) return 2;
            else if (slowa >= 1000 && slowa < 2000) return 3;
            else if (slowa >= 2000 && slowa < 5000) return 4;
            else if (slowa >= 5000 && slowa < 10000) return 5;
            else if (slowa >= 10000 && slowa < 20000) return 6;
            else if (slowa >= 20000 && slowa < 50000) return 7;
            else if (slowa >= 50000 && slowa < 100000) return 8;
            else if (slowa >= 100000 && slowa < 1000000) return 9;
            else return 10;

        }
    }
}
