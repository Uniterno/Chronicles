using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory object", menuName = "Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<inventorySlots> Container = new List<inventorySlots>();
    public void AddItem(Card _item, int _ammount)
    {
        /* bool exists = false;
         for (int i = 0; i< Container.Count;i++)
         {
             if (Container[i].item ==_item)
             {
                 Container[i].addAmount(_ammount);
                 exists = true;
                 break;
             }
         }*/
        Container.Add(new inventorySlots(_item, _ammount));
        /*if (!exists)
        {
            Container.Add(new inventorySlots(_item, _ammount));
        }*/
    }
}

[System.Serializable]
public class inventorySlots
{
    public Card item;
    public int ammount;
    public inventorySlots(Card _item, int _ammount)
    {
        item = _item;
        ammount = _ammount;
    }


    public void addAmount(int value)
    {
        ammount += value;
    }
}