using System;
using System.Threading.Tasks;
using Xunit;

namespace TaskUtils.Tests
{
    public class TaskUtils_All_Tests
    {
        static Task<long>   get1() => Task.FromResult(1L);
        static Task<float>  get2() => Task.FromResult(2F);
        static Task<double> get3() => Task.FromResult(3D);

        static Task<long>   get4() => Task.FromResult(4L);
        static Task<float>  get5() => Task.FromResult(5F);
        static Task<double> get6() => Task.FromResult(6D);

        static Task<long>   get7() => Task.FromResult(7L);
        static Task<float>  get8() => Task.FromResult(8F);
        static Task<double> get9() => Task.FromResult(9D);

        [Fact]
        public async Task TesttArity1()
        {
            Tuple<long> results = await TaskUtils.All(get1());

            Assert.Equal(1, results.Item1);
        }

        [Fact]
        public async Task TestArity2()
        {
            var (_1, _2) = await TaskUtils.All(
                get1(),
                get2()
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
        }

        [Fact]
        public async Task TestArity3()
        {
            var (_1, _2, _3) = await TaskUtils.All(
                get1(),
                get2(),
                get3()
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
            Assert.Equal(3, _3);
        }

        [Fact]
        public async Task TestArity4()
        {
            var (_1, _2, _3, _4) = await TaskUtils.All(
                get1(),
                get2(),
                get3(),
                get4()
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
            Assert.Equal(3, _3);
            Assert.Equal(4, _4);
        }

        [Fact]
        public async Task TestArity5()
        {
            var (_1, _2, _3, _4, _5) = await TaskUtils.All(
                get1(),
                get2(),
                get3(),
                get4(),
                get5()
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
            Assert.Equal(3, _3);
            Assert.Equal(4, _4);
            Assert.Equal(5, _5);
        }

        [Fact]
        public async Task TestArity6()
        {
            var (_1, _2, _3, _4, _5, _6) = await TaskUtils.All(
                get1(),
                get2(),
                get3(),
                get4(),
                get5(),
                get6()
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
            Assert.Equal(3, _3);
            Assert.Equal(4, _4);
            Assert.Equal(5, _5);
            Assert.Equal(6, _6);
        }

        [Fact]
        public async Task TestArity7()
        {
            var (_1, _2, _3, _4, _5, _6, _7) = await TaskUtils.All(
                get1(),
                get2(),
                get3(),
                get4(),
                get5(),
                get6(),
                get7()
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
            Assert.Equal(3, _3);
            Assert.Equal(4, _4);
            Assert.Equal(5, _5);
            Assert.Equal(6, _6);
            Assert.Equal(7, _7);
        }

        [Fact]
        public async Task TestArity8()
        {
            var (_1, _2, _3, _4, _5, _6, _7, _8) = await TaskUtils.All(
                get1(),
                get2(),
                get3(),
                get4(),
                get5(),
                get6(),
                get7(),
                get8()
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
            Assert.Equal(3, _3);
            Assert.Equal(4, _4);
            Assert.Equal(5, _5);
            Assert.Equal(6, _6);
            Assert.Equal(7, _7);
            Assert.Equal(8, _8);
        }

        [Fact]
        public async Task TestArity9()
        {
            var (_1, _2, _3, _4, _5, _6, _7, (_8, _9)) = await TaskUtils.All(
                get1(),
                get2(),
                get3(),
                get4(),
                get5(),
                get6(),
                get7(),
                TaskUtils.All(
                    get8(),
                    get9()
                )
            );

            Assert.Equal(1, _1);
            Assert.Equal(2, _2);
            Assert.Equal(3, _3);
            Assert.Equal(4, _4);
            Assert.Equal(5, _5);
            Assert.Equal(6, _6);
            Assert.Equal(7, _7);
            Assert.Equal(8, _8);
            Assert.Equal(9, _9);
        }
    }
}
