using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicTheory.Harmony;


public class PlayerCharacter : Character
{
    public PlayerCharacter(PlayerSpecs playerSpecs, CharacterSpecs charSpecs) : base(charSpecs)
    {
        Specs = playerSpecs;
    }

    readonly PlayerSpecs Specs;
    public Instrument Instrument => Specs.instrument;
    public Genre FavoriteGenre => Specs.genre;
    public AbilityCard[] AbilityCards => Specs.abilityCards;


    public static PlayerCharacter Bird => new(
          new PlayerSpecs() { instrument = Instrument.AltoSax, genre = Genre.Jazz },
          new CharacterSpecs() { name = nameof(Bird), maxHealth = 250, damagePotential = 50 });

    public static PlayerCharacter Louis => new(
          new PlayerSpecs() { instrument = Instrument.Trumpet, genre = Genre.Jazz },
          new CharacterSpecs() { name = nameof(Louis), maxHealth = 250, damagePotential = 50 });

    public static PlayerCharacter Ian => new(
          new PlayerSpecs() { instrument = Instrument.Flute, genre = Genre.Rock },
          new CharacterSpecs() { name = nameof(Ian), maxHealth = 250, damagePotential = 50 });

    public static PlayerCharacter YoYo => new(
          new PlayerSpecs() { instrument = Instrument.Cello, genre = Genre.Classical },
          new CharacterSpecs() { name = nameof(YoYo), maxHealth = 250, damagePotential = 50 });

    public static PlayerCharacter RileyB => new(
          new PlayerSpecs() { instrument = Instrument.Guitar, genre = Genre.Blues },
          new CharacterSpecs() { name = nameof(RileyB), maxHealth = 250, damagePotential = 50 });

    public static PlayerCharacter Thile => new(
          new PlayerSpecs() { instrument = Instrument.Mandolin, genre = Genre.Folk },
          new CharacterSpecs() { name = nameof(Thile), maxHealth = 250, damagePotential = 50 });

}

public class PlayerSpecs
{
    public Instrument instrument;
    public Genre genre;
    public AbilityCard[] abilityCards;

    public PlayerSpecs SetAbilityCards(AbilityCard[] cards) { abilityCards = cards; return this; }
}