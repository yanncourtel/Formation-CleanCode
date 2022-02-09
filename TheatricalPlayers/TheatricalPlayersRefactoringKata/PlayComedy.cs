
using System;

namespace TheatricalPlayersRefactoringKata
{
    public class PlayComedy : Play
    {
        public PlayComedy(string name) : base(name, "comedy")
        {
        }

        internal override int GetAmount(int audience)
        {
            var thisAmount = 30000;
            if (audience > 20)
            {
                thisAmount += 10000 + 500 * (audience - 20);
            }

            return thisAmount += 300 * audience;
        }

        internal override int GetCredits(int audience)
        {
            var volumeCredit = base.GetCredits(audience);
            volumeCredit += (int)Math.Floor((decimal)audience / 5);
            return volumeCredit;
        }
    }
}