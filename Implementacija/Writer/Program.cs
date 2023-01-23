using CacheMemory.Structures.Implementations;
using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using CacheMemory.Writer;
using System.Collections.Concurrent;
using System.ComponentModel;

var concurrentQueue = new ConcurrentQueue<SpentEnergyDto>();
IDumpingBuffer dumpingBuffer = new DumpingBuffer(concurrentQueue);
Historical historical = new();
Writer writer = new Writer(dumpingBuffer, historical);

Console.WriteLine("-------------------------------------------");
Console.WriteLine("Unos podataka :");
Console.WriteLine("-------------------------------------------");
var input = string.Empty;

while (!input.Equals("kraj"))
{
    Console.WriteLine("Unesite ID korisnika :");
    input = Console.ReadLine();
    var result = int.TryParse(input, out int userId);
    if (!result)
    {
        Console.WriteLine("Greška! Morate uneti ceo broj!");
        continue;
    }

    Console.WriteLine("Unesite potrošnju toplotne energije :");
    var spentEnery = Console.ReadLine();
    result = double.TryParse(spentEnery, out double insertedEnergy);
    if (!result)
    {
        Console.WriteLine("Greška! Morate uneti decimalan broj!");
        continue;
    }

    writer.Write(userId, insertedEnergy);
    Console.WriteLine("-------------------------------------------\n");
}
