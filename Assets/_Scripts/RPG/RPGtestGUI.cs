using UnityEngine;
using System.Collections;


public class RPGtestGUI : MonoBehaviour {

    public Specialty class1;
    private Specialty class2;

	// Use this for initialization
    void Start ()
    {
        class1 = ScriptableObject.CreateInstance<Brawler>();
        class2 = ScriptableObject.CreateInstance<Mystic>();

        Debug.Log(class1.characterSpecialty);
        Debug.Log(class2.characterSpecialty);
        Debug.Log(class1.strength);
        Debug.Log(class2.intelligence);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
