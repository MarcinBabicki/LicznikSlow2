using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy
{
    public class Slowo : KlasaBazowa
    {
        public override string Tekst1 { get => "Słowa: "; set => base.Tekst1 = value; }
        public List<Znak> Znaki { get; set; }

    }
}
