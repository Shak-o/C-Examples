namespace OOP.Console.OpenClosed;

public class PhoneMessageSender : IMessageSender
{
    public void SendMessage()
    {
        System.Console.WriteLine("Sending message to phone");
    }
}