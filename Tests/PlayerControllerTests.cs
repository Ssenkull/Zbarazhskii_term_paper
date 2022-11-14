using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PlayerControllerTests
    {
        private readonly PlayerController _playerController = new PlayerController();

        [Fact]
        public void PlayerControllerTests_GetAllPlayers()
        {
            //arrange
            var list = new List<Player>();
            //act
            list = _playerController.GetAllPlayers();
            //assert
            Assert.NotEmpty(list);
        }

        [Fact]
        public void PlayerControllerTests_GetPlayerByName()
        {
            //arrange
            var player = new Player();
            var fname = "Vitaliy";
            var lname = "Volochai";
            //act
            player = _playerController.GetPlayerByName(fname, lname);
            //assert
            Assert.Equal(fname, player.FirstName);
        }

        [Fact]
        public void PlayerControllerTests_PlayerExist()
        {
            //arrange
            var expected = true;
            var fname = "Vitaliy";
            var lname = "Volochai";
            //act
            var actual = _playerController.PlayerExist(fname, lname);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerControllerTests_SearchByNameOrSurname()
        {
            //arrange
            var fname = "Vitaliy";
            var lname = "Volochai";
            //act
            var list1 = _playerController.SearchByNameOrSurname(fname);
            var list2 = _playerController.SearchByNameOrSurname(lname);
            //assert
            Assert.NotEmpty(list1);
            Assert.NotEmpty(list2);
        }
    }
}
