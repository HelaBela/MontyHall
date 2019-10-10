using System;

namespace MontyHall
{
    public class RandomChooser:IRandomChooser
    {
        public int RandomNumber(int min, int max)
        {
            var number = new Random().Next(0, 3);

            return number;
        }
    }
}