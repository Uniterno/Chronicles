using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Inventory object", menuName = "Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string path;
    public Inventory Container;
    public CardDB database;
    //public int id;

    public void AddItem(Card _item, int _ammount)
    {
        for (int i = 0; i < Container.Cards.Length; i++)
        {


            if (Container.Cards[i].ID == _item.ID)
            {
                Container.Cards[i].addAmount(_ammount);
                return;
            }
        }
        EmptySlot(_item,_ammount);
        return;
        
        
        
        
    }

    public inventorySlots EmptySlot(Card _card, int _ammount)
    {
        for (int i = 0; i < Container.Cards.Length; i++)
        {
            if(Container.Cards[i].ID <= -1)
            {
                Container.Cards[i].UpdateSlot(_card.ID,_card,_ammount);
                return Container.Cards[i];
            }
        }
        return null;
    }

    public void move(inventorySlots origin,inventorySlots destination)
    {
        inventorySlots tmp = new inventorySlots(destination.ID,destination.item,destination.ammount);

        destination.UpdateSlot(origin.ID, origin.item, origin.ammount);

        origin.UpdateSlot(tmp.ID, tmp.item, tmp.ammount);

    }

    public void burn(Card _card)
    {
        for (int i = 0; i < Container.Cards.Length; i++)
        {
            if (Container.Cards[i].item == _card)
            {
                Container.Cards[i].UpdateSlot(-1, null, 0);
            }
        }
    }

    public void SaveData()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath,path),FileMode.Create,FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }


    public void LoadData()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, path), FileMode.Create, FileAccess.Write);
        Container = (Inventory)formatter.Deserialize(stream);
        stream.Close();

    }

   

}


[System.Serializable]
public class Inventory
{
    //ublic List<inventorySlots> Cards = new List<inventorySlots>();
    public inventorySlots[] Cards = new inventorySlots[40];
}
[System.Serializable]
public class inventorySlots
{
    public int ID = -1;
    public Card item;
    public int ammount;
    public inventorySlots(int _id,Card _item, int _ammount)
    {
        ID = _id;
        item = _item;
        ammount = _ammount;
    }
    public inventorySlots()
    {
        ID = -1;
        item = null;
        ammount = 0;
    }

    public void addAmount(int value)
    {
        ammount += value;
    }


    public void UpdateSlot(int _id,Card _card,int _ammount)
    {

    }
}