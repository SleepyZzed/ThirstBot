using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Linq;

namespace ThirstBotV2
{
    public class botclient
    {
        private DiscordSocketClient _client;
        private CommandService _cmdService;
        private IServiceProvider _services;

        public botclient(DiscordSocketClient client = null, CommandService cmdService = null)
        {
            _client = client ?? new DiscordSocketClient(new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                MessageCacheSize = 50,
                LogLevel = LogSeverity.Debug
            });

            _cmdService = cmdService ?? new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Verbose,
                CaseSensitiveCommands = false
            });
        }
        public async Task InitializeAsync()
        {
            Console.WriteLine("Please Select:\n 1. ThirstBot \n 2. ThirstBot \n 3. Enter your own Token");
            int result = Convert.ToInt32(Console.ReadLine());
            switch (result)
            {
                case 1:
                    string ThirstBot = "NzIzNDEyOTg0MzY5Nzc0NjAy.XuxQ3g.DGwCAaY3zJsIljk3c_1qJXUrQ5k";
                    Global.Ysmirr = ThirstBot;
                    break;
                case 2:
                    string ThirstBot1 = "NzI2Mjk3NjA3MDE3NTk1MTYy.XvbPZA.uPQ5St5jmx7T4xoe4DxXYV6eW_k";
                    Global.Ysmirr = ThirstBot1;

                    break;
                case 3:
                    Console.WriteLine("enter token now:");
                    string result2 = Console.ReadLine().ToString();
                    Global.Ysmirr = result2;
                    break;
            }


           

            await _client.LoginAsync(TokenType.Bot, Global.Ysmirr);

            await _client.StartAsync();
            _client.Log += LogAsync;

            _services = SetupServices();
           
            var cmdHandler = new CommandHandler(_client, _cmdService, _services);
            await cmdHandler.InitializeAsync();
           

            await Task.Delay(-1);

        }


        private Task LogAsync(LogMessage logMessage)
        {
            Console.WriteLine(logMessage.Message);

            return Task.CompletedTask;

        }






        private IServiceProvider SetupServices()
                => new ServiceCollection()
                    .AddSingleton(_client)
                    .AddSingleton(_cmdService)
                    .BuildServiceProvider();

    }

}