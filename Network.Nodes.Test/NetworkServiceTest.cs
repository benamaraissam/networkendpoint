using NUnit.Framework;

namespace Network.Nodes.Test
{
    [TestFixture]
    public class NetworkServiceTest
    {
        private NetworkService _networkService;

        [SetUp]
        public void Setup()
        {
            _networkService = new NetworkService();
        }

        [TestCase(2, new int[] { 7, 1, 3, 4, 2, 6, 9 }, new int[] { 3, 3, 4, 6, 6, 9, 5 }, 5)]
        [TestCase(3, new int[] { 7, 1, 3, 4, 2, 6, 9 }, new int[] { 3, 3, 4, 6, 6, 9, 5 }, 5)]
        [TestCase(1, new int[] { 7, 1, 3, 4, 2, 6, 9 }, new int[] { 3, 3, 4, 6, 6, 9, 5 }, 5)]
        [TestCase(1, new int[] { 1, 3, 4, 7}, new int[] { 3, 4, 7, 4 }, 7)]
        public void FindNetworkEndPoint_Test(int startNodeId, int[] fromIds, int[] toIds, int lastIndex)
        {
           var result = _networkService.FindNetworkEndPoint(startNodeId, fromIds, toIds);
           Assert.AreEqual(result, lastIndex);
        }
    }
}
