using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Actor : MonoBehaviour, IApplyEffect
{
    private SO_Param param;
    protected SpriteRenderer render;
    private List<AbnormalStatus> statusList = new List<AbnormalStatus>();


    //------------------------------------------
    // 外部共有関数
    //------------------------------------------
    public float HP { get; private set; }
    public float MP { get; private set; }
    public float Speed { get; private set; }
    public float Power { get; private set; }
    public float Defence { get; private set; }
    public float SatisfactRate { get; private set; }
    public float EscapeRate { get; private set; }
    public bool IsDeath { get; private set; }
    public void Init(SO_Param param, LocationalStatus locational)
    {
        this.param = param;
        HP = param.MaxHP;
        MP = param.MaxMP;
        Speed = param.Speed;
        Power = param.Power;
        Defence = param.Defence;
        SatisfactRate = param.SatisfactRate;
        EscapeRate = param.EscapeRate;

        render = GetComponent<SpriteRenderer>();
        render.sprite = param.SelfSprite;
        render.sortingOrder = locational.Depth;
        render.flipX = locational.IsFlipX;
        OnInit();
    }
    public void Attack(IApplyEffect reciever)
    {
        float damage = Power * -1;
        reciever.ApplyHP(damage);
        OnAttack();
    }
    public void Skill(SO_SkillBase skill)
    {
    }
    public void StepStatus()
    {
        if (statusList != null && statusList.Count != 0)
        {
            var tmpList = new List<AbnormalStatus>();
            foreach (var status in statusList)
            {
                status.UpdateKeepTime();
                if (status.Has)
                {
                    tmpList.Add(status);
                }
            }
            statusList.Clear();
            statusList = tmpList;
        }
    }


    //------------------------------------------
    // 継承先共有抽象関数
    //------------------------------------------
    protected virtual void OnInit()
    {
        transform.DOScaleY(transform.localScale.y + 0.02f, 0.2f).SetLoops(-1, LoopType.Yoyo);
    }
    protected virtual void OnAttack()
    {
        transform.DOShakePosition(0.2f, 0.5f);
    }
    protected virtual void OnExcute() { }


    //------------------------------------------
    // 内部共有関数
    //------------------------------------------


    //------------------------------------------
    // デリゲート通知
    //------------------------------------------
    public delegate void OnDeathNotifyer();
    public OnDeathNotifyer OnDeathNotifyerHandler;


    //------------------------------------------
    // インターフェイス
    //------------------------------------------
    public void AddAbnormalStatus(AbnormalStatus status)
    {
        statusList.Add(status);
    }
    public void RemoveAbnormalStatus(AbnormalStatusType removeType)
    {
        if (statusList != null && statusList.Count != 0)
        {
            var tmpList = new List<AbnormalStatus>();
            foreach (var status in statusList)
            {
                if (!removeType.Equals(status.Type))
                {
                    tmpList.Add(status);
                }
            }
            statusList.Clear();
            statusList = tmpList;
        }
    }
    public void ApplyHP(float value)
    {
        if (!IsDeath)
        {
            HP = Mathf.Clamp(HP + value, 0, param.MaxHP * 2);
            if (HP <= 0)
            {
                OnDeathNotifyerHandler?.Invoke();
                IsDeath = true;
            }
        }
    }
    public void ApplyMP(float value)
    {
        MP = Mathf.Clamp(MP + value, 0, param.MaxMP * 2);
    }
    public void ApplySpeed(float value)
    {
        Speed = Mathf.Clamp(Speed + value, 0, param.Speed * 2);
    }
    public void ApplyPower(float value)
    {
        Power = Mathf.Clamp(Power + value, 0, param.Power * 2);
    }
    public void ApplyDefence(float value)
    {
        Defence = Mathf.Clamp(Defence + value, 0, param.Defence * 2);
    }
    public void ApplySatisfactRate(float value)
    {
        SatisfactRate = Mathf.Clamp(SatisfactRate + value, 0, param.SatisfactRate * 2);
    }
    public void ApplyEscapeRate(float value)
    {
        EscapeRate = Mathf.Clamp(EscapeRate + value, 0, param.EscapeRate * 2);
    }
}
