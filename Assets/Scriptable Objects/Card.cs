using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Card",menuName ="Assets/Scriptable Objects/Cards")]
public class Card : ScriptableObject
{

    public GameObject prefab;
    public int id;
    public string cardName;
    public int Mcost;
    public int atk;
    public int def;
    [TextArea(5,10)]
    public string cardText;
    public int effect;
    public Sprite art;
    public Card(int ID, string CardName,int MCost,int ATK,int DEF, string CardText,int Effect,Sprite Art)
    {
        this.id  = ID;
        this.cardName = CardName;
        this.Mcost = MCost;
        this.atk = ATK;
        this.def = DEF;
        this.cardText = CardText;
        this.effect = Effect;
        this.art = Art;
    }
}
