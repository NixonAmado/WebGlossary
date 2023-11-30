using System.Text;
using API.Dtos;
using API.Helpers;
using Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace API.Services;
public class OpenAIService : IOpenAIService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpClient _httpClient;
    private readonly OpenAi _openAiConfiguration;

    public OpenAIService(IUnitOfWork unitOfWork, HttpClient httpClient, IOptions<OpenAi> openAiConfiguration)
    {
        _unitOfWork = unitOfWork;
        _httpClient = httpClient;
        _openAiConfiguration = openAiConfiguration.Value;
        _httpClient.BaseAddress = new Uri(_openAiConfiguration.ApiUrl);
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<string> DetermineWordFeatures(WordDto WordDto)
    {
        _httpClient.DefaultRequestHeaders.Add("Authorization",$"Bearer {_openAiConfiguration.ApiKey}");
        if(!string.IsNullOrEmpty(WordDto.Word))
        {
            var requestBody = new { WordDto.Word, prompt = "Que tipo de palabra es"};
            var requestBodyJson = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return responseJson;
            }
            else
            {
                return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            }
        }
        else
        {
            return "error";
        }
           
    }

    

}
