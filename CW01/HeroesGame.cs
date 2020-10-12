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
        }
    }
}
