using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CC;

public partial class Actor : MonoBehaviour
{
    private List<AbnormalStatus> statusList = new List<AbnormalStatus>();
    private SkillBase skill;
    private SO_Param param;
    private Actor selected;
    private Pawn pawn;
    private Role role;


    //------------------------------------------
    // 外部共有関数
    //------------------------------------------
    public void Init<T>(SO_Param param, Location location) where T : Pawn
    {
        role = (typeof(T) == typeof(PawnPlayer)) ? Role.Player : Role.Enemy;

        pawn = gameObject.AddComponent<T>();
        pawn.InitPawn(param.SelfSprite, location);
        InitParams(param);
        OnInit(param, location);
    }
    public void SetSkill(SkillBase skill)
    {
        this.skill = skill;
    }
    public void SetActor(Actor selected)
    {
        this.selected = selected;
    }
    public void Excute()
    {
        skill.Excute(this, selected);
        OnExcute();
    }
    public void StepStatus()
    {
        if (statusList != null && statusList.Count != 0)
        {
            Utility.SetTrimmedList(ref statusList, (status) => status.Has, (status) => { status.UpdateKeepTime(); });
        }
    }


    //------------------------------------------
    // デリゲート通知
    //------------------------------------------
    public delegate void OnDeathNotifyer();
    public OnDeathNotifyer OnDeathNotifyerHandler;


    //------------------------------------------
    // 継承先共有抽象関数
    //------------------------------------------
    protected virtual void OnInit(SO_Param param, Location location)
    {
        transform.DOScaleY(transform.localScale.y + 0.02f, 0.2f).SetLoops(-1, LoopType.Yoyo);
    }
    protected virtual void OnExcute()
    {
        transform.DOShakePosition(0.2f, 0.5f);
    }
}
