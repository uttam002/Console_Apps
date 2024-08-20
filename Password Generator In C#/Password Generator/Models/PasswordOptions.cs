using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorApp.Models
{
    public class PasswordOptions
    {
        public int Length { get; set; }
        public bool IncludeLowercase { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeDigits { get; set; }
        public bool IncludeSpecial { get; set; }
        public bool ExcludeSimilar { get; set; }
        public bool EnforceComplexity { get; set; }
    }
}

