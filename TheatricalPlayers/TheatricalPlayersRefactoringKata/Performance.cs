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
            return Play.GetAmount(Audience);
        }

        internal int GetVolumeCredit()
        {
            return Play.GetCredits(Audience);
        }
    }
}
