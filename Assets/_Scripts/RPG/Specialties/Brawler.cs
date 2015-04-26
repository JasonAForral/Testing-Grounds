using UnityEngine;
using System.Collections;

public class Brawler : Specialty
{
    public Brawler ()
    {
        characterSpecialty = "Brawler";
        characterSpecialtyDescription = "Aggressive and in your face";
        strength += 4;
        dexterity += 2;
        intelligence += 0;
        constitution += 3;
    }
}
