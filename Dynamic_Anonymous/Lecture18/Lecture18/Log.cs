namespace Lecture18
{
    public class Log
    {
        public void LogTime(object clock, object[] args)
        {
            Console.WriteLine($"logged {DateTime.Now}, {args[0]}");
        }
    }
}
