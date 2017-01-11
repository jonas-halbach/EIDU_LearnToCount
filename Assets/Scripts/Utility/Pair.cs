using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.eidu.util
{
    /// <summary>
    /// Class to store a pair of variables.
    /// Copied and slightly modified from:
    /// http://stackoverflow.com/questions/4354596/storing-pair-of-ints-on-the-list
    /// </summary>
    class Pair
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Pair(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (Object.ReferenceEquals(this, obj))
            {
                isEqual = true;
            }
            else
            {
                Pair instance = obj as Pair;
                if (instance != null)
                {
                    isEqual = this.X == instance.X && this.Y == instance.Y;
                }
            }
            return isEqual;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }
    }
}