// Decompiled with JetBrains decompiler
// Type: YsmirrV3.Core.DataStorage
// Assembly: YsmirrV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA3BFC3F-AF25-4C6C-8FF7-ADF0193B8EB3
// Assembly location: E:\Ysmirr\YsmirrV3.dll

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ThirstBotV2.Core.UserProfiles;

namespace ThirstBotV2.Core
{
  public static class DataStorage
  {
    public static void SavedUserAccounts(IEnumerable<UserAccounts> accounts, string filePath)
    {
      string contents = JsonConvert.SerializeObject((object) accounts, Formatting.Indented);
      File.WriteAllText(filePath, contents);
    }

    public static void SavedLinks(IEnumerable<LinksAction> links, string filePath)
    {
      string contents = JsonConvert.SerializeObject((object) links, Formatting.Indented);
      File.WriteAllText(filePath, contents);
    }

    public static IEnumerable<UserAccounts> LoadUserAccounts(string filePath)
    {
      return (IEnumerable<UserAccounts>) JsonConvert.DeserializeObject<List<UserAccounts>>(File.ReadAllText(filePath));
    }

    public static IEnumerable<LinksAction> LoadLinks(string filePath)
    {
      return (IEnumerable<LinksAction>) JsonConvert.DeserializeObject<List<LinksAction>>(File.ReadAllText(filePath));
    }

    public static bool SaveExists(string filePath)
    {
      return File.Exists(filePath);
    }
  }
}
