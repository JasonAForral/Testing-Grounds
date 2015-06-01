using UnityEngine;
using System.Collections;

public class Marshal : Specialty
{
    public Marshal ()
    {
        characterSpecialty = "Marshal";
        characterSpecialtyDescription = "Tactical and Sturdy";
        strength += 3;
        dexterity += 0;
        intelligence += 2;
        constitution += 4;
    }
}
