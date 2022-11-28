using Npgsql;
using Dapper;

public class ProductService
{

    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Exam;User Id=postgres;Password=Muhammad.23;";
    public List<Product> GetProducts()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM products order by id asc";
            var result = connection.Query<Product>(sql).ToList();
            return result;
        }
    }

    public int InsertProduct(Product product)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into products (productname,company,productcount,price) values ('{product.ProductName}','{product.Company}',{product.ProductCount},{product.Price} where )";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateProduct(Product product)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update products Set productname = '{product.ProductName}', company = '{product.Company}', productcount = {product.ProductCount}, price = {product.Price} where id = {product.Id}";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int DeleteProduct(int id){
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from products where id = {id}";
            var result = connection.Execute(sql);
            return result;
        }
    }
}