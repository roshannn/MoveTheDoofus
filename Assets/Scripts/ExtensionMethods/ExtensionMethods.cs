using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ExtensionMethods
    {
        public static void SetZ(this Vector3 vector, float setZ)
        {
            vector.z = setZ;
        }
        public static void SetX(this Vector3 vector, float setX)
        {
            vector.x = setX;
        }
    } 
}
