namespace AiTech.WebUI.Services.GeminiServices;

public interface IGeminiService
{
    Task<String> GetGeminiDataAsync(string prompt);
}