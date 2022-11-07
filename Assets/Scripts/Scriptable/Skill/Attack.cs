using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "ScriptableObject/スキル/攻撃系スキル")]
public class Attack : ToOppo
{
    [SerializeField] float multiply = 1.2f;


    public override void Excute(Actor owner, Actor selected)
    {
        float damage = (owner.Power * multiply) * -1;
        selected.ApplyHP(damage);
    }
}
