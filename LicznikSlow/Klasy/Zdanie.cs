using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicznikSlow.Klasy
{
    public class Zdanie : KlasaBazowa
    {
        public override string Tekst1 { get => "Zdania: "; set => base.Tekst1 = value; }

        public List<Slowo> Slowa { get; set; }
    }
}
