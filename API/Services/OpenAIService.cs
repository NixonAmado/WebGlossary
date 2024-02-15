using System.Text;
using API.Dtos;
using API.Helpers;
using Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace API.Services;
public class OpenAIService : IOpenAIService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OpenAi _openAiConfiguration;
    private  HttpClient _httpClient;
    public OpenAIService(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IOptions<OpenAi> openAiConfiguration)
    {
        _unitOfWork = unitOfWork;
        _httpClientFactory = httpClientFactory;
        _openAiConfiguration = openAiConfiguration.Value;
        InitializeHtpCLient();
    }

    private void InitializeHtpCLient()
    {
        _httpClient = _httpClientFactory.CreateClient("OpenAiApiClient");
        _httpClient.BaseAddress = new Uri(_openAiConfiguration.ApiUrl);
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
        _httpClient.DefaultRequestHeaders.Add("Usser-Agent", "MiApp/1.0 (Windows; U; Windows NT 10.0; en-US; rv:1.8.1.6)");
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
