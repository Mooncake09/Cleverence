using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverence.Tests
{
    [TestClass]
    public class AsyncCallerTest
    {
        [TestMethod]
        [DataRow(2000)]
        [DataRow(5000)]
        [DataRow(7000)]
        public void Invoke_true(int miliseconds)
        {
            var eventHandler = new EventHandler((sender, args) =>
            {
                Console.WriteLine("Doing some work 1000 miliseconds");
                Thread.Sleep(1000);
            });

            var asyncCaller = new AsyncCaller(eventHandler);
            var isCompletedOnTime = asyncCaller.Invoke(miliseconds, null, EventArgs.Empty);

            Assert.IsTrue(isCompletedOnTime);
        }

        [TestMethod]
        [DataRow(700)]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(999)]
        [DataRow(200)]
        public void Invoke_false(int miliseconds)
        {
            var eventHandler = new EventHandler((sender, args) =>
            {
                Console.WriteLine("Doing some work 1000 miliseconds");
                Thread.Sleep(1000);
            });

            var asyncCaller = new AsyncCaller(eventHandler);
            var isCompletedOnTime = asyncCaller.Invoke(miliseconds, null, EventArgs.Empty);

            Assert.IsFalse(isCompletedOnTime);
        }
    }
}
