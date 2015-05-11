using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6_Beta_Demo.DataContext;
using EF6_Beta_Demo.Models;
using EF6_Beta_Demo.Services;
using FluentAssertions;
using NUnit.Framework;
using Rhino.Mocks;

namespace EF6_Beta_Demo_Tests_Unit
{
    public class ManufacturerServiceTests
    {
        [Test]
        public void GetAll_ShouldReturnAll_Manufacturers_SortedBy_Name() {
            //Arrange
            MockRepository mockRepo = new MockRepository();
            var manufacturers = new List<Manufacturer> {
                new Manufacturer {Name = "ZZZZ"},
                new Manufacturer {Name = "AAAA"},
                new Manufacturer {Name = "CCCC"}
            }.AsQueryable();
            var contextMock = mockRepo.StrictMock<EF6DemoDataContext>();
            var dbSetMock = mockRepo.StrictMock<MockableDbSet<Manufacturer>>();
            contextMock.Expect(x => x.Manufacturers).Return(dbSetMock);
            dbSetMock.Expect(x => x.Provider).Return(manufacturers.Provider);
            dbSetMock.Expect(x => x.Expression).Return(manufacturers.Expression);
            mockRepo.ReplayAll();
            var service = new ManufacturerService(contextMock);
            //Act
            var result = service.GetAll();
            //Assert
            mockRepo.VerifyAll();
            result.Count.Should().Be(3);
            result[0].Name.Should().Be("AAAA");
            result[1].Name.Should().Be("CCCC");
            result[2].Name.Should().Be("ZZZZ");
        }
    }
}
