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
            var startNodeindex = Array.FindIndex(fromIds, index => index == startNodeId);
           
            // If Not Found StartNodeId
            if (startNodeindex < 0)
            {
                throw new ArgumentException(nameof(startNodeId));
            }

            // Get NextNodeId from toIds
            var nextNodeId = toIds[startNodeindex];

            // Check for NextNodeId index from fromIds
            var NextNodeIndex = Array.FindIndex(fromIds, index => index == nextNodeId);

            // Check If Recursive loop
            if (NextNodeIndex > 0 && toIds[NextNodeIndex] == startNodeId)
            {
                return toIds[startNodeindex];
            }

            // return lastIndex
            var lastIndex = FindNetworkEndPoint(nextNodeId, fromIds, toIds);

            return lastIndex;

        }
    }
}
