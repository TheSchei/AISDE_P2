using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    enum Typ { KONIEC_BUFORA, KONIEC_RAMKI, ZMIANA_PRĘDKOŚCI, WZMOWIENIE_POBIERANIA};
    class Symulacja
    {
        //    private const float czas_trwania=60;
        //    //private int czas = 0;
        //    private float pozostaly_czas;
        //    private float przepustowość_łącza;
        //    private float przepustowość_nominalna=6;
        //    private Random rand = new Random();
        //    private const int p = 720;
        //    private float ramka;
        //    private float bufor, buforp;
        //    private float pobrane;
        //    private void losuj_przepustowosc()
        //    {
        //        double los = rand.NextDouble();
        //        if (los > 0.8) przepustowość_łącza = 1;
        //        else if (los > 0.2) przepustowość_łącza = 0.75F;
        //        else przepustowość_łącza = 0.2F;
        //    }
        //    private void losuj_przepustowosc2()
        //    {
        //        double los = rand.NextDouble();
        //        if (los > 0.6) przepustowość_łącza = 0.3F;
        //        else if (los > 0.4) przepustowość_łącza = 0.2F;
        //        else przepustowość_łącza = 0.1F;
        //    }
        //    private void oblicz_ramke()
        //    {
        //        ramka = (p * ((16 / 9) * p) * 25*3)/(1024*1024);
        //    }
        //    private void oblicz_ramke2()
        //    {
        //        ramka = 0.5F;//minuty
        //    }
        //    //public string symuluj()
        //    //{
        //    //    pozostaly_czas = czas_trwania;
        //    //    pobrane = 0;
        //    //    bufor = 0;
        //    //    czas = 0;
        //    //    string raport="RAPORT:\n";
        //    //    oblicz_ramke();
        //    //    while (pobrane<czas_trwania)
        //    //    {
        //    //        if (czas<30) losuj_przepustowosc();
        //    //        else losuj_przepustowosc2();
        //    //        czas++;
        //    //        buforp = bufor;
        //    //        if (buforp != 0) bufor += (przepustowość_nominalna * przepustowość_łącza / ramka) - 1;//warunki są raczej dobre, ale przerobić na ciąg zdarzeń
        //    //        else bufor += (przepustowość_nominalna * przepustowość_łącza / ramka);
        //    //        if (bufor < 0)
        //    //        {
        //    //            bufor = buforp + (przepustowość_nominalna * przepustowość_łącza / ramka);
        //    //            pobrane += przepustowość_nominalna * przepustowość_łącza / ramka;
        //    //        }
        //    //        else if (bufor < 10)
        //    //        {
        //    //            pobrane += przepustowość_nominalna * przepustowość_łącza / ramka;
        //    //        }
        //    //        else
        //    //        {
        //    //            pobrane += buforp - (przepustowość_nominalna * przepustowość_łącza / ramka);
        //    //            bufor = 10;
        //    //        }
        //    //        raport += (czas + ". bufor= " + bufor + "\t\t pobrane: " + pobrane + "\tprzep: " + przepustowość_łącza + "\n");
        //    //        if (czas > 100) break;
        //    //    }
        //    //    return raport;
        //    //}

        //    enum Typ { KONIEC_BUFORA, KONIEC_RAMKI, ZMIANA_PRĘDKOŚCI };

        //    struct zdarzenie
        //    {
        //        //public string typ;
        //        public Typ typ;
        //        public float czas;
        //        public zdarzenie(Typ typ, float czas)
        //        {
        //            this.typ = typ;
        //            this.czas = czas;
        //        }
        //        public void ustaw_czas(float czas) { this.czas = czas; }
        //    }
        //    private const int czas_trwania2 = 60;
        //    List <zdarzenie> zdarzenia = new List<zdarzenie>();
        //    float KONIEC_RAMKI;
        //    float KONIEC_BUFORA;
        //    float bufor2=0;
        //    //public void symuluj2()
        //    //{
        //    //    oblicz_ramke2();
        //    //    losuj_przepustowosc();
        //    //    int liczba_ramek = czas_trwania2 / ramka;
        //    //    float czas;
        //    //    czas = ramka / (przepustowość_nominalna * przepustowość_łącza);
        //    //    zdarzenia.Add(new zdarzenie("KONIEC_RAMKI", czas));
        //    //    while (liczba_ramek > 0)
        //    //    {
        //    //        zdarzenia.Sort(((x, y) => x.czas.CompareTo(y.czas)));
        //    //        if (zdarzenia[0].typ== "KONIEC_RAMKI")
        //    //        {
        //    //            bufor += ramka;
        //    //            losuj_przepustowosc();
        //    //            czas = ramka / (przepustowość_nominalna * przepustowość_łącza);
        //    //            zdarzenia.Add(new zdarzenie("KONIEC_RAMKI", czas));
        //    //            zdarzenia.RemoveAt(0);
        //    //        }
        //    //        else if (zdarzenia[0].typ == "KONIEC_BUFORA")//inaczej zrobię. Zrobię zamiast listy zdarzeń 2 oddzielne zdarzenia (ewentualnie 3) i po prostu będę je cały czas modyfikował i 
        //    //                                                       // porównywał które jest wcześniejsze. Tak powinno być wygodniej. Reszta raczej bez zmian, czyly bufor dopisany po całej ramce itp.
        //    //        {

        //    //        }
        //    //    }
        //    //}
        //    public string Symuluj3()
        //    {
        //        string raport = "RAPORT:\n";
        //        oblicz_ramke2();
        //        losuj_przepustowosc();
        //        int liczba_ramek = Convert.ToInt32(czas_trwania2 / ramka);
        //        float czas=0, czasp=0;
        //        raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
        //        //raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
        //        //czas = ramka / (przepustowość_nominalna * przepustowość_łącza);
        //        //czasp = czas;
        //        //KONIEC_RAMKI = czas;
        //        //KONIEC_BUFORA = czas + ramka;
        //        //bufor2 = ramka;
        //        //raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
        //        KONIEC_RAMKI = ramka / (przepustowość_nominalna * przepustowość_łącza);
        //        KONIEC_BUFORA = KONIEC_RAMKI + ramka;
        //        losuj_przepustowosc();
        //        liczba_ramek--;
        //        while (liczba_ramek>0)
        //        {
        //            if (czas < 40) losuj_przepustowosc();//sprawdzić sens
        //            else losuj_przepustowosc2();//sypią się warunki dla "laga"
        //            if (KONIEC_RAMKI<=KONIEC_BUFORA)//sypło się
        //            {
        //                //czas = KONIEC_RAMKI;
        //                //KONIEC_BUFORA += ramka;
        //                //bufor2 += ramka - (czas-czasp);
        //                //KONIEC_RAMKI += (ramka / (przepustowość_nominalna * przepustowość_łącza));
        //                //liczba_ramek--;
        //                czas = KONIEC_RAMKI;
        //                liczba_ramek--;
        //                KONIEC_BUFORA += ramka;
        //                bufor2 = KONIEC_BUFORA - KONIEC_RAMKI;
        //                KONIEC_RAMKI += ramka/(przepustowość_nominalna * przepustowość_łącza);
        //            }
        //            else
        //            {
        //                //czas = KONIEC_BUFORA;
        //                //KONIEC_BUFORA = KONIEC_RAMKI + ramka;
        //                //bufor2 = 0;
        //                czas = KONIEC_BUFORA;
        //                bufor2 = 0;
        //                KONIEC_BUFORA = KONIEC_RAMKI;
        //            }
        //            //czasp=czas;
        //            raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
        //            if (bufor2 > 3F && liczba_ramek>0)
        //            {
        //                //czas += ramka;
        //                KONIEC_RAMKI += ramka;
        //            }
        //        }

        //        //KONIEC_BUFORA -= ramka;//ramka dodająca się gdy nie ma już ramek :p
        //        raport += "Czas: " + KONIEC_BUFORA  + "\n";
        //        return raport;
        //    }
        //    public string Symuluj4()
        //    {
        //        string raport = "RAPORT:\n";
        //        //bufor 30 (3)
        //        //ramka 3 (0.5)
        //        float czas;
        //        //float bufortemp;
        //        oblicz_ramke2();
        //        int liczba_ramek = Convert.ToInt32(czas_trwania2 / ramka);
        //        bool pobieranie = true;
        //        losuj_przepustowosc();
        //        float pozostało_do_pobrania;
        //        czas = (float)rand.NextDouble() * 5 + 5;
        //        zdarzenia.Add(new zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, czas));
        //        czas= ramka / (przepustowość_nominalna * przepustowość_łącza);
        //        zdarzenia.Add(new zdarzenie(Typ.KONIEC_RAMKI, czas));
        //        while(liczba_ramek>0)
        //        {
        //            //zdarzenia.OrderBy(item => (item.czas));
        //            zdarzenia.Sort(((x, y) => x.czas.CompareTo(y.czas)));
        //            switch (zdarzenia[0].typ)
        //            {
        //                case Typ.ZMIANA_PRĘDKOŚCI:
        //                    pozostało_do_pobrania = 1 - ((przepustowość_nominalna * przepustowość_łącza * (zdarzenia[0].czas - czas)) / ramka);//ile pozostalo do pobrania
        //                    //losuj_przepustowosc();
        //                    //bufortemp = bufor;
        //                    bufor2 -= zdarzenia[0].czas - czas;
        //                    if (pozostało_do_pobrania < 0)
        //                    {
        //                        //pozostało_do_pobrania++;//powinno załątwić jeśli jest przepełniony bufor, a prędkość zmieniła się po rozpoczęciu pobierania, czyli po odetkaniu bufora
        //                        pozostało_do_pobrania = 1 - ((przepustowość_nominalna * przepustowość_łącza * ((zdarzenia[0].czas - czas) - (czas + (ramka / (przepustowość_nominalna * przepustowość_łącza))))) / ramka);
        //                        losuj_przepustowosc();
        //                        czas = (ramka * pozostało_do_pobrania) / (przepustowość_nominalna * przepustowość_łącza);//tymczasowa zmiana zastosowania zmiennej
        //                    }
        //                    else if (pobieranie == false)
        //                    {
        //                        losuj_przepustowosc();//ojezualeinba
        //                        czas = zdarzenia[1].czas + (ramka / (przepustowość_nominalna * przepustowość_łącza));
        //                    }
        //                    else
        //                    {
        //                        losuj_przepustowosc();
        //                        czas = (ramka * pozostało_do_pobrania) / (przepustowość_nominalna * przepustowość_łącza);
        //                    }

        //                    //if (pobieranie==false)
        //                    //{
        //                    //    if(pobrane<1)
        //                    //    {

        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        pobrane++;

        //                    //    }
        //                    //}
        //                    //zmien_czas(Typ.KONIEC_RAMKI, czas);
        //                    usun_zdarzenie(Typ.KONIEC_RAMKI);
        //                    zdarzenia.Add(new zdarzenie(Typ.KONIEC_RAMKI, czas));
        //                    czas = zdarzenia[0].czas+((float)rand.NextDouble() * 5 + 5);//znowu recykling
        //                    zdarzenia.Add(new zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, czas));
        //                    czas = zdarzenia[0].czas;
        //                    zdarzenia.RemoveAt(0);
        //                    break;

        //                case Typ.KONIEC_RAMKI:
        //                    liczba_ramek--;
        //                    bufor2 += ramka - (zdarzenia[0].czas - czas);
        //                    if (bufor > 2.5F)
        //                    {
        //                        pobieranie = false;
        //                        czas = zdarzenia[0].czas + (ramka / (przepustowość_nominalna * przepustowość_łącza)) + ramka;
        //                    }
        //                    else
        //                    {
        //                        pobieranie = true;
        //                        czas = zdarzenia[0].czas + (ramka / (przepustowość_nominalna * przepustowość_łącza));
        //                    }
        //                    zdarzenia.Add(new zdarzenie(Typ.KONIEC_RAMKI, czas));
        //                    usun_zdarzenie(Typ.KONIEC_BUFORA);
        //                    czas = zdarzenia[0].czas;
        //                    zdarzenia.Add(new zdarzenie(Typ.KONIEC_BUFORA, czas+bufor2));
        //                    //bufortemp = bufor;
        //                    zdarzenia.RemoveAt(0);
        //                    break;

        //                case Typ.KONIEC_BUFORA:
        //                    bufor2 = 0;
        //                    czas = zdarzenia[0].czas;
        //                    //bufortemp = bufor;
        //                    zdarzenia.RemoveAt(0);
        //                    break;
        //                default:
        //                    throw new Exception("ni ma");
        //            }
        //            //generacja raportu
        //            raport += "czas: " + czas + "\tbufor: " + bufor2 + "\n";
        //            //bufor = bufortemp;
        //        }
        //        raport += "czas: " + zdarzenia[2].czas + "\tbufor: " + (bufor2- zdarzenia[2].czas) + "\n";
        //        return raport;
        //    }
        //    //private void zmien_czas(Typ typ, float czas)
        //    //{
        //    //    for (int i=0; i<zdarzenia.Count(); i++)
        //    //    {
        //    //        if (zdarzenia[i].typ==typ)
        //    //        {
        //    //            zdarzenia[i].ustaw_czas(czas);
        //    //            break;
        //    //        }
        //    //    }
        //    //}
        //    private void usun_zdarzenie(Typ typ)
        //    {
        //        for (int i = 0; i < zdarzenia.Count(); i++)
        //        {
        //            if (zdarzenia[i].typ == typ)
        //            {
        //                zdarzenia.RemoveAt(i);
        //                break;
        //            }
        //        }
        //    }

        private List<Zdarzenie> zdarzenia = new List<Zdarzenie>();
        private double Przepustowość_nominalna=10;//sekund filmu na sekundę
        private double Prędkość;
        private int ilość_ramek = 120;
        private double ramka = 5;//sekund filmu
        private Random Rand=new Random();
        private double bufor=0;
        private double czas = 0, czasp=0;
        private double temp;
        private bool pobieranie = true;
        private double pobrano = 0;
        string raport = "RAPORT:\n";
        public string symuluj()
        {
            przelicz_przepustowość();
            temp = Rand.NextDouble() * 5 + 10;//obliczanie czasu pierwszej możliwej zmiany prędkości
            zdarzenia.Add(new Zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, temp));//dodanie pierwszej zmiany prędkości
            temp = ramka / (Przepustowość_nominalna * Prędkość);//obliczenie czasu pobrania pierwszej ramki
            zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));//dodanie zdarzenia
            while (zdarzenia.Count > 0)
            {
                if (czas>570)
                {
                    czas += 0;
                }
                zdarzenia.Sort(((x, y) => x.Czas.CompareTo(y.Czas)));//sortowanko
                raport += Convert.ToString(zdarzenia[0].Typ) + ":\t\t\t";
                czas = zdarzenia[0].Czas;//ustawienie czasu//prawdopodobnie będę musiał to przenieść do casów, może się przydać "poprzedni czas"
                pobrano += ((czas - czasp) / (ramka / (Przepustowość_nominalna * Prędkość)))/ramka;//postęp pobierania aktualnej ramki
                switch (zdarzenia[0].Typ)
                {
                    case Typ.KONIEC_RAMKI:
                        zdarzenia.RemoveAt(0);
                        pobrano = 0;
                        ilość_ramek--;
                        bufor += ramka;//powiększenie bufora
                        if (ilość_ramek > 0)
                        {
                            if (bufor > 25)//przepełnienie bufora
                            {
                                usun_zdarzenie(Typ.KONIEC_BUFORA);
                                bufor -= (czas - czasp);//zmniejszenie bufora
                                temp = bufor + czas;//nowy koniec bufora
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                                pobieranie = false;
                                temp = czas + ramka;//czas wznowienia pobierania po oddtworzeniu JEDNEJ ramki
                                zdarzenia.Add(new Zdarzenie(Typ.WZMOWIENIE_POBIERANIA, temp));
                            }
                            else if (bufor != ramka)//bufor normalny
                            {
                                bufor -= (czas - czasp);//zmniejszenie bufora
                                //bufor += ramka;//powiększenie bufora
                                usun_zdarzenie(Typ.KONIEC_BUFORA);
                                temp = bufor + czas;//nowy koniec bufora
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                                temp = czas + (ramka / (Przepustowość_nominalna * Prędkość));//nowy koniec ramki
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));
                            }
                            else//pusty bufor
                            {
                                //bufor += ramka;
                                temp = bufor + czas;//nowy koniec bufora
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                                temp = czas + (ramka / (Przepustowość_nominalna * Prędkość));//nowy koniec ramki
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));
                            }
                        }
                        else//ostatnia zmiana końca bufora
                        {
                            usun_zdarzenie(Typ.KONIEC_BUFORA);
                            bufor -= (czas - czasp);//zmniejszenie bufora
                            temp = bufor + czas;//nowy koniec bufora
                            zdarzenia.Add(new Zdarzenie(Typ.KONIEC_BUFORA, temp));
                        }

                        break;
                    case Typ.KONIEC_BUFORA://istnieje tylko dla uładnienia wykresu
                        zdarzenia.RemoveAt(0);//usunięcie zdarzenia
                        bufor = 0;//zerowanie bufora
                        break;
                    case Typ.ZMIANA_PRĘDKOŚCI:
                        if (bufor != 0) bufor -= (czas - czasp);//jeśli się zmieni w trakcie laga to nic się nie dzieje, warunek powinien zadziałąć, bo może to nastąpić TYLKO po zdarzeniu koniec bufora
                        zdarzenia.RemoveAt(0);
                        if (ilość_ramek > 0)
                        {
                            przelicz_przepustowość();
                            if (pobieranie)//jeśli trwa pobieranie to...
                            {
                                usun_zdarzenie(Typ.KONIEC_RAMKI);//usunięcie aktualnego końca ramki
                                temp = (ramka * (1 - pobrano)) / (Przepustowość_nominalna * Prędkość); //czas za ile pobierzesię reszta
                                temp += czas;//przesunięcie w czasie :p
                                zdarzenia.Add(new Zdarzenie(Typ.KONIEC_RAMKI, temp));
                            }//może starczy
                            temp = czas+Rand.NextDouble() * 5 + 10;//obliczanie czasu możliwej zmiany prędkości
                            zdarzenia.Add(new Zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, temp));//dodanie zmiany prędkości
                        }
                        break;
                    case Typ.WZMOWIENIE_POBIERANIA://pamiętać o zerowaniu pobierania
                        pobrano = 0;
                        bufor -= (czas - czasp);//bez warunku, bo pobieranie zatrzyma się tylko  gdzy bufor się przepełni
                        pobieranie = true;
                        temp = czas + (ramka / (Przepustowość_nominalna * Prędkość));//obliczenie czasu pobrania ramki
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
            if (Rand.NextDouble() > 0.4F) Prędkość = 1;
            else Prędkość = 0.05F;
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
