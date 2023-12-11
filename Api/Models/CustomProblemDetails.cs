using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models;

public class CustomProblemDetails
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("status")]
    public int? Status { get; set; }
    
    [JsonPropertyName("errors")]
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}