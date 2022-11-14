using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TeamControllerTests
    {
        private readonly GameController _gameController = new GameController();

        [Fact]
        public void TeamControllerTests_GetAllGames()
        {
            //arrange
            var list = new List<Game>();
            //act
            list = _gameController.GetAllGames();
            //assert
            Assert.NotEmpty(list);
        }

        [Fact]
        public void TeamControllerTests_GetByName()
        {
            //arrange
            var game = new Game();
            var gamename = "DynamoEdit-Shakhtar";
            //act
            game = _gameController.GetGameByName(gamename);
            //assert
            Assert.Equal(gamename, game.GameTitle);
        }

        [Fact]
        public void TeamControllerTests_GameExist()
        {
            //arrange
            var gamename = "DynamoEdit-Shakhtar";
            var expected = true;
            //act
            var actual = _gameController.GameExist(gamename);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TeamControllerTests_SearchByDateAndOp()
        {
            //arrange
            var games = new List<Game>();
            var gamename = "DynamoEdit-Shakhtar";
            var date = new DateTime(2023, 10, 08);
            //act
            games = _gameController.SearchByDateAndOp(date, gamename);
            //assert
            Assert.NotEmpty(games);
        }

        [Fact]
        public void TeamControllerTests_Sort_byDate()
        {
            //arrange
            var list = new List<Game>();
            //act
            list = _gameController.Sort(1);
            //assert
            Assert.NotEmpty(list);
        }

        [Fact]
        public void TeamControllerTests_Sort_byResult()
        {
            //arrange
            var list = new List<Game>();
            //act
            list = _gameController.Sort(2);
            //assert
            Assert.NotEmpty(list);
        }
    }
}
