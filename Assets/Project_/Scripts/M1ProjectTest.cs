using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] Hero a;
    [SerializeField] Hero b;

    void Update()
    {
        // GLI EROI SONO VIVI
        if (a.IsAlive() == false || b.IsAlive() == false)
        {
            Debug.Log("Un eroe è stato eliminato");
            return;
        }

        // CHI ATTACCA PER PRIMO

        Stats aStats = Stats.Sum(a.GetBaseStats(), a.GetWeapon().GetBonusStats());
        Stats bStats = Stats.Sum(b.GetBaseStats(), b.GetWeapon().GetBonusStats());

        if (aStats._spd > bStats._spd)
        {
            Debug.Log(a.GetName() + " attacca e " + b.GetName() + " difende");
            Round(a, b);
            if (b.IsAlive() == true)
            {
                Debug.Log(b.GetName() + " attacca e " + a.GetName() + " difende");
                Round(b, a);
            }
        }
        else if (aStats._spd < bStats._spd)
        {
            Debug.Log(b.GetName() + " attacca e " + a.GetName() + " difende");
            Round(b, a);
            if (a.IsAlive() == true)
            {
                Debug.Log(a.GetName() + " attacca e " + b.GetName() + " difende");
                Round(a, b);
            }
        }
    }

    // FUNZIONE PER IL ROUND
    void Round(Hero attacker, Hero defender)
    {
        // SE IL COLPO VA A SEGNO
        bool hasHit = GameFormulas.HasHit(attacker.GetBaseStats(), defender.GetBaseStats());
        if (hasHit == true)
        {
            if (GameFormulas.HasElementAdvantage(attacker.GetWeapon().GetElem(), defender) == true)
            {
                Debug.Log("WEAKNESS");
            }
            else if (GameFormulas.HasElementDisadvantage(attacker.GetWeapon().GetElem(), defender) == true)
            {
                Debug.Log("RESIST");
            }

            // CALCOLO DEL DANNO

            int danno = GameFormulas.CalculateDamage(attacker, defender);
            Debug.Log(attacker.GetName() + " infligge " + danno + " danni a " + defender.GetName());

            // INFLIGGE IL DANNO

            defender.TakeDamage(danno);
            Debug.Log("La vita rimanente di " + defender.GetName() + " è di " + defender.GetHp());
            if (defender.GetHp() <= 0)
            {
                Debug.Log("Il vincitore è " + attacker.GetName());
            }
        }
    }
}