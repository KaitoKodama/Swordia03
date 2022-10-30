using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    [SerializeField] List<SO_Param> actorParams = default;


    private void Start()
    {
        Locator<Database>.Bind(this);
    }
    private void OnDestroy()
    {
        Locator<Database>.Unbind(this);
    }

    public List<SO_Param> GetActorParams(bool isOnlyForPlayer)
    {
        var tmpList = new List<SO_Param>();
        foreach (var param in actorParams)
        {
            if (isOnlyForPlayer == param.IsOnlyForPlayer)
            {
                tmpList.Add(param);
            }
        }
        return tmpList;
    }
    public List<SO_Param> GetActorParamFromIDs(List<int> ids)
    {
        var tmpList = new List<SO_Param>();
        for (int i = 0; i < actorParams.Count; i++)
        {
            bool isSame = false;
            foreach (var id in ids)
            {
                if (id == i)
                {
                    isSame = true;
                }
            }
            if (isSame)
            {
                tmpList.Add(actorParams[i]);
            }
        }
        return tmpList;
    }
}
