using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy.KlasyOrdery
{
    public class OrderStraszliwca : OrderBaza
    {
        public override string OrderSmoczkaTekst { get => "Order Straszliwca"; }
        public override string OrderTekstTekst { get => "Twoje opowiadanie jest tak małe, jak Straszliwiec."; }
        public override string OrderTekst2Tekst { get => "I tak samo niebezpieczne!  Otrzymujesz"; }
        public override string OrderTekstDodTekst { get => "Kij wie co z niego wyrośnie."; }
        public override string OrderSource { get => "straszliwiecOrder.jpg"; }
        public override int OrderTekstFontSize { get => 11; }
        public override int OrderTekst2FontSize { get => 12; }
        public override int OrderWidth { get => 194; }
    }
}
