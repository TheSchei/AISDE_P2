using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Symulacja
    {
        private const float czas_trwania=60;
        //private int czas = 0;
        private float pozostaly_czas;
        private float przepustowość_łącza;
        private float przepustowość_nominalna=6;
        private Random rand = new Random();
        private const int p = 720;
        private float ramka;
        private float bufor, buforp;
        private float pobrane;
        private void losuj_przepustowosc()
        {
            double los = rand.NextDouble();
            if (los > 0.8) przepustowość_łącza = 1;
            else if (los > 0.2) przepustowość_łącza = 0.75F;
            else przepustowość_łącza = 0.2F;
        }
        private void losuj_przepustowosc2()
        {
            double los = rand.NextDouble();
            if (los > 0.6) przepustowość_łącza = 0.3F;
            else if (los > 0.4) przepustowość_łącza = 0.2F;
            else przepustowość_łącza = 0.1F;
        }
        private void oblicz_ramke()
        {
            ramka = (p * ((16 / 9) * p) * 25*3)/(1024*1024);
        }
        private void oblicz_ramke2()
        {
            ramka = 0.5F;//minuty
        }
        //public string symuluj()
        //{
        //    pozostaly_czas = czas_trwania;
        //    pobrane = 0;
        //    bufor = 0;
        //    czas = 0;
        //    string raport="RAPORT:\n";
        //    oblicz_ramke();
        //    while (pobrane<czas_trwania)
        //    {
        //        if (czas<30) losuj_przepustowosc();
        //        else losuj_przepustowosc2();
        //        czas++;
        //        buforp = bufor;
        //        if (buforp != 0) bufor += (przepustowość_nominalna * przepustowość_łącza / ramka) - 1;//warunki są raczej dobre, ale przerobić na ciąg zdarzeń
        //        else bufor += (przepustowość_nominalna * przepustowość_łącza / ramka);
        //        if (bufor < 0)
        //        {
        //            bufor = buforp + (przepustowość_nominalna * przepustowość_łącza / ramka);
        //            pobrane += przepustowość_nominalna * przepustowość_łącza / ramka;
        //        }
        //        else if (bufor < 10)
        //        {
        //            pobrane += przepustowość_nominalna * przepustowość_łącza / ramka;
        //        }
        //        else
        //        {
        //            pobrane += buforp - (przepustowość_nominalna * przepustowość_łącza / ramka);
        //            bufor = 10;
        //        }
        //        raport += (czas + ". bufor= " + bufor + "\t\t pobrane: " + pobrane + "\tprzep: " + przepustowość_łącza + "\n");
        //        if (czas > 100) break;
        //    }
        //    return raport;
        //}

        enum Typ { KONIEC_BUFORA, KONIEC_RAMKI, ZMIANA_PRĘDKOŚCI };

        struct zdarzenie
        {
            //public string typ;
            public Typ typ;
            public float czas;
            public zdarzenie(Typ typ, float czas)
            {
                this.typ = typ;
                this.czas = czas;
            }
            public void ustaw_czas(float czas) { this.czas = czas; }
        }
        private const int czas_trwania2 = 60;
        List <zdarzenie> zdarzenia = new List<zdarzenie>();
        float KONIEC_RAMKI;
        float KONIEC_BUFORA;
        float bufor2=0;
        //public void symuluj2()
        //{
        //    oblicz_ramke2();
        //    losuj_przepustowosc();
        //    int liczba_ramek = czas_trwania2 / ramka;
        //    float czas;
        //    czas = ramka / (przepustowość_nominalna * przepustowość_łącza);
        //    zdarzenia.Add(new zdarzenie("KONIEC_RAMKI", czas));
        //    while (liczba_ramek > 0)
        //    {
        //        zdarzenia.Sort(((x, y) => x.czas.CompareTo(y.czas)));
        //        if (zdarzenia[0].typ== "KONIEC_RAMKI")
        //        {
        //            bufor += ramka;
        //            losuj_przepustowosc();
        //            czas = ramka / (przepustowość_nominalna * przepustowość_łącza);
        //            zdarzenia.Add(new zdarzenie("KONIEC_RAMKI", czas));
        //            zdarzenia.RemoveAt(0);
        //        }
        //        else if (zdarzenia[0].typ == "KONIEC_BUFORA")//inaczej zrobię. Zrobię zamiast listy zdarzeń 2 oddzielne zdarzenia (ewentualnie 3) i po prostu będę je cały czas modyfikował i 
        //                                                       // porównywał które jest wcześniejsze. Tak powinno być wygodniej. Reszta raczej bez zmian, czyly bufor dopisany po całej ramce itp.
        //        {

        //        }
        //    }
        //}
        public string Symuluj3()
        {
            string raport = "RAPORT:\n";
            oblicz_ramke2();
            losuj_przepustowosc();
            int liczba_ramek = Convert.ToInt32(czas_trwania2 / ramka);
            float czas=0, czasp=0;
            raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
            //raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
            //czas = ramka / (przepustowość_nominalna * przepustowość_łącza);
            //czasp = czas;
            //KONIEC_RAMKI = czas;
            //KONIEC_BUFORA = czas + ramka;
            //bufor2 = ramka;
            //raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
            KONIEC_RAMKI = ramka / (przepustowość_nominalna * przepustowość_łącza);
            KONIEC_BUFORA = KONIEC_RAMKI + ramka;
            losuj_przepustowosc();
            liczba_ramek--;
            while (liczba_ramek>0)
            {
                if (czas < 40) losuj_przepustowosc();//sprawdzić sens
                else losuj_przepustowosc2();//sypią się warunki dla "laga"
                if (KONIEC_RAMKI<=KONIEC_BUFORA)//sypło się
                {
                    //czas = KONIEC_RAMKI;
                    //KONIEC_BUFORA += ramka;
                    //bufor2 += ramka - (czas-czasp);
                    //KONIEC_RAMKI += (ramka / (przepustowość_nominalna * przepustowość_łącza));
                    //liczba_ramek--;
                    czas = KONIEC_RAMKI;
                    liczba_ramek--;
                    KONIEC_BUFORA += ramka;
                    bufor2 = KONIEC_BUFORA - KONIEC_RAMKI;
                    KONIEC_RAMKI += ramka/(przepustowość_nominalna * przepustowość_łącza);
                }
                else
                {
                    //czas = KONIEC_BUFORA;
                    //KONIEC_BUFORA = KONIEC_RAMKI + ramka;
                    //bufor2 = 0;
                    czas = KONIEC_BUFORA;
                    bufor2 = 0;
                    KONIEC_BUFORA = KONIEC_RAMKI;
                }
                //czasp=czas;
                raport += "Czas: " + czas + "\tbufor = " + bufor2 + "\n";
                if (bufor2 > 3F && liczba_ramek>0)
                {
                    //czas += ramka;
                    KONIEC_RAMKI += ramka;
                }
            }

            //KONIEC_BUFORA -= ramka;//ramka dodająca się gdy nie ma już ramek :p
            raport += "Czas: " + KONIEC_BUFORA  + "\n";
            return raport;
        }
        public void Symuluj4()//muszę jeszcze dużo zrobić, ale przede wszystkim poprawić wszystko z buforem bo zapomniałem o jego wygaszaniu i przepełnianiu
        {
            //bufor 30 (3)
            //ramka 3 (0.5)
            float czas;
            //float bufortemp;
            int liczba_ramek = Convert.ToInt32(czas_trwania2 / ramka);
            bool pobieranie = true;
            losuj_przepustowosc();
            float pozostało_do_pobrania;
            czas = (float)rand.NextDouble() * 5 + 5;
            zdarzenia.Add(new zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, czas));
            czas= ramka / (przepustowość_nominalna * przepustowość_łącza);
            zdarzenia.Add(new zdarzenie(Typ.KONIEC_RAMKI, czas));
            while(liczba_ramek>0)
            {
                zdarzenia.OrderBy(item => (item.czas));
                
                switch (zdarzenia[0].typ)
                {
                    case Typ.ZMIANA_PRĘDKOŚCI:
                        pozostało_do_pobrania = 1 - ((przepustowość_nominalna * przepustowość_łącza * (zdarzenia[0].czas - czas)) / ramka);//ile pozostalo do pobrania
                        //losuj_przepustowosc();
                        //bufortemp = bufor;
                        bufor2 -= zdarzenia[0].czas - czas;
                        if (pozostało_do_pobrania < 0)
                        {
                            //pozostało_do_pobrania++;//powinno załątwić jeśli jest przepełniony bufor, a prędkość zmieniła się po rozpoczęciu pobierania, czyli po odetkaniu bufora
                            pozostało_do_pobrania = 1 - ((przepustowość_nominalna * przepustowość_łącza * ((zdarzenia[0].czas - czas) - (czas + (ramka / (przepustowość_nominalna * przepustowość_łącza))))) / ramka);
                            losuj_przepustowosc();
                            czas = (ramka * pozostało_do_pobrania) / (przepustowość_nominalna * przepustowość_łącza);//tymczasowa zmiana zastosowania zmiennej
                        }
                        else if (pobieranie == false)
                        {
                            losuj_przepustowosc();//ojezualeinba
                            czas = zdarzenia[1].czas + (ramka / (przepustowość_nominalna * przepustowość_łącza));
                        }
                        else
                        {
                            losuj_przepustowosc();
                            czas = (ramka * pozostało_do_pobrania) / (przepustowość_nominalna * przepustowość_łącza);
                        }

                        //if (pobieranie==false)
                        //{
                        //    if(pobrane<1)
                        //    {

                        //    }
                        //    else
                        //    {
                        //        pobrane++;

                        //    }
                        //}
                        //zmien_czas(Typ.KONIEC_RAMKI, czas);
                        usun_zdarzenie(Typ.KONIEC_RAMKI);
                        zdarzenia.Add(new zdarzenie(Typ.KONIEC_RAMKI, czas));
                        czas = zdarzenia[0].czas+((float)rand.NextDouble() * 5 + 5);//znowu recykling
                        zdarzenia.Add(new zdarzenie(Typ.ZMIANA_PRĘDKOŚCI, czas));
                        czas = zdarzenia[0].czas;
                        zdarzenia.RemoveAt(0);
                        break;

                    case Typ.KONIEC_RAMKI:
                        liczba_ramek--;
                        bufor2 += ramka - (zdarzenia[0].czas - czas);
                        if (bufor > 2.5F)
                        {
                            pobieranie = false;
                            czas = zdarzenia[0].czas + (ramka / (przepustowość_nominalna * przepustowość_łącza)) + ramka;
                        }
                        else
                        {
                            pobieranie = true;
                            czas = zdarzenia[0].czas + (ramka / (przepustowość_nominalna * przepustowość_łącza));
                        }
                        zdarzenia.Add(new zdarzenie(Typ.KONIEC_RAMKI, czas));
                        czas = zdarzenia[0].czas;
                        //bufortemp = bufor;
                        zdarzenia.RemoveAt(0);
                        break;

                    case Typ.KONIEC_BUFORA:
                        bufor2 = 0;
                        czas = zdarzenia[0].czas;
                        //bufortemp = bufor;
                        zdarzenia.RemoveAt(0);
                        break;
                    default:
                        throw new Exception("ni ma");
                }
                //generacja raportu
                //bufor = bufortemp;
            }
        }
        //private void zmien_czas(Typ typ, float czas)
        //{
        //    for (int i=0; i<zdarzenia.Count(); i++)
        //    {
        //        if (zdarzenia[i].typ==typ)
        //        {
        //            zdarzenia[i].ustaw_czas(czas);
        //            break;
        //        }
        //    }
        //}
        private void usun_zdarzenie(Typ typ)
        {
            for (int i = 0; i < zdarzenia.Count(); i++)
            {
                if (zdarzenia[i].typ == typ)
                {
                    zdarzenia.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
