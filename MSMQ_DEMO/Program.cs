using System;
using System.Messaging;
class Program
{
static void Main()
{
    Console.WriteLine("Latest Message");

    MessageQueue MyQueue=null;
    if (MessageQueue.Exists(@".\Private$\MyQueue"))
    {

        Message MyMessage = MyQueue.Receive();
        // Set FOrmatter for Messge

        MyMessage.Formatter = new BinaryMessageFormatter();
        Console.WriteLine(MyMessage.Body.ToString());
        Console.Read();
    }
}
}
