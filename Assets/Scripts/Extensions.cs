using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public static string ConvertArrayToString<T>(this T[] mas)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < mas.Length - 1; i++)
            stringBuilder.Append(JsonUtility.ToJson(mas[i]) + "|||");
        stringBuilder.Append(JsonUtility.ToJson(mas[mas.Length - 1]));
        return stringBuilder.ToString();
    }

    public static T[] ConvertStringToArray<T>(this string str)
    {
        string[] strArray = str.Split("|||");
        T[] result = new T[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
            result[i] = JsonUtility.FromJson<T>(strArray[i]);
        return result;
    }
}
