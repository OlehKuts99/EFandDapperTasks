using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Models;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class TestExample : IClassFixture<DbFixture>
    {
        private readonly OrderContext context;

        public TestExample(DbFixture fixture)
        {
            context = fixture.ServiceProvider.GetService<OrderContext>();
        }

        [Fact]
        public void TestAdd()
        {
            context.Database.EnsureCreated();

            context.Licenses.Add(new Persistence.Models.License { ID = Guid.NewGuid(), CreatedBy = "Me" });
            context.SaveChanges();

            Assert.Equal(1, context.Licenses.Count());
        }

        [Fact]
        public void TestConnectionOrderWithCustomerInsert()
        {
            context.Database.EnsureCreated();

            Customer tempCustomer = new Customer() { License = null, Name = "Oleh Kuts", Location = "Lviv" };
            context.Orders.Add(new Order { Customer = tempCustomer });
            context.SaveChanges();

            Assert.Equal(1, context.Customers.Count());
        }

        [Fact]
        public void TestConnectionOrderWithCustomerDelete()
        {
            context.Database.EnsureCreated();

            Customer tempCustomer = new Customer() { License = null, Name = "Oleh Kuts", Location = "Lviv" };
            context.Orders.Add(new Order { Customer = tempCustomer });
            context.SaveChanges();

            context.Customers.Remove(context.Customers.First());
            context.SaveChanges();

            Assert.Equal(0, context.Orders.Count());
        }

        [Fact]
        public void DeleteCustomerFromDataBase()
        {
            context.Database.EnsureCreated();

            Customer tempCustomer = new Customer() { License = null, Name = "Oleh Kuts", Location = "Lviv" };
            context.Customers.Add(tempCustomer);
            context.SaveChanges();

            context.Customers.Remove(context.Customers.First());
            context.SaveChanges();

            Assert.Equal(0, context.Customers.Count());
        }

        [Fact]
        public void UpdateNameOfCutomer()
        {
            context.Database.EnsureCreated();

            Customer tempCustomer = new Customer() { License = null, Name = "Oleh Kuts", Location = "Lviv" };
            string oldName = tempCustomer.Name;
            context.Customers.Add(tempCustomer);
            context.SaveChanges();

            Customer updatedCustomer = context.Customers.First();
            updatedCustomer.Name = "Test Test";
            context.Entry(updatedCustomer).State = EntityState.Modified;
            context.SaveChanges();

            Assert.NotEqual(oldName, updatedCustomer.Name);
        }
    }
}
