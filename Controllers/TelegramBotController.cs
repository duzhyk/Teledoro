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
        
        [HttpPost]
        public async Task<ActionResult> Post(string body)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.telegram.org/bot1973123977:AAEVZQJ8kLiLM482WX2ciwT4oG-p3mI9SeM/sendMessage"),
                Content = new StringContent(@"{
                                                  ""chat_id"": 5646908,
                                                  ""text"": ""hi, there""
                                              }", Encoding.UTF8)
            };

            var response = await client.SendAsync(request);

            return Ok(response);
        }
    }
}