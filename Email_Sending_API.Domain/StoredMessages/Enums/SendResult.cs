using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Enums
{
    public enum SendResult
    {
        [Display(Name = "Failed")]
        Failed = 0,

        [Display(Name = "OK")]
        OK = 1
    }
}
