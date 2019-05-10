namespace ProblemSet04.Task01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implements expression parse tree.
    /// The parse tree of an arithmetic expression decomposes an expression into a syntax tree.
    /// Each node stores either a link to the subtree, or a number, or an operator.
    /// </summary>
    public sealed class ExpressionTree
    {
        private readonly TreeNode _root;

        public ExpressionTree(string expression)
        {
            var sk = new Stack<char>();
            foreach (var c in expression.Reverse())
            {
                sk.Push(c);
            }

            _root = CreateNode(sk);
        }

        public enum State
        {
            WaitingExpressionOrNumber,
            WaitingEndOfNumber,
            WaitingOperatorSymbol,
            WaitingEndOfExpression,
        }

        public string Print() => _root.Print();

        public int Calculate() => _root.Calculate();

        private static TreeNode CreateNode(Stack<char> sk)
        {
            TreeNode currentLeft = null;
            TreeNode currentRight = null;
            var currentSymbol = '?';

            var currentValue = string.Empty;
            var currentState = State.WaitingExpressionOrNumber;

            void ProcessExpression(char c)
            {
                currentSymbol = c;
                currentLeft = CreateNode(sk);
                currentRight = CreateNode(sk);
                currentState = State.WaitingEndOfExpression;
            }

            TreeNode ProcessNumber()
            {
                var val = currentValue;
                currentValue = string.Empty;

                // no need to set state because we are retuning from recursive call
                return new Number(Convert.ToInt32(val));
            }

            while (true)
            {
                if (sk.Count == 0 & currentState == State.WaitingEndOfNumber)
                {
                    return ProcessNumber();
                }

                var c = sk.Pop();

                switch (c)
                {
                    case '(':
                        currentState = State.WaitingOperatorSymbol;
                        break;

                    case '-':
                        if (currentState == State.WaitingExpressionOrNumber)
                        {
                            // this is start of negative number
                            currentState = State.WaitingEndOfNumber;
                            currentValue = c.ToString();
                        }
                        else if (currentState == State.WaitingOperatorSymbol)
                        {
                            ProcessExpression(c);
                        }

                        break;

                    case '+':
                    case '*':
                    case '/':
                        if (currentState == State.WaitingOperatorSymbol)
                        {
                            ProcessExpression(c);
                        }

                        break;

                    case ')':
                        if (currentState == State.WaitingEndOfExpression)
                        {
                            switch (currentSymbol)
                            {
                                case '/':
                                    return new Divide(currentLeft, currentRight);
                                case '*':
                                    return new Multiply(currentLeft, currentRight);
                                case '+':
                                    return new Plus(currentLeft, currentRight);
                                case '-':
                                    return new Minus(currentLeft, currentRight);
                                default:
                                    throw new IndexOutOfRangeException($"Unknown operation{currentSymbol}");
                            }
                        }

                        break;

                    case ' ':
                        if (currentState == State.WaitingEndOfNumber)
                        {
                            return ProcessNumber();
                        }

                        break;

                    default:
                        if (char.IsDigit(c))
                        {
                            currentState = State.WaitingEndOfNumber;
                            currentValue += c.ToString();
                        }

                        break;
                }
            }
        }
    }
}
