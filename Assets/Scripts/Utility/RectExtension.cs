using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.eidu.util
{
    public static class RectExtension
    {

        /// <summary>
        /// Extends the rect struct with the functionality to check if
        /// one rect contains the other given rect.
        /// </summary>
        /// <param name="surroundingRect">The rect which shall contain the other given rect.</param>
        /// <param name="other">The other rect which shall be contained by the surrounding rect.</param>
        /// <returns>true is surroundingRect completly contains the other rect. </returns>
        public static bool Contains(this Rect surroundingRect, Rect other)
        {

            Vector2 leftTop = new Vector2(other.x, -other.y);
            Vector2 rightTop = new Vector2(other.x + other.width, -other.y);
            Vector2 leftBottom = new Vector2(other.x, -other.y + other.height);
            Vector2 rightBottom = new Vector2(other.x + other.width, -other.y + other.height);

            surroundingRect.x -= 1f;
            surroundingRect.y -= 1f;
            surroundingRect.width += 2f;
            surroundingRect.height += 2f;



            bool containsOtherRect = surroundingRect.Contains(leftTop) && surroundingRect.Contains(rightTop)
                        && surroundingRect.Contains(leftBottom) && surroundingRect.Contains(rightBottom);

            return containsOtherRect;
        }
    }
}
