using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

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
        public async Task<ActionResult> Post(string token, Update update)
        {
            var client = new TelegramBotClient(token);
            var response = await client.SendTextMessageAsync(5646908, "msg from tg bot client");
            
            //var sr = new StreamReader(Request.Body);
            //var requestContent =  await sr.ReadToEndAsync();
//
            //var request = new HttpRequestMessage()
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://api.telegram.org/bot" + token + "/sendMessage"),
            //    Content = new StringContent(@"{
            //                                      ""chat_id"": 5646908,
            //                                      ""text"": ""hi, there " + requestContent + @" ""
            //                                  }", Encoding.UTF8, "application/json")
            //};
//
            //var response = await client.SendAsync(request).ConfigureAwait(false);
            //response.EnsureSuccessStatusCode();

            return Ok(update);
        }
    }
}