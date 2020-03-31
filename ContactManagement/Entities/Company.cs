using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContactManagement.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public List<CompanyAddress> Addresses { get; set; } = new List<CompanyAddress>();
        public string Vat { get; set; }

        public Company()
        {
        }

        public Company(string name, string address, string vat)
        {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(address);
            if (string.IsNullOrWhiteSpace(vat)) throw new ArgumentNullException(vat);

            Name = name;
            Vat = vat;
            Addresses.Add(CompanyAddress.HeadQuarter(address));
        }

        public void Update(string name, string vat)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(vat)) throw new ArgumentNullException(nameof(vat));

            Name = name;
            Vat = vat;
        }

        public void AddAddress(string value, bool isHQ)
        {
            MaybeResetHeadQuartersFlag(isHQ);

            var address = isHQ ? CompanyAddress.HeadQuarter(value) : CompanyAddress.Subsidiary(value);

            Addresses.Add(address);
        }

        public void UpdateAddress(string addressId, string value, bool isHQ)
        {
            MaybeResetHeadQuartersFlag(isHQ);

            var address = Addresses.Single(a => a.Id == addressId);

            if (address.IsHQ && !isHQ) throw new InvalidOperationException();

            address.Value = value;

            address.IsHQ = isHQ;
        }

        private void MaybeResetHeadQuartersFlag(bool flag)
        {
            if (!flag) return;

            foreach (var item in Addresses)
            {
                item.IsHQ = false;
            }
        }

        public bool HasAddress(string addressId)
        {
            return Addresses.Any(a => a.Id == addressId);
        }
    }
}