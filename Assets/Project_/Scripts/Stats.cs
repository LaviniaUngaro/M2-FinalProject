
[System.Serializable]

public struct Stats
{
    public int _atk, _def, _res, _spd, _crt, _aim, _eva;

    // Costruttore che assegna i valori
    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        _atk = atk;
        _def = def;
        _res = res;
        _spd = spd;
        _crt = crt;
        _aim = aim;
        _eva = eva;
    }

    // Funzione SUM()
    public static Stats Sum(Stats Stats1, Stats Stats2)
    {
        Stats totStats = new Stats
        (Stats1._atk + Stats2._atk,
        Stats1._def + Stats2._def,
        Stats1._res + Stats2._res,
        Stats1._spd + Stats2._spd,
        Stats1._crt + Stats2._crt,
        Stats1._aim + Stats2._aim,
        Stats1._eva + Stats2._eva);

        /* METODO LUNGO
            totStats._atk = Stats1._atk + Stats2._atk;
            totStats._def = Stats1._def + Stats2._def;
            totStats._res = Stats1._res + Stats2._res;
            totStats._spd = Stats1._spd + Stats2._spd;
            totStats._crt = Stats1._crt + Stats2._crt;
            totStats._aim = Stats1._aim + Stats2._aim;
            totStats._eva = Stats1._eva + Stats2._eva; */

        return totStats;
    }


    public enum ELEMENT
    {
        NONE, FIRE, ICE, LIGHTNING
    }
}

