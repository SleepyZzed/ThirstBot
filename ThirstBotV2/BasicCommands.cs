using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace ThirstBotV2
{
    public class BasicCommands : ModuleBase<SocketCommandContext>
    {
        [Command("userinfo")]
        [Summary
   ("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync(
       [Summary("The (optional) user to get info from")]
        SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            // await ReplyAsync($"Username: {userInfo.Mention}#{userInfo.Discriminator} Created At:{userInfo.CreatedAt} User ID:{userInfo.Id}");

            var builder = new EmbedBuilder();
            string Username = Convert.ToString(userInfo.Username);
            string CreatedDate = Convert.ToString(userInfo.CreatedAt);
            string ID = Convert.ToString(userInfo.Id);
            


            builder.WithTitle("Info");
            builder.WithDescription($"Username: {user.Mention} \n user Id: {ID} \n Created On: {CreatedDate}");

            builder.WithImageUrl(user.GetAvatarUrl());

            builder.WithColor(Color.Red);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
            await Task.Delay(1);
        }
        [Command("cck")]
        [RequireOwner]
        public async Task csk()
        {
            var guild = Context.Guild as IGuild;
            var users = await guild.GetUsersAsync();

            foreach (var user in users)
            {
                var u = user as IGuildUser;
                var roles = u.RoleIds;
                ulong underage = 601919400924282882;
                var rlunderage = Context.Guild.Roles.FirstOrDefault(x => x.Name == "-18");

                if (!u.IsBot && !u.IsWebhook)
                {
                    try
                    {   if (roles.Contains(underage))
                        {
                            await user.BanAsync();
                        }
                        
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }
        [Command("Ad")]
        public async Task Advert()
        {
            var embed = new EmbedBuilder();

            embed.WithColor(153, 51, 255);
            embed.WithTitle("https://discord.gg/pnVMjXA");
            embed.WithDescription(@"
This is an 18+ NSFW server and community with many features to satiate your thirst. We are a lax community with relaxed rules and a place to be thirsty without being a creep. Harmless banter and perverted jokes are welcome as long as it does not cross the line.


**__Our community offers__**


- Safe place for everyone;

-Friendly staff;

            -Server dedicated bots;

            -Many roles to choose from;

            -E - girls;

            -Verification system to avoid catfishes and underage scrubs;\u200B

            -NSFW Channels;

            -Many fun bots;

            -Nudes channels;

            -Events

            - And much more.

Whether you are looking for a place to make friends or just looking to thirst over nudes, this is the server for you!");
            embed.WithImageUrl("https://media.discordapp.net/attachments/624194359780442122/644703916763774986/download.png");




            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
}
