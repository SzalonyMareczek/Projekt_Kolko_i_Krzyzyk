using System;

namespace Kolko_I_Krzyzyk
{
    class Program
    {
        static void Main(string[] args)
        {
            int statusGry = 0;
            char[] znacznik = { '1', '2', '3', '4', '5', '6', '7', '8', '9', };
            int Gracz = 1;
            Powitanie();
            Gracz = KolejnyGracz(Gracz);
            

            do
            {
                Console.Clear();
                Gracz = KolejnyGracz(Gracz);
                Menu(znacznik);
                SilnikGry(znacznik, Gracz);
                statusGry = Zwyciezca(znacznik);               
            } while (statusGry.Equals(0));
            Console.Clear();
            Menu(znacznik);
            if (statusGry.Equals(1))
            {
                if (Gracz == 1)
                {
                    Console.WriteLine("\r\n");
                    Console.WriteLine($"Gratulacje, wygrałeś!");
                    Console.ReadKey();
                }
                if(Gracz == 2)
                {
                    Console.WriteLine("\r\n");
                    Console.WriteLine($"Przegrałeś z komputerem który stawia kółka w losowe miejsca, gratulacje!\r\nPrzeczytaj zasady gry jeszcze raz i spróbuj ponownie");
                    Console.ReadKey();
                }
            }

            if (statusGry.Equals(2))
            {
                Console.WriteLine("\r\n");
                Console.WriteLine($"Remis");
                Console.ReadKey();
            }
        }
        private static int Zwyciezca(char[] znacznik)
        {
            if (CzyWygrana(znacznik))
            {
                return 1;
            }

            if (CzyRemis(znacznik))
            {
                return 2;
            }

            
            

            return 0;
        }
        static void Przyklad()
        {
            Console.WriteLine("Przykład wygranej: \r\n");
            Console.WriteLine("  X | O | X  ");
            Console.WriteLine("-------------");
            Console.WriteLine("  O | X | O  ");
            Console.WriteLine("-------------");
            Console.WriteLine("  7 | 8 | X  ");
        }
        static void Powitanie()
        {
            char[] znacznik = { '1', '2', '3', '4', '5', '6', '7', '8', '9', };
            Console.WriteLine("Witaj w grze Kółko i krzyżyk! \r\n ");
            Console.WriteLine("Autorzy: Michal Redek 47405, Marek Udziela 49130\r\n ");
            Console.WriteLine("Instrukcja: Aby postawić kółko lub krzyżyk wpisz numer odpowiadający danemu polu \r\n");
            Menu(znacznik);
            Console.WriteLine("\r\n");
            Console.WriteLine("Aby wygrać grę, gracz musi postawić trzy krzyżyki w tej samej linii. Linie mogą być pionowe, poziome i po ukosie.\r\n");
            Przyklad();
            Console.WriteLine("\r\n");
            Console.WriteLine("Gracz 1 (Ty) : X, Gracz 2 (Komputer) : O");
            Console.WriteLine("Jeśli zrozumialeś zasady, wciśnij dowolny klawisz aby kontunować\r\n");
            Console.ReadKey();
            Console.Clear();
        }
        static void Menu(char[] znacznik)
        {

            Console.WriteLine($"  {znacznik[0]} | {znacznik[1]} | {znacznik[2]}  ");
            Console.WriteLine("-------------");
            Console.WriteLine($"  {znacznik[3]} | {znacznik[4]} | {znacznik[5]}  ");
            Console.WriteLine("-------------");
            Console.WriteLine($"  {znacznik[6]} | {znacznik[7]} | {znacznik[8]}  ");
        }
        static char ZnacznikGracza(int Gracz)
        {
            if (Gracz % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }
        static int KolejnyGracz(int Gracz)
        {
            if (Gracz.Equals(1))
            {
                return 2;
            }
            return 1;
        }
        private static bool CzyWygrana(char[] znacznik)
        {
            if (PorownanieZnacznikowTrzy(znacznik, 0, 1, 2))
            {
                return true;
            }

            if (PorownanieZnacznikowTrzy(znacznik, 3, 4, 5))
            {
                return true;
            }

            if (PorownanieZnacznikowTrzy(znacznik, 6, 7, 8))
            {
                return true;
            }

            if (PorownanieZnacznikowTrzy(znacznik, 0, 3, 6))
            {
                return true;
            }

            if (PorownanieZnacznikowTrzy(znacznik, 1, 4, 7))
            {
                return true;
            }

            if (PorownanieZnacznikowTrzy(znacznik, 2, 5, 8))
            {
                return true;
            }

            if (PorownanieZnacznikowTrzy(znacznik, 0, 4, 8))
            {
                return true;
            }

            if (PorownanieZnacznikowTrzy(znacznik, 2, 4, 6))
            {
                return true;
            }

            return false;
        }
        private static bool PorownanieZnacznikowTrzy(char[] Znacznikitest, int poz1, int poz2, int poz3)
        {
            //Porownujemy Czy postawiony został 3 razy krzyżyk lub 3 razy kółko, potrzebne do sprawdzenia czy wygralismy gre
            return Znacznikitest[poz1].Equals(Znacznikitest[poz2]) && Znacznikitest[poz2].Equals(Znacznikitest[poz3]);
        }
        private static bool PorownanieZnacznikowDwa(char[] Znacznikitest, int poz1, int poz2)
        {          
            if (Znacznikitest[poz1] == 'X') {
                return Znacznikitest[poz1].Equals(Znacznikitest[poz2]);
                    }
            else
            {
                return false;
            }                                              
        }
        private static bool CzyRemis(char[] znaczniki)
        {
            return znaczniki[0] != '1' &&
                   znaczniki[1] != '2' &&
                   znaczniki[2] != '3' &&
                   znaczniki[3] != '4' &&
                   znaczniki[4] != '5' &&
                   znaczniki[5] != '6' &&
                   znaczniki[6] != '7' && 
                   znaczniki[7] != '8' &&
                   znaczniki[8] != '9';
        }
        private static bool CzyDwazRzedu(char[] znacznik) 
        {            

            if (PorownanieZnacznikowDwa(znacznik, 0, 1))
            {
                if (znacznik[2] != 'X' && znacznik[2] != 'O')
                {                   
                        return true;
                    
                }
            }
            
             if (PorownanieZnacznikowDwa(znacznik, 0, 2))
             {
                 if (znacznik[1] != 'X' && znacznik[1] != 'O')
                 {
                     return true;
                 }
             }
             if (PorownanieZnacznikowDwa(znacznik, 1, 2))
             {
                 if (znacznik[0] != 'X' && znacznik[0] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 3, 4))
             {
                 if (znacznik[5] != 'X' && znacznik[5] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 3, 5))
             {
                 if (znacznik[4] != 'X' && znacznik[4] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 4, 5))
             {
                if (znacznik[3] != 'X' && znacznik[3] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 6, 7))
             {
                 if (znacznik[8] != 'X' && znacznik[8] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 6, 8))
             {
                 if (znacznik[7] != 'X' && znacznik[7] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 8, 7))
             {
                 if (znacznik[6] != 'X' && znacznik[6] != 'O')
                {
                    return true;
                }
             }
             //Gorny srodkowy i dolny rzad
             if (PorownanieZnacznikowDwa(znacznik, 0, 3))
             {
                 if (znacznik[6] != 'X' && znacznik[6] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 0, 6))
             {
                 if (znacznik[3] != 'X' && znacznik[3] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 3, 6))
             {
                 if (znacznik[0] != 'X' && znacznik[0] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 1, 4))
             {
                 if (znacznik[7] != 'X' && znacznik[7] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 1, 7))
             {
                 if (znacznik[4] != 'X' && znacznik[4] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 4, 7))
             {
                 if (znacznik[1] != 'X' && znacznik[1] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 2, 5))
             {
                 if (znacznik[8] != 'X' && znacznik[8] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 2, 8))
             {
                 if (znacznik[5] != 'X' && znacznik[5] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 5, 8))
             {
                 if (znacznik[2] != 'X' && znacznik[2] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 0, 4))
             {
                 if (znacznik[8] != 'X' && znacznik[8] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 2, 4))
             {
                 if (znacznik[6] != 'X' && znacznik[6] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 0, 8))
             {
                 if (znacznik[4] != 'X' && znacznik[4] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 2, 6))
             {
                 if (znacznik[4] != 'X' && znacznik[4] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 4, 8))
             {
                 if (znacznik[0] != 'X' && znacznik[0] != 'O')
                {
                    return true;
                }
             }
             if (PorownanieZnacznikowDwa(znacznik, 6, 4))
             {
                 if (znacznik[2] != 'X' && znacznik[2] != 'O')
                {
                    return true;
                }
             }

             

            return false;

        }

        private static int Dwa(char[] znacznik) {
            if (CzyDwazRzedu(znacznik))
            {                
                return 1;
            }
            return 0;
        }

            private static void SilnikGry(char[] znacznik, int Gracz)
        {
            if (Gracz == 1)
            {
                
                

                bool niepoprawnyRuch = true;


                if (Dwa(znacznik) == 1)
                {
                    
                    {
                        
                        Console.WriteLine("\r\n");
                        Console.WriteLine("Jesteś jeden ruch od wygranej!");
                    }

                }


                Console.WriteLine("\r\n");

                Console.WriteLine("Twój ruch, wpisz numer pola i zatwierdź enterem");
                Console.WriteLine("\r\n");
                
                do
                {
                    
                    string userInput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(userInput) &&
                        (userInput.Equals("1") ||
                        userInput.Equals("2") ||
                        userInput.Equals("3") ||
                        userInput.Equals("4") ||
                        userInput.Equals("5") ||
                        userInput.Equals("6") ||
                        userInput.Equals("7") ||
                        userInput.Equals("8") ||
                        userInput.Equals("9")))
                    {

                        int.TryParse(userInput, out var poleZnacznika);

                        char obecnyZnacznik = znacznik[poleZnacznika - 1];

                        if (obecnyZnacznik.Equals('X') || obecnyZnacznik.Equals('O'))
                        {
                            Console.WriteLine("Na tym polu jest już znacznik, wybierz inne");
                        }
                        else
                        {
                            

                            znacznik[poleZnacznika - 1] = ZnacznikGracza(Gracz);

                            niepoprawnyRuch = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawna wartość, wpisz inny numer pola.");
                    }
                } while (niepoprawnyRuch);
            }
            if (Gracz == 2)
            {
                bool niepoprawnyRuch = true;
                {
                    

                    do
                    {
                        
                        Random rnd = new Random();
                        int numerKomp = rnd.Next(1, 9);

                        if (
                            (numerKomp.Equals(1) ||
                            numerKomp.Equals(2) ||
                            numerKomp.Equals(3) ||
                            numerKomp.Equals(4) ||
                            numerKomp.Equals(5) ||
                            numerKomp.Equals(6) ||
                            numerKomp.Equals(7) ||
                            numerKomp.Equals(8) ||
                            numerKomp.Equals(9)))
                        {


                            char obecnyZnacznik = znacznik[numerKomp - 1];

                            if (obecnyZnacznik.Equals('X') || obecnyZnacznik.Equals('O'))
                            {
                                int x = 1;
                            }
                            else
                            {
                                znacznik[numerKomp - 1] = ZnacznikGracza(Gracz);
                                if (numerKomp.Equals(1))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("1");
                                }
                                if (numerKomp.Equals(2))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Dobry ruch, jaki będzie następny?");
                                }
                                if (numerKomp.Equals(3))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Dobry ruch, jaki będzie następny?");
                                }
                                if (numerKomp.Equals(4))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Dobry ruch, ale czy mój nie jest lepszy?");
                                }
                                if (numerKomp.Equals(5))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Zajmuje środek planszy, jaki będzie twój kolejny ruch?");
                                }
                                if (numerKomp.Equals(6))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Coraz bliżej końca, czy dasz radę wygrać?");
                                }
                                if (numerKomp.Equals(7))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Dobry ruch, jaki będzie następny?");
                                }
                                if (numerKomp.Equals(8))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Dobry ruch, jaki będzie następny?");
                                }
                                if (numerKomp.Equals(9))
                                {
                                    Console.WriteLine("\r\n");
                                    Console.WriteLine("Dobry ruch, jaki będzie następny?");
                                }

                                niepoprawnyRuch = false;
                                
                                Console.WriteLine("Komputer ruszył się na pole " + numerKomp);
                                Console.WriteLine("Wciśnij dowolny przycisk by zatwierdzić ruch komputera");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawna wartość, wpisz inny numer pola.");
                        }
                    } while (niepoprawnyRuch);
                }
            }
        }
        }
    }

           
            
        
    
    

