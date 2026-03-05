// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
void PrintNumbers()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine(Thread.CurrentThread.Name);
        //Thread.Sleep(50); // Simulate work
    }
}

Thread.CurrentThread.Name = "Main Thread";
Thread.CurrentThread.Priority = ThreadPriority.Normal;
Thread thread1 = new Thread(PrintNumbers)
{
    Name = "Worker Thread",
    Priority = ThreadPriority.Highest
};
thread1.Start();
Thread thread2 = new Thread(PrintNumbers)
{
    Name = "Worker Thread 2",
    Priority = ThreadPriority.Lowest
};
thread2.Start();
PrintNumbers();

