using var autoResetEvent = new AutoResetEvent(false);
Console.WriteLine("Enter \"go\" to release the waiting thread.");
string? input;
for(int i = 0 ; i < 3; i++)
{
    new Thread(Worker)
    {
        Name = $"WorkerThread-{i + 1}"
    }.Start();
}
while(true)
{
    input = Console.ReadLine();
    if(input == "go")
    {
        autoResetEvent.Set();
    }
    else if(input == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter \"go\" to release the waiting thread.");
    }
}

void Worker()
{
    while (true)
    {
        Console.WriteLine($" {Thread.CurrentThread.Name} thread is waiting...");
        autoResetEvent.WaitOne();
        Thread.Sleep(3000); // Simulate work
        Console.WriteLine($" {Thread.CurrentThread.Name} thread has been released!");
    }
}