using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static float[] ConvertToFloat(this Vector3 vector3)
    {
        return new float[]
        {
            vector3.x, 
            vector3.y, 
            vector3.z,
        };
    }

    public static Vector3 ConvertToVector3(this float[] mas)
    {
        return new Vector3(mas[0], mas[1], mas[2]);
    }
}
