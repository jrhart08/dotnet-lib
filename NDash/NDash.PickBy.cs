using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace NDash
{
    public static partial class NDashLib
    {
        /// <summary>
        /// Returns a new ExpandoObject consisting of the source object's properties which match the given predicate.
        /// </summary>
        /// <param name="sourceObject">The object to pick properties from.</param>
        /// <param name="predicate">A predicate to apply to each property on the given object. The second parameter is the name of the property.</param>
        /// <returns></returns>
        public static ExpandoObject PickBy(object sourceObject, Func<object, string, bool> predicate)
        {
            var pickedProperties = sourceObject
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(prop => Tuple.Create(prop.GetValue(sourceObject), prop.Name))
                .Where(pair => predicate(pair.Item1, pair.Item2));

            var subObject = new ExpandoObject();
            var shortcut = subObject as IDictionary<string, object>;

            foreach (var (val, key) in pickedProperties)
            {
                shortcut.Add(key, val);
            }

            return subObject;
        }

        /// <summary>
        /// Returns a new ExpandoObject consisting of the source object's properties which match the given predicate.
        /// </summary>
        /// <param name="sourceObject">The object to pick properties from.</param>
        /// <param name="predicate">A predicate to apply to each property on the given object.</param>
        /// <returns></returns>
        public static ExpandoObject PickBy(object sourceObject, Func<object, bool> predicate)
        {
            // shape this predicate for extended PickBy function
            Func<object, string, bool> paddedPredicate =
                (propertyValue, propertyName) => predicate(propertyValue);

            return PickBy(sourceObject, paddedPredicate);
        }
    }
}
