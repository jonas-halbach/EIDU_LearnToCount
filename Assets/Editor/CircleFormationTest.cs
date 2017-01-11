using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using com.eidu.util;
using System.Collections.Generic;

namespace com.eidu.counting.formation.tests
{
    public class CircleFormationTest
    {

        [Test]
        public void OneItemTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);

            Assert.AreEqual(objectsInfoList[0].Position.x, 50);
            Assert.AreEqual(objectsInfoList[0].Position.y, -50);

            Assert.AreEqual(objectsInfoList[0].Width, 25);
        }


        [Test]
        public void TwoItemsTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 2;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);

            Vector2[] expectedPositions = new Vector2[2];
            expectedPositions[0] = new Vector2(50, -25);
            expectedPositions[1] = new Vector2(50, -75);

            for(int i = 0; i < objectsInfoList.Count; i++)
            {
                Assert.AreEqual(expectedPositions[i].x, objectsInfoList[i].Position.x, 0.0001);
                Assert.AreEqual(expectedPositions[i].y, objectsInfoList[i].Position.y, 0.0001);
            }
        }


        [Test]
        public void FourItemsTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 4;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);

            Vector2[] expectedPositions = new Vector2[4];
            expectedPositions[0] = new Vector2(50, -25);
            expectedPositions[1] = new Vector2(75, -50);
            expectedPositions[2] = new Vector2(50, -75);
            expectedPositions[3] = new Vector2(25, -50);


            for (int i = 0; i < objectsInfoList.Count; i++)
            {
                Assert.AreEqual(expectedPositions[i].x, objectsInfoList[i].Position.x, 0.0001);
                Assert.AreEqual(expectedPositions[i].y, objectsInfoList[i].Position.y, 0.0001);
            }
        }


        [Test]
        public void WidthHeightUnequalTest()
        {
            int containerWidth = 50;
            int containerHeight = 100;
            int itemCount = 5;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);
        }

        [Test]
        public void TwoItemsOverlapTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 2;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }


        [Test]
        public void FourItemsOverlapTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 4;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }

        [Test]
        public void OverlappingTest()
        {
            int containerWidth = 500;
            int containerHeight = 500;
            int itemCount = 5;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }
    }
}
