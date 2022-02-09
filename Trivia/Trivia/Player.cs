namespace Trivia
{
    public class Player
    {
        private string playerName;

        public Player(string playerName)
        {
            this.playerName = playerName;
        }

        public override string ToString()
        {
            return playerName;
        }
    }
}