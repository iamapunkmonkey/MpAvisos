using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Avisos.Models
{
    public enum AvisoType
    {
        [Display(Name = "User name")]
        Deadline = 0,

        [Display(Name = "User name")]
        Construction = 1,

        [Display(Name = "User name")]   
        Meeting = 2,

        [Display(Name = "User name")]
        Event = 3,
    }


}