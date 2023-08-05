using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicTheory;

using System;

public struct Instrument
{
    public string Name;

    public Instrument(string name) { Name = name; }

    public static Instrument AltoSax => new() { Name = nameof(AltoSax) };
    public static Instrument TenorSax => new() { Name = nameof(TenorSax) };
    public static Instrument BariSax => new() { Name = nameof(BariSax) };
    public static Instrument Trumpet => new() { Name = nameof(Trumpet) };
    public static Instrument Trombone => new() { Name = nameof(Trombone) };
    public static Instrument Tuba => new() { Name = nameof(Tuba) };
    public static Instrument Flute => new() { Name = nameof(Flute) };
    public static Instrument Clarinet => new() { Name = nameof(Clarinet) };
    public static Instrument Mandolin => new() { Name = nameof(Mandolin) };
    public static Instrument Cello => new() { Name = nameof(Cello) };
    public static Instrument Guitar => new() { Name = nameof(Guitar) };

    public static bool operator ==(Instrument a, Instrument b) => a.Name == b.Name;
    public static bool operator !=(Instrument a, Instrument b) => a.Name != b.Name;

    public override readonly bool Equals(object obj) => obj is Instrument e && Name == e.Name;
    public override readonly int GetHashCode() => HashCode.Combine(Name);
}
