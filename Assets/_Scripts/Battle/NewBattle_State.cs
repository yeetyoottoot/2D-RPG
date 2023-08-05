using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBattle_State : State
{
    BattleMap BattleMap;

    protected override void PrepareState(System.Action callback)
    {
        BattleMap = new(RandomNME, RandomPCs());
        base.PrepareState(callback);
    }
    protected override void EngageState()
    {
        SetStateDirectly(new ActiveBattle_State(BattleMap));
    }


    PlayerCharacter[] RandomPCs()
    {
        return new PlayerCharacter[5]
        {
            PlayerCharacter.Bird,
            PlayerCharacter.Ian,
            PlayerCharacter.RileyB,
            PlayerCharacter.Thile,
            PlayerCharacter.YoYo,
        };
    }

    Enemy RandomNME => Random.Range(0, 5) switch
    {
        0 => Enemy.JazzFrog,
        1 => Enemy.BluesBug,
        2 => Enemy.ClassicalButterfly,
        3 => Enemy.RockLobster,
        _ => Enemy.FolkFaery
    };
}


