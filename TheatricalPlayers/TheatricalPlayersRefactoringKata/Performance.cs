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

    }
}
