using Azure;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PL
{
    public static class InputCommands
    {
        private static string NamePattern = @"^[A-Z][a-zA-Z]*$";

        public static string InputName(string message)
        {
            string Input;
            Regex regex = new Regex(NamePattern);
            do
            {
                Console.Write("Enter " + message + ": ");
                Input = Console.ReadLine();
            } while (!regex.IsMatch(Input));

            return Input;
        }

        public static decimal InputSalary()
        {
            string Input;
            decimal salary = 0;
            do
            {
                Console.Write("Enter salary: ");
                Input = Console.ReadLine();
                salary = decimal.Parse(Input);
            } while (salary < 0 && salary > 9999);

            return salary;
        }

        public static decimal InputPricePerSeat()
        {
            string Input;
            decimal price = 0;
            do
            {
                Console.Write("Enter price per seat: ");
                Input = Console.ReadLine();
                price = decimal.Parse(Input);
            } while (price < 0 && price > 9999);

            return price;
        }


        public static DateTime InputBirthDate()
        {
            Console.WriteLine("Input the birth date in dd/mm/yyyy format.");
            string line = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }
            return dt;
        }

        public static PlayerStatus InputPlayerStatus()
        {
            Console.WriteLine("Type in player status, choose one of the options: Active, Inactive");
            string input = Console.ReadLine();
            PlayerStatus playerStatus;
            while (!Enum.TryParse(input, out playerStatus))
            {
                Console.WriteLine("Invalid status, try again.");
                input = Console.ReadLine();
            }
            return playerStatus;
        }

        public static HealthStatus InputHealthStatus()
        {
            Console.WriteLine("Type in player health status, choose one of the options: Healthy, Injured");
            string input = Console.ReadLine();
            HealthStatus healthStatus;
            while (!Enum.TryParse(input, out healthStatus))
            {
                Console.WriteLine("Invalid status, try again.");
                input = Console.ReadLine();
            }
            return healthStatus;
        }

        public static Result InputGameStatus()
        {
            Console.WriteLine("Type in player game status, choose one of the options: Victory, Loss, Draw, NotYetHeld");
            string input = Console.ReadLine();
            Result gameResult;
            while (!Enum.TryParse(input, out gameResult))
            {
                Console.WriteLine("Invalid status, try again.");
                input = Console.ReadLine();
            }
            return gameResult;
        }

        public static int InputChoice()
        {
            string Input;
            int choice = 0;
            do
            {
                Console.Write("Enter your choice 1-4: ");
                Input = Console.ReadLine();
                choice = int.Parse(Input);
            } while (choice < 0 && choice > 4);

            return choice;
        }

        public static string InputTeamName(List<Team> teams)
        {
            string input;
            bool validTeam = false;
            do
            {
                Console.Write("Enter team name. List of available teams:\n");
                foreach (var team in teams)
                {
                    Console.WriteLine(team.TeamName);
                }
                input = Console.ReadLine();
                foreach (var team in teams)
                {
                    if (team.TeamName == input)
                    {
                        validTeam = true;
                    }
                }
            } while (!validTeam);
            return input;
        }

        public static string InputStadiumName(List<Stadium> stadiums)
        {
            string input;
            bool validStadium = false;
            do
            {
                Console.Write("Enter stadium name. List of available stadiums:\n");
                foreach (var stadion in stadiums)
                {
                    Console.WriteLine(stadion.StadiumName);
                }
                input = Console.ReadLine();
                foreach (var stadion in stadiums)
                {
                    if (stadion.StadiumName == input)
                    {
                        validStadium = true;
                    }
                }
            } while (!validStadium);
            return input;
        }

        public static DateTime InputGameDate(Result result)
        {
            Console.WriteLine("Input the game date in dd/mm/yyyy format. Notice, that if the result of the game is NotYetHeld you should input the date after the present date.");
            string line = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }
            if (result == Result.NotYetHeld)
            {
                if (dt < DateTime.Now)
                {
                    InputGameDate(result);
                }
            }
            return dt;
        }

        public static DateTime InputAnyDate()
        {
            Console.WriteLine("Input the game date in dd/mm/yyyy format. Notice, that if the result of the game is NotYetHeld you should input the date after the present date.");
            string line = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }            
            return dt;
        }

        public static int InputSearchOption()
        {
            string Input;
            int choice = 0;
            do
            {
                Console.Write("Enter your choice 1-3: ");
                Input = Console.ReadLine();
                choice = int.Parse(Input);
            } while (choice < 0 && choice > 3);

            return choice;
        }

        public static int InputNumberOfSeats()
        {
            string Input;
            int seats = 0;
            do
            {
                Console.Write("Enter max number of viewers: ");
                Input = Console.ReadLine();
                seats = int.Parse(Input);
            } while (seats < 0 && seats > 100000);

            return seats;
        }

        public static string InputGameTitle(List<Game> list)
        {
            Console.WriteLine("Choose one game from the list:\n");
            foreach (var game in list)
            {
                Console.WriteLine(game.GameTitle);
            }
            string Input;
            bool gameOk = false;
            do
            {
                Console.Write("Enter title of the game you want to edit: ");
                Input = Console.ReadLine();
                foreach (var game in list)
                {
                    if (game.GameTitle == Input)
                    {
                        gameOk = true;
                    }
                }
            } while (!gameOk);
            return Input;
        }

        public static string InputAnyGameTitle()
        {
            string Input;
            bool isText = false;
            do
            {
                Console.Write("Enter team-opponent: ");
                Input = Console.ReadLine();
                isText = Input.All(c => Char.IsLetterOrDigit(c) || c == '-');
            } while (!isText);

            return Input;
        }

        public static int InputSortOption()
        {
            string Input;
            int choice = 0;
            do
            {
                Console.Write("Enter your choice 1-2: ");
                Input = Console.ReadLine();
                choice = int.Parse(Input);
            } while (choice < 0 && choice > 2);

            return choice;
        }
    }
}