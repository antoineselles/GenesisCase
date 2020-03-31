using System;
using ContactManagement.Contracts;
using ContactManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagement.Tests.Contacts
{
    [TestClass]
    public class When_creating_contact
    {
        private const string dummy = "dummy";
        private const string empty = "";

        public When_creating_contact()
        {
        }

        [TestMethod]
        public void With_no_address__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Contact(dummy, ContactType.Employee, empty, dummy, new Company()));
        }

        [TestMethod]
        public void With_no_company__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Contact(dummy, ContactType.Employee, dummy, dummy, null));
        }

        [TestMethod]
        public void With_freelance_type_and_no_vat__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Contact(dummy, ContactType.Freelance, dummy, empty, new Company()));
        }
    }
}