using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHall
{
    public class Game
    {
        private readonly IRandomChooser _randomChooser;

        public Game(IRandomChooser randomChooser)
        {
            _randomChooser = randomChooser;
        }

        public Game()
        {
            _randomChooser = new RandomChooser();
        }


        public bool Play()
        {
            var doors = MakeDoors();
            RemoveDoor(doors);
            Switch(doors);

            var choosenDoor = doors.First(e => e.HasBeenChoosen);

            return choosenDoor.HasPrize;
        }

        public List<Door> MakeDoors()
        {
            var winnerDoorIndexNumber = _randomChooser.RandomNumber(0, 3);
            var choosenDoorIndexNumber = _randomChooser.RandomNumber(0, 3);

            var doors = new List<Door>() {new Door(), new Door(), new Door()};

            doors[winnerDoorIndexNumber].HasPrize = true;
            doors[choosenDoorIndexNumber].HasBeenChoosen = true;

            return doors;
        }

        public void RemoveDoor(List<Door> doors)
        {
            var doorToRemove = doors.FirstOrDefault(s => !s.HasPrize && !s.HasBeenChoosen);

            doors.Remove(doorToRemove);
        }

        public void Switch(List<Door> doors)
        {
            var chosenDoor = doors.First(s => s.HasBeenChoosen);
            var switchDoor = doors.First(s => !s.HasBeenChoosen);

            chosenDoor.HasBeenChoosen = false;
            switchDoor.HasBeenChoosen = true;
        }
    }
}