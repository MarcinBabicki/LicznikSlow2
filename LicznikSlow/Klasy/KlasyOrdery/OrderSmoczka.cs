using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy.KlasyOrdery
{
    public class OrderSmoczka : OrderBaza
    {
        public override string OrderSmoczkaTekst { get => "Order Smoczka"; }
        public override string OrderTekstTekst { get => "Małe opowiadanka tak szybko rosną      :')"; }
        public override string OrderTekst2Tekst { get => "Otrzymujesz"; }
        public override string OrderTekstDodTekst { get => ""; }
        public override string OrderSource { get => "smoczek.bmp"; }
        public override int OrderTekstFontSize { get => 12; }
        public override int OrderTekst2FontSize { get => 12; }
        public override int OrderWidth { get => 104; }
    }
}
