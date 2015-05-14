//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//public class MakeCharacterSheet {
 
//    //======================================
//    // static variables
//    public static int sheetIndex = 0;
//    // public variables
 	
//    // private variables 
 
//    //======================================
//    // Function Definitions
 
//    // getters & setters

//    [MenuItem("Assets/Create/CharactersSheet")]
//    public static void CreateCharacters ()
//    {
//        AssetDatabase.SaveAssets();

//        EditorUtility.FocusProjectWindow();

//        sheetIndex++;
//        if (sheetIndex > 999) sheetIndex = 0;
//    }
//}