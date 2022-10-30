using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStruct : MonoBehaviour
{
    [SerializeField] GameObject undoButton = default;
    [SerializeField] UIRoot arrowBox = default;
    [SerializeField] UIRoot panel01 = default;
    [SerializeField] UIRoot panel02 = default;
    [SerializeField] UIRoot panel03 = default;


    public GameObject UndoButton => undoButton;
    public UIRoot ArrowBox => arrowBox;
    public UIRoot Panel01 => panel01;
    public UIRoot Panel02 => panel02;
    public UIRoot Panel03 => panel03;
}
