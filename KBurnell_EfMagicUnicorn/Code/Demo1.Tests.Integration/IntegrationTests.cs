using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Demo1.DataContext;
using Demo1.Domain;
using Demo1.Tests.Integration.DataContext;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo1.Tests.Integration {

    [TestClass]
    public class IntegrationTests {

        [TestMethod]
        public void All_Manufacturers_ShouldReturn_4_Manufacturers() {
            //Arrange
            Database.SetInitializer(new TestDataContextInitializer());
            Demo1DataContext _db = new Demo1DataContext();
            //Act
            IList<Manufacturer> result = _db.Manufacturers.ToList();
            //Assert
            result.Count().Should().Be(4);
        }
    }
}