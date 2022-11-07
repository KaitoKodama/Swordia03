using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CC;

public partial class Actor
{
    //------------------------------------------
    // ì‡ïîã§óLä÷êî
    //------------------------------------------
    private void InitParams(SO_Param param)
    {
        HP = param.MaxHP;
        MP = param.MaxMP;
        Speed = param.Speed;
        Power = param.Power;
        Defence = param.Defence;
        SatisfactRate = param.SatisfactRate;
        EscapeRate = param.EscapeRate;
        this.param = param;
    }


    //------------------------------------------
    // äOïîã§óLä÷êî
    //------------------------------------------
    public List<SkillBase> CommandList { get { return param.SkillList; } }
    public float HP { get; private set; }
    public float MP { get; private set; }
    public float Speed { get; private set; }
    public float Power { get; private set; }
    public float Defence { get; private set; }
    public float SatisfactRate { get; private set; }
    public float EscapeRate { get; private set; }
    public bool IsDeath { get; private set; }
    public void AddAbnormalStatus(AbnormalStatus status)
    {
        statusList.Add(status);
    }
    public void RemoveAbnormalStatus(AbnormalStatusType removeType)
    {
        if (statusList != null && statusList.Count != 0)
        {
            Utility.SetTrimmedList(ref statusList, (el) => !removeType.Equals(el.Type));
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
        if (!IsDeath)
            MP = Mathf.Clamp(MP + value, 0, param.MaxMP * 2);
    }
    public void ApplySpeed(float value)
    {
        if (!IsDeath)
            Speed = Mathf.Clamp(Speed + value, 0, param.Speed * 2);
    }
    public void ApplyPower(float value)
    {
        if (!IsDeath)
            Power = Mathf.Clamp(Power + value, 0, param.Power * 2);
    }
    public void ApplyDefence(float value)
    {
        if (!IsDeath)
            Defence = Mathf.Clamp(Defence + value, 0, param.Defence * 2);
    }
    public void ApplySatisfactRate(float value)
    {
        if (!IsDeath)
            SatisfactRate = Mathf.Clamp(SatisfactRate + value, 0, param.SatisfactRate * 2);
    }
    public void ApplyEscapeRate(float value)
    {
        if (!IsDeath)
            EscapeRate = Mathf.Clamp(EscapeRate + value, 0, param.EscapeRate * 2);
    }
}
