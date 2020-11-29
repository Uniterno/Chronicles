using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InvObject inventory;

    public int x_space_between;
    public int columns;
    public int  y_space;

    Dictionary<Slots, Card> toDisplay = new Dictionary<Slots, Card>();

    private void Start()
    {
        Display();
    }


    public void Update()
    {
        //UpdateDisplay();
    }

    public void Display()
    {
        for (int i = 0; i < inventory.SlotList.Count; i++)
        {
            var obj = Instantiate(inventory.SlotList[i].card.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPos(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.SlotList[i].ammount.ToString();
        }
    }

    public Vector3 getPos(int i)
    {
        return new Vector3(x_space_between* (i % columns),(y_space*(i/columns)),0f);
    }
}
