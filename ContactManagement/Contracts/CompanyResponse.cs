using System.Collections.Generic;

namespace ContactManagement.Contracts
{
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CompanyAddressResponse> Addresses { get; set; }
        public string Vat { get; set; }
    }
}