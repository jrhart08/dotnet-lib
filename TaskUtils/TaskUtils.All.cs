using System;
using System.Threading.Tasks;

namespace TaskUtils
{
    public static partial class TaskUtils
    {
        public static async Task<Tuple<T1>> All<T1>(
            Task<T1> task1
        )
        {
            await Task.WhenAll(task1);

            return Tuple.Create(await task1);
        }

        public static async Task<Tuple<T1, T2>> All<T1, T2>(
            Task<T1> task1,
            Task<T2> task2
        )
        {
            await Task.WhenAll(task1, task2);

            return Tuple.Create(
                await task1,
                await task2
            );
        }

        public static async Task<Tuple<T1, T2, T3>> All<T1, T2, T3>(
            Task<T1> task1,
            Task<T2> task2,
            Task<T3> task3
        )
        {
            await Task.WhenAll(task1, task2, task3);

            return Tuple.Create(
                await task1,
                await task2,
                await task3
            );
        }

        public static async Task<Tuple<T1, T2, T3, T4>> All<T1, T2, T3, T4>(
            Task<T1> task1,
            Task<T2> task2,
            Task<T3> task3,
            Task<T4> task4
        )
        {
            await Task.WhenAll(task1, task2, task3, task4);

            return Tuple.Create(
                await task1,
                await task2,
                await task3,
                await task4
            );
        }

        public static async Task<Tuple<T1, T2, T3, T4, T5>> All<T1, T2, T3, T4, T5>(
            Task<T1> task1,
            Task<T2> task2,
            Task<T3> task3,
            Task<T4> task4,
            Task<T5> task5
        )
        {
            await Task.WhenAll(task1, task2, task3, task4, task5);

            return Tuple.Create(
                await task1,
                await task2,
                await task3,
                await task4,
                await task5
            );
        }

        public static async Task<Tuple<T1, T2, T3, T4, T5, T6>> All<T1, T2, T3, T4, T5, T6>(
            Task<T1> task1,
            Task<T2> task2,
            Task<T3> task3,
            Task<T4> task4,
            Task<T5> task5,
            Task<T6> task6
        )
        {
            await Task.WhenAll(task1, task2, task3, task4, task5, task6);

            return Tuple.Create(
                await task1,
                await task2,
                await task3,
                await task4,
                await task5,
                await task6
            );
        }

        public static async Task<Tuple<T1, T2, T3, T4, T5, T6, T7>> All<T1, T2, T3, T4, T5, T6, T7>(
            Task<T1> task1,
            Task<T2> task2,
            Task<T3> task3,
            Task<T4> task4,
            Task<T5> task5,
            Task<T6> task6,
            Task<T7> task7
        )
        {
            await Task.WhenAll(task1, task2, task3, task4, task5, task6, task7);

            return Tuple.Create(
                await task1,
                await task2,
                await task3,
                await task4,
                await task5,
                await task6,
                await task7
            );
        }

        public static async Task<Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<TRest>>> All<T1, T2, T3, T4, T5, T6, T7, TRest>(
            Task<T1> task1,
            Task<T2> task2,
            Task<T3> task3,
            Task<T4> task4,
            Task<T5> task5,
            Task<T6> task6,
            Task<T7> task7,
            Task<TRest> remainingTasks
        )
        {
            await Task.WhenAll(task1, task2, task3, task4, task5, task6, task7, remainingTasks);

            return Tuple.Create(
                await task1,
                await task2,
                await task3,
                await task4,
                await task5,
                await task6,
                await task7,
                await remainingTasks
            );
        }
    }
}
