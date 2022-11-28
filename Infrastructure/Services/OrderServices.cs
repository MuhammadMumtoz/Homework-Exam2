using Npgsql;
using Dapper;

public class OrderService
{

    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Exam;User Id=postgres;Password=Muhammad.23;";
    public List<Order> GetOrders()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM orders order by id asc";
            var result = connection.Query<Order>(sql).ToList();
            return result;
        }
    }
    // public List<Order> GetAppleOrders()
    // {
    //     using (var connection = new NpgsqlConnection(_connectionString))
    //     {
    //         string sql = "select * from orders join products on orders.productid = products.id where products.company = 'Apple'";
    //         var result = connection.Query<Order>(sql).ToList();
    //         return result;
    //     }
    // }
    // public List<Order> GetOrdersMoreThan1000()
    // {
    //     using (var connection = new NpgsqlConnection(_connectionString))
    //     {
    //         string sql = "select orders.id, products.productname from orders join products on orders.productid = products.id where orders.price>1000";
    //         var result = connection.Query<Order>(sql).ToList();
    //         return result;
    //     }
    // }
    // public List<Order> GetCustomerOrders()
    // {
    //     using (var connection = new NpgsqlConnection(_connectionString))
    //     {
    //         string sql = "select customers.id, customers.firstname, Count(orders.customerid) from orders inner join customers on orders.customerid = customers.id group by customers.id order by customers.id ASC";
    //         var result = connection.Query<Order>(sql).ToList();
    //         return result;
    //     }
    // }

    public int InsertOrder(Order order)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into orders (productid,customerid,createdat,productcount,price) values ({order.ProductId},{order.CustomerId},'{order.CreatedAt}',{order.ProductCount},{order.Price})";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateOrder(Order order)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update orders Set productid = {order.ProductId}, customerid = {order.CustomerId}, createdat = '{order.CreatedAt}', productcount = {order.ProductCount}, price = {order.Price} where id = {order.Id}";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int DeleteOrder(int id){
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from orders where id = {id}";
            var result = connection.Execute(sql);
            return result;
        }
    }
}