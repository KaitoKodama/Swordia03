using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    protected SpriteRenderer render;

    public void InitPawn(Sprite sprite, Location location)
    {
        render = GetComponent<SpriteRenderer>();
        render.sortingOrder = location.depth;
        render.sprite = sprite;
        OnInitPawn(sprite, location);
    }
    protected virtual void OnInitPawn(Sprite sprite, Location location) { }
}
