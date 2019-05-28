using Dapper;
using DapperPersistence.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperPersistence
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _config;
        public DapperService(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("ConnectionString"));
            }
        }

        public Customer GetTopOneCustomer()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT top 1 * FROM Customers";
                conn.Open();
                var result = conn.QueryFirstOrDefault<Customer>(sQuery);
                return result;
            }
        }

        public string TaskOne(int CustomerId)
        {
            using (IDbConnection conn = Connection)
            {
                var sqlCommand = "TotalPriceProcedure";
                conn.Open();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@CustomerId", CustomerId);
                queryParameters.Add("@result", DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute(sqlCommand, queryParameters, null, null, CommandType.StoredProcedure);

                var resultParameter = queryParameters.Get<int>("result");

                return resultParameter.ToString();
            }
        }

        public void TaskTwo(TaskThreeSubtaskTwoModel model)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
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

                        string getCustomer = 
                            "SELECT * FROM Customers AS c WHERE c.ID = @CustomerID;";
                        Customer tempCustomer = connection.QueryFirst<Customer>(getCustomer, 
                            new { CustomerID = model.CustomerId });

                        if (tempCustomer.LicenseID == null)
                        {
                            string customerUpdate = "UPDATE Customers SET LicenseId = @LicenseId " +
                                "WHERE ID = @CustomerId";

                            connection.Execute(customerUpdate, new { CustomerId = tempCustomer.ID,
                                LicenseId = tempLicense.ID });
                        }
                        else
                        {
                            string licenseUpdate = "UPDATE Licenses SET CustomerId = @CustomerId, " +
                                "CreatedBy = @CreatedBy WHERE ID = @LicenseId";

                            connection.Execute(licenseUpdate, new { CustomerId = tempCustomer.ID,
                                model.CreatedBy, LicenseId = tempCustomer.LicenseID });
                        }

                        tempCustomer = connection.QueryFirst<Customer>(getCustomer,
                            new { CustomerID = model.CustomerId });

                        string insertOrder = "INSERT INTO Orders (Status, CustomerId) VALUES ('Created', @CustomerId)";
                        connection.Execute(insertOrder, new { CustomerId = tempCustomer.ID });

                        string getOrder =
                            "SELECT TOP 1 * FROM Orders ORDER BY ID DESC";
                        Order tempOrder = connection.QueryFirst<Order>(getOrder);

                        string insertProductOrder = "INSERT INTO ProductOrders (ProductID, OrderID, Amount) " +
                            "VALUES (@ProductID, @OrderID, @Amount)";

                        for (int i = 0; i < model.ProductIds.Count; i++)
                        {
                            connection.Execute(insertProductOrder, 
                                new { ProductID = model.ProductIds[i], OrderID = tempOrder.ID,
                                Amount = model.ProductCount[i]});
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public List<string> TaskFour()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();

                var sql = "SELECT * FROM Customers C INNER JOIN Licenses L on C.LicenseId = L.ID";
                var result = conn.Query<Customer, License, Customer>(sql,
                (c, l) => { c.License = l ; return c; }, splitOn: "LicenseId").ToList();

                var resultList = new List<string>();

                for (int i = 0; i < result.Count; i++)
                {
                    resultList.Add(result[i].Name + " - " + result[i].License.CreatedBy);
                }

                return resultList;
            }
        }

        public List<string> TaskFive()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();

                var sql = "SELECT * FROM Orders O LEFT OUTER JOIN Customers C on C.ID = O.CustomerId";

                var result = conn.Query<Order, Customer, Order>(sql,
                (o, c) => { o.Customer = c; return o; }, splitOn: "CustomerId").ToList();

                var groupedList = result.GroupBy(o => o.Customer.Location);

                var resultList = new List<string>();

                foreach (var group in groupedList)
                {
                    resultList.Add(group.Key + " - " + group.Where(v => v.ID != 0).Count());
                }

                return resultList;
            }
        }
    }
}
