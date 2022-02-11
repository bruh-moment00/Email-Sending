using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Enums
{
    public enum ResultEnum
    {
        [Display(Name = "OK")]
        OK = 0,

        [Display(Name ="Failed")]
        Failed = 1
    }
}
