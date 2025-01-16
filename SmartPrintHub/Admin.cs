using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPrintHub;

namespace WinFormsApp1
{
    public partial class Admin : Form
    {
        AccountManager accountManager;
        PrinterManager printerManager;
        OrderManager orderManager;
        public Admin()
        {
            InitializeComponent();
            accountManager = new AccountManager();
            printerManager = new PrinterManager();
            orderManager = new OrderManager();
            foreach (Printer printer in printerManager.printers)
            {
                UserControl1 printerHolder = new UserControl1();
                printerHolder.SetPrinterInfo(printer.brand, printer.TipImprimanta, printer.MaterialCapacity.ToString(), printer);
                flowLayoutPanel1.Controls.Add(printerHolder);
            }
            foreach(Order order in orderManager.orders)
            {
                listBox1.Items.Add($"{order.Name},{order.ObjectName},{order.PrinterTypename},{order.Destination},{order.Price}");
            }
            this.FormClosing += Admin_FormClosing;
        }
        public void SendOrderToPrinter(Order order)
        {
            printerManager.GetOrderFromOrdermanager(orderManager.getOrder());
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    accountManager.SaveToJson();
                    orderManager.SaveToJson();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
