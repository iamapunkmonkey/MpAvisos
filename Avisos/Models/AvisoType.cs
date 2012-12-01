using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Avisos.Models
{
    public enum AvisoType
    {
        [Display(Name = "Deadline")]
        Deadline = 0,

        [Display(Name = "Construction")]
        Construction = 1,

        [Display(Name = "Meeting")]   
        Meeting = 2,

        [Display(Name = "Event")]
        Event = 3,

        [Display(Name = "Environmental")]
        Environmental = 4,

        [Display(Name = "Crime")]
        Crime = 5,
    }


}