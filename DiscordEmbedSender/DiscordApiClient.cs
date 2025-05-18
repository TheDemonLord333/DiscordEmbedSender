using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordEmbedSender
{
    public class DiscordApiClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl;

        public DiscordApiClient(string baseUrl)
        {
            this.baseUrl = baseUrl.TrimEnd('/');
            this.httpClient = new HttpClient();
            this.httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<List<Guild>> GetGuildsAsync()
        {
            try
            {
                string response = await httpClient.GetStringAsync($"{baseUrl}/api/guilds");
                return JsonConvert.DeserializeObject<List<Guild>>(response) ?? new List<Guild>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Abrufen der Server: {ex.Message}", ex);
            }
        }

        public async Task<List<Channel>> GetChannelsAsync(string guildId)
        {
            try
            {
                string response = await httpClient.GetStringAsync($"{baseUrl}/api/channels/{guildId}");
                return JsonConvert.DeserializeObject<List<Channel>>(response) ?? new List<Channel>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Abrufen der Kanäle: {ex.Message}", ex);
            }
        }

        public async Task<List<User>> SearchUsersAsync(string query)
        {
            try
            {
                string encodedQuery = Uri.EscapeDataString(query);
                string response = await httpClient.GetStringAsync($"{baseUrl}/api/users/search/{encodedQuery}");
                return JsonConvert.DeserializeObject<List<User>>(response) ?? new List<User>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Suchen der Nutzer: {ex.Message}", ex);
            }
        }

        public async Task<bool> SendEmbedAsync(string targetId, string type, Dictionary<string, object> embed)
        {
            try
            {
                var payload = new
                {
                    channelId = type == "channel" ? targetId : null,
                    userId = type == "dm" ? targetId : null,
                    embed = embed,
                    type = type
                };

                string json = JsonConvert.SerializeObject(payload, Newtonsoft.Json.Formatting.Indented);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{baseUrl}/api/send-embed", content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ApiErrorResponse>(errorContent);
                    throw new Exception(errorResponse?.Error ?? $"HTTP {response.StatusCode}: {errorContent}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Senden des Embeds: {ex.Message}", ex);
            }
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var response = await httpClient.GetAsync($"{baseUrl}/api/guilds");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }

        // Internal API response models
        private class ApiErrorResponse
        {
            public string Error { get; set; }
        }
    }
}