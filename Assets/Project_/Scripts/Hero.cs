using UnityEngine;

[System.Serializable]

public class Hero
{
    [SerializeField] private string _name;
    [SerializeField] private int _hp;
    [SerializeField] private Stats _baseStats;
    [SerializeField] private Stats.ELEMENT _resistance;
    [SerializeField] private Stats.ELEMENT _weakness;
    [SerializeField] private Weapon _weapon;

    public Hero(string name, int hp, Stats baseStats, Stats.ELEMENT resistance, Stats.ELEMENT weakness, Weapon weapon)
    {
        _name = name;
        _hp = hp;
        _baseStats = baseStats;
        _resistance = resistance;
        _weakness = weakness;
        _weapon = weapon;
    }

    //GET/SET NAME
    public string GetName() => _name;
    public void SetName(string name) => _name = name;

    //GET/SET HP
    public int GetHp() => _hp;
    public void SetHP(int hp) => _hp = hp;

    //GET/SET baseStats
    public Stats GetBaseStats() => _baseStats;
    public void SetBaseStats(Stats baseStats) => _baseStats = baseStats;

    //GET/SET RESISTANCE
    public Stats.ELEMENT GetResistance() => _resistance;
    public void SetResistance(Stats.ELEMENT resistance) => _resistance = resistance;

    //GET/SET WEAKNESS
    public Stats.ELEMENT GetWeakness() => _weakness;
    public void SetWeakness(Stats.ELEMENT weakness) => _weakness = weakness;

    //GET/SET WEAPON
    public Weapon GetWeapon() => _weapon;
    public void SetWeapon(Weapon weapon) => _weapon = weapon;


    // FUNZIONI
    public int AddHP(int amount)
    {
        int newHP = _hp + amount;
        SetHP(newHP);
        return newHP;
    }

    public int TakeDamage(int damage)
    {
        AddHP(-damage);
        return damage;
    }

    public bool IsAlive()
    {
        if (_hp > 0)
        {
            return true;
        }
        return false;
    }
}