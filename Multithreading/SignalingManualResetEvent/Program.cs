using var manualResetEvent = new ManualResetEvent(false);
Console.WriteLine("Press Enter to release all waiting threads...");
for(int i = 0; i < 5; i++)
{
    int threadIndex = i;
    new Thread(() =>
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} is waiting...");
        manualResetEvent.WaitOne();
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} has been released!");
    })
    {
        Name = $"Thread {threadIndex}"
    }.Start();
}


Console.ReadLine();
manualResetEvent.Set();
Console.ReadLine(); // Keep the console open to see the output