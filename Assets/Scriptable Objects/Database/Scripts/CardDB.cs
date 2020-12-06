using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card Database", menuName = "Inventory/Card Database")]
public class CardDB : ScriptableObject,ISerializationCallbackReceiver
{

    public List<Card> allCards = new List<Card>();
    public Dictionary<int, Card> GetCard = new Dictionary<int, Card>();



    public void OnAfterDeserialize()
    {
        
        for (int i = 0; i < allCards.Count; i++)
        {
            allCards[i].ID = i;
            GetCard.Add(i, allCards[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetCard = new Dictionary<int, Card>();
    }
}