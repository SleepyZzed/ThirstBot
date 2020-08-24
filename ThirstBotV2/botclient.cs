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
                    string ThirstBot = token.tkn;
                    Global.Ysmirr = ThirstBot;
                    break;
                case 2:
                    string ThirstBot1 = token.tkn1;
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
           

            _services = SetupServices();
           
            var cmdHandler = new CommandHandler(_client, _cmdService, _services);
            await cmdHandler.InitializeAsync();
           
            bool repeat = true;
            while (repeat) 
                {
            Console.WriteLine("Would you like to exit? Log or issue a command?");
            string response = Console.ReadLine().ToString();
            if(response == "exit"){

            
            Environment.Exit(0);
            
            }

            if(response == "log"){
                
                repeat = false;
                _client.Log += LogAsync;
                

                
            }
            if(response == "command")
            {   Console.WriteLine("I can send a message in the desired channel");
                Console.WriteLine("Please enter the message or quit");
                string msg = Console.ReadLine().ToString();
                if(msg == "quit")
                {
                    repeat = false;
                    _client.Log += LogAsync;
                    
                }
                
                
                Console.WriteLine("Please enter the channel you would like to send the message to");
                string chnl = Console.ReadLine().ToString();
             

                 ulong ChannelToSend=  _client.GetGuild(595663383777247297UL).Channels.FirstOrDefault(x => x.Name.Contains(chnl)).Id;
                var channel = _client.GetGuild(595663383777247297UL).GetChannel(ChannelToSend) as SocketTextChannel;
                Console.WriteLine(channel.Name);
                await channel.SendMessageAsync(msg);

                
                repeat = true;
            }
                }


            
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
