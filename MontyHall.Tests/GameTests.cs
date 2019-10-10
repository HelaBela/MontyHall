using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace MontyHall.Tests
{
    public class GameTests
    {
        [Test]
        public void CallingPlayGameReturnsFalse()
        {
            //arrange
            var testGame = new Game();


            //act

            var result = testGame.Play();
            //assert

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CanMakeAListOf3Doors()
        {
            //arrange
            var testGame = new Game();


            //act

            var doors = testGame.MakeDoors();
            //assert

            Assert.AreEqual(3, doors.Count);
        }

        [Test]
        public void CanMakeAListOf3DoorsWhereOneDoorHasPrize()
        {
            //arrange
            var testGame = new Game();


            //act

            var doors = testGame.MakeDoors();
            //assert

            Assert.AreEqual(1, doors.Count(s => s.HasPrize));
        }

        [Test]
        public void CanMakeAListOf3DoorsWhereOneDoorIsChoosen()
        {
            //arrange
            var testGame = new Game();


            //act

            var doors = testGame.MakeDoors();
            //assert

            Assert.AreEqual(1, doors.Count(s => s.HasBeenChoosen));
        }

        [Test]
        public void CanremoveDoorThatIsNotChosenAndHasNoPrize()
        {
            //arrange
            var testGame = new Game();
            var doors = testGame.MakeDoors();


            //act

            testGame.RemoveDoor(doors);
            //assert

            Assert.AreEqual(2, doors.Count());
            Assert.AreEqual(1, doors.Count(s => s.HasPrize));
            Assert.AreEqual(1, doors.Count(s => s.HasBeenChoosen));
        }

        [Test]
        public void CanSwitchDoor()
        {
            //arrange
            var testGame = new Game();

            var doors = new List<Door>() {new Door() {HasBeenChoosen = true}, new Door() {HasBeenChoosen = false}};


            //act

            testGame.Switch(doors);
            //assert

            Assert.AreEqual(true, doors[1].HasBeenChoosen);
            Assert.AreEqual(false, doors[0].HasBeenChoosen);
        }


        [Test]
        public void CanReturnTrueWhenUserWins()
        {
            //arrange

            var randomChooser = new Mock<IRandomChooser>();

            var testGame = new Game(randomChooser.Object);

            randomChooser.SetupSequence(s => s.RandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(1)
                .Returns(2);
            

            //act

            var result = testGame.Play();
            //assert

            Assert.AreEqual(true,result );
        }
        
        [Test]
        public void CanReturnFalseWhenUserLooses()
        {
            //arrange

            var randomChooser = new Mock<IRandomChooser>();

            var testGame = new Game(randomChooser.Object);

            randomChooser.SetupSequence(s => s.RandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(2)
                .Returns(2);
            

            //act

            var result = testGame.Play();
            //assert

            Assert.AreEqual(false,result );
        }
    }
}