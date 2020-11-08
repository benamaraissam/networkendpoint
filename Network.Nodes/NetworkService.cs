using System;
using System.Linq;

namespace Network.Nodes
{
    public class NetworkService
    {
        /// <summary>
        /// Find Network EndPoint
        /// </summary>
        /// <param name="startNodeId"></param>
        /// <param name="fromIds"></param>
        /// <param name="toIds"></param>
        /// <returns name="lastIndex"></returns>
        public int FindNetworkEndPoint(int startNodeId, int[] fromIds, int[] toIds)
        {
            // Index Of StartNodeId from fromIds
            var startNodeindex = Array.FindIndex(fromIds, value => value == startNodeId);

            // If Not Found StartNodeId
            if (startNodeindex < 0)
            {
                return startNodeId;
            }

            // Get NextNodeId from toIds
            var nextNodeId = toIds[startNodeindex];

            // Check for NextNodeIndex index from fromIds
            var NextNodeIndex = Array.FindIndex(fromIds, value => value == nextNodeId);

            // Check If Recursive loop
            if (NextNodeIndex > 0 && toIds[NextNodeIndex] == startNodeId)
            {
                return nextNodeId;
            }

            // return lastIndex
            var lastNodeId = FindNetworkEndPoint(nextNodeId, fromIds, toIds);

            return lastNodeId;

        }
    }
}
