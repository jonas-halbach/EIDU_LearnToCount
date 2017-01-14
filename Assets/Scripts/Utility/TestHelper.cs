using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using com.eidu.util;

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
            List<Rect> boundingRects = ConverObjectInfoToRectList(objectsInfoList);

            for (int i = 0; i < boundingRects.Count; i++)
            {
                for (int j = i + 1; j < boundingRects.Count; j++)
                {
                    Assert.IsFalse(boundingRects[i].Overlaps(boundingRects[j]));
                }
            }
        }


        /// <summary>
        /// Checks if all objects with the properties of objectsToTest are completly inside of container.
        /// </summary>
        /// <param name="container">The bounding rect of the container which shall include the objects
        /// described by objectsToTest</param>
        /// <param name="objectsToTest">A List of objects which shall be completely inside in the container.</param>
        public static void CheckIfAllObjectsInsideContainer(Rect container, List<ObjectInfo> objectsToTest)
        {
            List<Rect> boundingRects = ConverObjectInfoToRectList(objectsToTest);

            Dictionary<Rect, bool> testResults = new Dictionary<Rect, bool>();

            foreach(Rect objectBounds in boundingRects)
            {
                testResults.Add(objectBounds, container.Contains(objectBounds));
            }

            foreach(KeyValuePair<Rect, bool> kvp in testResults)
            {
                Assert.IsTrue(kvp.Value, "Bounding rect.x:" + container.x +
                                        " y: " + container.y +
                                        " width: " + container.width +
                                        " height: " + container.height +
                                        " object rect x: " + kvp.Key.x +
                                        " object rect y: " + kvp.Key.y +
                                        " object rect width: " + kvp.Key.width +
                                        " object rect height: " + kvp.Key.height);
            }
        }


        /// <summary>
        /// Converts a list of ObjectInfo-Objects to Rect-Objects
        /// </summary>
        /// <param name="objectsInfoList">the object list to convert.</param>
        /// <returns>A list of rects describing the bounds of the object given by the
        /// objectsInfoList.</returns>
        public static List<Rect> ConverObjectInfoToRectList(List<ObjectInfo> objectsInfoList)
        {
            List<Rect> boundingRects = new List<Rect>();
            foreach (ObjectInfo objectInfo in objectsInfoList)
            {
                Rect boundingRect = new Rect(objectInfo.Position.x, objectInfo.Position.y, objectInfo.Width, objectInfo.Height);
                boundingRects.Add(boundingRect);
            }

            return boundingRects;
        }
    }
}
