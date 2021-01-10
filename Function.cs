﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TarkisW
{
    public class Function
    {
        private const string buttonNotExist = "Button {0} does not exist";
        private const string twoButtonsNotExist = "Button {0} or {1} does not exist";

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public static int[] NameToPosition(string name)
        {
            int pos = int.Parse(name);
            int a = pos / 10;
            int b = pos % 10;
            int[] result = new int[2];

            result[0] = a;
            result[1] = b;

            return result;
        }

        public static bool AboveOf(string btn1, string btn2)
        {
            try
            {
                var button1 = (MyButton)Form1.ActiveForm.Controls.Find(btn1, true).Single();
                var button2 = (MyButton)Form1.ActiveForm.Controls.Find(btn2, true).Single();
                return button1.Position[1] + 1 == button2.Position[1];
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(twoButtonsNotExist, btn1, btn2));
                return false;
            }
        }

        public static bool BelowOf(string btn1, string btn2)
        {
            try
            {
                var button1 = (MyButton)Form1.ActiveForm.Controls.Find(btn1, true).Single();
                var button2 = (MyButton)Form1.ActiveForm.Controls.Find(btn2, true).Single();
                return button1.Position[1] - 1 == button2.Position[1];
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(twoButtonsNotExist, btn1, btn2));
                return false;
            }
        }

        public static bool LeftOf(string btn1, string btn2)
        {
            try
            {
                var button1 = (MyButton)Form1.ActiveForm.Controls.Find(btn1, true).Single();
                var button2 = (MyButton)Form1.ActiveForm.Controls.Find(btn2, true).Single();
                return button1.Position[0] + 1 == button2.Position[0];
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(twoButtonsNotExist, btn1, btn2));
                return false;
            }
        }

        public static bool RightOf(string btn1, string btn2)
        {
            try
            {
                var button1 = (MyButton)Form1.ActiveForm.Controls.Find(btn1, true).Single();
                var button2 = (MyButton)Form1.ActiveForm.Controls.Find(btn2, true).Single();
                return button1.Position[0] - 1 == button2.Position[0];
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(twoButtonsNotExist, btn1, btn2));
                return false;
            }
        }

        public static bool Small(string btn)
        {
            try
            {
                var button = (MyButton)Form1.ActiveForm.Controls.Find(btn, true).Single();
                return button.ButtonSize == ButtonSize.Small;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(buttonNotExist, btn));
                return false;
            }
        }

        public static bool Small()
        {
            return GetAllButtons().Any(button => button.ButtonSize == ButtonSize.Small);
        }

        public static bool Medium(string btn)
        {
            try
            {
                var button = (MyButton)Form1.ActiveForm.Controls.Find(btn, true).Single();
                return button.ButtonSize == ButtonSize.Medium;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(buttonNotExist, btn));
                return false;
            }
        }

        public static bool Medium()
        {
            return GetAllButtons().Any(button => button.ButtonSize == ButtonSize.Medium);
        }

        public static bool Large(string btn)
        {
            try
            {
                var button = (MyButton)Form1.ActiveForm.Controls.Find(btn, true).Single();
                return button.ButtonSize == ButtonSize.Large;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(buttonNotExist, btn));
                return false;
            }
        }

        public static bool Large()
        {
            return GetAllButtons().Any(button => button.ButtonSize == ButtonSize.Large);
        }

        public static bool Square(string btn)
        {
            try
            {
                var button = (MyButton)Form1.ActiveForm.Controls.Find(btn, true).Single();
                return button.ButtonShape == ButtonShape.Square;

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(buttonNotExist, btn));
                return false;
            }
        }

        public static bool Square()
        {
            return GetAllButtons().Any(button => button.ButtonShape == ButtonShape.Square);
        }

        public static bool Circle(string btn)
        {
            try
            {
                var button = (MyButton)Form1.ActiveForm.Controls.Find(btn, true).Single();
                return button.ButtonShape == ButtonShape.Circle;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(buttonNotExist, btn));
                return false;
            }
        }

        public static bool Circle()
        {
            return GetAllButtons().Any(button => button.ButtonShape == ButtonShape.Circle);
        }

        public static bool Triangle(string btn)
        {
            try
            {
                var button = (MyButton)Form1.ActiveForm.Controls.Find(btn, true).Single();
                return button.ButtonShape == ButtonShape.Triangle;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(string.Format(buttonNotExist, btn));
                return false;
            }
        }

        public static bool Triangle()
        {
            return GetAllButtons().Any(button => button.ButtonShape == ButtonShape.Triangle);
        }

        private static IEnumerable<MyButton> GetAllButtons()
        {
            var panel = (Panel)Form1.ActiveForm.Controls.Find("panel1", true).Single();
            return panel.Controls
                .OfType<Panel>()
                .Select(p => p.Controls.OfType<MyButton>().SingleOrDefault())
                .Where(b => b != null);
        }

        //public static bool Exists(string a){
        //    Panel pn = (Panel)Form1.ActiveForm.Controls.Find("panel1", true).Single();
        //    List<Panel> panels = pn.Controls.OfType<Panel>().ToList();
        //    List<MyButton> buttonlist = new List<MyButton>();
        //    foreach (Panel pans in panels)
        //    {
        //        List<MyButton> buttons = pans.Controls.OfType<MyButton>().ToList();
        //        foreach (MyButton btns in buttons)
        //        {
        //            buttonlist.Add(btns);
        //        }
        //    }



        //}

        public static bool Implies(bool a, bool b)
        {
            return !a | b;
        }

        public static bool Bicon(bool a, bool b)
        {
            return !(a & b);
        }

        public static bool And(bool a, bool b)
        {
            return a & b;
        }

        public static bool Or(bool a, bool b)
        {
            return a | b;
        }

        public static bool Not(bool a)
        {
            return !a;
        }

        public static int precedence(char o)
        {
            switch (o)
            {
                case '¬':
                    return 1;

                case '∧':
                    return 2;

                case '∨':
                    return 3;
                    ;
                case '→':
                    return 4;

                case '↔':
                    return 5;
                default:
                    return 0;

            }
        }

        public static string Infix_To_Postfix(string expn)
        {
            Stack<char> stk = new Stack<char>();
            string output = "";
            char _out;
            foreach (var ch in expn)
            {
                bool isAlphaBet = Regex.IsMatch(ch.ToString(), "[a-z]", RegexOptions.IgnoreCase);
                if (Char.IsDigit(ch) || isAlphaBet)
                {
                    output = output + ch;
                }
                else
                {
                    switch (ch)
                    {
                        case '¬':
                        case '∧':
                        case '∨':
                        case '→':
                        case '↔':
                            while (stk.Count > 0 && precedence(ch) <= precedence(stk.Peek()))
                            {
                                _out = stk.Peek();
                                stk.Pop();
                                output = output + " " + _out;
                            }
                            stk.Push(ch);
                            output = output + " ";
                            break;
                        case '(':
                            stk.Push(ch);
                            break;
                        case ')':
                            while (stk.Count > 0 && (_out = stk.Peek()) != '(')
                            {
                                stk.Pop();
                                output = output + " " + _out + " ";
                            }
                            if (stk.Count > 0 && (_out = stk.Peek()) == '(')
                                stk.Pop();
                            break;
                    }
                }
            }
            while (stk.Count > 0)
            {
                _out = stk.Peek();
                stk.Pop();
                output = output + _out + " ";
            }
            return output;
        }

        public void expression(string postfix)
        {
            Stack<String> stk = new Stack<String>();
            string output = "";
            char _out;
            bool a, b, ans;
            foreach (var ch in postfix)
            {
                bool isAlphaBet = Regex.IsMatch(ch.ToString(), "[a-z]", RegexOptions.IgnoreCase);
                if (Char.IsDigit(ch) || isAlphaBet)
                {
                    output = output + ch;
                    stk.Push(output);
                }
                else
                {
                    if (ch.Equals('¬'))
                    {
                        String sa = (String)stk.Pop();

                        a = bool.Parse(sa);
                        ans = Not(a);
                        stk.Push(ans.ToString());
                    }
                }
            }
        }

        public static string evaluatePostfix(string exp)
        {
            // create a stack  
            Stack<string> stack = new Stack<string>();

            // Scan all characters one by one  
            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                bool isAlphaBet = Regex.IsMatch(c.ToString(), "[a-z]", RegexOptions.IgnoreCase);
                if (c == ' ')
                {
                    continue;
                }

                // If the scanned character is an   
                // operand (number here),extract  
                // the number. Push it to the stack.  
                
                //if (Char.IsDigit(ch) || isAlphaBet)
                else if (char.IsDigit(c) || isAlphaBet)
                {
                    string n = "";

                    // extract the characters and  
                    // store it in num  
                    while (char.IsDigit(c) || isAlphaBet)
                    {
                        n = n + c;
                        i++;
                        c = exp[i];
                    }
                    //i--;

                    // push the number in stack  
                    stack.Push(n);
                }
            }
            return stack.Peek();
        }
    }
}
