using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "ScriptableObject/�X�L��/�U���n�X�L��")]
public class SO_Attack : SO_SkillBase
{
    [SerializeField] float multiply = 1.2f;


    public override void Excute(Actor owner, IApplyEffect reciever)
    {
        float damage = (owner.Power * multiply) * -1;
        reciever.ApplyHP(damage);
    }
}
