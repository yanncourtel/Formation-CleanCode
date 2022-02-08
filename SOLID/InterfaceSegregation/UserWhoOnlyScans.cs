namespace SOLID.InterfaceSegregation
{
    public class UserWhoOnlyScans {

        Scanner scanner;
    }

    public class Scanner : ICanScan
    {
        public void Scan()
        {
            throw new System.NotImplementedException();
        }
    }
}
