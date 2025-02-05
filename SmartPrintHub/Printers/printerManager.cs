﻿public class PrinterManager
{
    public OrderManager orderManager;
    public List<Printer> printers = new List<Printer>();
    Printer Filamentprinter1 = new FilamentPrinter("SmartImprim");  
    Printer Filamentprinter2 = new FilamentPrinter("SmartImprim");
    Printer Resinprinter1 = new ResinPrinter("MyResinPrinter");
    Printer Resinprinter2 = new ResinPrinter("MyResinPrinter");

    public PrinterManager()
    {
        printers.Add(Filamentprinter1);
        printers.Add(Filamentprinter2);
        printers.Add(Resinprinter1);
        printers.Add(Resinprinter2);
        orderManager = new OrderManager();
    }
    public Order GetOrderFromOrdermanager(Order order)
    {
        Order ordertemp = orderManager.getOrder();
        orderManager.SaveToJson();
        return ordertemp;
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
    public bool SendOrderToPrinter()
    {
        Order order = orderManager.getOrder();
        if (order == null)
        {
            return false;
        }
        int i = FindeAvaliblePrinter(order.PrinterTypename, order.Weight);
        if (i != -1)
        {
            orderManager.SaveToJson();
            printers[i].Print(order.Weight);
            return true;
        }
        return false;
    }
}