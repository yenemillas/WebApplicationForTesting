using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForTesting.Models;
using WebApplicationForTesting.Resources;

namespace WebApplicationForTesting.Services
{
    public class MessageService : IMessageService
    {

        private readonly LocService _locService;
        public MessageService(LocService locService)
        {
            _locService = locService;
        }

        /// <summary>
        /// Methode pour les tests unitaire
        /// </summary>
        /// <param name="messageTypeEnum"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string GetMessage(MessageTypeEnum messageTypeEnum, CultureInfo cultureInfo)
        {
            switch (messageTypeEnum)
            {
                case MessageTypeEnum.Type1:
                    return $"Message Type 1 : {_locService.GetLocalized("Type1Message", cultureInfo)}";
                case MessageTypeEnum.Type2:
                    return $"Message Type 2 : {_locService.GetLocalized("Type1Message", cultureInfo)}";
                case MessageTypeEnum.Type3:
                    return $"Message Type 2 : {_locService.GetLocalized("Type1Message", cultureInfo)}";
                default:
                    return string.Empty;
            }
        }
    }
}
