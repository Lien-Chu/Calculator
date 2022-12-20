using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lienchu_moment5
{
    public partial class Form1 : Form
    {
        // Create variable for resultValue and set its type to double.
        Double resultValue = 0;
        // Create variable for operationPerformed and set it's type to string.
        string operationPerformed = " ";
        // Create a variable for identifying if the operation has been performed.
        bool isOperationPerformed;
        public Form1()
        {
            InitializeComponent();
        }

        // Set click event handler for all buttons of numbers and ",".
        private void button_Click(object sender, EventArgs e)
        {
            // Remove the "0" in the resultTextBox when the calculation starts.
            if ((resultTextBox.Text == "0") || (isOperationPerformed))
                resultTextBox.Clear();
            isOperationPerformed = false;
            // Set sender to typecasting the button class for typecasting object and accessing it's properties.
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                // Set the "," can only contains once.
                if (!resultTextBox.Text.Contains(","))
                    resultTextBox.Text = resultTextBox.Text + button.Text;
            }
            else
            {
                resultTextBox.Text = resultTextBox.Text + button.Text;
            }
        }

        // Set click event handler for all operators.
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                equal.PerformClick();
                operationPerformed = button.Text;
                // Create a lable to set to show the current operatoin.
                currentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                // Convert resultValue to type from string to double for calculator.
                resultValue = Double.Parse(resultTextBox.Text);
                currentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }
        // Set click event handler for CE button.
        private void clearError_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
        }
        // Set click event handler for C button.
        private void clear_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
            currentOperation.Text = " ";
            resultValue = 0;
        }
        // Set click event handler for equal button.
        private void equal_Click(object sender, EventArgs e)
        {
            // Switch case according to operationPerformed.
            switch (operationPerformed)
            {
                case "+":
                    resultTextBox.Text = (resultValue + Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "-":
                    resultTextBox.Text = (resultValue - Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "×":
                    resultTextBox.Text = (resultValue * Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "÷":
                    resultTextBox.Text = (resultValue / Double.Parse(resultTextBox.Text)).ToString();
                    break;
                default:
                    break;

            }
            // Convert the result value to type double and set lable to empty after calculator.
            resultValue = Double.Parse(resultTextBox.Text);
            currentOperation.Text = "";
        }
    }
}
