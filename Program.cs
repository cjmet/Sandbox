

using Newtonsoft.Json.Bson;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

mainloop();
Environment.Exit(0);

async void mainloop()
{
    int spinner = 0;
    string message = "Hello World!";
    Console.WriteLine($"{message}");

    ButtonClickedAction((x, y) => message = y);

    int i = 0;
    do
    {
        // spin for a while
        var spin = "|/-\\"[spinner++ % 4];
        Console.Write($"[{i++,2}]{spin} {message}\r");
        Thread.Sleep(1000);
    } while (message == "Hello World!");
    Console.WriteLine(message);
}



async void ButtonClickedAction(Action<string,string> CallBack)
{
    string message = await GetMessageAsync();
    CallBack(message,message);
}

async Task<string> GetMessageAsync()
{
    string buffer= "";
    var task  = new Task(() => buffer = BlockingIoApiCall());
    task.Start();
    await task;
    return buffer;
}

string BlockingIoApiCall()
{
        Task.Delay(3000).Wait();
        return "World Goodbye!     ";
}
