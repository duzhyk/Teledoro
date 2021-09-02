using System.Threading.Tasks;

namespace Teledoro.Interfaces
{
    public interface ITelegramBotClientWrapper
    {
        Task ReceiveUpdate(string token, string update);
    }
}