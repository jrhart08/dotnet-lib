using System;

namespace NDash
{
    public static partial class NDashLib
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> g, Func<T2, T3> f)
        {
            return x => f(g(x));
        }
    }
}
