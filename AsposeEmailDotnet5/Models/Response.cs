using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsposeEmailDotnet5.Models
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string FileName { get; set; }

        public override string ToString()
        {
            return $"{StatusCode}|{FileName}";
        }
    }
}
