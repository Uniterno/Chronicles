using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory sys/InventorySlots")]
public class NewBehaviourScript : ScriptableObject,ISerializationCallbackReceiver
{
    JsonData toload;
    public List<Slots> SlotList = new List<Slots>();
    public CardDB db;
    public string path;
    public void AddCard(Card _card, int _ammount)
    {
        for (int i =0; i <SlotList.Count; i++)
        {
            if (SlotList[i].card == _card)
            {
                SlotList[i].addAmm(_ammount);
                
                return;
            }
        }
        SlotList.Add(new Slots(db.GetId[_card],_card, _ammount));




    }

    public void saveJson()
    {
        string saveD = JsonUtility.ToJson(this,true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, path));
        bf.Serialize(file, saveD);
        file.Close();
    }
    public void loadJson()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath,path)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath,path),FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
        
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        for(int i = 0; i < SlotList.Count; i++)
        {
            SlotList[i].card = db.GetCard[SlotList[i].id];
        }
    }
}

[System.Serializable]
public class Slots
{
    public int id;
    public Card card;
    public int ammount;

    public Slots(int _id,Card _card,int _ammount)
    {
        id = _id;
        card = _card;
        ammount = _ammount;
    }

    public void addAmm(int value)
    {
        ammount += value;
    }
}
