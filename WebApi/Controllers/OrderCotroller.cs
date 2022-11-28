using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrderController
{
    private OrderService _orderService;
    public OrderController()
    {
        _orderService = new OrderService();
    }

    [HttpGet("GetAllOrders")]
    public List<Order> GetOrders()
    {
        return _orderService.GetOrders();
    }
    [HttpGet("GetAppleOrders")]
    // public List<Order> GetAppleOrders()
    // {
    //     return _orderService.GetAppleOrders();
    // }
    // [HttpGet("GetOrdersMoreThan1000")]
    // public List<Order> GetOrdersMoreThan1000()
    // {
    //     return _orderService.GetOrdersMoreThan1000();
    // }
    // [HttpGet("GetCustomerOrders")]
    // public List<Order> GetCustomerOrders()
    // {
    //     return _orderService.GetCustomerOrders();
    // }


    [HttpPost("InstertOrder")]
    public int InsertOrder(Order order)
    {
        return _orderService.InsertOrder(order);
    }
    [HttpPut("UpdateOrder")]
    public int UpdateOrder(Order order)
    {
        return _orderService.UpdateOrder(order);
    }
    [HttpDelete("DeleteOrder")]
    public int DeleteOrders(int id)
    {
        return _orderService.DeleteOrder(id);
    }
}