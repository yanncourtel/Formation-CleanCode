using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Performance
    {
        public int Audience { get; private set; }
        public Play Play { get; private set; }

        public Performance(Play play, int audience)
        {
            this.Play = play;
            this.Audience = audience;
        }

        internal int GetTotalAmount()
        {
            var thisAmount = 0;
            switch (Play.Type)
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (Audience > 30)
                    {
                        thisAmount += 1000 * (Audience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (Audience > 20)
                    {
                        thisAmount += 10000 + 500 * (Audience - 20);
                    }
                    thisAmount += 300 * Audience;
                    break;
                default:
                    throw new Exception("unknown type: " + Play.Type);
            }
            return thisAmount;
        }

        internal int GetVolumeCredit()
        {
            // add volume credits
            var volumeCredit = Math.Max(Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == Play.Type) volumeCredit += (int)Math.Floor((decimal)Audience / 5);
            return volumeCredit;
        }
    }
}
