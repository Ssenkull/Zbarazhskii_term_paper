using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class StadiumControllerTests
    {
        private readonly StadiumController _stadiumController = new StadiumController();

        [Fact]
        public void StadiumControllerTests_GetAllStadiums()
        {
            //arrange
            var stadiums = new List<Stadium>();
            //act
            stadiums = _stadiumController.GetAllStadiums();
            //assert
            Assert.NotEmpty(stadiums);
        }

        [Fact]
        public void StadiumControllerTests_GetStadiumByName()
        {
            //arrange
            var stadium = new Stadium();
            var stadiumName = "Palac";
            //act
            stadium = _stadiumController.GetStadiumByName(stadiumName);
            //assert
            Assert.Equal(stadiumName, stadium.StadiumName);
        }

        [Fact]
        public void StadiumControllerTests_StadiumExist()
        {
            //arrange
            var expected = true;
            var stadiumName = "Palac";
            //act
            var actual = _stadiumController.StadiumExist(stadiumName);
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
