using System;
using ContactManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagement.Tests.Companies
{
    public class When_updating_company
    {
        private const string dummy = "dummy";
        private const string empty = "";
        private readonly Company _sutCompany;

        public When_updating_company()
        {
            _sutCompany = new Company(dummy, dummy, dummy);
        }

        [TestMethod]
        public void With_no_vat__Should_throw_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _sutCompany.Update(dummy, empty));
        }
    }
}