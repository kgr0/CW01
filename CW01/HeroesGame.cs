using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CW01
{
    public enum EHeroClass
    {
        barbarian,
        paladin,
        amazon
    }
    public static class HeroesGame
    {
        public static Hero hero;
        public static string check_name(string name)
        {
            Regex regex = new Regex(@"^(?![\s.]+$)[a-zA-Z\s.]*$");
            string name_ = "";

            if (!regex.IsMatch(name))
                return "";
            int space_counter = 0;
            int letter_counter = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] != ' ')
                {
                    name_ += name[i];
                    space_counter = 0;
                    letter_counter++;
                }
                else if (name[i] == ' ' && space_counter==0 && name_!="")
                {
                    name_ += name[i];
                    space_counter++;
                }
            }
            if (letter_counter < 3)
                return "";
            if (name_[name_.Length - 1] == ' ')
            {
                name_ = name_.Remove(name_.Length - 1);
            }

            return name_;
        }

       public static void Init(Location location)
        {
            NpcDialogPart n1 = new NpcDialogPart("Witaj, czy możesz mi pomóc dostać się do innego miasta?");

            HeroDialogPart h1_1 = new HeroDialogPart("Tak, chętnie pomogę");
            HeroDialogPart h1_2 = new HeroDialogPart("Nie, nie pomogę, żegnaj.");
            n1.answers.Add(h1_1);
            n1.answers.Add(h1_2);

            NpcDialogPart n2 = new NpcDialogPart("Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota");
            h1_1.answers.Add(n2);

            HeroDialogPart h2_1 = new HeroDialogPart("Dam znać jak będę gotowy");
            HeroDialogPart h2_2 = new HeroDialogPart("100 sztuk złota to za mało!");
            n2.answers.Add(h2_1);
            n2.answers.Add(h2_2);

            NpcDialogPart n3 = new NpcDialogPart("Niestety nie mam więcej. Jestem bardzo biedny");
            h2_2.answers.Add(n3);

            HeroDialogPart h3_1 = new HeroDialogPart("OK, może być 100 sztuk złota.");
            HeroDialogPart h3_2 = new HeroDialogPart("W takim razie radź sobie sam.");
            n3.answers.Add(h3_1);
            n3.answers.Add(h3_2);

            NpcDialogPart n4 = new NpcDialogPart("Dziękuję.");
            h3_1.answers.Add(n4);


            NpcDialogPart n5 = new NpcDialogPart("Witaj, mam do sprzedarzy różne rzeczy. Czego szukasz?");

            HeroDialogPart h5_1 = new HeroDialogPart("Potrzebuję zbroję.");
            HeroDialogPart h5_2 = new HeroDialogPart("Nic nie potrzebuję.");
            n5.answers.Add(h5_1);
            n5.answers.Add(h5_2);

            NpcDialogPart n6 = new NpcDialogPart("Mam skórzaną.");
            h5_1.answers.Add(n6);

            HeroDialogPart h6_1 = new HeroDialogPart("Nie, chcę lamelkową.");
            HeroDialogPart h6_2 = new HeroDialogPart("Ile kosztuje?");
            n6.answers.Add(h6_1);
            n6.answers.Add(h6_2);

            NpcDialogPart n7 = new NpcDialogPart("300 sztuk złota. A razem z kapturem za 350.");
            h6_2.answers.Add(n7);

            HeroDialogPart h7_1 = new HeroDialogPart("Dobrze, kupuję wszystko.");
            HeroDialogPart h7_2 = new HeroDialogPart("Biorę bez kaptura.");
            n7.answers.Add(h7_1);
            n7.answers.Add(h7_2);

            NpcDialogPart n8 = new NpcDialogPart("Fajny wybór.");
            h7_2.answers.Add(n8);


            location.Add_npc(new NonPlayerCharacter("Cain", n1));
            location.Add_npc(new NonPlayerCharacter("Warriv", n5));

            Console.ReadLine();
        }

        public static EHeroClass choose_class(string name)
        {
            Console.Clear();
            Console.WriteLine($"Witaj {name}, wybierz klasę bohatera: ");

            Console.WriteLine("[1] barbarzyńca");
            Console.WriteLine("[2] paladyn");
            Console.WriteLine("[3] amazonka");

            while (true)
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return EHeroClass.barbarian;
                    case "2":
                        return EHeroClass.paladin;
                    case "3":
                        return EHeroClass.amazon;
                    default:
                        Console.WriteLine("Niepoprawna opcja. Sprobuj jeszcze raz.");
                        break;
                }
            }
        }

        public static void TalkTo(NonPlayerCharacter npc)
        {
            Console.Clear();
            NpcDialogPart npc_part;
            HeroDialogPart hero_part;
            npc_part = npc.StartTalking();

            string choice;
            int part_index;

            while(true)
            {
                Console.WriteLine("{0}: {1}", npc.name, npc_part.part);

                if(npc_part.answers.Count == 0)
                {
                    Console.WriteLine("KONIEC");
                    Console.WriteLine("Wciśnij Enter...");
                    Console.ReadLine();
                    return;
                }
                for(int i=0; i < npc_part.answers.Count; i++)
                {
                    Console.WriteLine("[{0}] {1}", i+1, npc_part.answers[i].part);
                }

                while (true) 
                {
                    choice = Console.ReadLine();

                    if (!Int32.TryParse(choice, out part_index) || part_index > npc_part.answers.Count)
                    {
                        Console.WriteLine("Niepoprawna opcja. Sprobuj jeszcze raz.");
                    }
                    else
                    {
                        hero_part = npc_part.answers[part_index - 1];

                        if (hero_part.answers.Count == 0)
                        {
                            Console.WriteLine("KONIEC");
                            Console.WriteLine("Wciśnij Enter...");
                            Console.ReadLine();
                            return;
                        }
                        npc_part = hero_part.answers[0];
                        break;
                    }
                }
            }

        }
        public static void ShowLocation(Location location)
        {
            Console.Clear();
            Console.WriteLine("Znajdujesz się w: {0}. Co chcesz zrobić?", location.name);

            for(int i=0; i < location.npc_list.Count; i++)
            {
                Console.WriteLine("[{0}] Porozmawiaj z {1}", i+1, location.npc_list[i].name);
            }
            Console.WriteLine("[X] Zamknij program");

            string choice;
            int npc_index;

            while (true)
            {
                choice = Console.ReadLine();
                if (choice == "X")
                    return;
                else if (!Int32.TryParse(choice, out npc_index) || npc_index > location.npc_list.Count)
                {
                    Console.WriteLine("Niepoprawna opcja. Sprobuj jeszcze raz.");
                }
                else
                {
                    TalkTo(location.npc_list[npc_index - 1]);
                    ShowLocation(location);
                    break;
                }
            }
        }
        public static void start_menu()
        {
            Console.Clear();
            Console.WriteLine("Witaj w grze < Heroes Game >");
            Console.WriteLine("[1] Zacznij nową grę");
            Console.WriteLine("[X] Zamknij program");

            string choice = Console.ReadLine();
            string name;
            bool check = true;

            Console.Clear();
            while (check)
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Proszę podać imię bohatera:");
                        name = Console.ReadLine();
                        name = check_name(name);
                        if (name != "")
                        {
                            hero = new Hero(name, choose_class(name));

                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawne imię. Sprobuj jeszcze raz.");
                        }
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Niepoprawna opcja. Sprobuj jeszcze raz.");
                        Console.ReadLine();
                        start_menu();
                        break;
                }
            }

            Console.Clear();

            string hero_class = "Barbarzyńca";
            if (hero.hero_class == EHeroClass.paladin)
                hero_class = "Paladyn";
            else if (hero.hero_class == EHeroClass.amazon)
                hero_class = "Amazonka";

            Console.WriteLine("{0} {1} wyrusza na przygodę", hero_class, hero.name);
            Console.WriteLine("Wciśnij Enter...");

            Location location = new Location("Calimport");
            Init(location);
            ShowLocation(location);
        }
    }
}
