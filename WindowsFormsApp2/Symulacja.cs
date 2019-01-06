using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    enum Typ { KONIEC_BUFORA, KONIEC_RAMKI, ZMIANA_PRĘDKOŚCI, WZMOWIENIE_POBIERANIA};
    class Symulacja
    {
        private double[] jakosci = { 1, 2, 4 };
        private List<Zdarzenie> zdarzenia = new List<Zdarzenie>();
        private double Przepustowość_nominalna=6;//sekund filmu na sekundę
        private double Prędkość;
        private double pierwsza_pochodna=0;
        private double druga_pochodna;
        private int ilość_ramek = 600;//120;
        private double ramka = 0.5;//5;//sekund filmu
        private double jakosc;//dodać funkcje zainicjuj jakosc
        private Random Rand=new Random();
        private double bufor=0;
        private double czas = 0, czasp=0;
        private double temp;
        private bool pobieranie = true;
        private double pobrano = 0;
        private double BUFOR_max = 30;
        private List<System.Drawing.PointF> Punkty_prędkości = new List<System.Drawing.PointF>();
        private List<System.Drawing.PointF> Punkty_bufora = new List<System.Drawing.PointF>();
        private List<System.Drawing.PointF> Punkty_jakości = new List<System.Drawing.PointF>();
        string raport = "RAPORT:\n";

        public List<PointF> Punkty_Prędkości { get => Punkty_prędkości; set => Punkty_prędkości = value; }
        public List<PointF> Punkty_Bufora { get => Punkty_bufora; set => Punkty_bufora = value; }
        public double Czas { get => czas; set => czas = value; }
        public double BUFOR_MAX { get => BUFOR_max; set => BUFOR_max = value; }
        public List<PointF> Punkty_Jakości { get => Punkty_jakości; set => Punkty_jakości = value; }

        public string symuluj()
        {
            if (ilość_ramek<118)
            {
                ilość_ramek += 0;
            }
            //przelicz_przepustowość();//do wywalenia
            Zainicjuj_dane();
            Punkty_jakości.Add(new System.Drawing.PointF(0, (float)jakosc));
            Punkty_prędkości.Add(new System.Drawing.PointF(0, (float)Prędkość));
            //temp = Rand.NextDouble() * 5 + 10;//obliczanie czasu pierwszej możliwej zmiany prędkości
            temp = Rand.NextDouble() * 0.5 + 0.5;
            zdarzenia.Add(new Zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, temp));//dodanie pierwszej zmiany prędkości
            temp = ramka*jakosc / (Przepustowość_nominalna * Prędkość);//obliczenie czasu pobrania pierwszej ramki
            zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));//dodanie zdarzenia
            while (zdarzenia.Count > 0)
            {
                zdarzenia.Sort(((x, y) => x.Czas.CompareTo(y.Czas)));//sortowanko
                raport += Convert.ToString(zdarzenia[0].Typ) + ":\t\t\t";
                czas = zdarzenia[0].Czas;//ustawienie czasu
                pobrano += ((czas - czasp) / (ramka*jakosc / (Przepustowość_nominalna * Prędkość)));///ramka;//postęp pobierania aktualnej ramki
                switch (zdarzenia[0].Typ)
                {
                    case Typ.KONIEC_RAMKI:
                        Punkty_jakości.Add(new System.Drawing.PointF((float)czas, (float)jakosc));
                        ustaw_jakość();
                        pobrano = 0;
                        ilość_ramek--;
                        if (bufor!=0) bufor -= (czas - czasp);
                        Punkty_bufora.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)bufor));//dodane dzisiaj
                        bufor += ramka;//powiększenie bufora
                        if (ilość_ramek > 0)
                        {
                            //ustaw_jakosc()
                            if (bufor > (BUFOR_max-ramka))//przepełnienie bufora
                            {
                                usun_zdarzenie(Typ.KONIEC_BUFORA);
                                temp = bufor + czas;//nowy koniec bufora
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                                pobieranie = false;
                                temp = czas + ramka;//czas wznowienia pobierania po oddtworzeniu JEDNEJ ramki
                                zdarzenia.Add(new Zdarzenie(Typ.WZMOWIENIE_POBIERANIA, temp));
                                //Punkty_jakości.Add(new System.Drawing.PointF((float)czas, 0));
                                Punkty_jakości.Add(new System.Drawing.PointF((float)czas, (float)jakosc));
                            }
                            else if (bufor != ramka)//bufor normalny
                            {
                                usun_zdarzenie(Typ.KONIEC_BUFORA);
                                temp = bufor + czas;//nowy koniec bufora
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                                temp = czas + (ramka*jakosc / (Przepustowość_nominalna * Prędkość));//nowy koniec ramki
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));
                                Punkty_jakości.Add(new System.Drawing.PointF((float)czas, (float)jakosc));
                            }
                            else//pusty bufor
                            {
                                temp = bufor + czas;//nowy koniec bufora
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                                temp = czas + (ramka*jakosc / (Przepustowość_nominalna * Prędkość));//nowy koniec ramki
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));
                                Punkty_jakości.Add(new System.Drawing.PointF((float)czas, (float)jakosc));
                            }
                        }
                        else//ostatnia zmiana końca bufora
                        {
                            usun_zdarzenie(Typ.KONIEC_BUFORA);
                            temp = bufor + czas;//nowy koniec bufora
                            zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                        }
                        Punkty_bufora.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)bufor));
                        zdarzenia.RemoveAt(0);
                        break;
                    case Typ.KONIEC_BUFORA://istnieje tylko dla uładnienia wykresu
                        bufor = 0;//zerowanie bufora
                        Punkty_bufora.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)bufor));
                        zdarzenia.RemoveAt(0);//usunięcie zdarzenia
                        break;
                    case Typ.ZMIANA_PRĘDKOŚCI:
                        if (bufor != 0) bufor -= (czas - czasp);//jeśli się zmieni w trakcie laga to nic się nie dzieje, warunek powinien zadziałąć, bo może to nastąpić TYLKO po zdarzeniu koniec bufora
                        Punkty_bufora.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)bufor));
                        Punkty_prędkości.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)Prędkość));
                        przelicz_przepustowość();
                        Punkty_prędkości.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)Prędkość));
                        if (ilość_ramek > 0)
                        {
                            if (pobieranie)//jeśli trwa pobieranie to...
                            {
                                usun_zdarzenie(Typ.KONIEC_RAMKI);//usunięcie aktualnego końca ramki
                                temp = (ramka*jakosc * (1 - pobrano)) / (Przepustowość_nominalna * Prędkość); //czas za ile pobierzesię reszta
                                temp += zdarzenia[0].Czas;//przesunięcie w czasie :p
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));
                            }//może starczy
                            //temp = czas + Rand.NextDouble() * 5 + 10;//obliczanie czasu możliwej zmiany prędkości
                            temp = czas + Rand.NextDouble() * 0.5 + 0.5;
                            zdarzenia.Add(new Zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, temp));//dodanie zmiany prędkości
                        }
                        else
                        {
                            Punkty_prędkości.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)Prędkość));
                            Punkty_prędkości.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, 0));
                        }
                        zdarzenia.RemoveAt(0);
                        break;
                    case Typ.WZMOWIENIE_POBIERANIA://pamiętać o zerowaniu pobierania
                        pobrano = 0;
                        //Punkty_jakości.Add(new System.Drawing.PointF((float)czas, 0));
                        Punkty_jakości.Add(new System.Drawing.PointF((float)czas, (float)jakosc));
                        ustaw_jakość();
                        Punkty_jakości.Add(new System.Drawing.PointF((float)czas, (float)jakosc));
                        bufor -= (czas - czasp);//bez warunku, bo pobieranie zatrzyma się tylko  gdzy bufor się przepełni
                        Punkty_bufora.Add(new System.Drawing.PointF((float)zdarzenia[0].Czas, (float)bufor));
                        pobieranie = true;
                        temp = czas + (ramka*jakosc / (Przepustowość_nominalna * Prędkość));//obliczenie czasu pobrania ramki
                        zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));//dodanie zdarzenia
                        zdarzenia.RemoveAt(0);
                        break;
                    default:
                        return "Błąd";
                }
                czasp = czas;
                raport += "Czas: " + czas + "\tBufor: " + bufor + "\t ramki: " + ilość_ramek + "\n";
            }
            return raport;
        }
        private void przelicz_przepustowość()
        {
            //if (Rand.NextDouble() > 0.3) Prędkość = 1;
            //else Prędkość = 0.05;
            ////nowa
            if (Rand.NextDouble() > 0.05)//95% szans na mały wzrost
                druga_pochodna = Rand.NextDouble() / 100;
            else
                druga_pochodna = Rand.NextDouble() / -10;

            pierwsza_pochodna += druga_pochodna;
            if (pierwsza_pochodna > 0.1) pierwsza_pochodna = 0.1;//zabezpieczenia przed przesadą, dobrać parametry
            else if (pierwsza_pochodna < -0.1) pierwsza_pochodna = -0.1;
            Prędkość += pierwsza_pochodna;
            if (Prędkość > 1)
            {
                Prędkość = 1;
                pierwsza_pochodna = 0;
            }//zabezpieczenia przed przesadą, dobrać parametry
            else if (Prędkość < 0)
            {
                Prędkość = 0;
                pierwsza_pochodna = 0;
            }
        }
        private void Zainicjuj_dane()
        {
            Prędkość = System.Math.Sqrt((Rand.NextDouble()/2)+0.5);
            przelicz_przepustowość();
            ustaw_jakość();
        }
        private void usun_zdarzenie(Typ typ)
        {
            for (int i=0; i<zdarzenia.Count(); i++)
            {
                if (zdarzenia[i].Typ==typ)
                {
                    zdarzenia.RemoveAt(i);
                    break;
                }
            }
        }
        private void ustaw_jakość()//powinno działąć, anie nie tetowałem
        {
            int i=0;
            if (bufor>BUFOR_MAX/2)
            {
                for (int j = 0; j < jakosci.Length; j++)
                {
                    if (jakosci[j] == jakosc)
                    {
                        i = j;
                        break;
                    }
                }
            }
            jakosc = jakosci[i];
            for (int j = i; j < jakosci.Length; j++)
            {
                if (jakosci[j] > Prędkość * Przepustowość_nominalna) break;
                else jakosc = jakosci[j];
            }
        }
    }
    class Zdarzenie
    {
        private double czas;
        private Typ typ;
        public Zdarzenie(Typ typ, double czas)
        {
            this.typ = typ;
            this.Czas = czas;
        }

        public double Czas { get => czas; set => czas = value; }
        public Typ Typ { get => typ; set => typ = value; }
    }
}
