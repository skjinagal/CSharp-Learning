// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
Queue<string> inputQueue = new Queue<string>();
var queueLock = new object();
using SemaphoreSlim semaphore = new SemaphoreSlim(3, 3); // limit to 3 concurrent processing threads
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
    lock(queueLock)
    {
        inputQueue.Enqueue(input);
    }
}
void MonitorQueue()
{
    while(true)
    {
        if(inputQueue.Count > 0)
        {
            string? input;
            lock(queueLock)
            {
                if(inputQueue.Count == 0) continue; // double check after acquiring lock
                input = inputQueue.Dequeue();
            }
            semaphore.Wait();
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
    try{
        Thread.Sleep(3000);
        Console.WriteLine($"Processed: {input}");
    }
    finally
    {
        var preCount = semaphore.Release();
        Console.WriteLine($"Semaphore released, previous count was {preCount}");
    }
}
