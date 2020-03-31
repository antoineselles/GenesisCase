using System;
using ContactManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagement.Tests.Companies
{
    [TestClass]
    public class When_updating_company_address
    {
        private const string dummy = "dummy";
        private const string empty = "";
        private readonly Company _sutCompany;

        public When_updating_company_address()
        {
            _sutCompany = new Company(dummy, dummy, dummy);
        }

        [TestMethod]
        public void With_removing_headQuarter_flag__Should_throw_InvalidOperationException()
        {
            var sutAddressId = _sutCompany.Addresses[0].Id;

            Assert.ThrowsException<InvalidOperationException>(() => _sutCompany.UpdateAddress(sutAddressId, dummy, false));
        }

        [TestMethod]
        public void With_setting_headQuarter_flag_true__Should_set_reset_flag()
        {
            _sutCompany.AddAddress(dummy, false);

            var sutAddressId = _sutCompany.Addresses[1].Id;

            _sutCompany.UpdateAddress(sutAddressId, dummy, true);

            Assert.IsFalse(_sutCompany.Addresses[0].IsHQ);
            Assert.IsTrue(_sutCompany.Addresses[1].IsHQ);
        }
    }
}