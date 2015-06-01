using UnityEngine;
using System.Collections;

public class StatItem : Item {

    private int _strength;
    private int _dexterity;
    private int _constitution;
    private int _intelligence;

    public int strength { get { return _strength; } set { _strength = value; } }
    public int dexterity { get { return _dexterity; } set { _dexterity = value; } }
    public int constitution { get { return _constitution; } set { _constitution = value; } }
    public int intelligence { get { return _intelligence; } set { _intelligence = value; } }
}
