public class ResinPrinter : Printer
{
    public ResinPrinter(string brand)
    {
        this.brand = brand;
        this.TipImprimanta = "Resin";
        this.MaterialCapacity = 0;
    }

    public override void Refil()
    {
        MaterialCapacity = 1500;
    }
}