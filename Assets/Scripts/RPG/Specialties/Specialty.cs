using UnityEngine;
using System.Collections;

public class Specialty :ScriptableObject
{
    private string _characterSpecialty;
    private string _characterSpecialtyDescription;
    private int _strength = 10;
    private int _dexterity = 10;
    private int _constitution = 10;
    private int _intelligence = 10;

    public string characterSpecialty { get { return _characterSpecialty; } set{_characterSpecialty = value; }}
    public string characterSpecialtyDescription { get { return _characterSpecialtyDescription; } set { _characterSpecialtyDescription = value; } }
    public int strength { get { return _strength; } set { _strength = value; } }
    public int dexterity { get { return _dexterity; } set { _dexterity = value; } }
    public int constitution { get { return _constitution; } set { _constitution = value; } }
    public int intelligence { get { return _intelligence; } set { _intelligence = value; } }
}
