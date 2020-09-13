using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public static Inventary sharedInstance;

    public bool filled = false;
    private Slot[] slots;
    private int emptySlotIndex = 0;
    public List<Item> items;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
    }

    private int NextEmptySlotIndex()
    {
        int nextIndex = 0;
        foreach(Slot s in slots)
        {
            if(s.itemStacked != null)
            {
                nextIndex++;
            }

            if(nextIndex >= slots.Length)
            {
                filled = true;
            }
        }
        return nextIndex;
    }
    
    public bool AddItem(Item item, int quantity)
    {
        if ((item.stackeable && !items.Contains(item) && !filled) || !item.stackeable && !filled)
        {
            emptySlotIndex = NextEmptySlotIndex();
            //Add item 
        }
        else if(item.stackeable && items.Contains(item) && !filled)
        {
            for(int i = 0; i < slots.Length; i++)
            {
                if(slots[i].itemStacked.name == item.name)
                {
                    emptySlotIndex = i;
                    //Add item 
                }
            } 
        }
        return true;
    }

}
