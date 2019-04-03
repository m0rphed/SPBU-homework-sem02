namespace ProblemSet02.Task03
{
    using System;

    public class Calculator
    {
        private readonly IStack<string> stack;

        public Calculator(IStack<string> stack)
        {
            this.stack = stack;
        }

        public double Evaluate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("Input is Null or Empty");
            }

            var arr = input.Split(' ');

            foreach (var item in arr)
            {
                double res;
                if (double.TryParse(item, out res))
                {
                    this.stack.Push(item);
                }
                else
                {
                    PerformOperation(item);
                }
            }

            if (stack.Count != 1)
            {
                throw new Exception("Invalid expression");
            }

            var finalItem = stack.Pop();

            double finalRes;
            if (double.TryParse(finalItem, out finalRes))
            {
                return finalRes;
            }
            else
            {
                throw new Exception("Invalid expression");
            }
        }

        private void PreformBinaryOperation(Func<double, double, double> func)
        {
            var right = GetNumberFromStack();
            var left = GetNumberFromStack();

            stack.Push(func(left, right).ToString());
        }

        private void PerformOperation(string item)
        {
            switch (item)
            {
                case "+":
                    PreformBinaryOperation((a, b) => a + b);
                    break;
                case "-":
                    PreformBinaryOperation((a, b) => a - b);
                    break;
                case "*":
                    PreformBinaryOperation((a, b) => a * b);
                    break;
                case "/":
                    PreformBinaryOperation((a, b) => a / b);
                    break;
                default:
                    throw new Exception("Unsupported operation");
            }
        }

        private double GetNumberFromStack()
        {
            if (stack.Count == 0)
            {
                throw new Exception("Not enough operands!");
            }

            return double.Parse(stack.Pop());
        }
    }
}
