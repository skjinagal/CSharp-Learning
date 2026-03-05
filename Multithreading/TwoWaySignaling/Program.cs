using var workerEvent = new ManualResetEvent(true);
using var consumerEvent = new ManualResetEvent(false);
Thread[] threads = new Thread[3];
Queue<int> queue = new Queue<int>();
int counter = 0;
for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(Consume)
    {
            Name = $"Worker Thread {i + 1}"
    };
    threads[i].Start();
}
Console.WriteLine("Enter \"f\" to signal the pig threads to consume.");
string? input;
while(true)
{
    workerEvent.WaitOne(); // Wait for a signal from the worker thread
    workerEvent.Reset(); // Reset the event to non-signaled state
    input = Console.ReadLine();
    if (input == "f")
    {
        for(int i = 0; i< 10; i++)
        {
            queue.Enqueue(i);
        }
        Console.WriteLine("Main farmer thread signaled the pig threads to consume.");
        consumerEvent.Set(); // Signal the worker threads to consume
    }
}
void Consume()
{
    while(true)
    {
        consumerEvent.WaitOne(); // Wait for a signal from the worker thread
        Console.WriteLine($"pig thread {Thread.CurrentThread.Name} received a signal from the main farmer thread.");
        while(queue.TryDequeue(out int item))
        {
            Console.WriteLine($"pig thread {Thread.CurrentThread.Name} consumed item {item}.");
        }
        counter++;
        if(counter == threads.Length)
        {
            counter = 0;
            consumerEvent.Reset(); // Reset the event to non-signaled state
            workerEvent.Set(); // Signal the main thread that all worker threads have consumed
            Console.WriteLine($"pig thread {Thread.CurrentThread.Name} signaled the main farmer thread that all pig threads have consumed.");
        }

    }
}