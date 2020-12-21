using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressionEvaluator
{

    /// <summary>
    /// Class containing methods for evaluating infix expressions. Infix expressions are arithmetic expressions 
    /// written in traditional notation, such as (2+3)-4.
    /// </summary>
    public static class Expression
    {
        /// <summary>
        /// Table to store the expression and evaluated results.
        /// Search - O(1) Insert O(1)
        /// </summary>
        private static readonly Dictionary<string, decimal> ExpressionLookup = new Dictionary<string, decimal>();
        /// <summary>
        /// Dictionary mapping operators to order of precedence. Larger integers indicate greater precedence.
        /// <br/><br/>
        /// Operators omitted by this dictionary are unsupported. Also note that the - operator cannot be used to 
        /// negate a number.
        /// </summary>
        private static readonly Dictionary<char, int> OperatorsTable = new Dictionary<char, int>
        {
            {'-', 1},
            {'+', 2},
            {'/', 3},
            {'*', 4}
        };

        /// <summary>
        /// Evaluates an infix expression by 1) converting it to a postfix expression and 2) evaluating the
        /// postfix expression.3. Store in the Table.
        /// </summary>
        /// <param name="infixExpression">A string infix expression.</param>
        /// <returns>A decimal storing the infix expression's evaluation.</returns>
        /// <exception cref="System.Exception">Thrown if the infix expression is invalid.</exception>
        /// <exception cref="System.DivideByZeroException">Thrown if the infix expression attempts to divide by 0.</exception>
        public static decimal Evaluate(string infixExpression)
        {
            if (!ExpressionLookup.ContainsKey(infixExpression))
            {
                ExpressionLookup.Add(infixExpression, EvaluatePostfix(ToPostfix(infixExpression)));
            }
            return ExpressionLookup[infixExpression];
        }

        # region InfixToPostfix

        /// <summary>
        /// Uses the shunting-yard algorithm to parse an infix expression and convert it to a postfix expression.
        /// </summary>
        /// <param name="infixExpression">A string infix expression.</param>
        /// <returns>A string postfix expression.</returns>
        /// <exception cref="System.Exception">Thrown if the infix expression is invalid.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the infix expression is null, empty, or consists only of whitespace characters.</exception>
        public static string ToPostfix(string infixExpression)
        {
            if (string.IsNullOrWhiteSpace(infixExpression)) throw new ArgumentException("Expression is empty.");

            var operatorStack = new Stack<char>();
            var stringBuilder = new StringBuilder();

            foreach (char token in Regex.Replace(infixExpression, @"\s+", ""))
            {
                if (OperatorsTable.ContainsKey(token))
                {
                    HandleOperatorCase(token, operatorStack, stringBuilder);
                }
                else
                    switch (token)
                    {
                        case '(':
                            operatorStack.Push(token);
                            break;
                        case ')':
                            HandleRightParenthesisCase(operatorStack, stringBuilder);
                            break;
                        default:
                            // Token must be a number. Don't append a space since the number may have multiple digits.
                            stringBuilder.Append(token);
                            break;
                    }
            }

            EmptyOperatorStack(operatorStack, stringBuilder);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Pops operators off operatorStack having greater or equal precedence to operatorToken, appends the operators
        /// to the output string, then pushes operatorToken onto operatorStack.
        /// </summary>
        /// <param name="operatorToken">The operator to parse.</param>
        /// <param name="operatorStack">The shunting-yard algorithm's operator stack.</param>
        /// <param name="stringBuilder">The shunting-yard algorithm's current output string.</param>
        /// <exception cref="System.Exception">Thrown if two operators are adjacent.</exception>
        private static void HandleOperatorCase(char operatorToken, Stack<char> operatorStack, StringBuilder stringBuilder)
        {
            // The operator case is the only case where a space is appended to the output string ahead of
            // the next iteration. Thus, if the last character in the output string is a space, then two
            // operators must be adjacent to one another.
            if (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] == ' ')
            {
                throw new Exception(String.Format(
                    "Operators {0} and {1} are adjacent.", operatorStack.Peek(), operatorToken));
            }

            // Pop operators off operatorStack having greater or equal precedence to operatorToken.
            // Note that a left parenthesis on the stack will stop the loop.
            while (operatorStack.Count > 0 && OperatorsTable.ContainsKey(operatorStack.Peek()) &&
                   OperatorsTable[operatorStack.Peek()] >= OperatorsTable[operatorToken])
            {
                stringBuilder.Append(" ").Append(operatorStack.Pop());
            }

            stringBuilder.Append(" ");
            operatorStack.Push(operatorToken);
        }

        /// <summary>
        /// Pops operators off operatorStack and appends them to the output string until a matching left parenthesis
        /// is found. The matching left parenthesis is then popped off operatorStack but is not appended to the output
        /// string.
        /// </summary>
        /// <param name="operatorStack">The shunting-yard algorithm's operator stack.</param>
        /// <param name="stringBuilder">The shunting-yard algorithm's current output string.</param>
        /// <exception cref="System.Exception">Thrown if a matching left parenthesis is not found.</exception>
        private static void HandleRightParenthesisCase(Stack<char> operatorStack, StringBuilder stringBuilder)
        {
            while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
            {
                stringBuilder.Append(" ").Append(operatorStack.Pop());
            }
            if (operatorStack.Count == 0)
            {
                throw new Exception("Missing ( parenthesis.");
            }
            operatorStack.Pop();
        }

        /// <summary>
        /// Pops remaining operators off operatorStack and appends them to the output string.
        /// </summary>
        /// <param name="operatorStack">The shunting-yard algorithm's operator stack.</param>
        /// <param name="stringBuilder">The shunting-yard algorithm's current output string.</param>
        /// <exception cref="System.Exception">Thrown if a left parenthesis is found on the stack.</exception>
        private static void EmptyOperatorStack(Stack<char> operatorStack, StringBuilder stringBuilder)
        {
            while (operatorStack.Count > 0)
            {
                if (operatorStack.Peek() == '(')
                {
                    throw new Exception("Missing ) parenthesis.");
                }
                stringBuilder.Append(" ").Append(operatorStack.Pop());
            }
        }

        #endregion

        #region EvaluatePostfix

        /// <summary>
        /// Uses a stack to evaluate a postfix expression to a number.
        /// </summary>
        /// <param name="postfixExpression">A string postfix expression.</param>
        /// <returns>A decimal storing the postfix expression's evaluation.</returns>
        /// <exception cref="System.Exception">Thrown if the postfix expression is invalid.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the postfix expression is null, empty, or consists only of whitespace characters.</exception>
        /// <exception cref="System.DivideByZeroException">Thrown if the postfix expression attempts to divide by 0.</exception>
        public static decimal EvaluatePostfix(string postfixExpression)
        {
            if (string.IsNullOrWhiteSpace(postfixExpression)) throw new ArgumentException("Expression is empty.");

            var numberStack = new Stack<decimal>();

            foreach (string token in Regex.Split(postfixExpression.Trim(), @"\s+"))
            {
                if (token.Length == 1 && OperatorsTable.ContainsKey(token[0]))
                {
                    if (numberStack.Count < 2) throw new Exception("Too many operators.");
                    decimal operand2 = numberStack.Pop(), operand1 = numberStack.Pop();
                    ApplyOperatorToOperands(token[0], operand1, operand2, numberStack);
                }
                else
                {
                    try
                    {
                        // Token must be a number.
                        numberStack.Push(Decimal.Parse(token));
                    }
                    catch (FormatException)
                    {
                        throw new Exception(String.Format("{0} is not a valid number.", token));
                    }
                }
            }

            return numberStack.Pop();
        }

        /// <summary>
        /// Evaluates the expression `operand1 operatorToken operand2`, then pushes the result onto stack.
        /// </summary>
        /// <param name="operatorToken">The operator to apply to operand1 and operand2.</param>
        /// <param name="operand1">The expression's first operand.</param>
        /// <param name="operand2">The expression's second operand.</param>
        /// <param name="stack">The stack being used to evaluate a postfix expression.</param>
        /// <exception cref="System.Exception">Thrown if operatorToken is unsupported.</exception>
        /// <exception cref="System.DivideByZeroException">Thrown if the expression attempts to divide by 0.</exception>
        private static void ApplyOperatorToOperands(char operatorToken, decimal operand1, decimal operand2,
            Stack<decimal> stack)
        {
            switch (operatorToken)
            {
                case '-':
                    stack.Push(operand1 - operand2);
                    break;
                case '+':
                    stack.Push(operand1 + operand2);
                    break;
                case '/':
                    if (operand2 == 0) throw new DivideByZeroException();
                    stack.Push(operand1 / operand2);
                    break;
                case '*':
                    stack.Push(operand1 * operand2);
                    break;
                default:
                    throw new Exception(
                        String.Format("{0} is an unsupported operator.", operatorToken));
            }
        }

        #endregion
    }
}