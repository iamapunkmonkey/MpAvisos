using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avisos.Models
{
    public class Aviso
    {
        public int AvisoID { get; set; }

        public AvisoType Type { get; set; }

        public string Text { get; set; }

        public DateTime Publish { get; set; }

        public DateTime Created { get; set; }
    }
}