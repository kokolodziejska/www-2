using Microsoft.AspNetCore.Http;
using System.Text.Json;

public static class SessionExtensions
{
    // Serializacja obiektu do JSON i zapisanie go w sesji
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    // Deserializacja obiektu z JSON zapisanym w sesji
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
    }
}
