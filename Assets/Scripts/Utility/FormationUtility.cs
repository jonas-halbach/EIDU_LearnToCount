using com.eidu.counting.formation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.eidu.util
{
    public class FormationUtility
    {

        public static List<ObjectInfo> GetHorizontalLineFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
        {
            List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

            int horizontalCenter = containerHeight / 2;

            float itemDistance = containerWidth / (float)numberOfItems;

            float size = Mathf.Min(itemDistance, containerHeight);

            for (int i = 0; i < numberOfItems; i++)
            {
                float x = itemDistance / 2 + i * itemDistance;
                ObjectInfo currentObjectInfo = new ObjectInfo();
                currentObjectInfo.Position = new Vector2(x, -horizontalCenter);
                currentObjectInfo.Height = Mathf.Min(size, Constants.MAX_ITEM_SIZE);
                currentObjectInfo.Width = Mathf.Min(size, Constants.MAX_ITEM_SIZE);
                objectsInformationList.Add(currentObjectInfo);
            }

            return objectsInformationList;
        }


        public static List<ObjectInfo> GetCircleFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
        {
            List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

            float maxRadius = Mathf.Min(containerWidth, containerHeight) / 2;

            float radius = Mathf.Min(maxRadius - maxRadius / 2, Mathf.Abs(maxRadius - Constants.MAX_ITEM_SIZE));

            float anglDistance = 360 / (float)numberOfItems;

            if (numberOfItems == 1)
            {
                ObjectInfo currentObjectInfo = new ObjectInfo();
                currentObjectInfo.Position = new Vector2(containerWidth / 2, -containerHeight / 2);
                currentObjectInfo.Width = radius;
                currentObjectInfo.Height = radius;
                objectsInformationList.Add(currentObjectInfo);
            }
            else
            {
                float itemSize = GetMaxItemDistanceCircle(anglDistance, radius);

                for (int i = 0; i < numberOfItems; i++)
                {
                    float currentAngle = i * anglDistance;
                    ObjectInfo currentObjectInfo = new ObjectInfo();
                    Vector2 circlePos = GetObjectPositionByRadiusAngle(radius, currentAngle);
                    circlePos.x += containerWidth / 2;
                    circlePos.y -= containerHeight / 2;
                    currentObjectInfo.Position = circlePos;

                    currentObjectInfo.Width = Mathf.Min(itemSize, Constants.MAX_ITEM_SIZE);
                    currentObjectInfo.Height = Mathf.Min(itemSize, Constants.MAX_ITEM_SIZE);

                    objectsInformationList.Add(currentObjectInfo);
                }
            }

            return objectsInformationList;
        }


        public static List<ObjectInfo> GetGridFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
        {
            List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

            Vector2 gridDimension = GetGridDimensions(containerWidth, containerHeight, numberOfItems);

            int itemsAdded = 0;

            float resultingWidth = Mathf.Min(containerWidth / gridDimension.x, containerHeight / gridDimension.y);

            int resultingDimensionX = (int)(containerWidth / resultingWidth);

            while (itemsAdded < numberOfItems)
            {
                int row = itemsAdded / resultingDimensionX;
                int col = itemsAdded % resultingDimensionX;

                ObjectInfo currentObjectInfo = new ObjectInfo();
                currentObjectInfo.Position = new Vector2(col * resultingWidth + resultingWidth / 2, -row * resultingWidth - resultingWidth / 2);
                currentObjectInfo.Width = Mathf.Min(resultingWidth, Constants.MAX_ITEM_SIZE);
                currentObjectInfo.Height = Mathf.Min(resultingWidth, Constants.MAX_ITEM_SIZE);

                objectsInformationList.Add(currentObjectInfo);

                itemsAdded++;
            }

            return objectsInformationList;
        }


        public static List<ObjectInfo> GetRandomFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
        {
            List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

            float freeFieldPercentage = 0.9f;

            //calculating the number of free field needed if freeFieldPercentage of the fields shall be free
            int neededFields = Mathf.FloorToInt(-numberOfItems / (freeFieldPercentage - 1));

            Vector2 dimensions = GetGridDimensions(containerWidth, containerHeight, neededFields);
            List<Pair> coordinates = new List<Pair>();

            float itemSize = Mathf.Min(containerWidth / dimensions.x, containerHeight / dimensions.y);

            int resultingDimensionX = (int)(containerWidth / itemSize);
            int resultingDimensionY = (int)(containerHeight / itemSize);

            while (coordinates.Count < numberOfItems)
            {
                int x = (int)(Random.value * resultingDimensionX);
                int y = (int)(Random.value * resultingDimensionY);

                Pair currentCoordinate = new Pair(x, y);
                if(!coordinates.Contains(currentCoordinate))
                {
                    coordinates.Add(currentCoordinate);

                    ObjectInfo currentObjectInfo = new ObjectInfo();
                    currentObjectInfo.Position = new Vector3(x * itemSize + itemSize / 2, -y * itemSize - itemSize / 2);
                    currentObjectInfo.Width = itemSize;
                    currentObjectInfo.Height = itemSize;

                    objectsInformationList.Add(currentObjectInfo);
                }
            }

            return objectsInformationList;
        }


        public static Vector2 GetGridDimensions(int containerWidth, int containerHeight, int numberOfItems)
        {
            Vector2 aspectRatio = MathHelper.GetAspectRatio(containerWidth, containerHeight);

            bool addColumn = aspectRatio.x < aspectRatio.y;

            

            while (aspectRatio.x * aspectRatio.y < numberOfItems)
            {
                if (addColumn)
                {
                    aspectRatio.x += 1;
                }
                else
                {
                    aspectRatio.y += 1;
                }
                addColumn = !addColumn;
            }

            return aspectRatio;
        }

        public static float GetMaxItemDistanceCircle(float angleDistance, float radius)
        {
            float oppositeLeg = radius * Mathf.Sin(angleDistance * Mathf.Deg2Rad);
            float adjacentLeg = radius * Mathf.Cos(angleDistance * Mathf.Deg2Rad);

            float p = radius - adjacentLeg;

            return Mathf.Min(oppositeLeg, p);
        }

        public static Vector2 GetObjectPositionByRadiusAngle(float radius, float angle)
        {
            float x = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);

            return new Vector2(x, y);
        }

        public static Vector3 GetScaleSize(GameObject objectToScale, float resultingWidth)
        {
            Vector3 scaleSize = Vector3.one;

            SpriteRenderer spriteRenderer = objectToScale.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                Vector3 currentSpriteSize = spriteRenderer.sprite.bounds.size;
                scaleSize *= resultingWidth / currentSpriteSize.x;
            }

            return scaleSize;
        }
    }
}
