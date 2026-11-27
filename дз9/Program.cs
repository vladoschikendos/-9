using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз9
{
    interface IGame
    {
        string Name { get; }
        void Play(Team team);
    }
    class Team
    {
        public string Country;
        public int PeopleCount = 15;
        public Team(string country)
        {
            Country = country;
        }
    }
    class Beach : IGame
    {
        public string Name => "Пляж";
        public void Play(Team team) => Console.WriteLine( $"[{Name}] Команда {team.Country} ({team.PeopleCount} чел.) кидает мяч на песке!");
    }
    class Mousetrap : IGame
    {
        public string Name => "Мышеловка";
        public void Play(Team team) => Console.WriteLine($"[{Name}] Команда {team.Country} ({team.PeopleCount} чел.) убегает от мышеловки!");
    }

    class Sea : IGame
    {
        public string Name => "Море";
        public void Play(Team team) => Console.WriteLine($"[{Name}] Команда {team.Country} ({team.PeopleCount} чел.) плывет на плотах!");
    }

    class Fishing : IGame
    {
        public string Name => "Рыбалка";
        public void Play(Team team) => Console.WriteLine($"[{Name}] Команда {team.Country} ({team.PeopleCount} чел.) ловит рыбу!");
    }

    class Postmen : IGame
    {
        public string Name => "Почтальоны";
        public void Play(Team team) => Console.WriteLine($"[{Name}] Команда {team.Country} ({team.PeopleCount} чел.) разносит письма!");
    }

    class Slide : IGame
    {
        public string Name => "Горка";
        public void Play(Team team) => Console.WriteLine($"[{Name}] Команда {team.Country} ({team.PeopleCount} чел.) скатывается с горки!");
    }
    class Bilyard: IGame
    {
        public string Name => "Бильярд";
        public void Play(Team team) => Console.WriteLine($"[{Name}] Команда {team.Country} ({team.PeopleCount} чел.) катают шары!");
    }
    class BigRace
    {
        private List<IGame> _games;
        public BigRace(List<IGame> games)
        {
            _games = games;
        }
        public void Start(Team team)
        {
            Console.WriteLine($"--- Команда {team.Country} начинает испытания! ---");
            foreach (var game in _games)
            {
                game.Play(team);
            }
            Console.WriteLine();
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Team russia = new Team("Россия");
            Team france = new Team("Зимбабве");
            Team china = new Team("Китай");
            Team kazakhstan = new Team("Туркменистан");


            List<IGame> games = new List<IGame>
        {
            new Beach(),
            new Mousetrap(),
            new Sea(),
            new Fishing(),
            new Postmen(),
            new Slide(),
            new Bilyard() 
        };

            
            BigRace show = new BigRace(games);

            
            show.Start(russia);
            show.Start(france);
            show.Start(china);
            show.Start(kazakhstan);
        }
    }
}
