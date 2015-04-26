using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

    private string _itemName;
    private string _itemDescription;
    private int _itemID;
    public enum ItemType
    {
        Equipment,
        Weapon,
        Scroll,
        Potion,
        Container
    }
    private ItemType _itemType;

    public string itemName { get { return _itemName; } set { _itemName = value; } }
    public string itemDescription { get { return _itemDescription; } set { _itemDescription = value; } }
    public int itemID { get { return _itemID; } set { _itemID = value; } }
    public ItemType itemType { get { return _itemType; } set { _itemType = value; } }
}
