namespace Parrot
{
    public class ParrotAfrican : ICanGetSpeed
    {
        private int v;

        public ParrotAfrican(int v)
        {
            this.v = v;
        }

        public double GetSpeed()
        {
            return 12;
        }
    }
}