using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DatabaseHandler : MonoBehaviour
{
    public CardDB cards;
    private static DatabaseHandler activeInstance;

    public void Awake()
    {
        if (activeInstance == null)
        {
            activeInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public static Card GetById(int ID)
    {
        /*foreach (Card _card in activeInstance.cards.allCards)
        {
            if (_card.id == ID)
            {
                return _card;
            }
            

        }
        return null;*/

        return activeInstance.cards.allCards.FirstOrDefault(i => i.id == ID);

    }



    public static Card randomize()
    {
        return activeInstance.cards.allCards[Random.Range(0, activeInstance.cards.allCards.Count())];
    }

    public static List<Card> GetCards()
    {
        List<Card> _allCards = activeInstance.cards.allCards;
        return _allCards;
    }

}
