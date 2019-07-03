using System.Globalization;
using WebApplicationForTesting.Models;

namespace WebApplicationForTesting.Services
{
    public interface IMessageService
    {
        string GetMessage(MessageTypeEnum messageTypeEnum, CultureInfo cultureInfo);
    }
}