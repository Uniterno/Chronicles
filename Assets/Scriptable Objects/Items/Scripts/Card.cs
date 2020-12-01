using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Card", menuName = "Inventory/Card")]
public class Card : ScriptableObject
{
    public enum Rarity { Common, Uncommon, Rare, Epic, Legendary }
    public enum CardType { Monster, Spell }

    public GameObject prefab;
    public int ID;
    public string cardName;
    public CardType cardType;
    public Rarity rarity;
    public int manaCost;
    public int ATK;
    public int DEF;
    public int effectID;

    [TextArea(10, 15)]
    public string description;
}
