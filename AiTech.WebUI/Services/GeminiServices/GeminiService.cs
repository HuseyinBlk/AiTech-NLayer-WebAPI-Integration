using System.Text;
using AiTech.WebUI.DTOs.GeminiDtos;
using Newtonsoft.Json;

namespace AiTech.WebUI.Services.GeminiServices;

public class GeminiService : IGeminiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string Model = "gemini-3.5-flash";
    private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/";

    public GeminiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Gemini:ApiKey"];
    }
    
    public async Task<string> GetGeminiDataAsync(string prompt)
    {
        var requestBody = new GeminiRequestDto
        {
            contents = new List<Content>
            {
                new Content
                {
                    role = "user",
                    parts = new List<Part>
                    {
                        new Part
                        {
                            text = prompt
                        }
                    }
                }
            },
            generationConfig = new GenerationConfig
            {
                temperature = 0.7f,
                maxOutputTokens = 1000
            }
        };
        var jsonContent = JsonConvert.SerializeObject(requestBody);
        var httpContent = new StringContent(jsonContent,Encoding.UTF8, "application/json");
        
        var url = $"{BaseUrl}{Model}:generateContent?key={_apiKey}";
        
        var response = await _httpClient.PostAsync(url, httpContent);

        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }
        
        var responseString = await response.Content.ReadAsStringAsync();
        var geminiResponse = JsonConvert.DeserializeObject<GeminiResponseDto>(responseString);

        var candidate = geminiResponse?.Candidates?.FirstOrDefault();
        var resultText = candidate?.Content?.parts != null
            ? string.Join("", candidate.Content.parts.Select(p => p.text))
            : "Yanıt alınamadı.";

        return resultText;

    }
}