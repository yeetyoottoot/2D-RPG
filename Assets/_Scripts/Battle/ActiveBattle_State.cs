using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class ActiveBattle_State : State
{
    public ActiveBattle_State(BattleMap bMap)
    {
        BattleMap = bMap;
    }

    readonly BattleMap BattleMap;

    protected override void PrepareState(Action callback)
    {
        CharacterTurn();
        base.PrepareState(callback);
    }

    void CharacterTurn()
    {
        BattleMap.ActiveCharacter = BattleMap.PCCards[0];
    }

    protected override void ClickedOn(GameObject go)
    {
        foreach (Card card in BattleMap.PCCards)
        {
            if (go.transform.IsChildOf(card.GO.transform)) { BattleMap.ActiveCharacter = card; return; }
        }
    }
}

