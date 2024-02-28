


using System.Collections.Concurrent;

ConcurrentQueue<string?> strings = new ConcurrentQueue<String>();

strings.Enqueue("one");
strings.Enqueue(null);
strings.Enqueue("three");

foreach (var str in strings)
{
    Console.WriteLine($"{str}");
}
