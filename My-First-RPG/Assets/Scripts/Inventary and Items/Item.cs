using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/Generic Item")]
public class Item : ScriptableObject //This will be a generic item, Everything, from a potion to a sword will follow this script´s sctructure
{
    public Sprite sprite;
    public string itemName;
    public bool stackeable;
    [TextArea(1, 3)]
    public string description;
    public virtual bool CanBeUsed()
    {
        Debug.Log("Item used?");
        return true;
    }
}
