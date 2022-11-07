using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : ScriptableObject
{
    [SerializeField] float requireMP = default;
    [SerializeField] string skillName = default;
    [SerializeField, TextArea(5, 10)] string excuteSentence = default;
    [SerializeField, TextArea(5, 10)] string recievedSentence = default;


    public virtual void Excute(Actor owner, Actor selected) { }
    public float RequireMP => requireMP;
    public string SkillName => skillName;
    public string ExcuteSentence => excuteSentence;
    public string RecievedSentence => recievedSentence;
}
