// See https://aka.ms/new-console-template for more information

CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
CancellationToken ct = cts.Token;

try
{
    Task.Run(() =>
    {
        int i = 0;
        while (true)
        {
            Task.Delay(1000).Wait();
            Console.WriteLine($"{++i,2}:Hello, World!");
            // if(ct.IsCancellationRequested) return;
        }
    }).Wait(TimeSpan.FromSeconds(5),ct);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Canceled!");
}

Console.WriteLine();
Console.WriteLine("Waiting for 5 seconds...");
Task.Delay(5000).Wait();
Console.WriteLine("All Done.");
