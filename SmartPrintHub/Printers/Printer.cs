public abstract class Printer
{
    CalculatePrice calculatePrice = new CalculatePrice();
    public string brand { get; set; }
    public string TipImprimanta { get; set; }
    public float MaterialCapacity { get; set; }
    public bool isAvalible = true;
    public abstract void Refil();
    public bool Print(float Material)
    {
        if(Material > MaterialCapacity)
        {
            return false;
        }
        MaterialCapacity -= Material;
        return true;
        isAvalible = true;
    }
    public float getOrder(Order order)
    {
        return calculatePrice.Calculate(order.weight,order.PrinterTypename);
    }
}