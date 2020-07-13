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
            var userMessage = socketMessage as SocketUserMessage;
            var context = new SocketCommandContext(_client, userMessage);
            
            string prefix = "~";
            var argPos = 0;

            if (userMessage is null)
            return;
            
            if(userMessage.ToString().ToLower().StartsWith("dm me") && userMessage.ToString().ToLower().Contains("nudes") )
            {   if(userMessage.Channel.Id == 685800338879414286)
            {
                return;
            }   
               
                var ChannelID = context.Guild.GetTextChannel(userMessage.Id);
                await userMessage.DeleteAsync();
                await userMessage.Author.SendMessageAsync("Banned for possibily being a bot, dm an admin to dispute this ban");
                await context.Guild.AddBanAsync(userMessage.Author);
                return;
            }
            if(userMessage.Author.Id == 242730576195354624 && userMessage.Channel.Id == 617205518444003364)
            {
                await userMessage.DeleteAsync();
                return;
            }

            if (userMessage.Author.IsBot) 
               return;
            
            if (userMessage is null)
                return;
            if (context.User.IsBot)
                return;
            
           
            if (userMessage.Channel.GetType() == typeof (SocketDMChannel))
            {
                ulong zid;
                ulong id;
                EmbedBuilder embedBuilder = new EmbedBuilder();
        if (userMessage.Content.ToLower().StartsWith("confess"))
            {
            zid = 485512961000210433;
            
            string str1 = userMessage.ToString();
            string str2 = "__";
            embedBuilder.WithTitle("<:damnson:601641217322909706>__**Confession: Sent by Anon User**__<:damnson:601641217322909706>");
            embedBuilder.WithDescription(str2 + str1.Remove(0, 7) + str2);
            embedBuilder.WithCurrentTimestamp();
            embedBuilder.WithFooter("Dm me Confess <Follwed by confession> to make an anonymous confession");
            embedBuilder.WithColor(Color.Purple);
            await _client.GetGuild(595663383777247297UL).GetTextChannel(624175859690897408UL).SendMessageAsync("", false, embedBuilder.Build());
            id = userMessage.Author.Id;
            await _client.GetUser(id).SendMessageAsync("<:smileyheart:601641156866080771><:smileyheart:601641156866080771><:smileyheart:601641156866080771>Confession Sent<:smileyheart:601641156866080771><:smileyheart:601641156866080771><:smileyheart:601641156866080771>", false, (Embed) null, (RequestOptions) null);
            await _client.GetUser(zid).SendMessageAsync("confession sent in by: " + id.ToString() + " " + str1);
            }
            if (userMessage.Content.ToLower().StartsWith("sa"))
            {
            zid = 485512961000210433;
            
            string str1 = userMessage.ToString();
            string str2 = "__";
            embedBuilder.WithTitle("<:damnson:601641217322909706>__**Secret Admirer: Sent by Anon User**__<:damnson:601641217322909706>");
            embedBuilder.WithDescription(str2 + str1.Remove(0, 2) + str2);
            embedBuilder.WithCurrentTimestamp();
            embedBuilder.WithFooter("Dm me sa <Follwed by a name> to make an anonymous secret admirer post");
            embedBuilder.WithColor(Color.Purple);
            await _client.GetGuild(595663383777247297UL).GetTextChannel(665566408356265996).SendMessageAsync("", false, embedBuilder.Build());
            id = userMessage.Author.Id;
            await _client.GetUser(id).SendMessageAsync("<:smileyheart:601641156866080771><:smileyheart:601641156866080771><:smileyheart:601641156866080771>Secret Admirer sent Sent<:smileyheart:601641156866080771><:smileyheart:601641156866080771><:smileyheart:601641156866080771>", false, (Embed) null, (RequestOptions) null);
            await _client.GetUser(zid).SendMessageAsync("sa sent in by: " + id.ToString() + " " + str1);
            }
            if (userMessage.Content.ToLower().Contains("verify") && userMessage.Attachments.Any<Attachment>())
            {
            ulong id1 = userMessage.Author.Id;
            string mention = userMessage.Author.Mention;
            string url = userMessage.Attachments.ElementAt<Attachment>(0).Url;
            
            embedBuilder.WithTitle("Verification");
            embedBuilder.WithCurrentTimestamp();
            embedBuilder.WithDescription("sent by" + mention + " (" + userMessage.Author.Username + ")");
            embedBuilder.WithFooter("DM " + userMessage.Author.Mention + " if image is sketchty");
            embedBuilder.WithImageUrl(url);
            embedBuilder.WithColor(Color.Purple);
            await _client.GetUser(id1).SendMessageAsync("<:smileyheart:601641156866080771><:smileyheart:601641156866080771><:smileyheart:601641156866080771>Verification Sent<:smileyheart:601641156866080771><:smileyheart:601641156866080771><:smileyheart:601641156866080771>", false, (Embed) null, (RequestOptions) null);
            await _client.GetGuild(595663383777247297UL).GetTextChannel(624185396556857346UL).SendMessageAsync("", false, embedBuilder.Build());
            await Task.Delay(1);
            
            }
        }

            if (!userMessage.HasStringPrefix(prefix, ref argPos))
                return;


           var result = await _cmdService.ExecuteAsync(context, argPos, _services);

        }

        private Task LogAsync(LogMessage logMessage)
        {
            Console.WriteLine(logMessage.Message);
            return Task.CompletedTask;

        }
    }
}

