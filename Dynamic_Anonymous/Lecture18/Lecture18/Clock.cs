namespace Lecture18
{
    public class Clock
    {
        public delegate void SecondsChangeHandler(object clock, object[] parameters);

        public event SecondsChangeHandler? SecondsChanged;

        protected virtual void OnSecondsChange()
        {
            SecondsChanged?.Invoke(this, new []{"test"});
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                OnSecondsChange();
            }
        }
    }
}
