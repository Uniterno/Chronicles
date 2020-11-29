using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory sys/Inventory")]
public class NewBehaviourScript : ScriptableObject
{
    public List<Slots> SlotList = new List<Slots>();

    public void AddCard(Card _card, int _ammount)
    {
        bool exists = false;
        for (int i =0; i <SlotList.Count; i++)
        {
            if (SlotList[i].card == _card)
            {
                SlotList[i].addAmm(_ammount);
                exists = true;
                break;
            }
        }

        if (!exists)
        {
            SlotList.Add(new Slots(_card, _ammount));
        }
    }


    public void loadJson()
    {
        //JsonData toload = JsonMapper();
    }
}

[System.Serializable]
public class Slots
{
    public Card card;
    public int ammount;

    public Slots(Card _card,int _ammount)
    {
        card = _card;
        ammount = _ammount;
    }

    public void addAmm(int value)
    {
        ammount += value;
    }
}
