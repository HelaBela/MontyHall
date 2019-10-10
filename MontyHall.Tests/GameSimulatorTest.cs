using NUnit.Framework;

namespace MontyHall.Tests
{
    public class GameSimulatorTest
    {
        [Test]
        public void canCountWins()
        {
           //arrange
           var gameSimulator = new GameSimulator();
           
           //act

           var counterResult = gameSimulator.SimulateGame();

           //assert
           
           
        }
    }
}