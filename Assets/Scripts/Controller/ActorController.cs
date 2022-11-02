using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMN;

public class ActorController : MonoBehaviour
{
    [SerializeField] Actor actorPrefab = default;

    private List<LocationalStatus> locationals = new List<LocationalStatus>()
    {
        new LocationalStatus(new Vector3(3f, -2f, 0f), 0),
        new LocationalStatus(new Vector3(5f, -3f, 0f), 1),
        new LocationalStatus(new Vector3(6f, -1f, 0f), -1),
    };
    private List<Actor> fieldOfEnemies;
    private List<Actor> fieldOfPlayers;
    private int maxFieldActor = 3;


    //------------------------------------------
    // Unityランタイム
    //------------------------------------------
    private void Start()
    {
        fieldOfEnemies = new List<Actor>(maxFieldActor);
        fieldOfPlayers = new List<Actor>(maxFieldActor);

        GenerateEnemies();
        var selectedIDs = GameManager.instance.SelectedIDs;
        var playerParams = Locator<Database>.I.GetActorParamFromIDs(selectedIDs);
        for (int i = 0; i < playerParams.Count; i++)
        {
            var locational = locationals[i];
            locational.SetAsLeftSide();
            AddActor(ref fieldOfPlayers, playerParams[i], locational);
        }
    }


    //------------------------------------------
    // デリゲート受信
    //------------------------------------------
    private void OnDeathNotifyerReciever()
    {

    }


    //------------------------------------------
    // 内部共有関数
    //------------------------------------------
    private void GenerateEnemies()
    {
        var enemyParams = Locator<Database>.I.GetActorParams(false);
        int fieldOfEnemyNum = Random.Range(1, maxFieldActor + 1);
        for (int i = 0; i < fieldOfEnemyNum; i++)
        {
            var param = enemyParams[Random.Range(0, enemyParams.Count)];
            var locational = locationals[i];
            locational.SetAsRightSide();
            AddActor(ref fieldOfEnemies, param, locational);
        }
    }
    private void AddActor(ref List<Actor> actorList, SO_Param param, LocationalStatus locational)
    {
        var obj = Instantiate(actorPrefab.gameObject, locational.Origin, Quaternion.identity);
        obj.transform.SetParent(transform);

        var actor = obj.GetComponent<Actor>();
        actor.Init(param, locational);
        actorList.Add(actor);
    }
    private void RemoveActor(ref List<Actor> actorList, Actor removeActor)
    {
        actorList = Utility.GetTrimmedList(actorList, removeActor);
    }
}
