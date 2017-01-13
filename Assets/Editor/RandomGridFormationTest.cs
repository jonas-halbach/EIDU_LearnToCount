using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.eidu.counting.formation.tests;
using NUnit.Framework;
using com.eidu.util;

namespace com.eidu.counting.formation.tests
{
    public class RandomGridFormationTest {

        [Test]
        public void ZeroItemsTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 0;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);
        }

        [Test]
        public void OneItemTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);
        }

        [Test]
        public void HundredItemsTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 100;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            Assert.AreEqual(objectsInfoList.Count, itemCount);
        }


        [Test]
        public void ZeroItemsOverlappingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 0;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }

        [Test]
        public void OneItemOverlappingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }

        [Test]
        public void HundredItemsOverlappingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 100;

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.OverLappingTest(objectsInfoList);
        }

        [Test]
        public void OneItemContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 1;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }

        [Test]
        public void TenItemsContainingTest()
        {
            int containerWidth = 100;
            int containerHeight = 100;
            int itemCount = 10;

            Rect containerBounds = new Rect(0, 0, containerWidth, containerHeight);

            List<ObjectInfo> objectsInfoList = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

            TestHelper.CheckIfAllObjectsInsideContainer(containerBounds, objectsInfoList);
        }
    }
}
