using System;

namespace JZResgate.Domain.ApiModels
{
    public class RecoveryTruckResponse
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
