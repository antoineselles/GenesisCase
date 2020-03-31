using ContactManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagement.Tests.Companies
{
    [TestClass]
    public class When_adding_company_address
    {
        private const string dummy = "dummy";
        private readonly Company _sutCompany;

        public When_adding_company_address()
        {
            _sutCompany = new Company(dummy, dummy, dummy);
        }
        
        [TestMethod]
        public void When_adding_a_headQuarter_address__Should_add_it_and_reset_previous_one()
        {
            _sutCompany.AddAddress(dummy, true);
            Assert.AreEqual(2, _sutCompany.Addresses.Count);
            Assert.IsFalse(_sutCompany.Addresses[0].IsHQ);
            Assert.IsTrue(_sutCompany.Addresses[1].IsHQ);
        }
    }
}