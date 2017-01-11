using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.eidu.util
{
    public class MathHelper
    {


        /// <summary>
        /// Calculating the greatest common devisor.
        /// Copied from: http://stackoverflow.com/questions/10070296/c-sharp-how-to-calculate-aspect-ratio
        /// </summary>
        /// <param name="a">first number for finding the greatest common devisor</param>
        /// <param name="b">first number for finding the greatest common devisor</param>
        /// <returns>the greatest common devisor of a and b</returns>
        public static int GCD(int a, int b)
        {
            int remainder;

            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }


        /// <summary>
        /// Calculating the apect ration of a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>the aspect ratio.</returns>
        public static Vector2 GetAspectRatio(int a, int b)
        {
            int gcd = GCD(a, b);

            return new Vector2(a / gcd, b / gcd);
        }
    }
}