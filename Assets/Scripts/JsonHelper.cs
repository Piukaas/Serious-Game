using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        string jsonWrapped = "{\"items\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonWrapped);
        return wrapper.items;
    }

    public static string ToJson<T>(List<T> list)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = list.ToArray();
        return JsonUtility.ToJson(wrapper);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
