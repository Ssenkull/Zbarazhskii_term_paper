using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class MenuCommands
    {
        private static GameController _gameController = new GameController();
        private static PlayerController _playerController = new PlayerController();
        private static StadiumController _stadiumController = new StadiumController();
        private static TeamController _teamController = new TeamController();

        public static void AddMenu()
        {
            Console.WriteLine("Choose the entity you want to add: 1 - add team, 2 - add player, 3 - add stadium, 4 - add game.");
            var choice = InputCommands.InputChoice();

            switch (choice)
            {
                case 1:
                    AddTeam();
                    break;
                case 2:
                    AddPlayer();
                    break;
                case 3:
                    AddStadium();
                    break;
                case 4:
                    AddGame();
                    break;
            }
        }

        public static void EditMenu()
        {
            Console.WriteLine("Choose the entity you want to edit: 1 - edit team, 2 - edit player, 3 - edit stadium, 4 - edit game.");
            var choice = InputCommands.InputChoice();

            switch (choice)
            {
                case 1:
                    EditTeam();
                    break;
                case 2:
                    EditPlayer();
                    break;
                case 3:
                    EditStadium();
                    break;
                case 4:
                    EditGame();
                    break;
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Choose the entity you want to show: 1 - show teams, 2 - show players, 3 - show stadiums, 4 - show games.");
            var choice = InputCommands.InputChoice();

            switch (choice)
            {
                case 1:
                    ShowAllTeams();
                    break;
                case 2:
                    ShowAllPlayers();
                    break;
                case 3:
                    ShowAllStadiums();
                    break;
                case 4:
                    ShowAllGames();
                    break;
            }
        }

        public static void DeleteMenu()
        {
            Console.WriteLine("Choose the entity you want to delete: 1 - delete team, 2 - delete player, 3 - delete stadium, 4 - delete game.");
            var choice = InputCommands.InputChoice();

            switch (choice)
            {
                case 1:
                    DeleteTeam();
                    break;
                case 2:
                    DeletePlayer();
                    break;
                case 3:
                    DeleteStadium();
                    break;
                case 4:
                    DeleteGame();
                    break;
            }
        }

        public static void ShowInfo()
        {
            Console.WriteLine("Choose the entity you want to show: 1 - show team, 2 - show player, 3 - show stadium, 4 - show game.");
            var choice = InputCommands.InputChoice();

            switch (choice)
            {
                case 1:
                    ShowInfoAboutTeam();
                    break;
                case 2:
                    ShowInfoAboutPlayer();
                    break;
                case 3:
                    ShowInfoAboutStadium();
                    break;
                case 4:
                    ShowInfoAboutGame();
                    break;
            }
        }

        public static void SearchMenu()
        {
            Console.WriteLine("Choose the search option: 1 - search for a player by name or surname, 2 - search for a game by date, and team - opponent names, 3 - search stadium by name");
            var choice = InputCommands.InputSearchOption();

            switch (choice)
            {
                case 1:
                    SearchPlayerByNameOrSurname();
                    break;
                case 2:
                    SearchForGame();
                    break;
                case 3:
                    SearchForStadium();
                    break;
            }
        }

        private static void AddTeam()
        {
            var teamname = InputCommands.InputName("team name");
            if (_teamController.TeamExist(teamname))
            {
                AddTeam();
            }
            _teamController.AddTeam(teamname);
        }

        private static void AddPlayer()
        {
            var firstname = InputCommands.InputName("first name");
            var lastname = InputCommands.InputName("last name");
            var salary = InputCommands.InputSalary();
            var dateOfBirth = InputCommands.InputBirthDate();
            var healthStatus = InputCommands.InputHealthStatus();
            var playerStatus = InputCommands.InputPlayerStatus();
            var teamname = InputCommands.InputTeamName(_teamController.GetAllTeams());
            _playerController.AddPlayer(firstname, lastname, dateOfBirth, playerStatus, healthStatus, salary, teamname);
        }

        private static void AddStadium()
        {
            var stadiumName = InputCommands.InputName("name of the stadium");
            var numberOfSeats = InputCommands.InputNumberOfSeats();
            var priceForSeat = InputCommands.InputPricePerSeat();
            _stadiumController.AddStadium(stadiumName, numberOfSeats, priceForSeat);
        }

        private static void AddGame()
        {
            var viewers = InputCommands.InputNumberOfSeats();
            var gameStatus = InputCommands.InputGameStatus();
            string team;
            string opponents;
            do
            {
                var teams = _teamController.GetAllTeams();
                Console.WriteLine("First team");
                team = InputCommands.InputTeamName(teams);
                Console.WriteLine("Second team");
                opponents = InputCommands.InputTeamName(teams);
            } while (Equals(team, opponents));
            var stadiumName = InputCommands.InputStadiumName(_stadiumController.GetAllStadiums());
            var date = InputCommands.InputGameDate(gameStatus);
            _gameController.AddGame(viewers, gameStatus, team, opponents, stadiumName, date);
        }

        private static void EditTeam()
        {
            var originalTeam = InputCommands.InputTeamName(_teamController.GetAllTeams());
            if (!_teamController.TeamExist(originalTeam))
            {
                EditTeam();
            }
            var teamname = InputCommands.InputName("new team name");
            _teamController.EditTeam(originalTeam, teamname);
        }

        private static void EditPlayer()
        {
            var originalFname = InputCommands.InputName("first name of the person you want to edit");
            var originalLname = InputCommands.InputName("last name of the person you want to edit");

            if (!_playerController.PlayerExist(originalFname, originalLname))
            {
                EditPlayer();
            }
            var firstname = InputCommands.InputName("new first name");
            var lastname = InputCommands.InputName("new last name");
            var salary = InputCommands.InputSalary();
            var dateOfBirth = InputCommands.InputBirthDate();
            var healthStatus = InputCommands.InputHealthStatus();
            var playerStatus = InputCommands.InputPlayerStatus();
            var teamname = InputCommands.InputTeamName(_teamController.GetAllTeams());
            _playerController.EditPlayer(originalFname, originalLname, firstname, lastname, dateOfBirth, playerStatus, healthStatus, salary, teamname);
        }

        private static void EditStadium()
        {
            var originalStadiumName = InputCommands.InputName("original name of the stadium");

            if (!_stadiumController.StadiumExist(originalStadiumName))
            {
                EditStadium();
            }

            var stadiumName = InputCommands.InputName("name of the stadium");
            var numberOfSeats = InputCommands.InputNumberOfSeats();
            var priceForSeat = InputCommands.InputPricePerSeat();
            _stadiumController.EditStadium(originalStadiumName, stadiumName, numberOfSeats, priceForSeat);
        }

        private static void EditGame()
        {
            var originalGameName = InputCommands.InputGameTitle(_gameController.GetAllGames());

            var viewers = InputCommands.InputNumberOfSeats();
            var gameStatus = InputCommands.InputGameStatus();
            string team;
            string opponents;
            do
            {
                var teams = _teamController.GetAllTeams();
                Console.WriteLine("First team");
                team = InputCommands.InputTeamName(teams);
                Console.WriteLine("Second team");
                opponents = InputCommands.InputTeamName(teams);
            } while (Equals(team, opponents));
            var stadiumName = InputCommands.InputStadiumName(_stadiumController.GetAllStadiums());
            var date = InputCommands.InputGameDate(gameStatus);

            _gameController.EditGame(originalGameName, stadiumName, viewers, gameStatus, team, opponents, date);
        }

        private static void ShowAllTeams()
        {
            var teams = _teamController.GetAllTeams();
            foreach (var team in teams)
            {
                Console.WriteLine(team.TeamName);
            }
        }

        private static void ShowAllPlayers()
        {
            var players = _playerController.GetAllPlayers();
            foreach (var player in players)
            {
                Console.WriteLine(player.FirstName + " " + player.LastName);
            }
        }

        private static void ShowAllStadiums()
        {
            var stadiums = _stadiumController.GetAllStadiums();
            foreach (var stadium in stadiums)
            {
                Console.WriteLine(stadium.StadiumName);
            }
        }

        private static void ShowAllGames()
        {
            var games = _gameController.GetAllGames();
            Console.WriteLine("Choose the sort option 1 - sort by date, 2 - sort by results");
            var choice = InputCommands.InputSortOption();
            var list = new List<Game>();
            switch (choice)
            {
                case 1:
                    list = _gameController.Sort(1);
                    break;
                case 2:
                    list = _gameController.Sort(2);
                    break;
            }
            foreach (var game in list)
            {
                Console.WriteLine($"Game: {game.GameTitle};\nDate: {game.GameDate};\nResult: {game.ResultOfTheGame};");
            }
        }

        private static void DeleteTeam()
        {
            var teamToDelete = InputCommands.InputTeamName(_teamController.GetAllTeams());
            if (!_teamController.TeamExist(teamToDelete))
            {
                DeleteTeam();
            }
            _teamController.DeleteTeam(teamToDelete);
        }

        private static void DeletePlayer()
        {
            var fname = InputCommands.InputName("name of the player to be deleted.");
            var lname = InputCommands.InputName("surname of the player to be deleted.");
            if (!_playerController.PlayerExist(fname, lname))
            {
                DeletePlayer();
            }
            _playerController.DeletePlayer(fname, lname);
        }

        private static void DeleteStadium()
        {
            var stadiumName = InputCommands.InputStadiumName(_stadiumController.GetAllStadiums());
            if (!_stadiumController.StadiumExist(stadiumName))
            {
                DeleteStadium();
            }
            _stadiumController.DeleteStadium(stadiumName);
        }

        private static void DeleteGame()
        {
            var gameTitle = InputCommands.InputGameTitle(_gameController.GetAllGames());
            if (!_gameController.GameExist(gameTitle))
            {
                DeleteGame();
            }
            _gameController.DeleteGame(gameTitle);
        }

        private static void ShowInfoAboutTeam()
        {
            var teamToDelete = InputCommands.InputTeamName(_teamController.GetAllTeams());
            if (!_teamController.TeamExist(teamToDelete))
            {
                DeleteTeam();
            }
            var team = _teamController.GetTeamByName(teamToDelete);
            string players = string.Empty;
            foreach (var player in team.Players)
            {
                players += player.FirstName + " " + player.LastName;
            }
            Console.WriteLine("\n" + "Team name: " + team.TeamName + "\n" + "Team players: " + "\n" + players + "\n");
        }

        private static void ShowInfoAboutPlayer()
        {
            var fname = InputCommands.InputName("name of the player to show info");
            var lname = InputCommands.InputName("surname of the player to show info");
            if (!_playerController.PlayerExist(fname, lname))
            {
                ShowInfoAboutPlayer();
            }
            var player = _playerController.GetPlayerByName(fname, lname);

            Console.WriteLine($"\nPlayer first name: {player.FirstName};\nLast name: {player.LastName};\nHealth status: {player.HealthStatus};\nStatus: {player.PlayerStatus};\nSalary: {player.Salary};\n");
        }

        private static void ShowInfoAboutStadium()
        {
            var stadiumName = InputCommands.InputStadiumName(_stadiumController.GetAllStadiums());
            if (!_stadiumController.StadiumExist(stadiumName))
            {
                ShowInfoAboutStadium();
            }
            var stadium = _stadiumController.GetStadiumByName(stadiumName);

            Console.WriteLine($"\nStadium name: {stadium.StadiumName};\nNumber of seats: {stadium.NumberOfSeats};\nPrice per seat: {stadium.PricePerSeat};\n");
        }

        private static void ShowInfoAboutGame()
        {
            var gameTitle = InputCommands.InputGameTitle(_gameController.GetAllGames());
            if (!_gameController.GameExist(gameTitle))
            {
                ShowInfoAboutGame();
            }
            var game = _gameController.GetGameByName(gameTitle);

            Console.WriteLine($"\nGame title: {game.GameTitle};\nGame date: {game.GameDate};\nNumber of viewers: {game.NumberOfViewers};\nResult: {game.ResultOfTheGame};\n");
        }

        private static void SearchPlayerByNameOrSurname()
        {
            var fname = InputCommands.InputName("name or surname of the player to be found.");
            var players = _playerController.SearchByNameOrSurname(fname);

            if (players.Any())
            {
                Console.WriteLine("\nThe following players were found: ");
                foreach (var player in players)
                {
                    Console.WriteLine("\nPlayer first name: { player.FirstName};\nLast name: { player.LastName};\nHealth status: { player.HealthStatus};\nStatus: { player.PlayerStatus};\nSalary: { player.Salary};\n");
                }
            }
            else
            {
                Console.WriteLine("\n No players were found by the name: " + fname);
            }
        }

        private static void SearchForGame()
        {
            var date = InputCommands.InputAnyDate();
            var teamOp = InputCommands.InputAnyGameTitle();
            var games = _gameController.SearchByDateAndOp(date, teamOp);

            if (games.Any())
            {
                Console.WriteLine("\nFollowing games were found: ");
                foreach (var game in games)
                {
                    Console.WriteLine($"\nGame title: {game.GameTitle};\nGame date: {game.GameDate};\nNumber of viewers: {game.NumberOfViewers};\nResult: {game.ResultOfTheGame};\n");
                }
            }
            else
            {
                Console.WriteLine($"\nNo games were found for date: {date}, and following teams: {teamOp}");
            }
        }

        private static void SearchForStadium()
        {
            var sname = InputCommands.InputName("name of the stadium to search");
            var stadium = _stadiumController.GetStadiumByName(sname);

            if (stadium != null)
            {
                Console.WriteLine($"\nStadium name: {stadium.StadiumName};\nNumber of seats: {stadium.NumberOfSeats};\nPrice per seat: {stadium.PricePerSeat};\n");
            }
            else
            {
                Console.WriteLine($"\nNo stadium wasa found by name: {sname}");
            }
        }
    }
}
