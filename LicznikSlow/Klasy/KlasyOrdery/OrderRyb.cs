using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy.KlasyOrdery
{
    public class OrderRyb : OrderBaza
    {
        public override string OrderSmoczkaTekst { get => "Order Ryb"; }
        public override string OrderTekstTekst { get => "Twoje opowiadanie jest krótsze"; }
        public override string OrderTekst2Tekst { get => "niż przeciętny wytwór Ryb!  Otrzymujesz"; }
        public override string OrderTekstDodTekst { get => "Rozwaliła system!"; }
        public override string OrderSource { get => "zbojci1.jpg"; }
        public override int OrderTekstFontSize { get => 12; }
        public override int OrderTekst2FontSize { get => 12; }
        public override int OrderWidth { get => 133; }
    }
}
