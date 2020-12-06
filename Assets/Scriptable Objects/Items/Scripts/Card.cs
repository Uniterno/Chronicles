using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Card", menuName = "Inventory/Card")]
public class Card : ScriptableObject
{
    public enum Rarity { Common, Uncommon, Rare, Epic, Legendary }
    public enum CardType { Monster, Spell }

    public Sprite toDisplay;
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
    
    public Card(Card _card)
    {
        ID = _card.ID;
        cardName = _card.cardName;
        cardType = _card.cardType;
        rarity = _card.rarity;
        manaCost = _card.manaCost;
        ATK = _card.ATK;
        DEF = _card.DEF;
        effectID = _card.effectID;
    }
  
}
/*
[System.Serializable]
public class  CardGetter
{
    public string Name;
    public int Id;
    public CardGetter(Card _card)
    {
        Name = _card.cardName;
        Id = _card.ID;
    }
}*/

