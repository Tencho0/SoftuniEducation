namespace T02ConditionalExpressionResolver
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var expression = Console.ReadLine()
                .Split()
                .Select(x => x[0])
                .ToArray();

            var result = ResolveExpression(expression, 0);
            Console.WriteLine(result);
        }

        private static int ResolveExpression(char[] expression, int idx)
        {
            if (char.IsDigit(expression[idx]))
            {
                return expression[idx] - '0';
            }

            if (expression[idx] == 't')
            {
                return ResolveExpression(expression, idx + 2);
            }

            var foundConditions = 0;
            for (int i = idx + 2; i < expression.Length; i++)
            {
                var currentSymbol = expression[i];
                if (currentSymbol == '?')
                {
                    foundConditions++;
                }
                else if (currentSymbol == ':')
                {
                    foundConditions--;

                    if (foundConditions < 0)
                    {
                        return ResolveExpression(expression, i + 1);
                    }
                }
            }

            throw new InvalidOperationException("Invalid expression");
        }
    }
}
