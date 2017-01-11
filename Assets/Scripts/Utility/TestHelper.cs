using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.eidu.counting.formation.tests
{
    public class TestHelper
    {
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
