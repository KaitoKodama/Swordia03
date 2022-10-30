using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SO_SkillBase : ScriptableObject
{
    [SerializeField] string skillName = default;
    [SerializeField, TextArea(5, 10)] string excuteSentence = default;
    [SerializeField, TextArea(5, 10)] string recievedSentence = default;
    [SerializeField] float requireMP = default;


    public abstract void Excute(Actor owner, IApplyEffect reciever);
    public string SkillName => skillName;
    public float RequireMP => requireMP;
    public string ExcuteSentence => excuteSentence;
    public string RecievedSentence => recievedSentence;
}
