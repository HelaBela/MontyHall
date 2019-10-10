using System;

namespace MontyHall
{
    public interface IRandomChooser
    {
        int RandomNumber(int min, int max);
    }
}