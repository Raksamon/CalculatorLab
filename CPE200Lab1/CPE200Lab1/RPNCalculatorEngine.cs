﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
   
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        public string calculate(string oper)
        {
            string[] parts;
            Stack<string> myStack = new Stack<string>();
            parts = oper.Split(' ');

            try
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    if (isNumber(parts[i]))
                    {
                        myStack.Push(parts[i]);

                    }
                    else if (isOperator(parts[i]))
                    {
                        if (myStack.Count == 0)
                        {
                            return "E";
                        }
                        else if (myStack.Count == 1)
                        {
                            string first = myStack.Pop();
                            myStack.Push(calculate(parts[i], first, 4));
                        }
                        else if (parts[i] != "√" && parts[i] != "1/x" && parts[i] != "%")
                        {
                            string first = myStack.Pop();
                            string second = myStack.Pop();
                            myStack.Push(calculate(parts[i], second, first, 4));
                        }
                        else if (parts[i] == "%")
                        {
                            string second = myStack.Pop();
                            string first = myStack.Pop();
                            myStack.Push(first);
                            myStack.Push(calculate(parts[i], first, second, 4));
                        }

                    }

                }
                if (myStack.Count == 1)
                {
                    return myStack.Pop();
                }
                return "E";
            }
            catch (Exception)
            {
                return "E";
            }

        }
        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "1/x":
                case "%":
                    return true;
            }
            return false;
        }
    }
}

