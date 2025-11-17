using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messenger.Desktop.Models;

namespace Messenger.Desktop.Services;

public class NetManager
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly string _url;

    public NetManager(HttpClient httpClient, string url)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = false
        };
        _url = url;
    }


    public async Task<T?> GetAsync<T>(string path)
    {
        var response = await _httpClient.GetAsync(_url + path);
        return await ReadResponseAsync<T>(response);
    }

    // ---- generic POST ----
    public async Task<T?> PostAsync<T>(string path, object body)
    {
        var json = new StringContent(
            JsonSerializer.Serialize(body, _jsonOptions),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync(_url + path, json);
        return await ReadResponseAsync<T>(response);
    }

    // ---- PUT ----
    public async Task<T?> PutAsync<T>(string path, object body)
    {
        var json = new StringContent(
            JsonSerializer.Serialize(body, _jsonOptions),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PutAsync(_url + path, json);
        return await ReadResponseAsync<T>(response);
    }

    // ---- DELETE ----
    public async Task<T?> DeleteAsync<T>(string path)
    {
        var response = await _httpClient.DeleteAsync(_url + path);
        return await ReadResponseAsync<T>(response);
    }

    // ---- Parse response ----
    private async Task<T?> ReadResponseAsync<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API error {response.StatusCode}: {content}");
        }

        return JsonSerializer.Deserialize<T>(content, _jsonOptions);
    }

    // ---- AUTH ----
    public async Task<bool> AuthorizeAsync(string login, string password)
    {
        var response = await PostAsync<GetToken>(
            "api/auth/login",
            new { login, password }
        );

        if (response?.Token != null)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", response.Token);

            return true;
        }

        return false;
    }
}
