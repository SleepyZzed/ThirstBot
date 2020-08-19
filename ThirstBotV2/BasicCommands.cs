using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ThirstBotV2.Core.UserProfiles;
using System.Net;
using System.Drawing;
using System.IO;

namespace ThirstBotV2
{
    public class BasicCommands : ModuleBase<SocketCommandContext>
    { 
        private LinksAction linkact = new LinksAction();
        private List<LinksAction> sorted;
        private Random rand;

        public static string gog = "https://www.google.com";

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

            builder.WithColor(Discord.Color.Red);
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
        [Command("removeunderage")]
        [RequireOwner]
        public async Task RemoveUnderAge()
        {
            var guild = Context.Guild as IGuild;
            var users = await guild.GetUsersAsync();
            await Context.Channel.SendMessageAsync("Removing underage members");
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
                        {   await Context.Channel.SendMessageAsync("Removing underage members");
                            await u.BanAsync();
                            
                        }
                        
                    }
                    catch (Exception e)
                    {
                      await Context.Channel.SendMessageAsync(e.ToString());
                    }
                }
            }
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
    { EmbedBuilder embedBuilder = new EmbedBuilder();
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle("Lonely Fuck");
      embedBuilder.WithCurrentTimestamp();
      
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
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
      //EmbedBuilder embedBuilder = new EmbedBuilder();
      embedBuilder.WithTitle(string.Format("__{0}__ Hugged __{1}__", Context.User.Username, user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(Hugpost);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
     
    }
        [Command("fuck")]
        public async Task Fuck([Remainder] SocketUser user)
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle("Lonely Fuck");
      embedBuilder.WithCurrentTimestamp();
      
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
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
            //EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.WithTitle(string.Format("__{0}__ wants to fuck __{1}__", Context.User.Username, user));
            embedBuilder.WithCurrentTimestamp();
            embedBuilder.WithImageUrl(imageUrl);
            embedBuilder.WithColor(Discord.Color.Purple);
            await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
            await Task.Delay(1);
      }
        }
        [Command("kiss")]
    public async Task Kiss([Remainder] SocketUser user)
    {
      EmbedBuilder embedBuilder = new EmbedBuilder();
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle("Lonely Fuck");
      embedBuilder.WithCurrentTimestamp();
      
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
      sorted = UserAccount.kisslinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
      List<string> stringList = new List<string>();
      foreach (LinksAction linksAction in sorted)
      {
        string str = linksAction.Url.ToString();
        stringList.Add(str);
      }
      rand = new Random();
      int index = rand.Next(stringList.Count);
      string imageUrl = stringList[index];
      //EmbedBuilder embedBuilder = new EmbedBuilder();
      embedBuilder.WithTitle(string.Format("__{0}__ kissed __{1}__",Context.User.Username, user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      await Task.Delay(3);
    }
    }
    [Command("Pat")]
    public async Task pat([Remainder] SocketUser user)
    {
      EmbedBuilder embedBuilder = new EmbedBuilder();
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle("Lonely Fuck");
      embedBuilder.WithCurrentTimestamp();
      
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
      sorted = UserAccount.patlinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
      List<string> stringList = new List<string>();
      foreach (LinksAction linksAction in sorted)
      {
        string str = linksAction.Url.ToString();
        stringList.Add(str);
      }
      rand = new Random();
      int index = rand.Next(stringList.Count);
      string imageUrl = stringList[index];
      //EmbedBuilder embedBuilder = new EmbedBuilder();
      embedBuilder.WithTitle(string.Format("__{0}__ Pats __{1}__",  Context.User.Username,  user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      await Task.Delay(3);
      }
    }

    [Command("Feed")]
    public async Task feed([Remainder] SocketUser user)
    {
      EmbedBuilder embedBuilder = new EmbedBuilder();
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle("Fat fuck");
      embedBuilder.WithCurrentTimestamp();
      
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
      sorted = UserAccount.feedlinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
      List<string> stringList = new List<string>();
      foreach (LinksAction linksAction in sorted)
      {
        string str = linksAction.Url.ToString();
        stringList.Add(str);
      }
      rand = new Random();
      int index = rand.Next(stringList.Count);
      string imageUrl = stringList[index];
      //EmbedBuilder embedBuilder = new EmbedBuilder();
      embedBuilder.WithTitle(string.Format("__{0}__ Fed __{1}__",  Context.User.Username,  user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      await Task.Delay(3);
      }
    }

    [Command("Succ")]
    public async Task Succ([Remainder] SocketUser user)
    {
      EmbedBuilder embedBuilder = new EmbedBuilder();
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle("Lonely Fuck");
      embedBuilder.WithCurrentTimestamp();
      
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
      sorted = UserAccount.succlinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
      List<string> stringList = new List<string>();
      foreach (LinksAction linksAction in sorted)
      {
        string str = linksAction.Url.ToString();
        stringList.Add(str);
      }
      rand = new Random();
      int index = rand.Next(stringList.Count);
      string imageUrl = stringList[index];
      //EmbedBuilder embedBuilder = new EmbedBuilder();
      embedBuilder.WithTitle(string.Format("__{0}__ :flushed: __{1}__",  Context.User.Username,  user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      await Task.Delay(3);
      }
    }

    [Command("cry")]
    public async Task cry()
    {
      
      sorted = UserAccount.crylinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
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
      embedBuilder.WithTitle(Context.User.Username + " is crying");
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      await Task.Delay(3);
    }

    [Command("slap")]
    public async Task slap([Remainder] SocketGuildUser user)
    {
      EmbedBuilder embedBuilder = new EmbedBuilder();
      sorted = UserAccount.slaplinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
      List<string> stringList = new List<string>();
      foreach (LinksAction linksAction in sorted)
      {
        string str = linksAction.Url.ToString();
        stringList.Add(str);
      }
      rand = new Random();
      int index = rand.Next(stringList.Count);
      string imageUrl = stringList[index];
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle(string.Format("{0} Slapped themselves",  Context.User.Username));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
      
      //EmbedBuilder embedBuilder = new EmbedBuilder();
      embedBuilder.WithTitle(string.Format("{0} Slapped {1}",  Context.User.Username,  user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      await Task.Delay(3);
    }
    }

    [Command("punch")]
    public async Task punch([Remainder] SocketGuildUser user)
    {
      EmbedBuilder embedBuilder = new EmbedBuilder();
      sorted = UserAccount.punchlinks.OrderByDescending<LinksAction, string>((Func<LinksAction, string>) (o => o.Url)).ToList<LinksAction>();
      List<string> stringList = new List<string>();
      foreach (LinksAction linksAction in sorted)
      {
        string str = linksAction.Url.ToString();
        stringList.Add(str);
      }
      rand = new Random();
      int index = rand.Next(stringList.Count);
      string imageUrl = stringList[index];
      if(Context.User.Id == user.Id)
      {
      
      embedBuilder.WithTitle(string.Format("{0} Punched themselves",  Context.User.Username));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      }
      else{
      
      embedBuilder.WithTitle(string.Format("{0} Punched {1}",  Context.User.Username,  user));
      embedBuilder.WithCurrentTimestamp();
      embedBuilder.WithImageUrl(imageUrl);
      embedBuilder.WithColor(Discord.Color.Purple);
      await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
      await Task.Delay(3);
      }
    }
    [Command("br")]
    public async Task Br([Remainder] SocketGuildUser user)
    {
            string url = user.GetAvatarUrl(ImageFormat.Auto, 256);
            if (File.Exists("Resources/newimage.png"))
            {
                File.Delete("Resources/newimage.png");
            }
            if (File.Exists("Resources/Img4.png"))
            {
                File.Delete("Resources/Img4.png");
            }
            
            WebClient webClient = new WebClient();
            
            webClient.DownloadFile(user.GetAvatarUrl(ImageFormat.Auto, 256), "Resources/Img4.png");
            
            
            //webClient.DownloadFileAsync(new Uri(user.GetAvatarUrl(ImageFormat.Auto, 256)), "D:/Ysmirr/ThirstBot/ThirstBotV2/Resources/Img4.png");
            webClient.Dispose();

            string image1 = "Resources/Img4.png";
            string image2 = "Resources/Img12.png";

            System.Drawing.Image canvas = Bitmap.FromFile(image1);
            Graphics gra = Graphics.FromImage(canvas);
            Bitmap smallImg = new Bitmap(image2);
            gra.DrawImage(smallImg, new Point(0, 234));
            
            canvas.Save("Resources/newimage.png", System.Drawing.Imaging.ImageFormat.Png);
            await Context.Channel.SendFileAsync("Resources/newimage.png");
            smallImg.Dispose();
            gra.Dispose();
            canvas.Dispose();
        }
        [Command("gay")]
        public async Task Gay([Remainder] SocketGuildUser user)
        {
            string url = user.GetAvatarUrl(ImageFormat.Auto, 256);
            if (File.Exists("Resources/newimagePride.png"))
            {
                File.Delete("Resources/newimagePride.png");
            }
            if (File.Exists("Resources/Img4.png"))
            {
                File.Delete("Resources/Img4.png");
            }

            WebClient webClient = new WebClient();
            
            
            webClient.DownloadFile(user.GetAvatarUrl(ImageFormat.Auto, 256), "Resources/Img4.png");
            

            //webClient.DownloadFileAsync(new Uri(user.GetAvatarUrl(ImageFormat.Auto, 256)), "D:/Ysmirr/ThirstBot/ThirstBotV2/Resources/Img4.png");
            webClient.Dispose();

            string image1 = "Resources/Img4.png";
            string image2 = "Resources/pride.png";

            System.Drawing.Image canvas = Bitmap.FromFile(image1);
            Graphics gra = Graphics.FromImage(canvas);
            Bitmap smallImg = new Bitmap(image2);
            gra.DrawImage(smallImg, new Point(0, 0));

            canvas.Save("Resources/newimagePride.png", System.Drawing.Imaging.ImageFormat.Png);
            await Context.Channel.SendFileAsync("Resources/newimagePride.png");
            smallImg.Dispose();
            gra.Dispose();
            canvas.Dispose();
        }


    }
}
