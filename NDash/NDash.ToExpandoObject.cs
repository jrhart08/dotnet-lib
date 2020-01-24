using System.Collections.Generic;
using System.Dynamic;

namespace NDash
{
    public static partial class NDashLib
    {
        /// <summary>
        /// Copies an IDictionary<string, object> into an ExpandoObject. Useful if you want to quickly make it serializable.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static ExpandoObject ToExpandoObject(this IDictionary<string, object> dict)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var kvp in dict)
            {
                expando.Add(kvp);
            }

            return (ExpandoObject)expando;
        }
    }
}
