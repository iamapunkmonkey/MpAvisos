﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Spatial;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Avisos.Models
{
    public class Aviso
    {

        public Aviso()
        {
            AvisoTypeSelectList = Enum.GetNames(typeof(AvisoType)).Select(name => new SelectListItem()
            {
                Text = name,
                Value =name
            });
        }

        public IEnumerable<SelectListItem> AvisoTypeSelectList { get; set; }

        public int AvisoID { get; set; }

        public AvisoType Type { get; set; }

        [Required]
        [StringLength(140, ErrorMessage = "Text is required and must be less than 140 chracters")]
        public string Text { get; set; }

        public DbGeography Location { get; set; }

        public DateTime Publish { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }

        public bool SendSMS { get; set; }

        //public bool Nothing { get; set; }
 
    }
}