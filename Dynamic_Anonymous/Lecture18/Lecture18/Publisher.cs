namespace Lecture18
{
    public class Publisher
    {
        public delegate string EventHandler(string message);

        public event EventHandler TestEvent = default; 
        public void RaiseEvent(string message)
        {
            TestEvent?.Invoke(message);
        }
    }
}
