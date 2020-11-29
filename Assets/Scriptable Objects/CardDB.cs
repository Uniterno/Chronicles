using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="cards database",menuName ="Inventory sys/Card Database")]
public class CardDB : ScriptableObject, ISerializationCallbackReceiver
{
    public Card[] cards;
    public Dictionary<Card, int> GetId = new Dictionary<Card, int>();
    public Dictionary<int, Card> GetCard = new Dictionary<int, Card>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<Card, int>();
        GetCard = new Dictionary<int, Card>();
        for (int i =0;i<cards.Length;i++)
        {
            GetId.Add(cards[i], i);
            GetCard.Add(i, cards[i]);
        }

    }

    public void OnBeforeSerialize()
    {

    }

}
