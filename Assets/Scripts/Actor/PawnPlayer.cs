using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPlayer : Pawn
{
    protected override void OnInitPawn(Sprite sprite, Location location)
    {
        base.OnInitPawn(sprite, location);
        location.origin.x *= -1;
        transform.position = location.origin;
        render.flipX = false;
    }
}