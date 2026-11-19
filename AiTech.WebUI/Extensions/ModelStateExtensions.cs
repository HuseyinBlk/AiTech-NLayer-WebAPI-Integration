using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AiTech.WebUI.Extensions;

public static class ModelStateExtensions
{
    public static async Task AddModelErrorsAsync(this ModelStateDictionary modelState, HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

            if (problemDetails?.Errors != null)
            {
                foreach (var (key, messages) in problemDetails.Errors)
                {
                    foreach (var message in messages)
                    {
                        modelState.AddModelError(key, message);
                    }
                }
            }
        }
    }
}