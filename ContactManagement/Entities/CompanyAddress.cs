using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Entities
{
    public class CompanyAddress
    {
        [Required]
        public string Id { get; set; }
        public bool IsHQ { get; set; }
        public string Value { get; set; }
        
        public static CompanyAddress HeadQuarter(string value) => new CompanyAddress { Id = Guid.NewGuid().ToString(), IsHQ = true, Value = value };
        
        public static CompanyAddress Subsidiary(string value) => new CompanyAddress { Id = Guid.NewGuid().ToString(), Value = value };
    }
}