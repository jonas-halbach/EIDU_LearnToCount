using com.eidu.counting.formation;
using System.Collections.Generic;
using UnityEngine;

namespace com.eidu.util
{

    /// <summary>
    /// This class stores some methods which calculate the position of items for different given formations. 
    /// </summary>
    public class FormationUtility
    {

        /// <summary>
        /// Calculating a list of object-information with position, width and height of the objects for items positioned 
        /// on a horizontal line in the central height of the container.
        /// </summary>
        /// <param name="containerWidth">width of the container which shall store the calculated items.</param>
        /// <param name="containerHeight">height of the container which shall store the calculated items.</param>
        /// <param name="numberOfItems">the number of items which shall be stored in the container.</param>
        /// <returns>a list of object information specifying the position, width and height of a an amount of items arranged on a
        /// horizontal line in in central height of the container</returns>
        public static List<ObjectInfo> GetHorizontalLineFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
        {
            List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

            float horizontalCenter = containerHeight / 2f;

            float itemDistance = containerWidth / (float)numberOfItems;

            float size = Mathf.Min(itemDistance, containerHeight);

            size = Mathf.Min(size, Constants.MAX_ITEM_SIZE);

            float xBorderDistance = (containerWidth - numberOfItems * size) / 2; 

            for (int i = 0; i < numberOfItems; i++)
            {
                float x = xBorderDistance + i * size;
                ObjectInfo currentObjectInfo = new ObjectInfo();
                currentObjectInfo.Position = new Vector2(x, -horizontalCenter + size / 2);
                currentObjectInfo.Height = size;
                currentObjectInfo.Width = size;
                objectsInformationList.Add(currentObjectInfo);
            }

            return objectsInformationList;
        }


        /// <summary>
        /// Calculating a list of object-information with position, width and height of the objects for items positioned 
        /// in a circular formation.
        /// </summary>
        /// <param name="containerWidth">width of the container which shall store the calculated items.</param>
        /// <param name="containerHeight">height of the container which shall store the calculated items.</param>
        /// <param name="numberOfItems">the number of items which shall be stored in the container.</param>
        /// <returns>a list of object information specifying the position, width and height of a an amount of items arranged in a
        /// circular formation</returns>
        public static List<ObjectInfo> GetCircleFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
        {
            List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

            float maxRadius = Mathf.Min(containerWidth, containerHeight) / 2;

            float radius = Mathf.Min(maxRadius - maxRadius / 2, Mathf.Abs(maxRadius - Constants.MAX_ITEM_SIZE));

            float angleDistance = 360 / (float)numberOfItems;

            if (numberOfItems == 1)
            {
                ObjectInfo currentObjectInfo = new ObjectInfo();
                currentObjectInfo.Position = new Vector2(containerWidth / 2 - maxRadius / 2,  -containerHeight / 2 + maxRadius / 2);
                currentObjectInfo.Width = maxRadius;
                currentObjectInfo.Height = maxRadius;
                objectsInformationList.Add(currentObjectInfo);
            }
            else
            {
                float itemSize = GetMaxItemDistanceCircle(angleDistance, radius);
                itemSize = Mathf.Min(itemSize, Constants.MAX_ITEM_SIZE);


                for (int i = 0; i < numberOfItems; i++)
                {
                    float currentAngle = i * angleDistance;
                    ObjectInfo currentObjectInfo = new ObjectInfo();
                    Vector2 circlePos = GetObjectPositionByRadiusAngle(radius, currentAngle);
                    circlePos.x += containerWidth / 2 -itemSize / 2;
                    circlePos.y -= containerHeight / 2 - itemSize / 2;
                    currentObjectInfo.Position = circlePos;

                    currentObjectInfo.Width = itemSize;
                    currentObjectInfo.Height = itemSize;

                    objectsInformationList.Add(currentObjectInfo);
                }
            }

            return objectsInformationList;
        }


        /// <summary>
        /// Calculating a list of object-information with position, width and height of the objects for items positioned in a grid structure.
        /// </summary>
        /// <param name="containerWidth">width of the container which shall store the calculated items.</param>
        /// <param name="containerHeight">height of the container which shall store the calculated items.</param>
        /// <param name="numberOfItems">the number of items which shall be stored in the container.</param>
        /// <returns>a list of object information specifying the position, width and height of a an amount of items arranged in a
        /// grid structure</returns>
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
                currentObjectInfo.Position = new Vector2(col * resultingWidth, -row * resultingWidth);
                currentObjectInfo.Width = Mathf.Min(resultingWidth, Constants.MAX_ITEM_SIZE);
                currentObjectInfo.Height = Mathf.Min(resultingWidth, Constants.MAX_ITEM_SIZE);

                objectsInformationList.Add(currentObjectInfo);

                itemsAdded++;
            }

            return objectsInformationList;
        }

        /// <summary>
        /// Calculating a list of object-information with position, width and height of the objects for randomly positioned items.
        /// </summary>
        /// <param name="containerWidth">width of the container which shall store the calculated items.</param>
        /// <param name="containerHeight">height of the container which shall store the calculated items.</param>
        /// <param name="numberOfItems">the number of items which shall be stored in the container.</param>
        /// <returns>a list of object information specifying the position, width and height of a randomly arranged amount of items</returns>
        public static List<ObjectInfo> GetRandomFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
        {
            List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

            Rect containerRect = new Rect(0, 0, containerWidth, containerHeight);

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
                float randomX = Random.value;
                float randomY = Random.value;

                int x = (int)(Mathf.Clamp(randomX, 0.0001f, 0.9999f) * resultingDimensionX);
                int y = (int)(Mathf.Clamp(randomY, 0.0001f, 0.9999f) * resultingDimensionY);
                //int x = (int)(randomX * resultingDimensionX);
                //int y = (int)(randomY * resultingDimensionY);
                Pair currentCoordinate = new Pair((int)x, (int)y);
                if (!coordinates.Contains(currentCoordinate))
                {
                    

                    ObjectInfo currentObjectInfo = new ObjectInfo();
                    currentObjectInfo.Position = new Vector3(x * itemSize, -y * itemSize);

                    if (containerRect.Contains(new Vector2(currentObjectInfo.Position.x + itemSize, -currentObjectInfo.Position.y - itemSize)))
                    {
                        coordinates.Add(currentCoordinate);
                        currentObjectInfo.Width = itemSize;
                        currentObjectInfo.Height = itemSize;

                        objectsInformationList.Add(currentObjectInfo);
                    }
                }
            }

            return objectsInformationList;
        }


        /// <summary>
        /// Depending on the  apect ratio this function returns a vector specifying how many grid cells
        /// in x and y direction a grid must have to store the amount of items specified by the parameter
        /// numberOfItems
        /// </summary>
        /// <param name="containerWidth">the width of the container which shall store the items</param>
        /// <param name="containerHeight">the height of the container which shall store the items</param>
        /// <param name="numberOfItems">the number of items which shall be stored in the grid</param>
        /// <returns>A Vector specifying the optimal grid dimension in x- and y-direction</returns>
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


        /// <summary>
        /// This function returns the smaller value of opposite leg and radius - adjacent leg of
        /// two ciicle points
        /// </summary>
        /// <param name="angleDistance">the angle in degrees defining the triangle.</param>
        /// <param name="radius">the radius of the circle</param>
        /// <returns>the smallest of the values opposit leg or radius - adjacent leg</returns>
        public static float GetMaxItemDistanceCircle(float angleDistance, float radius)
        {
            float oppositeLeg = radius * Mathf.Sin(angleDistance * Mathf.Deg2Rad);
            float adjacentLeg = radius * Mathf.Cos(angleDistance * Mathf.Deg2Rad);

            float p = radius - adjacentLeg;

            float preferredSize = Mathf.Min(oppositeLeg, p);

            preferredSize = Mathf.Abs(preferredSize) < 0.0001f ? Mathf.Max(oppositeLeg, p) : preferredSize;

            return preferredSize;
        }


        /// <summary>
        /// This function calculates a position, for a point on a circle in a 2d-space
        /// by the circles radius and a specified angle in degrees.
        /// </summary>
        /// <param name="radius">Radius of the given circle.</param>
        /// <param name="angle">The angle (in degrees) for calculating the point.</param>
        /// <returns>A vector which gives the point on the circle.</returns>
        public static Vector2 GetObjectPositionByRadiusAngle(float radius, float angle)
        {
            float x = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);

            return new Vector2(x, y);
        }

        /// <summary>
        /// This function return the scaling-values for a gameobject, with a unity sprite component from its current width to
        /// a selected width
        /// </summary>
        /// <param name="objectToScale">game object with a sprite component </param>
        /// <param name="resultingWidth">the width the sprite shall have after scaling</param>
        /// <returns>A vector with the scaling information</returns>
        public static Vector3 GetScaleSize(GameObject objectToScale, float resultingWidth)
        {
            Vector3 scaleSize = Vector3.one;

            SpriteRenderer spriteRenderer = objectToScale.GetComponentInChildren<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                Vector3 currentSpriteSize = spriteRenderer.sprite.bounds.size;
                scaleSize *= resultingWidth / currentSpriteSize.x;
            }

            return scaleSize;
        }
    }
}
