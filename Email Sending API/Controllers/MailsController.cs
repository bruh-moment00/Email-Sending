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

        [HttpGet]
        public async Task<ActionResult> GetStoredMessagesAsync()
        {
            try
            {
                IResult<IEnumerable<StoredMessageView>> getStoredMessages = await _messageService.GetStoredMessagesViewAsync();

                JsonResult jsonResult;

                if (getStoredMessages.Ok)
                {
                    jsonResult = new JsonResult(Result.Success(getStoredMessages.Value));
                }
                else
                {
                    jsonResult = new JsonResult(Result.Failure(getStoredMessages.Reason));
                }
                return jsonResult;
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
