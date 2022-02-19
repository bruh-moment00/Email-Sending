using Email_Sending_API.Domain.StoredMessages.Models;
using Email_Sending_API.Domain.StoredMessages.Services.Interfaces;
using Jane;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Sending_API.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        IMessageService _messageService;

        public MailsController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Метод для получения отправленных сообщений из базы данных
        /// </summary>
        /// <returns>Возвращает результат в формате Json</returns>
        [HttpGet]
        public async Task<ActionResult> GetStoredMessagesAsync()
        {
            IResult<IEnumerable<StoredMessageView>> getStoredMessagesResult = await _messageService.GetStoredMessagesViewAsync();

            JsonResult jsonResult;

            if (getStoredMessagesResult.Ok)
            {
                jsonResult = new JsonResult(getStoredMessagesResult.Value);
            }
            else
            {
                jsonResult = new JsonResult(getStoredMessagesResult.Reason);
            }
            return jsonResult;
        }

        /// <summary>
        /// Метод для отправки сообщений
        /// </summary>
        /// <param name="queryMessage">Данные о сообщении</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SendAndSaveMessageAsync([FromBody]QueryMessage queryMessage)
        {
            IResult sendMessageResult = await _messageService.SendAndSaveMultipleMessagesAsync(queryMessage);

            JsonResult jsonResult;

            if (sendMessageResult.Ok)
            {
                jsonResult = new JsonResult(sendMessageResult.Ok);
            }
            else
            {
                jsonResult = new JsonResult(sendMessageResult.Reason);
            }
            return jsonResult;
        }
    }
}
