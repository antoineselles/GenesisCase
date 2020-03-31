using System.Collections.Generic;

namespace ContactManagement.Contracts
{
    public class ContactResponse
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Vat { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<CompanyResponse> Companies { get; set; }
    }
}