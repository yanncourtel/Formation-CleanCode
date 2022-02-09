using System;

namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        protected Play(string name, string type) {
            this.Name = name;
            this.Type = type;
        }

        internal abstract int GetAmount(int audience);

        internal virtual int GetCredits(int audience)
        {
            return Math.Max(audience - 30, 0);
        }
    }
}
