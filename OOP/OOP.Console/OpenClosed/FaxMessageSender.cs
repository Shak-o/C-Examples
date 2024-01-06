namespace OOP.Console.OpenClosed;

public class FaxMessageSender : IMessageSender
{
    public void SendMessage()
    {
        System.Console.WriteLine("Sending message to fax");
    }
}