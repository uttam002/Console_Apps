using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Calculator_in_C_.Modules
{
        public class Logic
        {
            // Define operator precedence and associativity
            private static readonly Dictionary<char, int> precedence = new Dictionary<char, int>
        {
            { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 2 }
        };

            // Evaluates the mathematical expression entered by the user
            public double EvaluateExpression(string expression)
            {
                var tokens = Tokenize(expression);
                var postfix = InfixToPostfix(tokens);
                return EvaluatePostfix(postfix);
            }

            // Tokenize the input string into numbers and operators
            private List<string> Tokenize(string input)
            {
                var tokens = new List<string>();
                var number = new StringBuilder();

                foreach (var ch in input)
                {
                    if (char.IsDigit(ch) || ch == '.')
                    {
                        number.Append(ch); // Append number and decimal points
                    }
                    else if (IsOperator(ch))
                    {
                        if (number.Length > 0)
                        {
                            tokens.Add(number.ToString());
                            number.Clear();
                        }
                        tokens.Add(ch.ToString());
                    }
                    else if (ch == '(' || ch == ')')
                    {
                        if (number.Length > 0)
                        {
                            tokens.Add(number.ToString());
                            number.Clear();
                        }
                        tokens.Add(ch.ToString());
                    }
                    else if (!char.IsWhiteSpace(ch))
                    {
                        throw new ArgumentException($"Invalid character in expression: {ch}");
                    }
                }

                if (number.Length > 0)
                {
                    tokens.Add(number.ToString());
                }

                return tokens;
            }

            // Convert infix to postfix (Reverse Polish Notation)
            private List<string> InfixToPostfix(List<string> tokens)
            {
                var output = new List<string>();
                var operators = new Stack<string>();

                foreach (var token in tokens)
                {
                    if (double.TryParse(token, out _))
                    {
                        output.Add(token); // If it's a number, add to output
                    }
                    else if (IsOperator(token[0]))
                    {
                        while (operators.Count > 0 && IsOperator(operators.Peek()[0]) &&
                               Precedence(token[0]) <= Precedence(operators.Peek()[0]))
                        {
                            output.Add(operators.Pop());
                        }
                        operators.Push(token);
                    }
                    else if (token == "(")
                    {
                        operators.Push(token);
                    }
                    else if (token == ")")
                    {
                        while (operators.Count > 0 && operators.Peek() != "(")
                        {
                            output.Add(operators.Pop());
                        }
                        operators.Pop(); // Remove "(" from stack
                    }
                }

                while (operators.Count > 0)
                {
                    output.Add(operators.Pop());
                }

                return output;
            }

            // Evaluate the postfix expression
            private double EvaluatePostfix(List<string> tokens)
            {
                var stack = new Stack<double>();

                foreach (var token in tokens)
                {
                    if (double.TryParse(token, out double number))
                    {
                        stack.Push(number); // Push numbers onto stack
                    }
                    else if (IsOperator(token[0]))
                    {
                        if (stack.Count < 2) throw new InvalidOperationException("Insufficient values in expression.");
                        double right = stack.Pop();
                        double left = stack.Pop();
                        stack.Push(ApplyOperator(token[0], left, right));
                    }
                }

                if (stack.Count != 1) throw new InvalidOperationException("The user input has too many operators.");
                return stack.Pop();
            }

            // Apply operator to operands
            private double ApplyOperator(char op, double left, double right)
            {
                return op switch
                {
                    '+' => left + right,
                    '-' => left - right,
                    '*' => left * right,
                    '/' => right == 0 ? throw new DivideByZeroException("Cannot divide by zero.") : left / right,
                    _ => throw new ArgumentException($"Unsupported operator: {op}")
                };
            }

            // Check if character is an operator
            private bool IsOperator(char ch)
            {
                return precedence.ContainsKey(ch);
            }

            // Get precedence of operator
            private int Precedence(char op)
            {
                return precedence[op];
            }
        }
}