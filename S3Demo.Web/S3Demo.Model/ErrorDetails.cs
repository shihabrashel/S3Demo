using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace S3Demo.Model
{
    public partial class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
