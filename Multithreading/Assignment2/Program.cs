// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
var lockObj = new object();
var availableTickets = 10;
Queue<string> inputQueue = new Queue<string>();
var running = true;

// 2. monitor the queue and process input in separate threads
Thread monitorThread = new Thread(MonitorQueue);
monitorThread.Start();

// 1. read input from console and add to queue
while(true)
{
    var input = Console.ReadLine();
    if(input == "exit")
    {
        running = false;
        break;
    }
    inputQueue.Enqueue(input);
}
void MonitorQueue()
{
    while(true)
    {
        if(inputQueue.Count > 0)
        {
            var input = inputQueue.Dequeue();
            Thread processingThread = new Thread(() => ProcessInput(input));
            processingThread.Start();
        }
        else if(!running)
        {
            break;
        }
        Thread.Sleep(100);
    }
}

// 3. simulate processing input by sleeping for a few seconds and then printing the input
void ProcessInput(string input)
{
    
    if(Monitor.TryEnter(lockObj, 2000))
    {
        Thread.Sleep(5000);
        try{
            if(input == "b")
            {
                if(availableTickets <= 0)
                {
                    Console.WriteLine("No tickets available");
                    return;
                }
                availableTickets--;
                Console.WriteLine("Ticket booked successfully");
            }
            else if(input == "c")
            {
                if(availableTickets >= 10)
                {
                    Console.WriteLine("No tickets to cancel");
                    return;
                }
                availableTickets++;
                Console.WriteLine("Ticket cancelled successfully");
            }
        }
        finally{
            Monitor.Exit(lockObj);
        }
    }
    else
    {
        Console.WriteLine("Could not acquire lock, skipping input");
        return;
    }
}
