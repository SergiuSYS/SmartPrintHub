public class Order
{
    public string Name { get; set; }
    public string ObjectName { get; set; }
    public float Weight { get; set; }
    public string PrinterTypename { get; set; }
    public string Destination { get; set; }
    public float Price { get; set; }

    public Order() { }

    public Order(string name, string objectName, float weight, string printerType, string destination, float price)
    {
        Name = name;
        ObjectName = objectName;
        Weight = weight;
        PrinterTypename = printerType;
        Destination = destination;
        Price = price;
    }
}
