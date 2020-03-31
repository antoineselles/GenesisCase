using System;
using ContactManagement.Contracts;
using ContactManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagement.Tests.Contacts
{
    [TestClass]
    public class When_updating_contact
    {
        private const string dummy = "dummy";
        private const string empty = "";

        private readonly Contact _sutContact;

        public When_updating_contact()
        {
            _sutContact = new Contact(dummy, ContactType.Employee, dummy, dummy, new Company());
        }

        [TestMethod]
        public void With_no_address__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => _sutContact.Update(dummy, empty, ContactType.Employee, dummy));
        }
        
        [TestMethod]
        public void With_freelance_type_and_no_vat__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => _sutContact.Update(dummy, dummy, ContactType.Freelance, empty));
        }
    }
}