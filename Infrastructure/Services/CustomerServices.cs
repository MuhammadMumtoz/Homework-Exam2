using Npgsql;
using Dapper;

public class CustomerService
{

    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Exam;User Id=postgres;Password=Muhammad.23;";
    public List<Customer> GetCustomers()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM customers order by id asc";
            var result = connection.Query<Customer>(sql).ToList();
            return result;
        }
    }

    public int InsertCustomer(Customer customer)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into customers (firstname) values ('{customer.FirstName}')";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateCustomer(Customer customer)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update customers Set firstname = '{customer.FirstName}' where id = {customer.Id}";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int DeleteCustomer(int id){
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from customers where id = {id}";
            var result = connection.Execute(sql);
            return result;
        }
    }
}