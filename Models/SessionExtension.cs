using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace BotanicalDB.Models
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            string json = session.GetString(key);
            T t;
            if (string.IsNullOrEmpty(json))
            {
                t = default(T);
            }
            else
            {
                t = JsonSerializer.Deserialize<T>(json);
            }
            return t;
        }
    }
}
