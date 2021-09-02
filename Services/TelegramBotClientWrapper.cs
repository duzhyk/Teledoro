using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teledoro.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Teledoro.Services
{
    public class TelegramBotClientWrapper : ITelegramBotClientWrapper
    {
        private TelegramBotClient client;
        public TelegramBotClientWrapper()
        {
        }
        public async Task ReceiveUpdate(string token, string bodyContent)
        {
            if (client == null)
            {
                client = new TelegramBotClient(token);
                if (!await client.TestApiAsync())
                    throw new Exception("Token is not valid!");
            }

            var update = JsonConvert.DeserializeObject<Update>(bodyContent);
            var chatId = update.Message.Chat.Id;

            await client.SendTextMessageAsync(chatId, update.Message.Text);

        }
    }
}