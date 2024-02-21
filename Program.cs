

using Newtonsoft.Json.Bson;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AngelHornetLibrary;



//bool TEST_N_DRIVE = true;
//if (TEST_N_DRIVE)
//{
//    bool loop = true;
//    string _progressString = "Starting Search...";
//    Progress<string> progress = new Progress<string>(s => _progressString = s); ;

//    Task task = new Task(async () =>
//    {
//        int i = 0;
//        List<string> paths = ["N:\\Archive", "N:\\FTP", "N:\\Public", "N:\\Temp", "N:\\Updates", "N:\\Work"];
//        await foreach (var result in new AhGetFiles().GetFilesAsync(paths, "*.mp3", progress: progress))
//        {
//            string s = $"\rF[{++i,4}]  {result}";
//            s = s.PadRight(Console.BufferWidth);
//            Console.WriteLine(MiddleTruncate(s));
//        }
//        Console.WriteLine($"Search Complete. [{i}] files found.");
//        loop = false;
//    });
//    task.Start();

//    {
//        int j = 0;
//        int spinner = 0;
//        do
//        {

//            // spin for a while
//            var spin = "|/-\\"[spinner++ % 4];
//            string s = $"\rS[{j++ / 4,4}]{spin} {_progressString}";
//            s = s.PadRight(Console.BufferWidth);
//            Console.Write(MiddleTruncate(s));
//            Thread.Sleep(250);
//        } while (loop);
//        Console.Write($"S[{(j / 4),4}]");
//    }
//    Console.ReadLine();
//    Environment.Exit(0);
//}
// / TEST_N_DRIVE




// Aync DEMO
// Test the Asynchronous Interface DEMO

mainloop();
Environment.Exit(0);



// Main Loop, Simulating a GUI Application
async void mainloop()
{
    int spinner = 0;
    string message = "Hello World!";
    Console.WriteLine($"{message}");


    ButtonClickedAction((y) => message = y);        // Simulated Event Handler
    var tmp = IOWrapperAsync();                     // without await, this is equivalent to Task.Run


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

// Async Task or Async Void, since this is in theory simulating a button click event
async Task ButtonClickedAction(Action<string> CallBack)
{
    string message = await IOWrapperAsync();
    CallBack(message);
}



// Primary Program and Interactive Client
// ----
// Asynchronous Interface



async Task<string> IOWrapperAsync()     // This is effectively an interface between synchronous and asynchronous code
{
    string buffer = "";
    var task = new Task(() => buffer = BlockingIoApiCall(), TaskCreationOptions.LongRunning);
    task.Start();
    await task;
    return buffer;
}



// Asnchronous Interface
// ---
// Synchronous Blocking IO API Call



string BlockingIoApiCall()
{
    Task.Delay(3000).Wait();
    return "World Goodbye!     ";
}



static string MiddleTruncate(string input)
{
    var length = Console.BufferWidth - 1;
    if (input.Length <= length) return input;
    return input.Substring(0, length / 2 - 3) + " ... " + input.Substring(input.Length - length / 2 + 3);
}
