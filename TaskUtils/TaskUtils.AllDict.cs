using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NDash;
using TaskUtils.Exceptions;

namespace TaskUtils
{
    public static partial class TaskUtils
    {
        // when `((dynamic)task).Result` just isn't enough.
        // https://i.imgur.com/8M39Loq.jpg
        static object ForceGetResult(Task task) =>
            task.GetType().GetProperty("Result").GetValue(task);

        /// <summary>
        /// Maps a dictionary of {name, task} pairs to {name, result} pairs.
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public static async Task<Dictionary<string, object>>
            AllDict(IDictionary<string, Task> tasks)
        {
            await Task.WhenAll(tasks.Values);

            return tasks.ToDictionary(
                kvp => kvp.Key,
                kvp => ForceGetResult(kvp.Value)
            );
        }

        /// <summary>
        /// Maps this collection of (name, task) tuples to a dictionary of {name, result} pairs.
        /// Because of this, all names must be unique.
        /// </summary>
        /// <param name="nameTaskTuples"></param>
        /// <returns></returns>
        public static async Task<Dictionary<string, object>>
            AllDict(IEnumerable<Tuple<string, Task>> nameTaskTuples)
        {
            if(!NDashLib.AreUniqueBy(nameTaskTuples, tuple => tuple.Item1))
            {
                throw new DuplicateEntriesException(nameTaskTuples);
            }

            await Task.WhenAll(nameTaskTuples.Select(tuple => tuple.Item2));

            return nameTaskTuples.ToDictionary(
                tuple => tuple.Item1,
                tuple => ForceGetResult(tuple.Item2)
            );
        }

        /// <summary>
        /// Maps an array of (name, task) pairs to a dictionary of {name, result} pairs.
        /// Because of this, all names must be unique.
        /// </summary>
        /// <param name="nameTaskTuples"></param>
        /// <returns></returns>
        public static Task<Dictionary<string, object>>
            AllDict(params Tuple<string, Task>[] nameTaskTuples)
        {
            return AllDict(nameTaskTuples.AsEnumerable());
        }

        /// <summary>
        /// Iterates through all the Task properties on the object and returns a dictionary of the results.
        /// Skips non-task properties.
        /// </summary>
        /// <param name="taskCollection"></param>
        /// <returns></returns>
        public static Task<Dictionary<string, object>>
            AllDict(object taskCollection)
        {
            var nameTaskTuples = taskCollection
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop.GetMethod != null)
                .Where(prop => prop.PropertyType.IsSubclassOf(typeof(Task)))
                .Select(prop =>
                {
                    var name = prop.Name;
                    var task = prop.GetValue(taskCollection) as Task;

                    return Tuple.Create(name, task);
                });

            return AllDict(nameTaskTuples);
        }

        /// <summary>
        /// Iterates through all the Task properties on the object and returns a dictionary of the results.
        /// Copies over non-task properties.
        /// </summary>
        /// <param name="taskCollection"></param>
        /// <returns></returns>
        //public static Task<Dictionary<string, object>> AllDict(
        //    object taskCollection,
        //    bool copyNonTasks = false
        //)
        //{
        //    var properties = taskCollection
        //        .GetType()
        //        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        //        .Where(prop => prop.GetMethod != null)
        //        .Where(prop => copyNonTasks || prop.PropertyType.IsSubclassOf(typeof(Task)));

        //    var nameTaskTuples = properties.Select(prop =>
        //    {
        //        var name = prop.Name;
        //        var val = prop.GetValue(taskCollection);
        //        if (val is Task)
        //        {
        //            return Tuple.Create(name, val as Task);
        //        }
        //        return Tuple.Create(name, (Task)Task.FromResult(val));
        //    });

        //    return AllDict(nameTaskTuples);
        //}
    }
}
