namespace SimpleCalculator
{
    public static class Calculator
    {
        public static T Evaluate<T>(Operator operand, T? left, T? right)
        {
            if (left is null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right is null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            dynamic _left = left;
            dynamic _right = right;

            switch (operand)
            {
                case Operator.Addition:
                    return _left + _right;

                case Operator.Subtraction:
                    return _left - _right;

                case Operator.Multiplication:
                    return _left * _right;

                case Operator.Division:
                    if (right.Equals(0) || right.Equals(0.0) || right.Equals(0.0f))
                    {
                        throw new System.DivideByZeroException();
                    }

                    return _left / _right;

                default:
                    return default(T);
            }
        }
    }
}