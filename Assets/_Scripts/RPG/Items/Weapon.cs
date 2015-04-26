using UnityEngine;
using System.Collections;

public class Weapon : StatItem {

    public enum WeaponType
    {
        Blade,
        Blunt,
        Precision,
        Bow,
        Thrown,
        Polearm,
        Shield,
    }

    private WeaponType[] _weaponType;
    private int _mysticism;

    public WeaponType[] weaponType
    {
        get { return _weaponType; }
        set { _weaponType = value; }
    }

    public int mysticism
    {
        get { return _mysticism; }
        set { _mysticism = value; }
    }
}
