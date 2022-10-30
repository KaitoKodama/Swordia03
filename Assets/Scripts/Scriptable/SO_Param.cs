using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Params", menuName = "ScriptableObject/ƒpƒ‰ƒ[ƒ^")]
public class SO_Param : ScriptableObject
{
    [SerializeField] Sprite selfSprite = default;
    [SerializeField] string actorName = default;
    [SerializeField] float speed = default;
    [SerializeField] float maxHP = default;
    [SerializeField] float maxMP = default;
    [SerializeField] bool isOnlyForPlayer = false;


    public Sprite SelfSprite => selfSprite;
    public string ActorName => actorName;
    public float Speed => speed;
    public float MaxHP => maxHP;
    public float MaxMP => maxMP;
    public float Power { get { return maxHP / 3; } }
    public float Defence { get { return maxHP / 6; } }
    public float SatisfactRate { get { return speed / 1000f; } }
    public float EscapeRate { get { return speed / 10000f; } }
    public bool IsOnlyForPlayer => isOnlyForPlayer;
}
