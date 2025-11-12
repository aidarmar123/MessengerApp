using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Messenger.Desktop.Services;

public static class NetManager
{
    private static readonly HttpClient HttpClient = new();
    private static readonly string Url = "";

    public static async Task<T?> Get<T>(string path)
    {
        var response = await HttpClient.GetAsync(Url + path);
        var responseString = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<T>(responseString);
        return data;
    }
public static async Task<T?> Auth<T>(string path)
    {
        var response = await HttpClient.GetAsync(Url + path);
        var responseString = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<T>(responseString);
        return data;
    }

    
    public static async Task<A?> Post<A, T>(string path, T data)
    {
        var jsonData =  JsonSerializer.Serialize(data, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        
        var response = await HttpClient.PostAsync(Url + path, new StringContent(jsonData, Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<A>(responseString);
    }
}
