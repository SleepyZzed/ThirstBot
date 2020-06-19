using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ThirstBotV2.Core.UserProfiles;


namespace ThirstBotV2
{
    public class BasicCommands : ModuleBase<SocketCommandContext>
    { 
        private LinksAction linkact = new LinksAction();
        private List<LinksAction> sorted;
        private Random rand;

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
        [Command("hugadd")]
    [RequireOwner]
    public async Task addedHug(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.huglinks, UserAccount.hugfile);
    }

    [Command("fa")]
    [RequireOwner]
    public async Task addedfyuck(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.fucklinks, UserAccount.fuckfile);
    }

    [Command("ka")]
    [RequireOwner]
    public async Task addkiss(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.kisslinks, UserAccount.kissfile);
    }

    [Command("pa")]
    [RequireOwner]
    public async Task addp(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.patlinks, UserAccount.patfile);
    }

    [Command("fea")]
    [RequireOwner]
    public async Task feeda(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.feedlinks, UserAccount.feedfile);
    }

    [Command("succa")]
    [RequireOwner]
    public async Task succa(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.succlinks, UserAccount.succfile);
    }

    [Command("ca")]
    [RequireOwner]
    public async Task ca(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.crylinks, UserAccount.cryfile);
    }

    [Command("slapadd")]
    [RequireOwner]
    public async Task slapadd(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.slaplinks, UserAccount.slapfile);
    }

    [Command("punchadd")]
    [RequireOwner]
    public async Task punchadd(string url)
    {
      await Context.Channel.SendMessageAsync(url + " has been added to json");
      UserAccount.CreateLinkactnew(url, UserAccount.punchlinks, UserAccount.punchfile);
    }
    [Command("Hug")]
    public async Task Hug([Remainder] SocketUser user)
    {
      
      sorted = UserAccount.huglinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
      List<string> stringList = new List<string>();
      foreach (LinksAction linksAction in sorted)
      {
        string str = linksAction.Url.ToString();
        stringList.Add(str);
      }
      rand = new Random();
      int index = rand.Next(stringList.Count);
      string Hugpost = stringList[index];
      EmbedBuilder embedBuilder = new EmbedBuilder();
      embedBuilder.WithTitle(string.Format("__{0}__ Hugged __{1}__", Context.User.Username, user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(Hugpost);
      embedBuilder.WithColor(Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
     
    }
        [Command("fuck")]
        public async Task Fuck([Remainder] SocketUser user)
        {
            
            sorted = UserAccount.fucklinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>)(o => o.Url)).ToList<LinksAction>();
            List<string> stringList = new List<string>();
            foreach (LinksAction linksAction in sorted)
            {
                string str = linksAction.Url.ToString();
                stringList.Add(str);
            }
            rand = new Random();
            int index = rand.Next(stringList.Count);
            string imageUrl = stringList[index];
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.WithTitle(string.Format("__{0}__ wants to fuck __{1}__", Context.User.Username, user));
            embedBuilder.WithCurrentTimestamp();
            embedBuilder.WithImageUrl(imageUrl);
            embedBuilder.WithColor(Color.Purple);
             await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
            await Task.Delay(1);
        }
    }
}
