using System;
using System.Dynamic;

namespace NDash
{
    public static partial class NDashLib
    {
        /// <summary>
        /// (Inverse of PickBy): Returns a new ExpandoObject consisting of the source object's properties which DO NOT match the given predicate.
        /// </summary>
        /// <param name="sourceObject">The object to pick properties from.</param>
        /// <param name="predicate">A predicate to apply to each property on the given object. The second parameter is the name of the property.</param>
        /// <returns></returns>
        public static ExpandoObject OmitBy(object sourceObject, Func<object, string, bool> predicate)
        {
            return PickBy(sourceObject, Negate(predicate));
        }

        /// <summary>
        /// (Inverse of PickBy): Returns a new ExpandoObject consisting of the source object's properties which DO NOT match the given predicate.
        /// </summary>
        /// <param name="sourceObject">The object to pick properties from.</param>
        /// <param name="predicate">A predicate to apply to each property on the given object.</param>
        /// <returns></returns>
        public static ExpandoObject OmitBy(object sourceObject, Func<object, bool> predicate)
        {
            // return InverseOf(PickBy)(predicate);
            return PickBy(sourceObject, Negate(predicate));
        }

        //public static Func<TResult, TFunc> InverseOf<T, TFunc, TResult>(Func<Func<T, bool>, TFunc> predicateOperator)
        //{

        //    return predicate => predicateOperator(Negate(predicate));
        //}
    }
}
