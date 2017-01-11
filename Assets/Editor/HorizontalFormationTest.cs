using com.eidu.util;
using NUnit.Framework;
using System.Collections.Generic;

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
                Assert.AreEqual(objectInfo.Position.y, -50);
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


    }
}
