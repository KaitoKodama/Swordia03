using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControll : MonoBehaviour
{
    [SerializeField] Actor actor = default;
    [SerializeField] AbnormalStatusType type = default;
    [SerializeField] AbnormalStatus status = default;

    void Start()
    {
        //actor.Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            actor.AddAbnormalStatus(status);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            actor.RemoveAbnormalStatus(type);
        }
    }
}
