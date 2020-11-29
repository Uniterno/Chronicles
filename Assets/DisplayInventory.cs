using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InvObject inventory;

    public int x_space_between;
    public int columns;
    public int y_space;
    public int x_start;
    public int y_start;

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
            var obj = Instantiate(inventory.SlotList[i].card.prefab, Vector2.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPos(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.SlotList[i].ammount.ToString();
            Debug.Log(i);
        }
    }

    public void UdpdateDisplay()
    {
        for(int i =0; i < inventory.SlotList.Count; i++)
        {
            if (toDisplay.ContainsKey(inventory.SlotList[i]))
            {
                //toDisplay[inventory.SlotList[i]].
                    //GetComponentInChildren<TextMeshProUGUI>().text = inventory.SlotList[i].ammount;
            }
        }
    }

    public Vector2 getPos(int i)
    {
        return new Vector2(x_start + x_space_between* (i % columns),y_start + (y_space*(i/columns)));
    }
}
