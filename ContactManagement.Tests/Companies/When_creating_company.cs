using System;
using ContactManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagement.Tests.Companies
{
    [TestClass]
    public class When_creating_company
    {
        private const string dummy = "dummy";
        private const string empty = "";

        [TestMethod]
        public void With_no_address__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Company(dummy, empty, dummy));
        }

        [TestMethod]
        public void With_no_vat__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Company(dummy, dummy, empty));
        }

        [TestMethod]
        public void Should_create_company_with_headQuarterAddress()
        {
            var sutCompany = new Company(dummy, dummy, dummy);
            Assert.IsTrue(sutCompany.Addresses[0].IsHQ);
        }
    }
}