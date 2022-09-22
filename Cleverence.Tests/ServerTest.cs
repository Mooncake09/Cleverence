using Cleverence;

namespace Cleverence.Tests
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        [DataRow(10000)]
        public void ServerTasks(int value)
        {
            Server.ResetCountToZero();

            var tasks = new List<Task>();

            for (int i = 0; i < value; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => Server.AddToCount(1)));
                tasks.Add(Task.Factory.StartNew(() => Server.GetCount()));
            }

            Task.WaitAll(tasks.ToArray());

            Assert.AreEqual(value, Server.GetCount());
        }

        [TestMethod]
        [DataRow(10000)]
        public void ServerParallel(int value)
        {
            Server.ResetCountToZero();

            var parallelLoopResult = Parallel.For(0, value, i =>
            {
                Server.AddToCount(1);
                Server.GetCount();
            });

            if (parallelLoopResult.IsCompleted)
                Assert.AreEqual(value, Server.GetCount());
        }
    }
}