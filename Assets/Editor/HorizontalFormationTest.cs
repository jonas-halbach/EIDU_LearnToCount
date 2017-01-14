using com.eidu.util;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace com.eidu.counting.formation.tests
{
    public class HorizontalFormationTest
    {

        [Test]
        public void HorizontalLineFormationTest()
        {
            int containerWidth = 300;
            int containerHeight = 100;
            int itemCount = 10;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetHorizontalLineFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);

            foreach (ObjectInfo objectInfo in objectsInfoList)
            {
                Assert.AreEqual(-35, objectInfo.Position.y);
            }
        }

        [Test]
        public void HorizontalLineFormationOverlappingTest()
        {
            int containerWidth = 300;
            int containerHeight = 100;
            int itemCount = 10;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetHorizontalLineFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }

        [Test]
        public void OneItemContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetHorizontalLineFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }

        [Test]
        public void TenItemContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetHorizontalLineFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }

        [Test]
        public void HundredItemContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetHorizontalLineFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }
    }
}
