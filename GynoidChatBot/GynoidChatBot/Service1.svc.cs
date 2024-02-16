using System;
using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using GynoidChatBot;

namespace GynoidChatBot
{
    public class Service1 : IService1
    {
        public async Task<string> GetAnswer(string question)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://open-ai21.p.rapidapi.com/conversationgpt35"),     //api call
                Headers =
                {
                    { "X-RapidAPI-Key", "277b570845mshb255fcdf6a3ae0cp1f3520jsne2ea1e9409ce" }, // my api key
                    { "X-RapidAPI-Host", "open-ai21.p.rapidapi.com" },
                },
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    messages = new[]
                    {
                        new { role = "user", content = question }
                    },
                    web_access = false,
                    system_prompt = "",
                    temperature = 0.9,
                    top_k = 5,
                    top_p = 0.9,
                    max_tokens = 256
                }), System.Text.Encoding.UTF8, "application/json")
            };

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(body); // api deserialization happening and stored rsult in apiresponse.
                    return apiResponse.result;

                }
            }
            catch (Exception ex)
            {
                //error
                return $"Error: {ex.Message}";
            }
        }
    }


    //create apiResponse class to store json result after deserealization
    public class ApiResponse
    {
        public string result { get; set; }
    }
}
