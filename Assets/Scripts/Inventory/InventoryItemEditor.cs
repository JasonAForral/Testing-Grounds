using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class InventoryItemEditor  : EditorWindow {
 
    public InventoryItemList inventoryItemList;
    //private int viewIndex = 1;

    [MenuItem("Window/Inventory Item Editor %#e")]
    static void Init ()
    {
        EditorWindow.GetWindow(typeof(InventoryItemEditor));
    }

    void OnEnable ()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            inventoryItemList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(InventoryItemList)) as InventoryItemList;
        }
    }

    
}