using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{
    static BattleMap BattleMap;

    protected override void PrepareState(System.Action callback)
    {
        BattleMap = new(Random.Range(2, 6), 5);
        base.PrepareState(callback);
    }

}

