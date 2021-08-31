using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Teledoro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramBotController : ControllerBase
    {
        private HttpClient client = new HttpClient();

        public TelegramBotController()
        {

        }
        
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.telegram.org/bot" + token + "/sendMessage"),
                Content = new StringContent(@"{
                                                  ""chat_id"": 5646908,
                                                  ""text"": ""hi, there""
                                              }", Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return Ok(response);
        }
    }
}