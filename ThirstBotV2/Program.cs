using System;
using System.Threading.Tasks;
using Discord;

namespace ThirstBotV2
{
    class Program
    {
        static async Task Main(string[] args)

            => await new botclient().InitializeAsync();


    }
}
