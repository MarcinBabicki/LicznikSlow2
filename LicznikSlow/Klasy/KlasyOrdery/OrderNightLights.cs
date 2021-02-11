using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy.KlasyOrdery
{
    public class OrderNightLights : OrderBaza
    {
        public override string OrderSmoczkaTekst { get => "Order Night Lights"; }
        public override string OrderTekstTekst { get => "Twoje opowidanie się ładnie rozwija."; }
        public override string OrderTekst2Tekst { get => "Tak samo jak Night Lights. Otrzymujesz"; }
        public override string OrderTekstDodTekst { get => ""; }
        public override string OrderSource { get => "nightLightsOrder.png"; }
        public override int OrderTekstFontSize { get => 12; }
        public override int OrderTekst2FontSize { get => 12; }
        public override int OrderWidth { get => 188; }
    }
}
