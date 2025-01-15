using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPrintHub
{
    public partial class UserControl1 : UserControl
    {
        Printer PrinterHolder;
        PrinterManager printerManager;
        public UserControl1()
        {
            InitializeComponent();
        }
        public void SetPrinterInfo(string printerName, string printerType, string materialCapacity, Printer printer)
        {
            label1.Text = printerName;
            label4.Text = printerType;
            label3.Text = materialCapacity;
            PrinterHolder = printer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrinterHolder.Refil();
            label3.Text = PrinterHolder.MaterialCapacity.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //adugare de comanda pentru procesare in printer
        }
    }
}
