using Grosvenor.Restaurant.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grosvenor.Restaurant.DomainTests.Services
{
    [TestClass()]
    public class WaiterServiceTests
    {
        [TestMethod()]
        public void WhenIAskWithCaseSensitiveInput()
        {
            Assert.AreEqual(
                new WaiterService().ProcessClientOrder("morning, 1, 2, 3"),
                "Eggs, Toast, Coffee");
        }

        [TestMethod()]
        public void WhenIChangeAOrderOfTheOrder()
        {
            Assert.AreEqual(
                new WaiterService().ProcessClientOrder("morning, 2, 1, 3"),
                "Eggs, Toast, Coffee");
        }
        
        [TestMethod()]
        public void WhenIAskForADesertInTheMorning()
        {
            Assert.AreEqual(
                new WaiterService().ProcessClientOrder("morning, 1, 2, 3, 4"),
                "Eggs, Toast, Coffee, error");
        }
    }
}