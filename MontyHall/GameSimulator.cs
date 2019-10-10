using System;

namespace MontyHall
{
    public class GameSimulator
    {
        public int SimulateGame()
        {
            var game = new Game();
            
            var counter = 0;
            for (int i = 0; i < 1000; i++)
            {
                var gameResult = game.Play();

                if (gameResult)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}