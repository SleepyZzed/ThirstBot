using System;
using System.Collections.Generic;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;

namespace ThirstBotV2
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _cmdService;
        private readonly IServiceProvider _services;
        public int usersNum = 0;
 
     
        public CommandHandler(DiscordSocketClient client, CommandService cmdService, IServiceProvider services)
        {
            _client = client;
            _cmdService = cmdService;
            _services = services;

        }
        public async Task InitializeAsync()
        {
            
            await _cmdService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
            _cmdService.Log += LogAsync;
            _client.MessageReceived += HandleMessageAsync;
            _client.UserJoined += AnnounceUserJoined;
            _client.UserLeft += AnnounceUserLeft;


            await _client.SetGameAsync("Watching New Members", null, ActivityType.Watching);
            await _client.SetStatusAsync(UserStatus.DoNotDisturb);




        }
       


        public async Task AnnounceUserJoined(SocketGuildUser user)
        {
            var rules = _client.GetGuild(595663383777247297).GetChannel(604397574853754890) as SocketTextChannel;
            var roles = _client.GetGuild(595663383777247297).GetChannel(601930054103990311) as SocketTextChannel;
            var channel = _client.GetGuild(595663383777247297).GetChannel(601190933500788736) as SocketTextChannel;
            var channel1 = _client.GetGuild(595663383777247297).GetChannel(623868630375071764) as SocketTextChannel; // Gets the channel to send the message in
            SocketGuild socketGuild = _client.GetGuild(595663383777247297);
            

                usersNum = _client.GetGuild(595663383777247297).MemberCount;


                await _client.SetGameAsync($"{usersNum} members", null, ActivityType.Watching);

                string avurlid = user.GetAvatarUrl();
                EmbedBuilder builderJoin = new EmbedBuilder();

               
                builderJoin.WithDescription($"{user.Username}#{user.Discriminator} ({user.Mention}) Welcome To {channel.Guild.Name} Please read {rules.Mention} and get {roles.Mention} to access our server");


                builderJoin.WithThumbnailUrl(avurlid);

                builderJoin.WithColor(Color.Purple);


                var msg = await channel.SendMessageAsync("", false, builderJoin.Build());
                var msg1 = await channel1.SendMessageAsync("", false, builderJoin.Build());

                await Task.Delay(10000);

                await msg.DeleteAsync();

                

            



            //await _client.GetGuild(595663383777247297).GetTextChannel(593595026534170626).SendMessageAsync("Welcome bb" + " " + $"<@{user.Id}>");
            ulong roleID = 601575908603854860; //Some hard-coded roleID
            var role = user.Guild.GetRole(roleID);
            await user.AddRoleAsync(role);


           



        }
        public async Task AnnounceUserLeft(SocketGuildUser user)
        {
            SocketGuild socketGuild = _client.GetGuild(595663383777247297);
            if (user.AvatarId == null)
            {
                List<string> RoleList = new List<string>();


                foreach (SocketRole role in ((SocketGuildUser)user).Roles)
                {
                    RoleList.Add(role.Name);


                }
                var result = String.Join(", ", RoleList.ToArray());

                string avurlid = user.GetDefaultAvatarUrl();
                EmbedBuilder builderleave = new EmbedBuilder();

                builderleave.WithTitle("__**User Left**__");
                builderleave.WithDescription(user.Mention + "(" + user.Username + ")" + "Has left");
                builderleave.AddField(result, true);

                builderleave.WithThumbnailUrl(avurlid);
                builderleave.WithCurrentTimestamp();

                builderleave.WithColor(Color.Purple);
             

                await _client.GetGuild(595663383777247297).GetTextChannel(617205518444003364).SendMessageAsync("", false, builderleave.Build());

            }

            else
            {
              
                List<string> RoleList = new List<string>();


                foreach (SocketRole role in ((SocketGuildUser)user).Roles)
                {
                    RoleList.Add(role.Name);


                }
                var result = String.Join(", ", RoleList.ToArray());
                string avurlid = user.GetAvatarUrl();
                EmbedBuilder builderleave = new EmbedBuilder();

                builderleave.WithTitle("__**User Left**__");
                builderleave.WithDescription(user.Mention + "(" + user.Username + ")" + "Has left");
                builderleave.AddField(result, true);

                builderleave.WithThumbnailUrl(avurlid);
                builderleave.WithCurrentTimestamp();

                builderleave.WithColor(Color.Purple);


                await _client.GetGuild(595663383777247297).GetTextChannel(617205518444003364).SendMessageAsync("", false, builderleave.Build());

            }

            usersNum = _client.GetGuild(595663383777247297).MemberCount;
            
            await _client.SetGameAsync($"{usersNum} members", null, ActivityType.Watching);
           
        }
        private async Task HandleMessageAsync(SocketMessage socketMessage)
        {
            //Console.WriteLine(socketMessage.Content);
            string prefix = "#";
            ulong autajj = 242730576195354624;
            
            var argPos = 0;
            var userMessage = socketMessage as SocketUserMessage;
            if(userMessage.Author.Id == autajj)
            {
               await userMessage.DeleteAsync();
            }
           
            if (userMessage.Author.IsBot) 
               return;
            

            var context = new SocketCommandContext(_client, userMessage);
            if (userMessage is null)
                return;
            if (context.User.IsBot)
                return;

          

            if (!userMessage.HasStringPrefix(prefix, ref argPos))
                return;


           

        }

        private Task LogAsync(LogMessage logMessage)
        {
            Console.WriteLine(logMessage.Message);
            return Task.CompletedTask;

        }
    }
}

