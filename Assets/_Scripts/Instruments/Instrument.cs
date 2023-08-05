using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicTheory;

using System;

public struct Instrument
{
    public string Name;

    public Instrument(string name) { Name = name; }

    public static Instrument SopranoSax => new() { Name = nameof(SopranoSax) };
    public static Instrument AltoSax => new() { Name = nameof(AltoSax) };
    public static Instrument TenorSax => new() { Name = nameof(TenorSax) };
    public static Instrument BariSax => new() { Name = nameof(BariSax) };
    public static Instrument Trumpet => new() { Name = nameof(Trumpet) };
    public static Instrument MuteTrumpet => new() { Name = nameof(MuteTrumpet) };
    public static Instrument Trombone => new() { Name = nameof(Trombone) };
    public static Instrument Tuba => new() { Name = nameof(Tuba) };

    public static bool operator ==(Instrument a, Instrument b) => a.Name == b.Name;
    public static bool operator !=(Instrument a, Instrument b) => a.Name != b.Name;

    public override readonly bool Equals(object obj) => obj is Instrument e && Name == e.Name;
    public override readonly int GetHashCode() => HashCode.Combine(Name);
}
