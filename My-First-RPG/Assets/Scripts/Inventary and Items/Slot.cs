using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerDownHandler
{
    private Image slotImg;
    private int numStacked;
    public Item itemStacked;

    private void Awake()
    {
        slotImg = GetComponent<Image>();
    }

    void Start()
    {
       if(itemStacked == null)
        {
            slotImg.enabled = false;
        }
    }

    public void AddItem(Item item, int quantity)
    {
        if(item.name == itemStacked.name)
        {
            numStacked += quantity;
        }
        else
        {
            itemStacked = item;
            numStacked = quantity;
        }
 
        slotImg.enabled = true;
        slotImg.sprite = item.sprite;
    }

    protected virtual void UseItem()
    {
        if(itemStacked != null)
        {
            if (itemStacked.CanBeUsed())
            {
                numStacked--;
                if(numStacked <= 0)
                {
                    RemoveItem();
                }
            }
        }
    }

    public void RemoveItem()
    {
        numStacked = 0;
        itemStacked = null;
        slotImg.sprite = null;
        slotImg.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UseItem();
    }
}
