using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityCard
{
    private AbilityCard() { }

    public Riff Riff;
    public AbilityType Type;

    public static AbilityCard Heal => new() { Type = AbilityType.Heal };
    public static AbilityCard Attack => new() { Type = AbilityType.Attack };

    public AbilityCard SetRiff(Riff riff) { Riff = riff; return this; }
    public enum AbilityType { Heal, Attack }
}
