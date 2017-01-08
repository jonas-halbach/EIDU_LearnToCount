using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationUtility {

    public static List<ObjectInfo> GetHorizontalLineFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
    {
        List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

        int horizontalCenter = containerHeight / 2;

        int itemDistance = containerWidth / numberOfItems;

        for(int i = 0; i < numberOfItems; i++)
        {
            float x = itemDistance / 2 + i * itemDistance;
            ObjectInfo currentObjectInfo = new ObjectInfo();
            currentObjectInfo.Position = new Vector2(x, -horizontalCenter);
            currentObjectInfo.Height = itemDistance;
            currentObjectInfo.Width = itemDistance;
            objectsInformationList.Add(currentObjectInfo);
        }

        return objectsInformationList;
    }

    public static List<ObjectInfo> GetCircleFormationObjectsInformation(int containerWidth, int containerHeight, int numberOfItems)
    {
        List<ObjectInfo> objectsInformationList = new List<ObjectInfo>();

        float radius = Mathf.Min(containerWidth, containerHeight) / 3;

        float anglDistance = 360 / numberOfItems;

        float itemSize = GetMaxItemDistanceCircle(anglDistance, radius);

        for (int i = 0; i < numberOfItems; i++)
        {
            float currentAngle = i * anglDistance;
            ObjectInfo currentObjectInfo = new ObjectInfo();
            Vector2 circlePos = GetObectPositionByRadiusAngle(radius, currentAngle);
            circlePos.x += containerWidth / 2;
            circlePos.y -= containerHeight / 2;
            currentObjectInfo.Position = circlePos;

            currentObjectInfo.Width = itemSize;
            currentObjectInfo.Height = itemSize;

            objectsInformationList.Add(currentObjectInfo);
        }

        return objectsInformationList;
    }

    public static float GetMaxItemDistanceCircle(float angleDistance, float radius)
    {
        float oppositeLeg = radius * Mathf.Sin(angleDistance * Mathf.Deg2Rad);
        float adjacentLeg = radius * Mathf.Cos(angleDistance * Mathf.Deg2Rad);

        float p = radius - adjacentLeg;

        float maxItemDistance = Mathf.Sqrt(Mathf.Pow(p, 2) + Mathf.Pow(oppositeLeg, 2));

        maxItemDistance = Mathf.Abs(maxItemDistance) < 0.001 ? radius : maxItemDistance;

        return maxItemDistance;
    }

    public static Vector2 GetObectPositionByRadiusAngle(float radius, float angle)
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
