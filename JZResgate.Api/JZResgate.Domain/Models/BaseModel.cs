using System;
using System.ComponentModel.DataAnnotations;

namespace JZResgate.Domain.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
