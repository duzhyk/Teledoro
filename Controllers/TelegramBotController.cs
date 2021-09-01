using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Newtonsoft.Json;

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
            var client = new TelegramBotClient(token);
            
            using var sr = new StreamReader(Request.Body);
            var bodyContent =  await sr.ReadToEndAsync();
            var update = JsonConvert.DeserializeObject<Update>(bodyContent);

            var response = await client.SendTextMessageAsync(5646908, update.Message?.Text);

            return Ok();
        }
    }
}