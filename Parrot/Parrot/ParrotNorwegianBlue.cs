using System;

namespace Parrot
{
    public class ParrotNorwegianBlue : ICanGetSpeed
    {
        private double _voltage;
        private bool _isNailed;

        public ParrotNorwegianBlue(double voltage, bool isNailed)
        {
            this._voltage = voltage;
            this._isNailed = isNailed;
        }

        public double GetSpeed()
        {
            return _isNailed ? 0 : GetBaseSpeed(_voltage);
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * 12);
        }
    }
}