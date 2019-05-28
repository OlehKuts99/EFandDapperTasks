Tasks:
1. Change models according to schema.png
    
    Customers
    - Location max size 20 characters
    - LicenseId nullable

    Orders
    - Status in Order should be string in db table
    - LastChanged date prop - shadow property 
    - CreatedDate should have default value current date

2. Create migration and apply it on db. Apply script with test data TestDataScript.sql.

3. Create methods:
    - create stored procedure for recalculating Total Prices for specific cutomerID. You need to recalculate only created orders. Input param CutomerID as output param return total price of all created orders.
    - get Customer Name and License CreateBy in Lviv. Do not show customer without license
    - get Customer Name, Order Id and total amount of products
    - get count of orders in each location.(even if no orders in location)
    - get unique list of ordered product for each customer.
    - input model: CustomerId, LicenseId, License CreatedBy, List of product ids and count (create your own model)
        - add new license for customer
        - fill all needed tables 
        - use transaction
4. Repeat previous step with using Dapper.
5. Take a look at UnitTests project and add couple of test