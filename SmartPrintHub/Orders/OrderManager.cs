using System.Text.Json;

public class OrderManager
{
    private List<Order> orders = new List<Order>();
    public void AddOrder(Order order)
    {
        orders.Add(order);
    }
    public Order getOrder()
    {
        Order temp = orders[orders.Count()-1];
        if (orders.Count() > 0)
        {
            orders.RemoveAt(orders.Count() - 1);
            return temp;
        }
        return null;
    }
    public void LoadFromJson()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        string jsonString = File.ReadAllText("orders.json");
        orders = JsonSerializer.Deserialize<List<Order>>(jsonString, options);
    }

    public void SaveToJson()
    {
        string jsonString = JsonSerializer.Serialize(orders);
        File.WriteAllText("orders.json", jsonString);
    }

}