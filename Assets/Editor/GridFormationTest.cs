using com.eidu.util;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace com.eidu.counting.formation.tests
{
    public class GridFormationTest
    {
        [Test]
        public void ZeroItemsTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 0;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);
        }


        [Test]
        public void OneItemTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);

            Assert.AreEqual(0, objectsInfoList[0].Position.x);
            Assert.AreEqual(0, objectsInfoList[0].Position.y);
        }


        [Test]
        public void HeightGreaterWidthTest()
        {
            int containerWidth = 50;
            int containerHeight = 100;
            int itemCount = 4;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);

            Vector2[] expectedPositions = new Vector2[4];
            expectedPositions[0] = new Vector2(0.0f, 0.0f);
            expectedPositions[1] = new Vector2(25.0f, 0.0f);
            expectedPositions[2] = new Vector2(0.0f, -25.0f);
            expectedPositions[3] = new Vector2(25.0f, -25.0f);

            for(int i = 0; i < objectsInfoList.Count; i++)
            {
                ObjectInfo objectInfo = objectsInfoList[i];
                Assert.AreEqual(expectedPositions[i].x, objectInfo.Position.x);
                Assert.AreEqual(expectedPositions[i].y, objectInfo.Position.y);

                objectInfo.Width = 25;
            }
        }

        [Test]
        public void HeightGreaterWidthOverlapTest()
        {
            int containerWidth = 50;
            int containerHeight = 100;
            int itemCount = 4;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }

        [Test]
        public void OneItemContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }

        [Test]
        public void TenItemContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 10;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }

        [Test]
        public void HundredItemContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 100;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }
    }
}
