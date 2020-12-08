using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationDemo.Models
{
    public class Reading
    {
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
