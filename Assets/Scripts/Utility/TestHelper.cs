using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.eidu.counting.formation.tests
{
    /// <summary>
    /// This class implements methods which can be usefull for automated testing.
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// This method checks if items in the given objectsInfoList overlap.
        /// </summary>
        /// <param name="objectsInfoList">List of object information which shall be
        /// checked if some objects overlap.</param>
        public static void OverLappingTest(List<ObjectInfo> objectsInfoList)
        {
            List<Rect> boundingRects = new List<Rect>();
            foreach (ObjectInfo objectInfo in objectsInfoList)
            {
                Rect boundingRect = new Rect(objectInfo.Position.x, objectInfo.Position.y, objectInfo.Width, objectInfo.Height);
                boundingRects.Add(boundingRect);
            }

            for (int i = 0; i < boundingRects.Count; i++)
            {
                for (int j = i + 1; j < boundingRects.Count; j++)
                {
                    Assert.IsFalse(boundingRects[i].Overlaps(boundingRects[j]));
                }
            }
        }
    }
}
