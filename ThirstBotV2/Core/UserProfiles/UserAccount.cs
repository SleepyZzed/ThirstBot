// Decompiled with JetBrains decompiler
// Type: YsmirrV3.Core.UserProfiles.UserAccount
// Assembly: YsmirrV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA3BFC3F-AF25-4C6C-8FF7-ADF0193B8EB3
// Assembly location: E:\Ysmirr\YsmirrV3.dll

using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirstBotV2.Core.UserProfiles
{
  public static class UserAccount
  {
    private static string accountsFile = "Resources/accounts.json";
    public static string hugfile = "Resources/hugs.json";
    public static string fuckfile = "Resources/fuck.json";
    public static string kissfile = "Resources/kiss.json";
    public static string patfile = "Resources/pat.json";
    public static string feedfile = "Resources/feed.json";
    public static string succfile = "Resources/succ.json";
    public static string cryfile = "Resources/cry.json";
    public static string slapfile = "Resources/slap.json";
    public static string punchfile = "Resources/punch.json";
    public static List<UserAccounts> accounts;
    public static List<LinksAction> huglinks;
    public static List<LinksAction> fucklinks;
    public static List<LinksAction> kisslinks;
    public static List<LinksAction> patlinks;
    public static List<LinksAction> feedlinks;
    public static List<LinksAction> succlinks;
    public static List<LinksAction> crylinks;
    public static List<LinksAction> slaplinks;
    public static List<LinksAction> punchlinks;

    static UserAccount()
    {
      if (DataStorage.SaveExists(UserAccount.accountsFile))
      {
        UserAccount.accounts = DataStorage.LoadUserAccounts(UserAccount.accountsFile).ToList<UserAccounts>();
      }
      else
      {
        UserAccount.accounts = new List<UserAccounts>();
        UserAccount.SaveAccounts();
      }
      if (DataStorage.SaveExists(UserAccount.hugfile))
      {
        UserAccount.huglinks = DataStorage.LoadLinks(UserAccount.hugfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.huglinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.huglinks, UserAccount.hugfile);
      }
      if (DataStorage.SaveExists(UserAccount.fuckfile))
      {
        UserAccount.fucklinks = DataStorage.LoadLinks(UserAccount.fuckfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.fucklinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.fucklinks, UserAccount.fuckfile);
      }
      if (DataStorage.SaveExists(UserAccount.kissfile))
      {
        UserAccount.kisslinks = DataStorage.LoadLinks(UserAccount.kissfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.kisslinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.kisslinks, UserAccount.kissfile);
      }
      if (DataStorage.SaveExists(UserAccount.patfile))
      {
        UserAccount.patlinks = DataStorage.LoadLinks(UserAccount.patfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.patlinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.patlinks, UserAccount.patfile);
      }
      if (DataStorage.SaveExists(UserAccount.feedfile))
      {
        UserAccount.feedlinks = DataStorage.LoadLinks(UserAccount.feedfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.feedlinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.feedlinks, UserAccount.feedfile);
      }
      if (DataStorage.SaveExists(UserAccount.succfile))
      {
        UserAccount.succlinks = DataStorage.LoadLinks(UserAccount.succfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.succlinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.succlinks, UserAccount.succfile);
      }
      if (DataStorage.SaveExists(UserAccount.cryfile))
      {
        UserAccount.crylinks = DataStorage.LoadLinks(UserAccount.cryfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.crylinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.crylinks, UserAccount.cryfile);
      }
      if (DataStorage.SaveExists(UserAccount.slapfile))
      {
        UserAccount.slaplinks = DataStorage.LoadLinks(UserAccount.slapfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.slaplinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.slaplinks, UserAccount.slapfile);
      }
      if (DataStorage.SaveExists(UserAccount.punchfile))
      {
        UserAccount.punchlinks = DataStorage.LoadLinks(UserAccount.punchfile).ToList<LinksAction>();
      }
      else
      {
        UserAccount.punchlinks = new List<LinksAction>();
        UserAccount.SavenewLinks(UserAccount.punchlinks, UserAccount.punchfile);
      }
    }

    public static void SaveAccounts()
    {
      DataStorage.SavedUserAccounts((IEnumerable<UserAccounts>) UserAccount.accounts, UserAccount.accountsFile);
    }

    public static void SavenewLinks(List<LinksAction> linksstr, string str)
    {
      DataStorage.SavedLinks((IEnumerable<LinksAction>) linksstr, str);
    }

    public static UserAccounts GetAccounts(SocketUser user)
    {
      return UserAccount.GetOrCreateAccount(user.Id, user.Username);
    }

    private static UserAccounts GetOrCreateAccount(ulong id, string username)
    {
      return UserAccount.accounts.Where<UserAccounts>((Func<UserAccounts, bool>) (a => (long) a.ID == (long) id)).FirstOrDefault<UserAccounts>() ?? UserAccount.CreateUserAccount(id, username);
    }

    private static UserAccounts CreateUserAccount(ulong id, string username)
    {
      UserAccounts userAccounts = new UserAccounts()
      {
        Username = username,
        ID = id,
        Points = 10
      };
      UserAccount.accounts.Add(userAccounts);
      UserAccount.SaveAccounts();
      return userAccounts;
    }

    public static LinksAction CreateLinkactnew(
      string url,
      List<LinksAction> lnk,
      string file)
    {
      LinksAction linksAction = new LinksAction()
      {
        Url = url
      };
      lnk.Add(linksAction);
      UserAccount.SavenewLinks(lnk, file);
      return linksAction;
    }
  }
}
