using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : IHaveHealth, IDealDamage
{
    public Character(CharacterSpecs specs)
    {
        Specs = specs;
    }

    CharacterSpecs Specs;

    public string Name => Specs.name;
    public Sprite Icon => Specs.icon;

    public virtual int MaxHealth
    {
        get => Specs.maxHealth;
        set => Specs.maxHealth = value;
    }

    protected int _currentHealth;
    public virtual int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
    }

    public virtual int DamagePotential
    {
        get => Specs.damagePotential;
        set { Specs.damagePotential = value; }
    }

    public void TakeDamage(int i) => CurrentHealth -= i;
    public void RestoreHealth(int i) => CurrentHealth += i;

}

public struct CharacterSpecs
{
    public string name;
    public int maxHealth;
    public int damagePotential;
    public Sprite icon;
}

public interface IHaveHealth
{
    public bool IsDead => CurrentHealth <= 0;
    public bool IsFullHealth => CurrentHealth >= MaxHealth;

    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    public void TakeDamage(int i);
    public void RestoreHealth(int i);
}

public interface IDealDamage
{
    public int DealDamage() => DamagePotential;
    public int DamagePotential { get; set; }
}
