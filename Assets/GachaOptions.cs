using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GachaOptions : MonoBehaviour
{

    // Start is called before the first frame update
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Boton de abrir paquete
    public void OpenPackageButton()
    {
        List<int> Obtained = OpenPack();

        /* REMOVE - ONLY FOR DEBUGGING PURPOSES, REMOVE WHEN UPDATED */
        Debug.Log("You got: " + DatabaseHandler.GetById(Obtained[0]).cardName + " (" + DatabaseHandler.GetById(Obtained[0]).rarity + ")");
        Debug.Log("You got: " + DatabaseHandler.GetById(Obtained[1]).cardName + " (" + DatabaseHandler.GetById(Obtained[1]).rarity + ")");
        Debug.Log("You got: " + DatabaseHandler.GetById(Obtained[2]).cardName + " (" + DatabaseHandler.GetById(Obtained[2]).rarity + ")");
        /* REMOVE TAG END - REMOVE TAG END - REMOVE TAG END - REMOVE */

        /* TODO HERE:
           - Add cards to player's inventory
           - Show obtained cards on Scene
        */
    }

    public List<int> OpenPack()
    {
        uint pullAmount = 3;
        //int[] raritiesObtained = obtainRarities(pullAmount);
        List<int> cardsObtained = ObtainCards(ObtainRarities(pullAmount));
        return cardsObtained;
    }

    public List<int> ObtainRarities(uint pullAmount)
    {
        List<int> obtained = new List<int>((int) pullAmount);
        for (int i = 0; i < pullAmount; i++)
        {
            Card.Rarity rarity = GetRarity(Random.Range(1, 10001));

            if (i == pullAmount - 1 && rarity < Card.Rarity.Rare) // Rare or above guaranteed
            {
                rarity = Card.Rarity.Rare;
            }

            obtained.Add((int) rarity);
        }

        return obtained;
    }

    private Card.Rarity GetRarity(int rng)
    {
        if (rng <= 5500)
        {
            return Card.Rarity.Common; // 55%
        }
        if (rng <= 8000)
        {
            return Card.Rarity.Uncommon; // 25%
        }
        if (rng <= 9250)
        {
            return Card.Rarity.Rare; // 12.5%
        }
        if (rng <= 9875)
        {
            return Card.Rarity.Epic; // 6.25%
        }
        else
        {
            return Card.Rarity.Legendary; // 1.25%
        }
    }

    public List<int> ObtainCards(List<int> rarities)
    {

        List<int> c = new List<int>(); // Common
        List<int> u = new List<int>(); // Uncommon
        List<int> r = new List<int>(); // Rare
        List<int> e = new List<int>(); // Epic
        List<int> l = new List<int>(); // Legendary

        for (int i = 0; i < DatabaseHandler.GetCards().Count; i++)
        {
            switch (DatabaseHandler.GetCards()[i].rarity)
            {
                case Card.Rarity.Common:
                    c.Add(DatabaseHandler.GetCards()[i].ID);
                    break;
                case Card.Rarity.Uncommon:
                    u.Add(DatabaseHandler.GetCards()[i].ID);
                    break;
                case Card.Rarity.Rare:
                    r.Add(DatabaseHandler.GetCards()[i].ID);
                    break;
                case Card.Rarity.Epic:
                    e.Add(DatabaseHandler.GetCards()[i].ID);
                    break;
                case Card.Rarity.Legendary:
                    l.Add(DatabaseHandler.GetCards()[i].ID);
                    break;
                default:
                    break;
            }
        }
        for (int i = 0; i < rarities.Count; i++)
        {
            switch (rarities[i])
            {
                case (int) Card.Rarity.Common:
                    rarities[i] = c[Random.Range(0, c.Count)];
                    break;
                case (int) Card.Rarity.Uncommon:
                    rarities[i] = u[Random.Range(0, u.Count)];
                    break;
                case (int) Card.Rarity.Rare:
                    rarities[i] = r[Random.Range(0, r.Count)];
                    break;
                case (int) Card.Rarity.Epic:
                    rarities[i] = e[Random.Range(0, e.Count)];
                    break;
                case (int) Card.Rarity.Legendary:
                    rarities[i] = l[Random.Range(0, l.Count)];
                    break;
                default:
                    break;
            }
        }
        return rarities;
    }
}

