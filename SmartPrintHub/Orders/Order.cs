public class Order
{
    public string Name { get; private set; }
    public string ObjectName { get; private set; }
    public float weight { get; private set; }
    public string PrinterTypename { get; private set; }
    public string destination { get; private set; }
    public float price { get; private set; }
    public Order(string name,string objectName, float weight,string printerType, string destination, float price)
    {
        Name = name;
        PrinterTypename = printerType;
        ObjectName = objectName;
        this.weight = weight;
        this.destination = destination;
        this.price = price;
    }
}
