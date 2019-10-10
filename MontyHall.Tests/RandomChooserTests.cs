using System;
using NUnit.Framework;

namespace MontyHall.Tests
{
    public class RandomChooserTests
    {
        [Test]

        public void CanMakeRandomNumber()
        {
            //arrange
            var randomChooser = new RandomChooser();

            //act
            var randomNumber = randomChooser.RandomNumber(0, 3);
            
            //assert
            Assert.True(randomNumber>=0);
            Assert.True(randomNumber<3);
            
        }
    }
}