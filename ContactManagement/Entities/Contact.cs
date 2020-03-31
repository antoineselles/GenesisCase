using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContactManagement.Contracts;

namespace ContactManagement.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public ContactType Type { get; set; }
        public string Vat { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();

        public Contact()
        {
        }

        public Contact(string name, ContactType type, string address, string vat, Company company)
        {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));
            if (type == ContactType.Freelance && string.IsNullOrWhiteSpace(vat)) throw new ArgumentNullException(nameof(vat));
            if (company == null) throw new ArgumentNullException(nameof(company));

            Type = type;
            Vat = vat;
            Name = name;
            Address = address;
            Companies.Add(company);
        }

        public void Update(string name, string address, ContactType type, string vat)
        {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));
            if (type == ContactType.Freelance && string.IsNullOrWhiteSpace(vat)) throw new ArgumentNullException(nameof(vat));

            Type = type;
            Vat = vat;
            Name = name;
            Address = address;
        }
    }
}