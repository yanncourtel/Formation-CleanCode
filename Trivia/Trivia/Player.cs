using System;

namespace Trivia
{
    public class Player
    {
        private string playerName;
        private bool _isInJail;

        public int Purse { get; internal set; }
        public int Position { get; private set; }

        public Player(string playerName)
        {
            this.playerName = playerName;
        }

        public override string ToString()
        {
            return playerName;
        }

        public void Score()
        {
            Purse++;
        }

        public bool IsTheWinner(int goldCoinsToWin)
        {
            return Purse == goldCoinsToWin;
        }

        internal void Move(int roll, int boardSize)
        {
            Position += roll;
            if (Position >= boardSize) Position -= boardSize;
        }

        public bool IsInJail()
        {
            return _isInJail;
        }

        internal void GoToJail()
        {
            _isInJail = true;
        }

        internal void GetOutOfJail()
        {
            _isInJail = false;
        }
    }
}