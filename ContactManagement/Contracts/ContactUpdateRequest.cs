namespace ContactManagement.Contracts
{
    public class ContactUpdateRequest
    {
        public string Name { get; set; }
        public ContactType Type { get; set; }
        public string Vat { get; set; }
        public string Address { get; set; }
    }
}