namespace ConsoleApp2.Main;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}