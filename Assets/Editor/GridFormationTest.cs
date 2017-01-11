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

            Assert.AreEqual(objectsInfoList[0].Position.x, 50);
            Assert.AreEqual(objectsInfoList[0].Position.y, -50);
        }


        [Test]
        public void HeightGreaterWidthTest()
        {
            int containerWidth = 50;
            int containerHeight = 100;
            int itemCount = 4;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);

            Vector2[] awaitedPositions = new Vector2[4];
            awaitedPositions[0] = new Vector2(12.5f, -12.5f);
            awaitedPositions[1] = new Vector2(37.5f, -12.5f);
            awaitedPositions[2] = new Vector2(12.5f, -37.5f);
            awaitedPositions[3] = new Vector2(37.5f, -37.5f);

            for(int i = 0; i < objectsInfoList.Count; i++)
            {
                ObjectInfo objectInfo = objectsInfoList[i];
                Assert.AreEqual(awaitedPositions[i].x, objectInfo.Position.x);
                Assert.AreEqual(awaitedPositions[i].y, objectInfo.Position.y);

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

    }
}
