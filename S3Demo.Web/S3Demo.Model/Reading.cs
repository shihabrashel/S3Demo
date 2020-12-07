using System;
using System.Collections.Generic;
using System.Text;

namespace S3Demo.Model
{
    public partial class Reading
    {
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
