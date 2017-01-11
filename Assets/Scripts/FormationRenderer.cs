using com.eidu.util;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.eidu.counting.formation
{

    public class FormationRenderer : MonoBehaviour
    {

        public GameObject itemToShow;

        public GameObject container;

        public InputField widthInput;
        public InputField heightInput;
        public InputField itemCountInput;

        public float distanceToNextItem = 0.05f;

        private List<GameObject> itemList;

        private int containerWidth = 900;
        private int containerHeight = 600;
        private int itemCount = 5;


        private void Start()
        {
            itemList = new List<GameObject>();
        }

        public void OnHorizontalLineFormationClick()
        {
            if (itemToShow != null)
            {
                List<ObjectInfo> objectsInformation = FormationUtility.GetHorizontalLineFormationObjectsInformation(containerWidth, containerHeight, itemCount);

                RenderObjects(objectsInformation);
            }
        }

        public void OnCircleFormationClick()
        {
            if (itemToShow != null)
            {
                List<ObjectInfo> objectsInformation = FormationUtility.GetCircleFormationObjectsInformation(containerWidth, containerHeight, itemCount);

                RenderObjects(objectsInformation);
            }
        }

        public void OnGridFormationClick()
        {
            if (itemToShow != null)
            {
                List<ObjectInfo> objectsInformation = FormationUtility.GetGridFormationObjectsInformation(containerWidth, containerHeight, itemCount);

                RenderObjects(objectsInformation);
            }
        }

        public void OnRandomFormationClick()
        {
            if(itemToShow != null)
            {
                List<ObjectInfo> objectInformation = FormationUtility.GetRandomFormationObjectsInformation(containerWidth, containerHeight, itemCount);

                RenderObjects(objectInformation);
            }
        }

        public void RenderObjects(List<ObjectInfo> objectsInformation)
        {
            RectTransform rectTransform = container.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(containerWidth, containerHeight);
            if (itemToShow != null)
            {
                DeleteItems();

                if (objectsInformation.Count > 0)
                {
                    ObjectInfo firstObject = objectsInformation[0];

                    Vector3 scaleSize = FormationUtility.GetScaleSize(itemToShow, firstObject.Width);

                    foreach (ObjectInfo objectInfo in objectsInformation)
                    {
                        GameObject currentItem = GameObject.Instantiate(itemToShow);
                        currentItem.transform.parent = container.transform;
                        currentItem.transform.localPosition = objectInfo.Position;

                        currentItem.transform.localScale = scaleSize;

                        itemList.Add(currentItem);
                    }
                }
            }
        }


        public void ParseContainerWidthValue()
        {

            string value = widthInput.text;
            int parsedValue;
            bool success = int.TryParse(value, out parsedValue);

            if (success)
            {
                containerWidth = parsedValue;
            }
        }


        public void ParseContainerHeightValue()
        {
            string value = heightInput.text;
            int parsedValue;
            bool success = int.TryParse(value, out parsedValue);

            if (success)
            {
                containerHeight = parsedValue;
            }
        }


        public void ParseItemCountValue()
        {
            string value = itemCountInput.text;
            int parsedValue;
            bool success = int.TryParse(value, out parsedValue);

            if (success)
            {
                itemCount = parsedValue;
            }
        }


        private void DeleteItems()
        {
            foreach (GameObject item in itemList)
            {
                GameObject.Destroy(item);
            }

            itemList = new List<GameObject>();
        }
    }
}