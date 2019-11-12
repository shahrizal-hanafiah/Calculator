using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Helpers
{
    public static class Calculator
    {
        private static Stack<string> _operators = new Stack<string>();
        private static Stack<double> _values = new Stack<double>();

        public static double Calculate(string sum)
        {
            try
            {
                char[] split = { ' ' };
                string[] arrls = sum.Split(split);

                foreach (var item in EvaluateArray(arrls))
                {
                    string strItem = item.ToString();
                    if (strItem.Length > 0 || strItem != "")
                    {
                        if (strItem.Equals("(")) { }
                        else if (strItem.Equals("+")) _operators.Push(strItem);
                        else if (strItem.Equals("-")) _operators.Push(strItem);
                        else if (strItem.Equals("*")) _operators.Push(strItem);
                        else if (strItem.Equals("/")) _operators.Push(strItem);
                        else if (strItem.Equals(")"))
                        {
                            int count = _operators.Count;
                            while (count > 0)
                            {
                                string op = _operators.Pop();
                                double val = _values.Pop();
                                val = op.Operator(_values.Pop(), val);
                                _values.Push(val);

                                count--;
                            }
                        }
                        else _values.Push(double.Parse(strItem));
                    }
                }
                return _values.Pop();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To add start, end of statement and remove '(' and ')' from array item. 
        /// </summary>
        /// <param name="arrls"></param>
        /// <returns></returns>
        private static Array EvaluateArray(string[] arrls)
        {
            ArrayList lsSum = new ArrayList(arrls.Length);
            lsSum.Add("(");
            for (int i = 0; i < arrls.Length; i++)
            {
                var item = arrls[i];
                if (item.Length > 0)
                {
                    if (arrls[i].IndexOf('(') > -1)
                    {
                        lsSum.Add("(");
                        item = item.Replace("(", "");
                        lsSum.Add(item);
                    }
                    else if (arrls[i].IndexOf(')') > -1)
                    {
                        item = item.Replace(")", "");
                        lsSum.Add(item);
                        lsSum.Add(")");
                    }
                    else
                    {
                        lsSum.Add(item);
                    }
                }
            }
            lsSum.Add(")");
            return (lsSum.ToArray());
        }
        /// <summary>
        /// Do calculation based on operator given
        /// </summary>
        /// <param name="logic">Operator</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double  Operator(this string logic, double x, double y)
        {
            switch (logic)
            {
                case "+": return x + y;
                case "-": return x - y;
                case "/": return x / y;
                case "*": return x * y;
                default: throw new Exception("invalid logic");
            }
        }
    }
}
