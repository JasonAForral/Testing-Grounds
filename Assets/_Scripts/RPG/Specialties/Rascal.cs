using UnityEngine;
using System.Collections;

public class Rascal : Specialty
{
    public Rascal ()
    {
        characterSpecialty = "Rascal";
        characterSpecialtyDescription = "Agile and Cunning";
        strength += 2;
        dexterity += 4;
        intelligence += 3;
        constitution += 0;
    }
}
