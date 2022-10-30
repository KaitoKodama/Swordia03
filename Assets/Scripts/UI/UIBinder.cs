using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBinder : MonoBehaviour
{
    //------------------------------------------
    // Unityƒ‰ƒ“ƒ^ƒCƒ€
    //------------------------------------------
    private void Start()
    {
        var btns = transform.GetComponentsInChildren<Button>(true);
        foreach (var btn in btns)
        {
            var trigger = btn.gameObject.AddComponent<EventTrigger>();
            var image = btn.gameObject.GetComponent<Image>();

            OnButtonEffect(EventTriggerType.PointerEnter, Color.gray, trigger, image);
            OnButtonEffect(EventTriggerType.PointerExit, Color.white, trigger, image);
        }
    }


    //------------------------------------------
    // “à•”‹¤—LŠÖ”
    //------------------------------------------
    private void OnButtonEffect(EventTriggerType type, Color color, EventTrigger trigger, Image img)
    {
        var entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener((data) =>
        {
            img.color = color;
        });
        trigger.triggers.Add(entry);
    }
}
