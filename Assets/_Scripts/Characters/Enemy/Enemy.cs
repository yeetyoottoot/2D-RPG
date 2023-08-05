using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicTheory.Harmony;

public class Enemy : Character
{
    public Enemy(CharacterSpecs charSpecs, EnemySpecs nmeSpecs) : base(charSpecs)
    {
        Specs = nmeSpecs;
    }

    EnemySpecs Specs;
    public Genre Genre => Specs.Genre;

    public static Enemy JazzFrog => new(
        new CharacterSpecs() { name = nameof(JazzFrog), maxHealth = Random.Range(70, 100), damagePotential = Random.Range(15, 20), },
        new EnemySpecs() { Genre = Genre.Jazz });

    public static Enemy ClassicalButterfly => new(
        new CharacterSpecs() { name = nameof(ClassicalButterfly), maxHealth = Random.Range(55, 75), damagePotential = Random.Range(20, 30), },
        new EnemySpecs() { Genre = Genre.Classical });

    public static Enemy RockLobster => new(
        new CharacterSpecs() { name = nameof(RockLobster), maxHealth = Random.Range(120, 150), damagePotential = Random.Range(10, 15), },
        new EnemySpecs() { Genre = Genre.Rock });

    public static Enemy BluesBug => new(
        new CharacterSpecs() { name = nameof(BluesBug), maxHealth = Random.Range(70, 100), damagePotential = Random.Range(15, 20), },
        new EnemySpecs() { Genre = Genre.Blues });

    public static Enemy FolkFaery => new(
        new CharacterSpecs() { name = nameof(FolkFaery), maxHealth = Random.Range(50, 65), damagePotential = Random.Range(25, 35), },
        new EnemySpecs() { Genre = Genre.Blues });
}

public struct EnemySpecs
{
    public Genre Genre;
}