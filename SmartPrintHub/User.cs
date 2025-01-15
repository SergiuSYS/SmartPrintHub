﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class User : Form
    {
        CalculatePrice calculatePrice = new CalculatePrice();
        OrderManager orderManager = new OrderManager();
        public User()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out float weight))
            {
                string printerType = textBox3.Text;

                if (!string.IsNullOrEmpty(printerType))
                {
                    float price = calculatePrice.Calculate(weight, printerType);
                    label9.Text = price.ToString("F2");
                }
                else
                {
                    label9.Text = "Enter a printer type.";
                }
            }
            else
            {
                label9.Text = "Invalid weight.";
            }
            label9.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            orderManager.AddOrder(new Order(textBox6.Text, textBox1.Text, float.Parse(textBox2.Text), textBox3.Text, textBox4.Text,float.Parse(label9.Text)));
            orderManager.SaveToJson();
        }
    }
    
}
