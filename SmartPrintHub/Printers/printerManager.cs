public class printerManager
{
    public List<Printer> printers = new List<Printer>();

    public void GetOrderFromOrdermanager(Order order)
    {

    }
    private int FindeAvaliblePrinter(string Type,float material)
    {
        foreach (Printer printer in printers) 
        {
            int i = 0;
            if(printer.TipImprimanta == Type && material < printer.MaterialCapacity)
            {
                i++;
                return i;
            }            
        }
        return -1;
    }
}