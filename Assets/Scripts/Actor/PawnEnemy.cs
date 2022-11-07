using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnEnemy : Pawn
{
    protected override void OnInitPawn(Sprite sprite, Location location)
    {
        base.OnInitPawn(sprite, location);
        transform.position = location.origin;
        render.flipX = true;
    }
}