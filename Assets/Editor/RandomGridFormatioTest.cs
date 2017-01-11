using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.eidu.counting.formation.tests;
using NUnit.Framework;
using com.eidu.util;

namespace com.eidu.counting.formation.tests
{
    public class RandomGridFormatioTest {

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
    }
}
