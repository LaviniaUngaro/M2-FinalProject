using static UnityEngine.Random;
using UnityEngine;

public static class GameFormulas
{
    public static bool HasElementAdvantage(Stats.ELEMENT attackElement, Hero defender)
    {
        Stats.ELEMENT defWeakness = defender.GetWeakness();

        if (attackElement == defWeakness)
        {
            return true;
        }
        return false;

    }

    public static bool HasElementDisadvantage(Stats.ELEMENT attackElement, Hero defender)
    {
        Stats.ELEMENT defResistance = defender.GetResistance();

        if (attackElement == defResistance)
        {
            return true;
        }
        return false;
    }

    public static float EvaluateElementalModifier(Stats.ELEMENT attackElement, Hero defender)
    {
        bool vantaggio = HasElementAdvantage(attackElement, defender);
        bool svantaggio = HasElementDisadvantage(attackElement, defender);

        if (vantaggio == true)
        {
            return 1.5f;
        }
        else if (svantaggio == true)
        {
            return 0.5f;
        }
        return 1;
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker._aim - defender._eva;
        int colpo = Random.Range(0, 100);
        if (colpo > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        return true;
    }

    public static bool IsCrit(int critValue)
    {
        int critico = Random.Range(0, 100);
        if (critico <= critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        return false;
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        // Hero -> GetWeapon --> classe Weapon -> GetBonusStats --> struct Stats

        // STATISTICHE EROI
        Stats attackerStats = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats defenderStats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());

        // TIPOLOGIA DI DIFESA DEFENDER
        Weapon.DAMAGE_TYPE dmgTypeAttacker = attacker.GetWeapon().GetDmgType();

        int difesa = 0;
        if (dmgTypeAttacker == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            difesa = defenderStats._def;
        }
        else if (dmgTypeAttacker == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            difesa = defenderStats._res;
        }

        // CALCOLO DANNO
        int dannoBase = attackerStats._atk - difesa;

        float moltiplicatoreDanno = EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender);
        dannoBase = (int)(dannoBase * moltiplicatoreDanno);

        bool critico = IsCrit(attacker.GetBaseStats()._crt);
        if (critico == true)
        {
            dannoBase *= 2;
        }

        if (dannoBase < 0)
        {
            dannoBase = 0;
        }

        return dannoBase;
    }
}