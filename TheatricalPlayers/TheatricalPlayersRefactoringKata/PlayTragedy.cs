
namespace TheatricalPlayersRefactoringKata
{
    public class PlayTragedy : Play
    {

        public PlayTragedy(string name):base(name, "tragedy")
        {
        }

        internal override int GetAmount(int audience)
        {
            var thisAmount = 40000;
            if (audience > 30)
            {
                thisAmount += 1000 * (audience - 30);
            }

            return thisAmount;
        }
    }
}