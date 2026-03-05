var filePath = "counter.txt";
using (var mutex = new Mutex(false, "GlobalMutexExample"))
{
    for(int i = 0; i < 10000; i++)
    {
        
            mutex.WaitOne(); // acquire the mutex
            try
            {
                int counter = ReadCounterFromFile(filePath);
                counter++;
                WriteCounterToFile(filePath, counter);
            }
            finally
            {
                mutex.ReleaseMutex(); // release the mutex
            }
    }
}

Console.WriteLine("Done");
Console.ReadLine();
int ReadCounterFromFile(string filePath)
{
    if(!File.Exists(filePath))
    {
        return 0;
    }
    var content = File.ReadAllText(filePath);
    return int.Parse(content);
}
void WriteCounterToFile(string filePath, int counter)
{
    File.WriteAllText(filePath, counter.ToString());
}