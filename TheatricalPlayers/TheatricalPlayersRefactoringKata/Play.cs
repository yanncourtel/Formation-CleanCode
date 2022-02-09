namespace TheatricalPlayersRefactoringKata
{
    public class Play
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Play(string name, string type) {
            this.Name = name;
            this.Type = type;
        }
    }
}
