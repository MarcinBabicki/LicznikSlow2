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

        public string AnalizowanyTekst { get; set; }

        public List<Zdanie> Zdania { get; set; }

        #region Methods
        public string Obrobka(string modified_str)
        {
            modified_str = modified_str.Trim();
            if (modified_str != "")
            {
                modified_str = LastSentence(modified_str);
                //znaki += modified_str.Length;
                modified_str += "\n";
            }
            return modified_str;
        }

        public string LastSentence(string modified_str) //Obsługa ostatniego zdania
        {
            char[] endCharacters = new char[] { '.', '?', '!', '_' };
            if (!endCharacters.Any(c => c == modified_str.Last()))
            //if (modified_str[modified_str.Length - 1] != '.' && modified_str[modified_str.Length - 1] != '?' && modified_str[modified_str.Length - 1] != '!' && modified_str[modified_str.Length - 1] != '…')
            {
                modified_str += ".";
                //zdania++;
            }

            return modified_str;
        }

        public string ZamianaMyslnikow(string tekst)
        {
            //if (tekst[0] == '-' || tekst[0] == '–' || tekst[0] == '—')
            //    tekst = " " + tekst;

            //tekstt = new List<char>();
            //if (tekst[0] != ' ')
            //    tekstt.Add(tekst[0]);

            //for (var i = 1; i < tekst.Length - 1; i++)
            //{
            //    if (tekst[i] == '-' && (tekst[i - 1] == ' ' || tekst[i - 1] == '\n') && tekst[i + 1] == ' ') { tekstt.Add('–'); }
            //    else
            //    {
            //        tekstt.Add(tekst[i]);
            //    }
            //}

            //string tekst1 = "";
            //for (var i = 0; i < tekst.Length - 1; i++)
            //{
            //    tekst1 += tekstt[i];
            //}
            ////tekst1 += tekst[tekst.Length - 1];
            //return tekst1;
            return tekst;
        }

        #endregion

    }
}
