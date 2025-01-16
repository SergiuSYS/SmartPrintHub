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
        Order currentOrder;
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
            if (currentOrder == null)
            {
                MessageBox.Show("Please select an order");
                return;
            }

            printerManager.GetOrderFromOrdermanager(currentOrder);
            bool success = PrinterHolder.Print(PrinterHolder.getOrder(currentOrder));

            if (success)
            {
                MessageBox.Show("Printing completed successfully!");
            }
            else
            {
                MessageBox.Show("Not enough material to print.");
            }
        }
        public void AssignOrder(Order order)
        {
            currentOrder = order;
            MessageBox.Show($"Order assigned: {order.ObjectName}");
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
