using UnityEngine;

[System.Serializable]

public class Weapon
{
    //VARIABILI
    [SerializeField] private string _name;
    [SerializeField] private DAMAGE_TYPE _dmgType;
    [SerializeField] private Stats.ELEMENT _elem;
    [SerializeField] private Stats _bonusStats;


    // ENUM    
    public enum DAMAGE_TYPE

    {
        PHYSICAL, MAGICAL
    }

    // COSTRUTTORE
    public Weapon(string name, DAMAGE_TYPE dmgType, Stats.ELEMENT elem, Stats bonusStats)
    {
        _name = name;
        _dmgType = dmgType;
        _elem = elem;
        _bonusStats = bonusStats;
    }

    // GET/SET NAME
    public string GetName() => _name;
    public void SetName(string name) => _name = name;

    // GET/SET dmgType
    public DAMAGE_TYPE GetDmgType() => _dmgType;
    public void SetDmgType(DAMAGE_TYPE dmgType) => _dmgType = dmgType;

    // GET/SET elem
    public Stats.ELEMENT GetElem() => _elem;
    public void SetElem(Stats.ELEMENT elem) => _elem = elem;

    // GET/SET bonusStats
    public Stats GetBonusStats() => _bonusStats;
    public void SetBonusStats(Stats bonusStats) => _bonusStats = bonusStats;

}