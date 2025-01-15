public class FilamentPrinter : Printer
{
    public FilamentPrinter(string brand)
    {
        this.brand = brand;
        this.TipImprimanta = "Filament";
        this.MaterialCapacity = 0;
    }

    public override void Refil()
    {
        MaterialCapacity = 2000;
    }
}