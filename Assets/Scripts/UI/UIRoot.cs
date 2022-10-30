using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public T GetUIElement<T>(string name) where T : Component
    {
        var els = transform.GetComponentsInChildren<T>(true);
        foreach (var el in els)
        {
            if (el.name == name)
            {
                return el;
            }
        }

        Debug.LogError($"{name} is not exist");
        return null;
    }
}
