﻿using System.IdentityModel.Tokens.Jwt;
using Taxi.App.Models;

namespace Taxi.App.Common;

public static class SecureStorageExtensions
{
    public static User GetUser(this ISecureStorage storage)
    {
        var token = Task.Run(async () => await storage.GetAsync("token")).Result;

        if (token == null)
        {
            return null;
        }

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token);
        var tokenS = jsonToken as JwtSecurityToken;

        var id = tokenS.Claims.First(claim => claim.Type == "Id").Value;
        var username = tokenS.Claims.First(claim => claim.Type == "Username").Value;
        var exp = tokenS.Claims.First(x => x.Type == "exp").Value;

        long expTimestamp = long.Parse(exp);

        DateTime d = UnixTimeStampToDateTime(expTimestamp);

        if (d < DateTime.Now)
        {
            SecureStorage.Default.Remove("token");
            return null;
        }

        return new User { Id = int.Parse(id), Token = token, Username = username };
    }

    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime;
    }
}
