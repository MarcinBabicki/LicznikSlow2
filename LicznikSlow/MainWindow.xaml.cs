using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LicznikSlow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //zmienne
        Wynik wynik;
        Wynik_tekst wyniktekst;
        bool zmieniacmyslniki = false;
        string tekstOut = "";
        string tekst = "";
        int znaki = 0;
        int slowa = 0;
        int zdania = 0;
        int biezaceZdanie = 0;
        string[] orderSmoczkaTeksk = { "Order Ryb", "Order Straszliwca", "Order Night Lights", "Order Smoczka", "Order Saczysmarka", "Order Tira", "Order Serialu", "Order Sluchawek z Kablem", "order MegaWonsza9", "Order Mickiewicza", "Order Sil Piekielnych" };
        string[] orderTekstTekst = { "Twoje opowiadanie jest krótsze", "Twoje opowiadanie jest tak małe, jak Straszliwiec.", "Twoje opowidanie się ładnie rozwija.", "Małe opowiadanka tak szybko rosną      :')", "A ciebie ponosi imaginacja!", "Twoje opwiadanie jest tak wielkie", "Twoje opowiadanie ciagnie się", " Twoje opowiadanie jest tak poplą    tane, jak słuchawki", "Na począ    tku był MegaWonsz9.", "Za wytrwałą      pracę nad wklejaniem wszystkich swoich", "IDŹ PRECZ SIŁO NIECZYSTA!!!" };
        string[] orderTekst2Tekst = { "niż przeciętny wytwór Ryb!  Otrzymujesz", "I tak samo niebezpieczne!  Otrzymujesz", "Tak samo jak Night Lights. Otrzymujesz", "Otrzymujesz", "Otrzymujesz", "i grube jak tir.  Otrzymujesz", "jak przęciętny Polski serial.  Otrzymujesz", "z kablem po wyjęciu ich z kieszeni.  Otrzymujesz", "A potem stworzył tak długie opowiadanie,", "opowiadań do jednego dokumentu otrzymujesz", "Otrzymujesz" };
        string[] orderTekstDodTekst = { "Rozwaliła system!", "Kij wie co z niego wyrośnie.", "", "", "", "", "", "", "jakiego ty nigdy nie będziesz w stanie stworzyć.  Otrzymujesz", "Oficjalnie otrzymujesz tytuł wieszcza domowego. Upoważnia on m. in. do kłótni z innymi wieszczami.", "" };
        string[] orderSource = { "zbojci1.jpg", "straszliwiecOrder.jpg", "nightLightsOrder.png", "smoczek.bmp", "saczysmarkOrder.png", "tirOrder.jpg", "serialOrder.jpg", "słuchawki order.jpg", "megawonsz9Order.jpg", "adam-mickiewicz-memy.jpg", "demonOrder.jpg" };
        int[] orderTekstFontSize = { 12, 11, 12, 12, 12, 12, 12, 10, 12, 10, 12 };
        int[] orderTekst2FontSize = { 12, 12, 12, 12, 12, 12, 12, 11, 12, 11, 12 };
        int[] orderWidth = { 133, 194, 188, 104, 56, 159, 160, 152, 94, 89, 89 };
        List<char> tekstt = new List<char>();
        public static readonly HttpClient client = new HttpClient();



        public MainWindow()
        {
            InitializeComponent();
        }

        //Metody najróżniejsze
        public void WczytanieTekstu()
        {
            TextRange textRange = new TextRange(pudelko.Document.ContentStart, pudelko.Document.ContentEnd);
            tekst = textRange.Text;
            tekst = tekst.Trim('\r', '\n', ' ');
        }

        public string ZamianaMyslnikow(string tekst)
        {
            if (tekst[0] == '-' || tekst[0] == '–' || tekst[0] == '—')
                tekst = " " + tekst;

            tekstt = new List<char>();
            if (tekst[0] != ' ')
                tekstt.Add(tekst[0]);

            for (var i = 1; i < tekst.Length - 1; i++)
            {
                if (tekst[i] == '-' && (tekst[i - 1] == ' ' || tekst[i - 1] == '\n') && tekst[i + 1] == ' ') { tekstt.Add('–'); }
                else
                {
                    tekstt.Add(tekst[i]);
                }
            }

            string tekst1 = "";
            for (var i = 0; i < tekst.Length - 1; i++)
            {
                tekst1 += tekstt[i];
            }
            //tekst1 += tekst[tekst.Length - 1];
            return tekst1;
        }

        public void Interpunkcja()
        {
            tekstt = new List<char>();
            //tekstt.Add();
            for (var i = 1; i < tekst.Length - 2; i++)
            {
                if (tekst[i] == '.' || tekst[i] == '!' || tekst[i] == '?' || tekst[i] == ',' || tekst[i] == ';' || tekst[i] == ':')
                {
                    if (tekst[i + 1] != ' ') { tekst = tekst.Insert(i + 1, " "); }
                    if (tekst[i - 1] == ' ') { tekst = tekst.Remove(i - 1, 1); }
                }
                else if (tekst[i] == '(' || tekst[i] == '[' || tekst[i] == '{' || tekst[i] == '<') {

                }
                else if (tekst[i] == ')' || tekst[i] == ']' || tekst[i] == '}' || tekst[i] == '>')
                {
                    if (tekst[i + 1] != ' ') { tekst = tekst.Insert(i + 1, " "); }
                    if (tekst[i - 1] == ' ') { tekst = tekst.Remove(i - 1, 1); }
                }
                else if (tekst[i] == '/' || tekst[i] == '\\')
                {
                    if (tekst[i + 1] == ' ') { tekst = tekst.Remove(i + 1, 1); }
                    if (tekst[i - 1] == ' ') { tekst = tekst.Remove(i - 1, 1); }
                }
            }

        }

        public string Obrobka(string modified_str)
        {
            modified_str = modified_str.Trim();
            if (modified_str != "")
            {
                modified_str = LastSentence(modified_str);
                znaki += modified_str.Length;
                modified_str += "\n";
            }         
            return modified_str;
        }

        public string LastSentence(string modified_str) //Obsługa ostatniego zdania
        {
            if (modified_str[modified_str.Length - 1] != '.' && modified_str[modified_str.Length - 1] != '?' && modified_str[modified_str.Length - 1] != '!' && modified_str[modified_str.Length - 1] != '…')
            {
                modified_str += ".";
                zdania++;
            }

            return modified_str;
        }

        public void Zliczanie()
        {
            slowa = 0;
            zdania = 0;
            znaki = 0;
            int eofParagraph = 0;
            string s = "";

            if (tekst != "")
            {

                if (tekst.Contains("\n"))
                {
                    tekst += "\r\n ";
                    for (var i = 0; i < tekst.Length - 1; i++)
                    {
                        biezaceZdanie++;

                        if (tekst[i] == '\n')
                        {
                            if (i - eofParagraph > 1)
                            {
                                s = tekst.Substring(eofParagraph, i - eofParagraph);
                                s = Obrobka(s);
                                if (s != "") tekstOut += s;
                            }

                            eofParagraph = i;
                        }
                        else
                        {

                            if ((tekst[i] == ' ' && tekst[i + 1] != ' ' && tekst[i + 1] != '–' && tekst[i + 1] != '—' && tekst[i + 1] != '-') || (tekst[i + 1] == '\r' && tekst[i] != ' ') || (tekst[i + 1] == '/')) slowa++;

                            if ((tekst[i] == '.' || tekst[i] == '!' || tekst[i] == '?' || tekst[i] == '…') && (tekst[i + 1] == ' ' || tekst[i + 1] == '\r'))
                            {

                                if (biezaceZdanie > 1)
                                {
                                    zdania++;
                                    biezaceZdanie = 0;
                                }
                            }
                        }
                    }
                    if (tekst[1] == '-' || tekst[1] == '–' || tekst[1] == '—' && tekst[2] == ' ') slowa -= 1;

                } else
                {
                    tekst += "\r";
                    for (var i = 0; i < tekst.Length - 1; i++)
                    {
                        biezaceZdanie++;

                        if ((tekst[i] == ' ' && tekst[i + 1] != ' ' && tekst[i + 1] != '–' && tekst[i + 1] != '—' && tekst[i + 1] != '-') || (tekst[i + 1] == '\r' && tekst[i] != ' ')) slowa++;

                        if ((tekst[i] == '.' || tekst[i] == '!' || tekst[i] == '?' || tekst[i] == '…') && (tekst[i + 1] == ' ' || tekst[i + 1] == '\r'))
                        {

                            if (biezaceZdanie > 1)
                            {
                                zdania++;
                                biezaceZdanie = 0;
                            }
                        }
                    }
                    if (tekst[0] == '-' || tekst[0] == '–' || tekst[0] == '—' && tekst[1] == ' ')
                    {
                        slowa -= 1;
                    }
                    tekstOut = tekst;
                    tekstOut = Obrobka(tekstOut);
                }
            }
        }

        public int RodzajOrderu()
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

        public void WybieranieOrderu(int rodzajOrderu)
        {
            try
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory;
                //Console.WriteLine(filePath);
                filePath = filePath.Substring(0, filePath.Length - 10);
                //Console.WriteLine(filePath);
                wynik.order.Source = new BitmapImage(new Uri(filePath + "images\\" + orderSource[rodzajOrderu]));
            }
            catch (UriFormatException e)
            {
                Console.WriteLine(e);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }

            wynik.orderTekst.Text = orderTekstTekst[rodzajOrderu];
            wynik.orderTekst2.Text = orderTekst2Tekst[rodzajOrderu];
            wynik.orderSmoczka.Text = orderSmoczkaTeksk[rodzajOrderu];
            wynik.orderTekst.FontSize = orderTekstFontSize[rodzajOrderu];
            wynik.orderTekst2.FontSize = orderTekst2FontSize[rodzajOrderu];
            wynik.order.Width = orderWidth[rodzajOrderu];
            wynik.orderTekstDod.Text = orderTekstDodTekst[rodzajOrderu];
        }

        /*static async Task ClientCheck()
        {
            //Uri myUri = new Uri("http://localhost/wordpress/wp-admin/", UriKind.Absolute);
            HttpResponseMessage response = await client.GetAsync("http://localhost/wordpress/wp-admin/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            Console.WriteLine(responseBody);
            try
            {
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }*/



        //naciśnięcie przycisku
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (wynik != null)
                wynik.Close();

            if (zamiana.IsChecked == true)
                zmieniacmyslniki = true;

            else
                zmieniacmyslniki = false;

            wynik = new Wynik();
            wyniktekst = new Wynik_tekst();
            WczytanieTekstu();
            Zliczanie();

            //await ClientCheck();
            //wynik.orderTekstDod.Text = x;

            //wyświetlanie
            wynik.wznaki.Text = "Znaki: " + (znaki).ToString();
            wynik.wslowa.Text = "Słowa: " + slowa.ToString();
            wynik.wzdania.Text = "Zdania: " + zdania.ToString();
            if (zdania == 0)
            {
                wynik.srednia.Text = "Średnia: 0";
            }
            else
            {
                wynik.srednia.Text = "Średnia: " + (Math.Round((Convert.ToDouble(slowa) / zdania) * 100) / 100).ToString();
            }


            if (RodzajOrderu() == 9)
            {
                wynik.orderTekstDod.FontSize = 8;
            }
            else
            {
                wynik.orderTekstDod.FontSize = 10;
            }

            WybieranieOrderu(RodzajOrderu());

            if (zmieniacmyslniki == true)
            {
                tekstOut = ZamianaMyslnikow(tekstOut);
                wyniktekst.zmienionyTekst.Document.Blocks.Clear();
                wyniktekst.zmienionyTekst.AppendText(tekstOut);
                wyniktekst.Owner = this;
                wyniktekst.Show();
                wyniktekst.Focus();
            }

            pudelko.Document.Blocks.Clear();
            wynik.Owner = this;
            wynik.Show();
            wynik.Focus();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Console.WriteLine("AA");
            Application.Current.Shutdown();
        }
    }
}
