using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDash
{
    public static partial class NDashLib
    {
        // TODO: upgrade to C# 9 for records
        public class DisjunctionResult<T> : IEnumerable<T>
        {
            public IEnumerable<T> Left { get; private set; }
            public IEnumerable<T> Right { get; private set; }

            public DisjunctionResult(IEnumerable<T> left, IEnumerable<T> right)
            {
                Left = left;
                Right = right;
            }

            public void Deconstruct(out IEnumerable<T> left, out IEnumerable<T> right)
            {
                left = Left;
                right = Right;
            }
        }

        public static DisjunctionResult<T> Disjunction<T>(this IEnumerable<T> leftSource, IEnumerable<T> rightSource)
        {
            var uniqueToLeft = leftSource.Except(rightSource);
            var uniqueToRight = rightSource.Except(leftSource);

            return new DisjunctionResult<T>(uniqueToLeft, uniqueToRight);
        }

        public static IEnumerable<T> DisjunctiveUnion<T>(this IEnumerable<T> leftSource, IEnumerable<T> rightSource)
        {
            var(left, right) = leftSource.Disjunction(rightSource);

            return left.Concat(right);
        }
}
}
