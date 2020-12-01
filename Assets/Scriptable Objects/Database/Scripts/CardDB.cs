using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card Database", menuName = "Inventory/Card Database")]
public class CardDB : ScriptableObject //ISerializationCallbackReceiver
{

    public List<Card> allCards = new List<Card>();

    public Dictionary<Card, int> GetId = new Dictionary<Card, int>();
    public Dictionary<int, Card> GetCard = new Dictionary<int, Card>();
}