using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CC;

public class AutoPush : MonoBehaviour
{
    private ActorController controller;

    private void Start()
    {
        controller = GetComponent<ActorController>();
        SetCommand();
    }


    private void SetCommand()
    {
        foreach (var enemy in controller.Enemeies.actors)
        {
            var skill = Utility.GetRndFromList(enemy.CommandList);
            Actor target;
            if (skill.GetType().IsSubclassOf(typeof(ToOppo)))
            {
                target = Utility.GetRndFromList(controller.Players.actors);
            }
            else
            {
                target = Utility.GetRndFromList(controller.Enemeies.actors);
            }
            enemy.SetSkill(skill);
            enemy.SetActor(target);
        }
    }
}