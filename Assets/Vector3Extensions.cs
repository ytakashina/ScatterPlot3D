using System;

namespace Extensions
{
    public static class Vector3Extensions
    {
        public static UnityEngine.Vector3 ToUnityVector3(this float[] v)
        {
            if (v.Length != 3)
                throw new ArgumentException($"The length of {v} is not 3.");

            return new UnityEngine.Vector3(v[0], v[1], v[2]);
        }

        public static UnityEngine.Vector3 ToUnityVector3(this double[] v)
        {
            if (v.Length != 3)
                throw new ArgumentException($"The length of {v} is not 3.");

            return new UnityEngine.Vector3((float)v[0], (float)v[1], (float)v[2]);
        }
    }
}