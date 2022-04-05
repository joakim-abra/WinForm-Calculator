using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformCalculator
{
    public partial class Form1 : Form
    {
        List<string> madeCalculations = new();
        List<string> calculation = new();
        string chosenOperator;
        string[] operators = {"+","-","*","/", "√","sqr" };
            double result;
        bool newCalc=true;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newCalc=newCalcCheck(newCalc, "1");
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "0");
        }

        private void button2_MouseClick(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "2");
        }

        private void button3_MouseClick(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            newCalc = newCalcCheck(newCalc, "9");
        }

        private void plus_Click(object sender, EventArgs e)
        {
            Operator(0);
        }

        private void minus_Click(object sender, EventArgs e)
        {
            Operator(1);
        }

        private void times_Click(object sender, EventArgs e)
        {
            Operator(2);
        }

        private void division_Click(object sender, EventArgs e)
        {
            Operator(3);
        }

        private void equals_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains(",") == false)
            { 
            textBox1.Text += ",";
            }
        }
        private void AddCalculation(List<string> num, string chosenOperator, double result)
        {
            if(chosenOperator==null)
            {
                calculation.Clear();
            }
            if(chosenOperator==operators[4] || chosenOperator == operators[5])
            {
                if (chosenOperator == operators[4])
                {
                    if(num.Count>0)
                    {
                        madeCalculations.Add(chosenOperator + "(" + num[num.Count-1] + ")" + " = " + Convert.ToString(result));
                    }
                    
                }
            }
            else
            {
                madeCalculations.Add(num[0] + " " + chosenOperator + " " + num[1] + " = " + Convert.ToString(result));
            }
            
            
            newCalc = true;
        }
        private bool newCalcCheck(bool newCalc, string number)
        {
            if(textBox1.Text=="0")
            {
                newCalc = true;
            }
            switch (newCalc)
            {
                case true:
                    textBox1.Text = number;
                    return false;
                default:
                    textBox1.Text += number;
                    return false;

            }
        }
        private void Calculate()
        {
            calculation.Add(textBox1.Text);
            switch (chosenOperator)
            {
                case "+":
                    result = Convert.ToDouble(calculation[0]) + Convert.ToDouble(calculation[1]);
                    textBox1.Text = result.ToString();
                    AddCalculation(calculation, chosenOperator, result);
                    newCalc = true;
                    break;
                case "-":
                    result = Convert.ToDouble(calculation[0]) - Convert.ToDouble(calculation[1]);
                    textBox1.Text = result.ToString();
                    AddCalculation(calculation, chosenOperator, result);
                    newCalc = true;
                    break;
                case "*":
                    result = Convert.ToDouble(calculation[0]) * Convert.ToDouble(calculation[1]);
                    textBox1.Text = result.ToString();
                    AddCalculation(calculation, chosenOperator, result);
                    newCalc = true;
                    break;
                case "/":
                    try
                    {
                        result = Convert.ToDouble(calculation[0]) / Convert.ToDouble(calculation[1]);
                        textBox1.Text = result.ToString();
                        AddCalculation(calculation, chosenOperator, result);
                        newCalc = true;
                    }
                    catch (DivideByZeroException)
                    {
                    }
                    break;

                case "sqr":
                    break;
                case "√":
                    result = Math.Sqrt(Convert.ToDouble(textBox1.Text));
                    textBox1.Text = result.ToString();
                    AddCalculation(calculation, chosenOperator, result);
                    newCalc = true;
                    break;
            }
            calculation.Clear();
            chosenOperator = null;

        }
        private void visaUträkningarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = null;
            if (madeCalculations != null)
            {
                foreach (var item in madeCalculations)
                {
                    temp = temp + item + "\n";
                }
                MessageBox.Show(temp, "Historik");
            }
            else
            {
                MessageBox.Show("", "Historik");
            }
        }
        private void Operator(int choice)
        {
            calculation.Add(textBox1.Text);
            textBox1.Text = operators[choice];
            newCalc = true;
            if (calculation.Count > 1)
            {
                Calculate();
            }
            chosenOperator = operators[choice];
        }
        

        private void rensaHistorikToolStripMenuItem_Click(object sender, EventArgs e)
        {

            madeCalculations.Clear();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            calculation.Clear();
            textBox1.Text = "0";
            chosenOperator = null;
        }
        
        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            chosenOperator = operators[4];
            result = Math.Sqrt(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
            AddCalculation(calculation, chosenOperator, result);
            newCalc = true;

        }
        
    }
}
