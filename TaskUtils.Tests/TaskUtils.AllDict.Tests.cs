using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TaskUtils.Tests
{
    public class TaskUtils_AllDict_Tests
    {
        class TestType1 { }
        class TestType2 { }
        class TestType3 { }

        static Task<TestType1> getType1() => Task.FromResult(new TestType1());
        static Task<TestType2> getType2() => Task.FromResult(new TestType2());
        static Task<TestType3> getType3() => Task.FromResult(new TestType3());

        static Task<long> get1() => Task.FromResult(1L);
        static Task<float> get2() => Task.FromResult(2F);
        static Task<double> get3() => Task.FromResult(3D);

        static Task<long> get4() => Task.FromResult(4L);
        static Task<float> get5() => Task.FromResult(5F);
        static Task<double> get6() => Task.FromResult(6D);

        static Task<long> get7() => Task.FromResult(7L);
        static Task<float> get8() => Task.FromResult(8F);
        static Task<double> get9() => Task.FromResult(9D);

        public class WithDictionary
        {
            [Fact]
            public async Task should_handle_empty_collections()
            {
                Dictionary<string, object> results = await TaskUtils.AllDict(new Dictionary<string, Task> { });

                Assert.Empty(results);
            }

            [Fact]
            public async Task should_map_tasks_to_results()
            {
                Dictionary<string, object> results = await TaskUtils.AllDict(new Dictionary<string, Task>
                {
                    { "Task 1", getType1() },
                    { "Task 2", getType2() },
                });

                Assert.NotNull(results["Task 1"]);
                Assert.IsType<TestType1>(results["Task 1"]);

                Assert.NotNull(results["Task 2"]);
                Assert.IsType<TestType2>(results["Task 2"]);
            }
        }

        public class WithTuples
        {
            [Fact]
            public async Task should_accept_name_task_tuples()
            {
                Dictionary<string, object> results = await TaskUtils.AllDict(
                    Tuple.Create<string, Task>("Task 1", getType1()),
                    Tuple.Create<string, Task>("Task 2", getType2()),
                    Tuple.Create("Task 3", (Task)getType3())
                );

                Assert.IsType<TestType1>(results["Task 1"]);
                Assert.IsType<TestType2>(results["Task 2"]);
                Assert.IsType<TestType3>(results["Task 3"]);
            }
        }

        public class WithAnonymousObjects
        {

            [Fact]
            public async Task should_accept_anonymous_objects()
            {
                Dictionary<string, object> results = await TaskUtils.AllDict(new
                {
                    Task1 = getType1(),
                    Task2 = getType2(),
                    NonTask = 1
                });

                Assert.NotNull(results["Task1"] as TestType1);
                Assert.NotNull(results["Task2"] as TestType2);
                // Assert.Equal(1, results["NonTask"]);
                // Assert.False(results.ContainsKey("NonTask"));

                Assert.IsType<TestType1>(results["Task1"]);
                Assert.IsType<TestType2>(results["Task2"]);
            }
        }
    }
}
