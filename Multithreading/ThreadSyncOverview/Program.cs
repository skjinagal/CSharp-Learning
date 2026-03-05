// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int counter = 0;
var lockObj = new object();
void IncreamentCounter()
{
    for(int i = 0; i < 1000000; i++)
    {
        using (var mutex = new Mutex(false, "GlobalMutext"))
        {
            mutex.WaitOne(); // get the lock
            try
            {
                counter++;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
Thread thread1 = new Thread(IncreamentCounter);
Thread thread2 = new Thread(IncreamentCounter);
thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();
Console.WriteLine($"Counter: {counter}"); // expected output: Counter: 2000000