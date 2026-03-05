// See https://aka.ms/new-console-template for more information
int SegmentSum(int[] arr, int start, int end)
{
    int sum = 0;
    for (int i = start; i <= end; i++)
    {
        sum += arr[i];
        Thread.Sleep(100); // Simulate work
    }
    return sum;
}

int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var startTime = DateTime.Now;
int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
var noOfThreads = 4;
var SegmentSize = arr.Length / noOfThreads;
Thread[] threads = new Thread[noOfThreads];
threads[0] = new Thread(() => sum1 = SegmentSum(arr, 0, SegmentSize - 1));
threads[1] = new Thread(() => sum2 = SegmentSum(arr, SegmentSize, 2 * SegmentSize - 1));
threads[2] = new Thread(() => sum3 = SegmentSum(arr, 2 * SegmentSize, 3 * SegmentSize - 1));
threads[3] = new Thread(() => sum4 = SegmentSum(arr, 3 * SegmentSize, arr.Length - 1));

foreach(var thread in threads)
{
    thread.Start();
}
foreach(var thread in threads)
{
    thread.Join(); // block the main thread until the worker thread finishes
}
var endTime = DateTime.Now;
var duration = endTime - startTime;
Console.WriteLine($"Sum: {sum1 + sum2 + sum3 + sum4}, Time taken: {duration.TotalMilliseconds} seconds");

