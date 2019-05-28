using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace entityFrameworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private OrderContext OrderContext { get; set; }

        public TaskController(OrderContext orderContext)
        {
            OrderContext = orderContext;
        }

        // GET api/task
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("taskTwo")]
        public void TaskTwo([FromBody] TaskThreeSubtaskTwoModel model)
        {
            using (var transaction = OrderContext.Database.BeginTransaction())
            {
                try
                {
                    model.ProductIds = new List<int>() { 3, 5, 1, 6 };
                    model.ProductCount = new List<int>() { 15, 2, 6, 10 };

                    License tempLicense = new License()
                    {
                        CreatedBy = model.CreatedBy,
                        CustomerId = model.CustomerId,
                    };

                    Customer tempCustomer = OrderContext.Customers.
                        SingleOrDefault(c => c.ID == model.CustomerId);

                    if (tempCustomer.LicenseId == null)
                    {
                        tempCustomer.License = tempLicense;
                        tempCustomer.LicenseId = tempLicense.ID;

                        OrderContext.Entry(tempCustomer).State = EntityState.Modified;
                    }
                    else
                    {
                        License license = OrderContext.Licenses.
                            SingleOrDefault(l => l.ID == tempCustomer.LicenseId);

                        license.CustomerId = tempCustomer.ID;
                        license.CreatedBy = model.CreatedBy;

                        OrderContext.Entry(license).State = EntityState.Modified;
                    }

                    Order tempOrder = new Order()
                    {
                        Customer = tempCustomer,
                    };
                    List<ProductOrder> productOrders = new List<ProductOrder>();

                    for (int i = 0; i < model.ProductIds.Count; i++)
                    {
                        productOrders.Add(new ProductOrder()
                        {
                            Order = tempOrder,
                            Product = OrderContext.Products.
                            SingleOrDefault(p => p.ID == model.ProductIds[i]),
                            Amount = model.ProductCount[i]
                        });
                    }

                    tempOrder.ProductOrders = productOrders;

                    OrderContext.Orders.Add(tempOrder);
                    OrderContext.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        [HttpPost]
        [Route("taskOne")]
        public string TaskOne(string CustomerId)
        {
            var sqlCommand = "EXEC TotalPriceProcedure @CustomerId, @result OUT";

            var customerIdParameter = new SqlParameter
            {
                ParameterName = "@CustomerId",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = Int32.Parse(CustomerId)
            };

            var resultParameter = new SqlParameter
            {
                ParameterName = "@result",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output,
            };

            OrderContext.Database.ExecuteSqlCommand(sqlCommand, customerIdParameter, resultParameter);

            return resultParameter.Value.ToString();
        }

        [HttpPost]
        [Route("taskThree")]
        public List<string> TaskThree()
        {
            var result = (from customers in OrderContext.Customers
                          join orders in OrderContext.Orders on customers.ID equals orders.CustomerID
                          join po in OrderContext.ProductOrders on orders.ID equals po.OrderID
                          join products in OrderContext.Products on po.ProductID equals products.ID
                          select new { CustomerName = customers.Name, ProductName = products.Name }).
                          Distinct().ToList();

            var resultList = new List<string>();

            for (int i = 0; i < result.Count; i++)
            {
                resultList.Add(result[i].CustomerName + " - " + result[i].ProductName);
            }

            return resultList;
        }

        [HttpPost]
        [Route("taskFour")]
        public List<string> TaskFour()
        {
            var result = (from customers in OrderContext.Customers
                         join license in OrderContext.Licenses on customers.LicenseId equals license.ID
                         where customers.LicenseId.HasValue == true
                         select new { CustomerName = customers.Name, license.CreatedBy }).ToList();

            var resultList = new List<string>();

            for (int i = 0; i < result.Count; i++)
            {
                resultList.Add(result[i].CustomerName + " - " + result[i].CreatedBy);
            }

            return resultList;
        }

        [HttpPost]
        [Route("taskFive")]
        public List<string> TaskFive()
        {
            var result = (from customers in OrderContext.Customers
                          join orders in OrderContext.Orders on customers.ID equals orders.CustomerID into co
                          from orders in co.DefaultIfEmpty()
                          select new { customers.Location, OrderId = orders == null ? 0 : orders.ID }
                          ).GroupBy(c => c.Location).ToList();

            var resultList = new List<string>();

            foreach (var group in result)
            {
                resultList.Add(group.Key + " - " + group.Where(v => v.OrderId != 0).Count());
            }

            return resultList;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
