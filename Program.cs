

using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;



mainloop();
Environment.Exit(0);    


void mainloop()
{
    int spinner = 0;
    string message = "Hello World!";
    Console.WriteLine($"{message}");

    //message = GetMessageAsync().Result;               // This will block, because of the .Result.  Aka: "World Goodbye!"
    Task.Run(() => { GetMessageByRef(ref message); });  // This will NOT block, but is unsafe.  Aka: "World World!"
    //                                                  // What's the best way to pass values back?  Use a ConcurrentQueue?
    //                                                  //  
    //                                                  // Do I pass the list by reference?  Or do I pass the list by value?
    //                                                  // Volatile keyword?
    //                                                  // Interlocked class?
    
    do
    {
        // spin for a while
        var spin = "|/-\\"[spinner++ % 4];
        Console.Write($"{spin} {message}\r");
        Thread.Sleep(1000);
    } while (message == "Hello World!");
    Console.WriteLine(message);
}

async Task<string> GetMessageAsync()
{
    string buffer= "";
    var task  = new Task(() => buffer = BlockingIoApiCall());
    task.Start();
    await task;
    return buffer;
}

void GetMessageByRef(ref string message)
{
    string buffer = "";
    Task task = new Task(() => { buffer = BlockingIoApiCall(); });
    task.Start();
    task.Wait();
    message = buffer;
}

string BlockingIoApiCall()
{
        Task.Delay(3000).Wait();
        return "World Goodbye!";
}
