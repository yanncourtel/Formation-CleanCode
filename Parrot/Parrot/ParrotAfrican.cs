using System;

namespace Parrot
{
    public class ParrotAfrican : ICanGetSpeed
    {
        private readonly int _numberOfCoconuts;

        public ParrotAfrican(int numberofCoconut)
        {
            this._numberOfCoconuts = numberofCoconut;
        }

        public double GetSpeed()
        {
            return Math.Max(0, 12 - 9 * _numberOfCoconuts);
        }
    }
}