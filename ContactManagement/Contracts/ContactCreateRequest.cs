namespace ContactManagement.Contracts
{
    public class ContactCreateRequest
    {
        public string Name { get; set; }
        public ContactType Type { get; set; }
        public string Vat { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
    }
}