using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    private Text text;


    private void Awake()
    {
        text = GetComponentInChildren<Text>(true);
    }


    public void SetText(string text)
    {
        this.text.text = text;
    }
}
