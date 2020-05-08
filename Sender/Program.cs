using System;

using System.Messaging;
//Sender
class Program
{
    static void Main()
    {// THS IS A NEW ADDED LINE
        Console.WriteLine("Enter Message to be sent");
        Console.WriteLine("Please Enter HP: to enter high priority Messages");
        string MessageToBeSend = Console.ReadLine();

        //Get or Create Queue
        MessageQueue MyQueue = null ;
        if (MessageQueue.Exists(@".\Private$\MyQueue"))
        {
            MyQueue = new MessageQueue(@".\Private$\MyQueue");
        }
        else
        {
            MyQueue = MessageQueue.Create(@".\Private$\MyQueue");
        }

        //Create Message

        IMessage MyMessage = new System.Messaging.Message();

        // Set FOrmatter for Messge

        MyMessage.Formatter = new BinaryMessageFormatter();
        MyMessage.Body = MessageToBeSend;
        MyMessage.Label = "App1Message";

        if (MessageToBeSend.Contains("HP:"))
        {
            MyMessage.Priority = MessagePriority.Highest;
        }
        else
        {
            MyMessage.Priority = MessagePriority.Normal;

        }
        MyQueue.Send(MyMessage);
        Console.WriteLine("Thanks for Sending Message");
        Conosle.Read();
    }
}
}
