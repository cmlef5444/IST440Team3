using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST440Team3.Models
{
    public class Translation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string startLanguage { get; set; }
        public string endLanguage { get; set; }
    }
}
