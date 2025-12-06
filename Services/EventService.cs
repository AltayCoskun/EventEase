using EventEase.Models;
using System.Text.Json;

namespace EventEase.Services;

public class EventService
{
    private readonly HttpClient _httpClient;
    private List<Event>? _events;

    public EventService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Event>> GetEventsAsync()
    {
        if (_events == null)
        {
            var response = await _httpClient.GetAsync("Data/events.json");
            var json = await response.Content.ReadAsStringAsync();
            _events = JsonSerializer.Deserialize<List<Event>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Event>();
        }
        return _events;
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        var events = await GetEventsAsync();
        return events.FirstOrDefault(e => e.Id == id);
    }

    public async Task<List<Event>> GetEventsByCategoryAsync(string category)
    {
        var events = await GetEventsAsync();
        return events.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
