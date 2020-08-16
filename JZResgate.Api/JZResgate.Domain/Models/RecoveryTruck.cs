using System;
using System.Collections.Generic;
using System.Text;

namespace JZResgate.Domain.Models
{
    public class RecoveryTruck: BaseModel
    {
        public string Alias { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
