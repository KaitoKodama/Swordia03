using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    /*
     * 
     * 期待の経過
     * プレイヤがアクター毎のコマンド、対象キャラを選択
     * 敵がアクター毎のコマンド、対象キャラを選択
     * パラメータ(Speed)が早い順にそれぞれ選択したアクタースキルを実行
     * 
     */



    [SerializeField] Actor prefab = default;
    [SerializeField] ActorSet<PawnEnemy> enemeies;
    [SerializeField] ActorSet<PawnPlayer> players;
    private int maxFieldActor = 3;


    //------------------------------------------
    // Unityランタイム
    //------------------------------------------
    private void Start()
    {
        enemeies = new ActorSet<PawnEnemy>(OnEnemyRemoveComplete);
        players = new ActorSet<PawnPlayer>(OnPlayerRemoveComplete);
        GenerateEnemies();
        GeneratePlayer();
    }


    //------------------------------------------
    // 外部共有関数
    //------------------------------------------
    public ActorSet<PawnEnemy> Enemeies => enemeies;
    public ActorSet<PawnPlayer> Players => players;
    public void OnExcute()
    {
        var tmpList = new List<Actor>(maxFieldActor * 2);
        tmpList.AddRange(enemeies.actors);
        tmpList.AddRange(players.actors);
        tmpList = tmpList.OrderBy(x => x.Speed).ToList();

        foreach (var tmp in tmpList)
        {
            tmp.Excute();
        }
    }


    //------------------------------------------
    // デリゲート受信
    //------------------------------------------
    private void OnEnemyRemoveComplete()
    {
        GenerateEnemies();
    }
    private void OnPlayerRemoveComplete()
    {
        Debug.Log("OnPlayerRemoveComplete");
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
            enemeies.Add(Instantiate(prefab.gameObject), param, i);
        }
    }
    private void GeneratePlayer()
    {
        var selectedIDs = GameManager.instance.SelectedIDs;
        var playerParams = Locator<Database>.I.GetActorParamFromIDs(selectedIDs);
        for (int i = 0; i < playerParams.Count; i++)
        {
            players.Add(Instantiate(prefab.gameObject), playerParams[i], i);
        }
    }
}
