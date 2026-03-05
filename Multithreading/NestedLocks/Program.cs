

var orderLock = new object();
var userLock = new object();
Thread userThread = new Thread(ManageUser);
userThread.Start();
ManageOrder(); // This will cause a deadlock since the main thread is holding the orderLock and waiting for userLock, while the userThread is holding the userLock and waiting for orderLock.
void ManageUser()
{
    lock (userLock)
    {
        // Perform operations on the user
        Console.WriteLine("UserManagent Managing user...");
        Thread.Sleep(2000); // Simulate some work
        lock (orderLock)
        {
            // Perform operations on the order
            Console.WriteLine("UserManagent Managing order...");
        }
    }
} 

void ManageOrder()
{
    lock (orderLock)
    {
        // Perform operations on the order
        Console.WriteLine("OrderManagent Managing order...");
        Thread.Sleep(2000); // Simulate some work
        lock (userLock)
        {
            // Perform operations on the user
            Console.WriteLine("OrderManagent Managing user...");
        }
    }
}