using System;

namespace MrSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello MrSharp!");
            var mrSharp = new MrSharp();
            mrSharp.Run().ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
